using Bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Model;
using System;
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
        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns>用户数组</returns>
        // GET: api/ApiUser
        [HttpGet(Name = "GetAllUserArray")]
        public IActionResult GetAllUserArray()
        {
            try
            {
                var users = userBll.GetAllUserArray().ToList();
                var usersresult = from user in users
                                  select new User(user.UserID, user.UserName, "******", user.Role, user.Number);
                return Ok(usersresult);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns>当前用户</returns>
        // GET: api/ApiUser/GetCurrentUser?number={number}
        [HttpGet("GetCurrentUser")]
        public IActionResult GetCurrentUser(string number)
        {
            try
            {
                return Ok(userBll.GetUserLogin(number));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 修改昵称
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="changedName">要修改的昵称</param>
        /// <returns>成功与否</returns>
        //PUT: api/ApiUser/ChangedName?id={id}&&changedName={changedName}
        [HttpPut("ChangedName")]
        public IActionResult ChangedName(string id, string changedName)
        {
            try
            {
                return Ok(userBll.ChangedName(id, changedName));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>是否存在</returns>
        //Get: api/ApiUser/UserNameCheck?userName={userName}
        [HttpGet("UserNameCheck")]
        public IActionResult UserNameCheck(string userName)
        {
            try
            {
                return Ok(userBll.UserNameCheck(userName));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="opwd">旧密码</param>
        /// <param name="npwd">新密码</param>
        /// <param name="userid">用户Id</param>
        /// <returns>成功与否</returns>
        //PUT: api/ApiUser/ChangePassword?opwd={opwd}&npwd={npwd}&userid={userid}
        [HttpPut("ChangePassword")]
        public IActionResult ChangePassword(string opwd, string npwd,string userid)
        {
            try
            {
                return Ok(userBll.ChangePassword(opwd, npwd, userid));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
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
                if ((GetCookies("islogin") == null) || (GetCookies("islogin") != "true"))
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