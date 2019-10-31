using Microsoft.AspNetCore.Mvc;

namespace StudentManagement_Web.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
