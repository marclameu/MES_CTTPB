using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTTPB.MESCDP.Domain.Entities;
using CTTPB.MESCDP.Domain.Interfaces;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using log4net.Util.TypeConverters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTTPB.MESCDP.Application.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/TremCarregamento")]
    public class TremCarregamentoController : Controller
    {
        private ITremCarregamentoRepository _tremCarregamentoRepository;
        private IComposicaoTremRepository _composicaoTremRepository;
        private ITremCarregamentoServices _tremCarregamentoServices;
        public TremCarregamentoController(ITremCarregamentoRepository tremCarregamentoRepository,
                                          IComposicaoTremRepository composicaoTremRepository,
                                          ITremCarregamentoServices tremCarregamentoServices)
        {
            _tremCarregamentoRepository = tremCarregamentoRepository;
            _composicaoTremRepository = composicaoTremRepository;
            _tremCarregamentoServices = tremCarregamentoServices;
        }

        [HttpGet("{idTrem}/{inicioCarregamento}/{terminoCarregamento}/{flTernCtrlSist?}")]
        public IActionResult GetTremPorId(int idTrem, string inicioCarregamento, string terminoCarregamento, string flTernCtrlSist="S")
        {
            try
            {
                var tremCarregamento = _tremCarregamentoRepository.GetById(idTrem);

                if(tremCarregamento == null)
                    return BadRequest(new { message = "Trem não encontrado. "});

                var dataInicio = Convert.ToDateTime(inicioCarregamento);
                var dataTermino = Convert.ToDateTime(terminoCarregamento);
                
                //Aumenta o range para buscar trens com um período maior
                dataInicio = dataInicio.AddDays(-1);
                dataTermino = dataTermino.AddDays(1);

                tremCarregamento.ComposicaoTremLista =
                    tremCarregamento.ComposicaoTremLista.OrderBy(ct => ct.NuPoscVagao).ToList();
                
                tremCarregamento.ComposicaoTremLista = _composicaoTremRepository.GetComposicaoComPesos(tremCarregamento.CdPfxoTremCrga, tremCarregamento.IdTrem, dataInicio, dataTermino, flTernCtrlSist);

                

                _tremCarregamentoServices.SalvarTremCarregamento(tremCarregamento);


                return Serialize(tremCarregamento);
                
            }
            catch (ConversionNotSupportedException ex)
            {
                Console.WriteLine(ex);
                return BadRequest(new { message = "Erro ao converter datas - " + ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(new { message = ex.Message });
            }
        }

        public JsonResult Serialize(TremCarregamento tremCarregamento)
        {
            return Json(
                new
                {
                    tremCarregamento.IdTrem,
                    tremCarregamento.CdPfxoTremCrga,
                    tremCarregamento.CdPfxoTremVazia,
                    tremCarregamento.DtRefrPrgmCrga,
                    tremCarregamento.CdTabl,
                    ComposicaoTremLista = tremCarregamento?.ComposicaoTremLista?.Select(ct => new
                    {
                        ct.IdTrem,
                        ct.NuPoscVagao,
                        ct.CdVclo,
                        ct.PsAprvVagaoAtrs,
                        ct.PsBrutoVagaoCrgaDscg,
                        ct.PsTaraVagaoCrgaDscg,
                        ct.FlTipoVclo,
                        PesagemVagaoLista = new
                        {
                            CdVclo = (ct.PesagemVagaoLista != null && ct.PesagemVagaoLista.Count > 0)? ct.PesagemVagaoLista?.First().CdVclo : "",
                            IdTrem = (ct.PesagemVagaoLista != null && ct.PesagemVagaoLista?.Count > 0) ? ct.PesagemVagaoLista?.First().IdTrem : null,
                            PsTaraVagao = (ct.PesagemVagaoLista != null && ct.PesagemVagaoLista?.Count > 0) ? ct.PesagemVagaoLista?.First().PsTaraVagao: null,
                            PsVagaoBruto = (ct.PesagemVagaoLista != null && ct.PesagemVagaoLista?.Count > 0) ? ct.PesagemVagaoLista?.First().PsVagaoBruto: null
                        }
                    })
                }
                );
        }
    }
}