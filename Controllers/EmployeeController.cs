using Microsoft.AspNetCore.Mvc;
using WP01.Models;

namespace WP01.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepository _emprp;
        public EmployeeController(IEmployeeRepository emprp)
        {
            _emprp = emprp;
        }
        public ActionResult Index()
        {
            var emplist = _emprp.GetAllEmployee();

            return View(emplist);
        }
       
        public ActionResult Display()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View(_emprp.GetEmployee(id));
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee empobj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _emprp.Add(empobj);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
                return View();
            
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_emprp.GetEmployee(id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee empobj)
        {
            try
            {
                _emprp.Update(empobj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_emprp.GetEmployee(id));
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee empobj)
        {
            try
            {
                _emprp.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
