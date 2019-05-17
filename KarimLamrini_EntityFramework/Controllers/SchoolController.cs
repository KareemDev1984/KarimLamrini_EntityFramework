using KarimLamrini_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarimLamrini_EntityFramework.Repository;
using KarimLamrini_EntityFramework.ViewModels;

namespace KarimLamrini_EntityFramework.Controllers
{
    public class SchoolController : Controller
    {
        private AuthorViewModel _authorViewModel = null;
        private StudentViewModel _studentViewModel = null;
        private BookViewModel _bookViewModel = null;
        private SchoolRepository _repository = null;

        public SchoolController()
        {
            _repository = new SchoolRepository();
            _authorViewModel = new AuthorViewModel();
            _studentViewModel = new StudentViewModel();
            _bookViewModel = new BookViewModel();

        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AddStudent()
        {
            _studentViewModel.Students = _repository.Get_Students();
            return View(_studentViewModel);
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
            return View();
        }

        public ActionResult AddAuthor()
        {
            _authorViewModel.Authors = _repository.Get_Authors();
            return View(_authorViewModel);
        }

        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {

            if (ModelState.IsValid)
            {
                _repository.Add_Author(author);
                TempData["Message"] = "Author was successfully added!";
                return RedirectToAction("AddAuthor");
            }

            return View();
        }


        public ActionResult AddBook()
        {
            _bookViewModel.Books = _repository.Get_Books();
            _bookViewModel.Authors = _repository.Get_Authors();
            ViewBag.SelectListAuthors = new SelectList(_bookViewModel.Authors, "AuthorID", "DisplayName");
            return View(_bookViewModel);
        }

        [HttpPost]
        public ActionResult AddBook(Book book, List<Author> authors)
        {

            if (ModelState.IsValid)
            {
                _bookViewModel.Book = book;

                foreach (var item in authors)
                {
                    _bookViewModel.Book.Authors.Add(item);

                }
                foreach (var item in _bookViewModel.Authors)
                {
                    _bookViewModel.Book.Authors.Add(item);

                }
                _repository.Add_Book(_bookViewModel.Book);
                TempData["Message"] = "Book was successfully added!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}