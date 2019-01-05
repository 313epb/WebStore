using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;

namespace WebApplication3.Controllers
{
    [Route("users")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeData _employeeData;

        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        public IActionResult Index()
        {
            return View(_employeeData.GetAll());
        }
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var empl = _employeeData.GetById(id);
            if (ReferenceEquals(empl, null))
            {
                return NotFound();
            }

            return View(empl);
        }

        [Route("edit/{id?}")]
        [Authorize]
        public IActionResult Edit(int? id)
        {
            EmployeeView model;
            if (id.HasValue)
            {
                model = _employeeData.GetById(id.Value);
                if (ReferenceEquals(model, null))
                    return NotFound();// возвращаем результат 404 Not Found
            }
            else
            {
                model = new EmployeeView();
            }
            return View(model);
        }
        [HttpPost]
        [Route("edit/{id?}")]
        [Authorize]
        public IActionResult Edit(EmployeeView model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    var dbItem = _employeeData.GetById(model.Id);

                    if (ReferenceEquals(dbItem, null))
                        return NotFound(); // возвращаем результат 404 Not Found

                    dbItem.Name = model.Name;
                    dbItem.Age = model.Age;
                    dbItem.Department = model.Department;
                    dbItem.LastName = model.LastName;
                    dbItem.Salary = model.Salary;
                    dbItem.SecondName = model.SecondName;
                    dbItem.Email = model.Email;
                }
                else
                {
                    _employeeData.AddNew(model);
                }

                _employeeData.Comit();


                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Route("delete/{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _employeeData.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}