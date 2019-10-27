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
            return GetIsloginState("Index");
        }
        public IActionResult Student()
        {
            return GetIsloginState("Student");
        }
        public IActionResult Teacher()
        {
            return GetIsloginState("Teacher");
        }
        public IActionResult Administrator()
        {
            return GetIsloginState("Administrator");
        }
        private IActionResult GetIsloginState(string sourceUrl)
        {
            try
            {
                if ((GetCookies("islogin") == null) || (GetCookies("islogin") != "true"))
                {
                    return Redirect("~/");
                }
                else
                {
                    JObject userinfo = (JObject)JsonConvert.DeserializeObject(GetCookies("User"));
                    string userrole = (string)userinfo.SelectToken("Role");
                    int role = int.Parse(userrole);
                    switch (role)
                    {
                        case 0:
                            if (sourceUrl != "Index")
                            {
                                return Redirect("~/Welcome/");
                            }break;
                        case 1:
                            if (sourceUrl != "Student")
                            {
                                return Redirect("~/Welcome/Student");
                            }
                            break;
                        case 2:
                            if (sourceUrl != "Teacher")
                            {
                                return Redirect("~/Welcome/Teacher");
                            }
                            break;
                        case 3:
                            if (sourceUrl != "Administrator")
                            {
                                return Redirect("~/Welcome/Administrator");
                            }
                            break;
                        default: break;
                    }
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