using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace StudentManagement_Web.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class IsLoginMiddleware
    {
        private readonly RequestDelegate _next;

        public IsLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() != "/")
            {
                if ((GetCookies("islogin", httpContext) == null) || (GetCookies("islogin", httpContext) != "true"))
                {
                    httpContext.Response.Redirect("/");
                }
            }
            return _next.Invoke(httpContext);
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
            if(cookies[0]=="")
                return String.Empty;
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
        #endregion
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class IsLoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseIsLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IsLoginMiddleware>();
        }
    }
}
