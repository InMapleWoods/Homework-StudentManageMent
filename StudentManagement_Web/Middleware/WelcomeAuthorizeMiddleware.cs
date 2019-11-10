using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StudentManagement_Web.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class WelcomeAuthorizeMiddleware
    {
        private readonly RequestDelegate _next;

        public WelcomeAuthorizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string sourceUrl = httpContext.Request.Path;
            string Pattern = "/Welcome/(.*)";
            Match resultGet = Regex.Match(sourceUrl, Pattern);
            if ((resultGet.Groups.Count >= 2)||(sourceUrl=="/Welcome"))
            {
                sourceUrl = resultGet.Groups[1].Value.ToString();
                string user = GetCookies("User", httpContext);
                user = user == string.Empty ? "" : user;
                if (user == "")
                {
                    DeleteCookies("islogin", httpContext);
                    httpContext.Response.Redirect("/");
                }
                JObject userinfo = (JObject)JsonConvert.DeserializeObject(user);
                string userrole = (string)userinfo.SelectToken("Role");
                int role = int.Parse(userrole);
                switch (role)
                {
                    case 0:
                        if (sourceUrl != "Index")
                        {
                            httpContext.Response.Redirect("/Welcome/");
                        }
                        break;
                    case 1:
                        if (sourceUrl != "Student")
                        {
                            httpContext.Response.Redirect("/Welcome/Student");
                        }
                        break;
                    case 2:
                        if (sourceUrl != "Teacher")
                        {
                            httpContext.Response.Redirect("/Welcome/Teacher");
                        }
                        break;
                    case 3:
                        if (sourceUrl != "Administrator")
                        {
                            httpContext.Response.Redirect("/Welcome/Administrator");
                        }
                        break;
                    default: break;
                }
            }
            return _next(httpContext);
        }
        #region Cookies操作
        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>返回对应的值</returns>
        public string GetCookies(string key, HttpContext httpContext)
        {
            StringValues values;
            httpContext.Request.Headers.TryGetValue("Cookie", out values);
            var cookies = values.ToString().Split(';').ToList();
            var result = cookies.Select(c => new { Key = c.Split('=')[0].Trim(), Value = c.Split('=')[1].Trim() }).ToList();
            if (result != null)
            {
                var value = result.Where(r => r.Key == key).FirstOrDefault();
                if (value != null)
                {
                    string valueresult = value.Value;
                    if (string.IsNullOrEmpty(valueresult))
                        valueresult = string.Empty;
                    return valueresult;
                }
            }
            return String.Empty;

        }
        /// <summary>
        /// 删除指定的cookie
        /// </summary>
        /// <param name="key">键</param>
        public void DeleteCookies(string key, HttpContext httpContext)
        {
            httpContext.Response.Cookies.Delete(key);
        }
        #endregion
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class WelcomeAuthorizeMiddlewareExtensions
    {
        public static IApplicationBuilder UseWelcomeAuthorizeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WelcomeAuthorizeMiddleware>();
        }
    }
}
