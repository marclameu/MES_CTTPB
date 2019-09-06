using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTTPB.MESCDP.Application.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CTTPB.MESCDP.WEBAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string GetTremPorId(int id)
        {
            return "value";
        }

    }
}
