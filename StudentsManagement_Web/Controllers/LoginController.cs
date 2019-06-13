﻿using Bll;
using Model;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsManagement_Web.Controllers
{
    /// <summary>
    /// 登录控制器
    /// </summary>
    public class LoginController : ApiController
    {
        /// <summary>
        /// 用户操作对象
        /// </summary>
        static UserBll userBll = new UserBll();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <param name="validate">验证码</param>
        /// <returns>登录成功与否</returns>
        // POST: api/Login?account={account}&validate={validate}
        public bool Login(string account, [FromBody]string password)
        {
            try
            {
                return userBll.Login(account, password);
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
        /// 获取登录用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns>登录用户</returns>
        // GET: api/Login?account={account}
        public User GetLoginUser(string account)
        {
            try
            {
                return userBll.GetUserLogin(account);
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
        /// 获取验证码
        /// </summary>
        /// <returns>验证码</returns>
        //GET: api/Login/Validate
        [HttpGet]
        public string Validate(bool t)
        {
            try
            {
                return userBll.GetValidateNum();
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
        [HttpGet]
        public IHttpActionResult ValidatePic(string validate)
        {
            try
            {
                userBll.GetValidate(4);
                Bitmap image = userBll.GetValidatePicture();
                MemoryStream mstream = new MemoryStream();
                image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //从图片中读取流
                byte[] arr = new byte[mstream.Length];
                mstream.Position = 0;
                mstream.Read(arr, 0, (int)mstream.Length);
                mstream.Close();
                return Json(Convert.ToBase64String(arr));
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
        /// 注册
        /// </summary>
        /// <param name="name">名字</param>
        /// <param name="password">密码</param>
        /// <param name="repeat">重复密码</param>
        /// <param name="role">角色</param>
        /// <returns>登录成功与否</returns>
        // POST: api/Login?name={name}&password={password}&repeat={repeat}&role={role}
        [HttpPost]
        public bool Register(string name, string password, string repeat, int role)
        {
            try
            {
                return userBll.Register(name, password, repeat, role);
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
        /// 获取注册者Id
        /// </summary>
        /// <returns>注册者ID</returns>
        //GET: api/Login/GetRegisterId
        public int GetRegisterId()
        {
            try
            {
                return userBll.GetRegisterId();
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
        /// 改变验证码
        /// </summary>
        /// <returns>成功与否</returns>
        //POST: api/Login/ChangeValidate
        [HttpPost]
        public bool ChangeValidate()
        {
            try
            {
                return userBll.ChangeValidate();
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
