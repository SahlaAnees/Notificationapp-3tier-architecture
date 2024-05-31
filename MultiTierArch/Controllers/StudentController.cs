using Microsoft.AspNetCore.Mvc;
using BOL.DatabaseEntities;
using BOL.CommonEntities;
using BLL.LogicServices.Contract;

namespace MultiTierArch.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic) { 
            _studentLogic = studentLogic;
        }

        [HttpGet]
        public IActionResult StudentList()
        {

            StudentModule model = new StudentModule();

            model.studentList = _studentLogic.GetStudentListLogic().ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudentPost(Student FormData)
        {
            string result = _studentLogic.SaveStudentRecordLogic(FormData);
            if (result == "Saved Successfully!")
            {
                return RedirectToAction("StudentList", "Student");
            }
            else {
                TempData["ErrorTemp"] = result;
                return RedirectToAction("CreateStudent", "Student");
            }

        }

    }
}
