using Api.Master.Core.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Rules.Interface;

namespace Api.Master.Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUser _process;
        public UserController(IUser process)
        {
            _process = process;
        }
        // GET: api/Home
        [HttpGet]
        public ActionResult Get()
        {
            var data = _process.Get();
            //return Ok(result);
            return new Success(new { data = data });
        }
    }
}
