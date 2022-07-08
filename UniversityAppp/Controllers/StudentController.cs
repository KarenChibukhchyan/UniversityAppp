using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityAppp.Models;
using UniversityAppp.Services;

namespace UniversityAppp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IPersonService<Student> _studentService;
        private readonly IPersonService<Teacher> _teacherService;

        public StudentController(IPersonService<Student> studentService, IPersonService<Teacher> teacherService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            var persons = _studentService.GetAll();
            return View(persons);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _studentService.Create(student);
            List<SelectListItem> Teachers = new List<SelectListItem>();
            int i = 1;
            foreach (var elem in _teacherService.GetAll())
            {
                Teachers.Add( new SelectListItem
                    {
                        Text = elem.LastName, Value = i.ToString()
                    });
                i++;
            }

            ViewBag.Teachers = Teachers;

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            Person person = _studentService.Get(id);
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _studentService.Update(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            Person? person = _studentService.Get(id);
            return View(person);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _studentService.Delete(student.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            Person? person = _studentService.Get(id);
            return View(person);
        }
    }
}