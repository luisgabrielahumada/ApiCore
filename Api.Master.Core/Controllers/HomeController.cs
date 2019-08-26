using Api.Master.Core.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Api.Master.Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        // GET: api/Home
        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            //return Ok(result);
            return new Failed(HttpStatusCode.BadRequest, new Exception("test"));
        }

        // GET: api/Home/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Home
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Home/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
