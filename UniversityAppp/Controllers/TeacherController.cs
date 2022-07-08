using System;
using Microsoft.AspNetCore.Mvc;
using UniversityAppp.Models;
using UniversityAppp.Services;

namespace UniversityAppp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IPersonService<Teacher> _personService;
        public TeacherController(IPersonService<Teacher> personService)
        {
            _personService = personService;
        }
        public IActionResult Index()
        {
            var teachers = _personService.GetAll();
            return View(teachers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            _personService.Create(teacher);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id)
        {
            Person? teacher = _personService.Get(id);
            return View(teacher);
        }
        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            _personService.Update(teacher);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            Person teacher = _personService.Get(id);
            return View(teacher);
        }
        [HttpPost]
        public IActionResult Delete(Teacher teacher)
        {
            _personService.Delete(teacher.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid id)
        {
            Person teacher = _personService.Get(id);
            return View(teacher);
        }
    }
}
