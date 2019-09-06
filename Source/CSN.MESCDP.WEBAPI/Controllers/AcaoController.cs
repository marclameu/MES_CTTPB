using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace CTTPB.MESCDP.Application.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Acao")]
    public class AcaoController : Controller
    {
        private IAcaoRepository _acaoRepository;
        public AcaoController(IAcaoRepository acaoRepository)
        {
            _acaoRepository = acaoRepository;
        }
        // GET: api/Acao
        [HttpGet]
        public IEnumerable<string> Get()
        {
            try
            {
                var acoes = _acaoRepository.GetAll();
                List<string> acoesList = new List<string>();
                acoes.ToList().ForEach(acao =>
                {
                    acoesList.Add(acao.NmAcao);
                });
                return acoesList;
            }
            catch (Exception ex)
            {
                return new string[] { "ERRO: " + ex.Message};
            }
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Acao/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Acao
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Acao/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
