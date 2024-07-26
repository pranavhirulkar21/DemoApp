using Microsoft.AspNetCore.Mvc;
using WP01.Models;

namespace WP01.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult Index123([FromServices] IEmployeeRepository _repository)
        {
            IEnumerable<Employee> allStudentDetails = _repository.GetAllEmployee();
            return Json(allStudentDetails);
        }
    }
}
