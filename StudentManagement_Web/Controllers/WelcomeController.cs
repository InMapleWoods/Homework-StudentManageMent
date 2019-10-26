using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace StudentManagement_Web.Controllers
{
    /// <summary>
    /// 主页面
    /// </summary>
    public class WelcomeController : Controller
    {
        /// <summary>
        /// Index页面
        /// </summary>
        /// <returns>返回视图</returns>
        public IActionResult Index()
        {
            try
            {
                if (GetCookies("islogin") == "true")
                {
                    JObject userinfo = (JObject)JsonConvert.DeserializeObject(GetCookies("User"));
                    string userrole = (string)userinfo.SelectToken("Role");
                    int role = int.Parse(userrole);
                    switch (role)
                    {
                        case 0:
                            return Redirect("~/Welcome/");
                        case 1:
                            return Redirect("~/Welcome/Student");
                        case 2:
                            return Redirect("~/Welcome/Teacher");
                        case 3:
                            return Redirect("~/Welcome/Administrator");
                        default: break;
                    }
                }
                else
                {
                    return Redirect("~/Welcome/");
                }
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return View();
        }

        public IActionResult Student()
        {
            return View();
        }
        public IActionResult Teacher()
        {
            return View();
        }
        public IActionResult Administrator()
        {
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
            var result = cookies.Select(c => new { Key = c.Split('=')[0].Trim(), Value = c.Split('=')[1].Trim() }).ToList();
            var value = result.Where(r => r.Key == key).FirstOrDefault();
            string valueresult = value.Value;
            if (string.IsNullOrEmpty(valueresult))
                valueresult = string.Empty;
            return valueresult;
        }
        #endregion

    }
}