using crud_app.Data;
using crud_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud_app.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext context;

        public EmployeeController(EmployeeDbContext context)
        {
            this.context = context;
        }
        //for showing the records in list formate
        public IActionResult Index()
        {
            var result = context.Employees.ToList();

            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // for create records

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    EmpName = model.EmpName,
                    Age = model.Age,
                    EmpDesc = model.EmpDesc

                };
                context.Employees.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Empty feild Can't Submit";
                return View(model);
            }


        }
        // for delete records
        public IActionResult Delete (int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.EmpId == id);
            context.Employees.Remove(emp);

            context.SaveChanges();
            TempData["error"] = "Record Update";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.EmpId == id);
            var result = new Employee()
            {
                EmpName = emp.EmpName,
                Age = emp.Age,
                EmpDesc = emp.EmpDesc
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                EmpId = model.EmpId,
                EmpName = model.EmpName,
                Age = model.Age,
                EmpDesc = model.EmpDesc
                
            };
            context.Employees.Update(emp);
            context.SaveChanges();
            TempData["error"] = "Record Update";
            return RedirectToAction("Index");

        }

    }
}
