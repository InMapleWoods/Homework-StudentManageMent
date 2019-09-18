using Bll;
using Model;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        /// 验证码对象
        /// </summary>
        static public Captcha captcha = new Captcha();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>登录成功与否</returns>
        // POST: api/Login?account={account}
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
                return captcha.GetValidateNum();
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
        /// 获取验证码图片
        /// </summary>
        /// <param name="validate">验证码</param>
        /// <returns>验证码图片</returns>
        [HttpGet]
        public HttpResponseMessage ValidatePic(string validate)
        {
            try
            {
                captcha.GetValidate(4);
                Bitmap image = captcha.GetValidatePicture();
                MemoryStream mstream = new MemoryStream();
                image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //从图片中读取流
                byte[] arr = new byte[mstream.Length];
                mstream.Position = 0;
                mstream.Read(arr, 0, (int)mstream.Length);
                mstream.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(arr);  //data为二进制图片数据
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                return response;
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
        public string GetRegisterId()
        {
            try
            {
                return userBll.GetRegisterId().ToString().PadLeft(8,'0');
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
                return captcha.ChangeValidate();
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
