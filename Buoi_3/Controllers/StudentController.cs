using Microsoft.AspNetCore.Mvc;
using BT3.Models;
using System.Collections.Generic;
using System.Linq;

namespace BT3.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> _registeredStudents = new List<Student>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                _registeredStudents.Add(student);
                return RedirectToAction("ShowKQ", student);
            }
            return View(student);
        }

        public IActionResult ShowKQ(Student student)
        {
            int countSameMajor = _registeredStudents.Count(s => s.ChuyenNganh == student.ChuyenNganh);

            ViewBag.MSSV = student.MSSV;
            ViewBag.HoTen = student.HoTen;
            ViewBag.ChuyenNganh = student.ChuyenNganh;
            ViewBag.SoLuongCungNganh = countSameMajor;

            return View();
        }
    }
}