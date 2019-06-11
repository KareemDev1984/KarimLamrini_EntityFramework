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
       
        private SchoolRepository _repository = null;
        private SchoolViewModel _schoolViewModel = null;
        private StudentViewModel _studentViewModel = null;

        public SchoolController()
        {
            _repository = new SchoolRepository();
            _schoolViewModel = new SchoolViewModel();
            _studentViewModel = new StudentViewModel();
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
        public ActionResult AddStudent(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                _repository.Add_Student(studentViewModel.Student);
                TempData["Message"] = "Student was successfully added!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult AddAuthor()
        {
           _schoolViewModel.AvailableAuthors = _repository.Get_Authors();
            return View(_schoolViewModel);
        }

        [HttpPost]
        public ActionResult AddAuthor(SchoolViewModel schoolViewModel)
        {
            if (ModelState.IsValid)
            {
                _repository.Add_Author(schoolViewModel.Author);
                TempData["Message"] = "Author was successfully added!";
                return RedirectToAction("AddAuthor");
            }
            return View();
        }
     
        public ActionResult AddAuthorInBookView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthorInBookView(Author author)
        {
            if (ModelState.IsValid)
            {
                _repository.Add_Author(author);
             
                TempData["Message"] = "Author was successfully added!";
                return RedirectToAction("AddBook");
            }
            return RedirectToAction("AddBook");
        }


        public ActionResult AddBook()
        {
            _schoolViewModel.Books = _repository.Get_Books();
            _schoolViewModel.AvailableAuthors = _repository.Get_Authors();
            ViewBag.SelectListAuthors = new SelectList(_schoolViewModel.AvailableAuthors, "AuthorID", "DisplayName");

            return View(_schoolViewModel);
        }

        [HttpPost]
        public ActionResult AddBook(SchoolViewModel bookViewModel)
        {   
            if (ModelState.IsValid)
            {
                List<Author> selectedAuthors = new List<Author>();
                foreach (var id in bookViewModel.idsOfSelectedAuthors)
                {
                    selectedAuthors.Add(_repository.Get_Authors().FirstOrDefault(author => author.AuthorId == id));
                }

                bookViewModel.Book.Authors = selectedAuthors;
                              
                _repository.Add_Book(bookViewModel.Book);
                TempData["Message"] = "Book was successfully added!";
                return RedirectToAction("Index");
            }
            return View();
        }

        //public JsonResult LoadAuthors()
        //{
        //    IEnumerable<Author> authorsSelect = _repository.Get_Authors();

        //    return Json(authorsSelect.Select(x => new
        //    {

        //        Id = x.AuthorId,
        //        Name = x.DisplayName

        //    }));
        //}

    

        [HttpPost]
        public JsonResult LoadAuthors()
        {

            _schoolViewModel.AvailableAuthors = _repository.Get_Authors();
           var authorsSelect = new SelectList(_schoolViewModel.AvailableAuthors, "AuthorID", "DisplayName");

            return Json(authorsSelect);
        }
    }
}