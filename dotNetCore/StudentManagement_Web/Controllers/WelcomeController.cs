using Microsoft.AspNetCore.Mvc;

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
    }
}