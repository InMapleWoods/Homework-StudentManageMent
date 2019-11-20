using Bll;
using Microsoft.AspNetCore.Mvc;
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
        private readonly UserBll userBll = new UserBll();
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
        public IActionResult ChangePassword(string opwd, string npwd, string userid)
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
            return View();
        }
        public IActionResult PasswordChange()
        {
            return View();
        }
        public IActionResult UserInfomation()
        {
            return View();
        }


    }
}