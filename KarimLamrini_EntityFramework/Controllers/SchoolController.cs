using KarimLamrini_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarimLamrini_EntityFramework.Repository;

namespace KarimLamrini_EntityFramework.Controllers
{
    public class SchoolController : Controller
    {

        private SchoolRepository _repository = null;
        public SchoolController()
        {
            _repository = new SchoolRepository();
        }

        public ActionResult Index()
        {

            return View(_repository.Get_Students());
        }

        public ActionResult AddStudent()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.Add_Student(student);
                TempData["Message"] = "Student was successfully added!";
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult AddAuthor()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                _repository.Add_Author(author);
                TempData["Message"] = "Author was successfully added!";
                return RedirectToAction("Index");
            }  
            return View(author);
        }

        public ActionResult AddBook()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _repository.Add_Book(book);
                TempData["Message"] = "Book was successfully added!";
                return RedirectToAction("Index");
            } 
            return View(book);
        }
    }
}