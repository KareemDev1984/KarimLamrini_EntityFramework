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
        private ViewModel _viewModel = null;
        private AuthorViewModel _authorViewModel = null;
        private StudentViewModel _studentViewModel = null;
        private SchoolRepository _repository = null;

        public SchoolController()
        {
            _repository = new SchoolRepository();
            _authorViewModel = new AuthorViewModel();
            _studentViewModel = new StudentViewModel();
            _viewModel = new ViewModel();
        }

        public ActionResult Index()
        {
            _viewModel = _repository.Get_AllLists();
                 
            return View(_viewModel);
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
            return View(student);
        }

        public ActionResult AddAuthor()
        {
            _authorViewModel.Authors = _repository.Get_Authors();
            return View(_authorViewModel);
        }

        [HttpPost]
        public ActionResult AddAuthor(Author author,Book book)
        {
            var _author = author;
            if (ModelState.IsValid)
            {
                author.Books.Add(book);
                _repository.Add_Author(author);
                TempData["Message"] = "Author was successfully added!";
                return RedirectToAction("AddAuthor");
            }

            return View();
        }

        public ActionResult AddBook()
        {
            return View(/*_repository.Get_Books()*/);
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