using Bll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StudentManagement_Web.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApiUserController : ControllerBase
    {
        /// <summary>
        /// 用户操作对象
        /// </summary>
        readonly UserBll userBll = new UserBll();
        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
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

    /// <summary>
    /// 用户页面
    /// </summary>
    public class UserController : Controller
    {
        public IActionResult NameChange()
        {
            return View();
        }
        public IActionResult PasswordChange()
        {
            return View();
        }
    }

}
