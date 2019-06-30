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
        /// 表单选择教师
        /// </summary>
        static public int choose_Teacher = 0x001;
        /// <summary>
        /// 表单选择学生
        /// </summary>
        static public int choose_Student = 0x002;
        /// <summary>
        /// 表单选择未审核
        /// </summary>
        static public int choose_Unchecked = 0x003;
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
                return userBll.GetUser();
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

        /// <summary>
        /// 接收申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        /// <param name="tobe">申请角色</param>
        /// <returns>成功与否</returns>
        //PUT: api/User/{id}?tobe={tobe}
        //PUT: api/User/AcceptLog/{id}?tobe={tobe}
        [HttpPut]
        public bool AcceptLog(string id, string tobe)
        {
            try
            {
                return userBll.AcceptLog(id, tobe);
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
        /// 拒绝申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        /// <returns>成功与否</returns>
        //PUT: api/User/{id}
        //PUT: api/User/RejectionLog/{id}
        [HttpPut]
        public bool RejectionLog(string id)
        {
            try
            {
                return userBll.RejectionLog(id);
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
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>成功与否</returns>       
        //DELETE: api/User/{id}
        //DELETE: api/User/DeleteUser/{id}
        [HttpDelete]
        public bool DeleteUser(string id)
        {
            try
            {
                return userBll.DeleteUser(id);
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
        /// 获取分页后的用户名单
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <param name="choose">分页选项</param>
        /// <returns>分页后名单</returns>
        //GET: api/User?index={index}&size={size}&choose={choose}
        //GET: api/User/GetPaperUsersArray?index={index}&size={size}&choose={choose}
        [HttpGet]
        public IEnumerable<User> GetPaperUsersArray(int index, int size, int choose)
        {
            try
            {
                return userBll.GetPaperUsersArray(index, size, choose);
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
        /// 获取未审核用户分页总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <param name="choose">分页选项</param>
        /// <returns>分页数</returns>
        //GET: api/User?size={size}&choose={choose}
        //GET: api/User/GetAllPageNum?size={size}&choose={choose}
        [HttpGet]
        public int GetAllPageNum(int size, int choose)
        {
            try
            {
                return userBll.GetAllPageNum(size, choose);
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
