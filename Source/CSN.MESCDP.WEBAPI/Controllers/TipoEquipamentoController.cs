using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTTPB.MESCDP.Application.WebApi.Filters;
using CTTPB.MESCDP.Domain.Entities;
using CTTPB.MESCDP.Domain.Interfaces;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using CTTPB.MESCDP.DOMAIN;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CTTPB.MESCDP.Application.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/TipoEquipamento")]
    public class TipoEquipamentoController : BaseController
    {
        private ITipoEquipamentoRepository _tipoEquipamentoRepository;
        private ITipoEquipamentoServices _tipoEquipamentoServices;

        public TipoEquipamentoController(ITipoEquipamentoRepository tipoEquipamentoRepository,
                                         ITipoEquipamentoServices tipoEquipamentoServices)
        {
            _tipoEquipamentoRepository = tipoEquipamentoRepository;
            _tipoEquipamentoServices = tipoEquipamentoServices;
        }

        // GET: api/TipoEquipamento
        [HttpGet]
        [AuthorizeAD("PESQUISAR", "ADMIN_MENSAGENS_WEBSERVICES_PESQUISAR")]
        //[AuthorizeAD("PERMISSAO", "RELATORIO_PARADAS_PESQUISAR")]
        public IActionResult Get()
        {
            // try
            //{
            var tiposEquipamentos = _tipoEquipamentoRepository.GetAll();
            return Ok(tiposEquipamentos);
            //}
            //catch (Exception ex)
            //{
            //return BadRequest(new { Message = "Erro ao obter Tipos de equipamentos - " + ex.Message });
            //}
        }

        [HttpGet("porPagina")]
        //[AuthorizeAD("PERMISSAO", "CADASTRO_AREA_PESQUISAR")]
        [AuthorizeAD("PERMISSAO", "RELATORIO_PARADAS_PESQUISAR")]
        public IActionResult PorPagina(int page, int pageSize, string cdTipoEqpm, string txDscrTipoEqpm, string flEqpmModel)
        {
            try
            {
                //var tiposEquipamentos = _tipoEquipamentoRepository.GetAll();
                var result = _tipoEquipamentoRepository.FindTipoEquipamentos(cdTipoEqpm, txDscrTipoEqpm, flEqpmModel,
                    new PaginationInfo<TipoEquipamento>(page, pageSize, null, null));
                return Json(
                    new
                    {
                        numPages = result.NumPages.ToString(),
                        page = result.Page.ToString(),
                        records = result.Total.ToString(),
                        rows = result.List.Count,
                        TipoEquipamentos = ToList(result.List)
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Erro ao obter Tipos de equipamentos - " + ex.Message });
            }
        }

        [HttpPost]
        //[AuthorizeAD("PERMISSAO", "MANUTENCAO_TAG_PESQUISAR")]
        [AuthorizeAD("PERMISSAO", "RELATORIO_PARADAS_PESQUISAR")]
        public IActionResult Post([FromBody] TipoEquipamento tipoEquipamento)
        {
            try
            {
                _tipoEquipamentoRepository.Create(tipoEquipamento);
                return Ok("Registro cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Salvar tipo de equipametno - " + ex.Message });

            }
        }


        private IList<TipoEquipamento> ToList(IEnumerable<TipoEquipamento> tipoEquipamentoEnumerable)
        {
            return (tipoEquipamentoEnumerable.Select(te =>
            {
                TipoEquipamento t = new TipoEquipamento();
                t.CdTipoEqpm = te.CdTipoEqpm;
                t.FlEqpmMovel = te.FlEqpmMovel;
                t.TxDscrTipoEqpm = te.TxDscrTipoEqpm;
                t.DtUltAtual = te.DtUltAtual;
                t.IdMtricUsuaUltAtual = te.IdMtricUsuaUltAtual;
                t.NuVers = te.NuVers;
                return t;
            }).ToList());
        }


        //// GET: api/TipoEquipamento/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/TipoEquipamento
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/TipoEquipamento/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
