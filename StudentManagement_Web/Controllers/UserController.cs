using Bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return GetIsloginState();
        }
        public IActionResult PasswordChange()
        {
            return GetIsloginState();
        }
        public IActionResult UserInfomation()
        {
            return GetIsloginState();
        }

        private IActionResult GetIsloginState()
        {
            try
            {
                if ((GetCookies("islogin")==null)||(GetCookies("islogin") != "true"))
                {
                    return Redirect("~/");
                }
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return View();
        }
        #region Cookies操作
        /// <summary>
        /// 设置本地cookie
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>  
        /// <param name="minutes">过期时长，单位：分钟</param>   
        public void SetCookies(string key, string value, int minutes = 30)
        {
            HttpContext.Response.Cookies.Append(key, value, new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(minutes)
            });
        }
        /// <summary>
        /// 删除指定的cookie
        /// </summary>
        /// <param name="key">键</param>
        public void DeleteCookies(string key)
        {
            HttpContext.Response.Cookies.Delete(key);
        }

        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>返回对应的值</returns>
        public string GetCookies(string key)
        {
            StringValues values;
            HttpContext.Request.Headers.TryGetValue("Cookie", out values);
            var cookies = values.ToString().Split(';').ToList();
            if (cookies == null)
                return null;
            var result = cookies.Select(c => new { Key = c.Split('=')[0].Trim(), Value = c.Split('=')[1].Trim() }).ToList();
            if (result == null)
                return null;
            var value = result.Where(r => r.Key == key).FirstOrDefault();
            if (value == null)
                return null;
            string valueresult = value.Value;
            if (string.IsNullOrEmpty(valueresult))
                valueresult = string.Empty;
            return valueresult;
        }
        #endregion

    }

}
