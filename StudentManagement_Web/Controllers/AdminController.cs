using Bll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;

namespace StudentManagement_Web.Controllers
{
    /// <summary>
    /// 管理员控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAdminController : ControllerBase
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
        readonly AdminBll adminBll = new AdminBll();

        /// <summary>
        /// 接收申请
        /// </summary>
        /// <param name="number">申请用户账号</param>
        /// <returns>成功与否</returns>
        //PUT: api/ApiAdmin/AcceptLog?number={number}
        [HttpPut("AcceptLog")]
        public IActionResult AcceptLog(string number)
        {
            try
            {
                return Ok(adminBll.AcceptLog(number));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 拒绝申请
        /// </summary>
        /// <param name="number">申请用户账号</param>
        /// <returns>成功与否</returns>
        //PUT: api/ApiAdmin/RejectionLog?number={number}
        [HttpPut("RejectionLog")]
        public IActionResult RejectionLog(string number)
        {
            try
            {
                return Ok(adminBll.RejectionLog(number));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="number">用户账号</param>
        /// <returns>成功与否</returns>       
        //DELETE: api/ApiAdmin?number={number}
        [HttpDelete]
        public IActionResult DeleteUser(string number)
        {
            try
            {
                return Ok(adminBll.DeleteUser(number));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 获取分页后的用户名单
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <param name="choose">分页选项</param>
        /// <returns>分页后名单</returns>
        //GET: api/ApiAdmin/GetPaperUsersArray?index={index}&size={size}&choose={choose}
        [HttpGet("GetPaperUsersArray")]
        public IActionResult GetPaperUsersArray(int index, int size, int choose)
        {
            try
            {
                var users = adminBll.GetPaperUsersArray(index, size, choose);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 获取未审核用户分页总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <param name="choose">分页选项</param>
        /// <returns>分页数</returns>
        //GET: api/ApiAdmin/GetAllPageNum?size={size}&choose={choose}
        [HttpGet("GetAllPageNum")]
        public IActionResult GetAllPageNum(int size, int choose)
        {
            try
            {
                return Ok(adminBll.GetAllPageNum(size, choose));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }

    public class AdminController : Controller
    {
        public IActionResult UserApply()
        {
            return GetIsloginState();
        }
        public IActionResult GetStudent()
        {
            return GetIsloginState();
        }
        public IActionResult GetTeacher()
        {
            return GetIsloginState();
        }
        public IActionResult ExamApply()
        {
            return GetIsloginState();
        }
        public IActionResult GetCourse()
        {
            return GetIsloginState();
        }
        private IActionResult GetIsloginState()
        {
            try
            {
                if ((GetCookies("islogin") == null) || (GetCookies("islogin") != "true"))
                {
                    return Redirect("~/Welcome");
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
}
