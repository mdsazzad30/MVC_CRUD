using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProjectCrud.DbCon;
using MvcProjectCrud.Models;

namespace MvcProjectCrud.Controllers
{
    public class EmployeeController : Controller


    {
        // Database instance & property.....
        private readonly DbConnectionContext _context;
        public EmployeeController(DbConnectionContext context)
        {
            _context = context;
        }

        // Get: Employee..........
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _context.Employees.ToListAsync();
            return View(data);
        }


        //Create: Employee.................
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Employee Employee)
        {
            if (!ModelState.IsValid)
            {
                return View(Employee);
            }
            await _context.Employees.AddAsync(Employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // Edit: Employee.................
        public IActionResult Edit(int id)
        {
            var data = _context.Employees.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Employee Employee)
        {

            if (!ModelState.IsValid)
            {
                return View(Employee);
            }
            _context.Entry(Employee).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        // Employee: Details..................................
        public IActionResult Details(int id)
        {
            var data = _context.Employees.Find(id);
            return View(data);
        }

        // Employee: Delete......................................
        public IActionResult Delete(int id)
        {
            return View(_context.Employees.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _context.Employees.Find(id);
            if (data != null)
            {
                _context.Employees.Remove(data);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
