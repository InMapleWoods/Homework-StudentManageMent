using Bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Model;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace StudentManagement_Web.Controllers
{
    /// <summary>
    /// 登录API控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApiLoginController : ControllerBase
    {
        /// <summary>
        /// 用户操作对象
        /// </summary>
        private UserBll userBll = new UserBll();
        /// <summary>
        /// 验证码对象
        /// </summary>
        private Captcha captcha = new Captcha();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>登录成功与否</returns>
        // POST: api/ApiLogin/Login
        [HttpPost("Login")]
        public IActionResult Login([FromBody]dynamic accountPassword)
        {
            try
            {
                dynamic accountPasswordObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(accountPassword.ToString());
                string account = accountPasswordObject.account;
                string password = accountPasswordObject.password;
                bool result = userBll.Login(account, password);
                User user = userBll.GetUserLogin(account);
                if (user != null)
                    user.PassWord = "******";
                if (result == true)
                {
                    SetCookies("User", JsonConvert.SerializeObject(new string[] { user.UserID.ToString(),user.UserName,user.Role.ToString(),user.Number }), 4320);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 获取登录用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns>登录用户</returns>
        // GET: api/ApiLogin?account={account}
        [HttpGet]
        public IActionResult GetLoginUser(string account)
        {
            try
            {
                User user = userBll.GetUserLogin(account);
                if (user != null)
                    user.PassWord = "******";
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns>验证码</returns>
        //GET: api/ApiLogin/validate
        [HttpGet("validate")]
        public IActionResult Validate()
        {
            try
            {
                captcha.GetValidate(4);
                Bitmap image = captcha.GetValidatePicture();
                string validatestring = captcha.GetValidateNum();
                MemoryStream mstream = new MemoryStream();
                image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //从图片中读取流
                byte[] arr = new byte[mstream.Length];
                mstream.Position = 0;
                mstream.Read(arr, 0, (int)mstream.Length);
                mstream.Close();
                return Ok(new object[] { validatestring, arr });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
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
        // POST: api/ApiLogin/Register?name={name}&password={password}&repeat={repeat}&role={role}
        [HttpPost("Register")]
        public IActionResult Register(string name, string password, string repeat, int role)
        {
            try
            {
                string account;
                bool result = userBll.Register(name, password, repeat, out account, role);
                if (result == true)
                {
                    SetCookies("User", JsonConvert.SerializeObject(new string[] {userBll.t.UserID.ToString(),name,role.ToString(), userBll.t.Number}), 4320);
                }
                return Ok(new object[] { result, account});
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
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
            var result = cookies.Select(c => new { Key = c.Split('=')[0].Trim(), Value = c.Split('=')[1].Trim() }).ToList();
            var value = result.Where(r => r.Key == key).FirstOrDefault();
            string valueresult = value.Value;
            if (string.IsNullOrEmpty(valueresult))
                valueresult = string.Empty;
            return valueresult;
        }
        #endregion
    }

    /// <summary>
    /// 登录控制器
    /// </summary>
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}