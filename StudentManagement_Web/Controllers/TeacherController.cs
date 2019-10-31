using Microsoft.AspNetCore.Mvc;

namespace StudentManagement_Web.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
