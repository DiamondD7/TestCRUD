using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCRUD.Data;
using TestCRUD.Models;

namespace TestCRUD.Controllers
{
    public class TableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable <StudentModel> students = _context.Students;
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentModel student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentModel studentEdit)
        {
            _context.Students.Update(studentEdit);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(StudentModel studentEdit)
        {
            _context.Students.Remove(studentEdit);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
