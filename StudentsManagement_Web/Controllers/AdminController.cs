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
    public class AdminController : ApiController
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
        /// 管理员操作对象
        /// </summary>
        AdminBll adminBll = new AdminBll();

        /// <summary>
        /// 接收申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        /// <param name="tobe">申请角色</param>
        /// <returns>成功与否</returns>
        //PUT: api/Admin/{id}?tobe={tobe}
        //PUT: api/Admin/AcceptLog/{id}?tobe={tobe}
        [HttpPut]
        public bool AcceptLog(string id, string tobe)
        {
            try
            {
                return adminBll.AcceptLog(id, tobe);
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
        //PUT: api/Admin/{id}
        //PUT: api/Admin/RejectionLog/{id}
        [HttpPut]
        public bool RejectionLog(string id)
        {
            try
            {
                return adminBll.RejectionLog(id);
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
        //DELETE: api/Admin/{id}
        //DELETE: api/Admin/DeleteUser/{id}
        [HttpDelete]
        public bool DeleteUser(string id)
        {
            try
            {
                return adminBll.DeleteUser(id);
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
        //GET: api/Admin?index={index}&size={size}&choose={choose}
        //GET: api/Admin/GetPaperUsersArray?index={index}&size={size}&choose={choose}
        [HttpGet]
        public IEnumerable<User> GetPaperUsersArray(int index, int size, int choose)
        {
            try
            {
                return adminBll.GetPaperUsersArray(index, size, choose);
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
        //GET: api/Admin?size={size}&choose={choose}
        //GET: api/Admin/GetAllPageNum?size={size}&choose={choose}
        [HttpGet]
        public int GetAllPageNum(int size, int choose)
        {
            try
            {
                return adminBll.GetAllPageNum(size, choose);
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
