using Microsoft.AspNetCore.Mvc;

namespace StudentManagement_Web.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult AddCourse()
        {
            return View();
        }
        public IActionResult ApplyExam()
        {
            return View();
        }
        public IActionResult ManageGrade()
        {
            return View();
        }
        public IActionResult AllGrade()
        {
            return View();
        }

        public IActionResult ManageExamQuestion(int id)
        {
            return View(id);
        }
        public IActionResult AddExamQuestion(int id)
        {
            return View(id);
        }
        public IActionResult UpdateExamQuestion(int id)
        {
            return View(id);
        }
    }
}
