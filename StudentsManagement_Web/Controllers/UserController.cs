using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsManagement_Web.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// 用户操作对象
        /// </summary>
        UserBll userBll = new UserBll();
        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns>用户数组</returns>
        // GET: api/User/GetAllUserArray
        [HttpGet]
        public IEnumerable<User> GetAllUserArray()
        {
            try
            {
                return userBll.GetAllUserArray();
            }
            catch (Exception ex)
            {
                //在webapi中抛出异常
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "error"
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns>当前用户</returns>
        // GET: api/User/GetCurrentUser
        [HttpGet]
        public User GetCurrentUser()
        {
            try
            {
                return userBll.t;
            }
            catch (Exception ex)
            {
                //在webapi中抛出异常
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "error"
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// 修改昵称
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="changedName">要修改的昵称</param>
        /// <returns>成功与否</returns>
        //PUT: api/User/{id}?changedName={changedName}
        //PUT: api/User/ChangedName/{id}?changedName={changedName}
        [HttpPut]
        public bool ChangedName(string id, string changedName)
        {
            try
            {
                return userBll.ChangedName(id, changedName);
            }
            catch (Exception ex)
            {
                //在webapi中抛出异常
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "error"
                };
                throw new HttpResponseException(response);
            }
        }
        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>是否存在</returns>
        //Get: api/User/UserNameCheck?userName={userName}
        //Get: api/User?userName={userName}
        [HttpGet]
        public bool UserNameCheck(string userName)
        {
            try
            {
                return userBll.UserNameCheck(userName);
            }
            catch (Exception ex)
            {
                //在webapi中抛出异常
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "error"
                };
                throw new HttpResponseException(response);
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="opwd">旧密码</param>
        /// <param name="npwd">新密码</param>
        /// <returns>成功与否</returns>
        //PUT: api/User?opwd={opwd}&npwd={npwd}
        //PUT: api/User/ChangePassword?opwd={opwd}&npwd={npwd}
        [HttpPut]
        public bool ChangePassword(string opwd, string npwd)
        {
            try
            {
                return userBll.ChangePassword(opwd, npwd);
            }
            catch (Exception ex)
            {
                //在webapi中抛出异常
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "error"
                };
                throw new HttpResponseException(response);
            }
        }

    }
}
