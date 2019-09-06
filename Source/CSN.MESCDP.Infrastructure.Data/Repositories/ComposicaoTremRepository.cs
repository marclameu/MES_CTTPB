using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using CTTPB.MESCDP.Domain.Config;
using CTTPB.MESCDP.Domain.DTO;
using CTTPB.MESCDP.Domain.Entities;
using CTTPB.MESCDP.Domain.Enums;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using RestSharp;

namespace CTTPB.MESCDP.Infrastructure.Data.Repositories
{
    public class ComposicaoTremRepository : GenericRepository<ComposicaoTrem>, IComposicaoTremRepository
    {
        private IntegracaoMassaConfig _integracaoMassaConfig;
        private IntegracaoToledoConfig _integracaoToledoConfig;
        private BalancaFerroviariaGenericConfig _balancaFerroviariaGenericConfig;
        public ComposicaoTremRepository(IOptions<IntegracaoMassaConfig> integracaoMassaConfig,
                                        IOptions<IntegracaoToledoConfig> integracaoToledoConfig,
                                        IOptions<BalancaFerroviariaGenericConfig> balancaFerroviariaGenericConfig)
        {
            _integracaoMassaConfig = integracaoMassaConfig.Value;
            _integracaoToledoConfig = integracaoToledoConfig.Value;
            _balancaFerroviariaGenericConfig = balancaFerroviariaGenericConfig.Value;
        }
        public IList<ComposicaoTrem> GetComposicaoTremListaPorID(int idTrem)
        {
            var criteria = Session.CreateCriteria<ComposicaoTrem>();
            criteria.CreateAlias(ComposicaoTrem.Atributos.PesagemVagaoLista, "pesagemVagao", JoinType.LeftOuterJoin);
            criteria.Add(Restrictions.Eq(ComposicaoTrem.Atributos.IdTrem, idTrem));

            return criteria.List<ComposicaoTrem>();
        }

        public IList<ComposicaoTrem> GetComposicaoComPesos(string cdPfxoTremCrga, int IdTrem, DateTime dataInicio, DateTime dataTermino, string flTernCtrlSist)
        {
            IList<ComposicaoTrem> composicaoTremLista = null;
            var client = new RestClient(_balancaFerroviariaGenericConfig.EnderecoAPI);
            string errorMessage = "";
            try
            {
                composicaoTremLista = GetComposicaoTremListaPorID(IdTrem);
                composicaoTremLista = composicaoTremLista.OrderBy(ct => ct.NuPoscVagao).ToList();

                if (flTernCtrlSist.ToUpper().Equals(SimNaoEnum.Sim.ToString()))
                {
                    var toledoRequest = new RestRequest(_integracaoToledoConfig.ObterComposicoesToledoController + "/" +
                                                        cdPfxoTremCrga + "/" +
                                                        dataInicio.ToString("yyyy-MM-ddThh:mm:ss") + "/" +
                                                        dataTermino.ToString("yyyy-MM-ddThh:mm:ss"), Method.GET);
                    try
                    {
                        var toledoResponse = client.Execute<dynamic>(toledoRequest);
                        var pesosLista = SimpleJson.DeserializeObject<List<VagoesDTO>>(toledoResponse.Content);
                        composicaoTremLista.ToList()
                            .Where(ct => ct.FlTipoVclo.Equals(TipoVeiculoTremEnum.Vagao.ToString()))
                            .ToList().ForEach(
                                ct =>
                                        {
                                            var pl = (from p in pesosLista
                                                      where Convert.ToInt16(p.ord) == ct.NuPoscVagao
                                                      select p).FirstOrDefault();
                                            if (pl != null)
                                            {
                                                ct.PesagemVagaoLista = new List<PesagemVagao>
                                                {
                                                    new PesagemVagao()
                                                    {
                                                        IdTrem = ct.IdTrem,
                                                        CdVclo = ct.CdVclo,
                                                        PsVagaoBruto = (double) pl.bruto,
                                                        PsTaraVagao = (double) pl.tara,
                                                    }
                                                };
                                            }
                                });

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao tentar obter pesos, api TOLEDO não respondeu. " + ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        var massaRequest = new RestRequest(_integracaoMassaConfig.ObterComposicoesMassaController + "/"
                                                                                                                  + dataInicio
                                                                                                                      .ToString(
                                                                                                                          "yyyy-MM-ddThh:mm:ss") +
                                                                                                                  "/"
                                                                                                                  + dataTermino
                                                                                                                      .ToString(
                                                                                                                          "yyyy-MM-ddThh:mm:ss") +
                                                                                                                  "/"
                                                                                                                  + cdPfxoTremCrga,
                            Method.GET);
                        var massaResponse = client.Execute<dynamic>(massaRequest);
                        if (massaResponse.StatusCode.Equals(HttpStatusCode.BadRequest))
                        {
                            throw new Exception(massaResponse.Content);
                        }
                        var pesosLista = SimpleJson.DeserializeObject<List<VagoesDTO>>(massaResponse.Content);
                        pesosLista = pesosLista.OrderBy(p => p.ord).ToList();
                        int nuPosicaoVagaoMassa = 1;
                        composicaoTremLista.ToList().ForEach(ct =>
                        {
                            if (ct.FlTipoVclo.Equals(TipoVeiculoTremEnum.Vagao.ToString()))
                            {
                                var pl = (from p in pesosLista
                                          where Convert.ToInt16(p.ord) == nuPosicaoVagaoMassa
                                          select p).FirstOrDefault();
                                ct.PesagemVagaoLista = new List<PesagemVagao>
                                {
                                    new PesagemVagao()
                                    {
                                        IdTrem = ct.IdTrem,
                                        CdVclo = ct.CdVclo,
                                        PsVagaoBruto = (pl != null && String.IsNullOrEmpty(pl.bruto.ToString()))
                                            ? 0
                                            : double.Parse(pl.bruto.ToString()),
                                        PsTaraVagao = (pl != null && String.IsNullOrEmpty(pl.tara.ToString()))
                                            ? 0
                                            : double.Parse(pl.tara.ToString())
                                    }
                                };
                                nuPosicaoVagaoMassa++;
                            }
                            else
                            {
                                ct.PesagemVagaoLista = new List<PesagemVagao>();
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    //composicaoTremLista.ToList().ForEach(ct =>
                    //{
                    //    var pl = (from p in pesosLista
                    //        where Convert.ToInt16(p.ord) == ct.NuPoscVagao
                    //        select p).FirstOrDefault();
                    //    ct.PesagemVagaoLista = new List<PesagemVagao>
                    //    {
                    //        new PesagemVagao()
                    //        {
                    //            IdTrem = ct.IdTrem,
                    //            CdVclo = ct.CdVclo,
                    //            PsVagaoBruto = (pl != null && String.IsNullOrEmpty(pl.bruto.ToString()))? 0 : double.Parse(pl.bruto.ToString()),
                    //            PsTaraVagao = (pl != null && String.IsNullOrEmpty(pl.tara.ToString()))? 0 : double.Parse(pl.tara.ToString())
                    //        }
                    //    };


                    //});

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return composicaoTremLista;

            //IRestResponse toledoResponse = client.Execute(toledoRequest);
            //dynamic pesos = toledoResponse.Data.VWtabcadcompCTTPB;

            //IRestResponse<ViewToledo> response1 = client.Execute<ViewToledo>(request);
            //var pesos = SimpleJson.DeserializeObject(toledoResponse.Content, );


            //IList<PesagemVagao> pesoLista = 
        }


    }

}
