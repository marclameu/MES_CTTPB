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
    [Route("api/ComposicaoTrem")]
    public class ComposicaoTremController : BaseController
    {
        private IComposicaoTremRepository _composicaoTremRepository;
        public ComposicaoTremController(IComposicaoTremRepository composicaoTremRepository)
        {
            _composicaoTremRepository = composicaoTremRepository;
        }
        // GET: api/GetComposicoesComPesos/5
        [HttpGet("{idTrem}", Name = "GetComposicoesComPesos")]
        public IActionResult GetComposicoesComPesos(int idTrem)
        {
            try
            {
                var composicaoTremLista = _composicaoTremRepository.GetComposicaoTremListaPorID(idTrem);
                return Ok(composicaoTremLista);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(new {Message = e.Message});
            }
        }
        
    }
}
