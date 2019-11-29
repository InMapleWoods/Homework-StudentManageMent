using Microsoft.AspNetCore.Mvc;

namespace StudentManagement_Web.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult GetCourseView()
        {
            return View();
        }
        public IActionResult ChooseCourse()
        {
            return View();
        }
        public IActionResult GetGradeView()
        {
            return View();
        }
        public IActionResult GetExam()
        {
            return View();
        }
        public IActionResult ExamView(int id)
        {
            return View(id);
        }
    }
}
