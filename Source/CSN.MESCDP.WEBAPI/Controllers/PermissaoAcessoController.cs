using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTTPB.MESCDP.Application.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/PermissaoAcesso")]
    public class PermissaoAcessoController : BaseController
    {
        private IPermissaoAcessoRepository _permissaoAcessoRepository;

        public PermissaoAcessoController(IPermissaoAcessoRepository permissaoAcessoRepository)
        {
            _permissaoAcessoRepository = permissaoAcessoRepository;
        }

        [HttpGet]
        public IActionResult GetTodosGruposADMesMina()
        {
            try
            {
                var gruposAdMES = _permissaoAcessoRepository.ObtemTodosGruposMes();

                return Ok(gruposAdMES);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(new {Message = "Erro ao obter grupos do MES no Banco - " + e.Message});
            }
        }
    }
}