﻿using Bll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        /// <param name="id">申请用户ID</param>
        /// <returns>成功与否</returns>
        //PUT: api/ApiAdmin/AcceptLog/{id}
        [HttpPut("AcceptLog/{id}")]
        public IActionResult AcceptLog(string id)
        {
            try
            {
                return Ok(adminBll.AcceptLog(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 拒绝申请
        /// </summary>
        /// <param name="id">申请用户ID</param>
        /// <returns>成功与否</returns>
        //PUT: api/ApiAdmin/RejectionLog/{id}
        [HttpPut("RejectionLog/{id}")]
        public IActionResult RejectionLog(string id)
        {
            try
            {
                return Ok(adminBll.RejectionLog(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>成功与否</returns>       
        //DELETE: api/ApiAdmin/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                return Ok(adminBll.DeleteUser(id));
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
                return Ok(adminBll.GetPaperUsersArray(index, size, choose));
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
}
