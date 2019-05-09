using KarimLamrini_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KarimLamrini_EntityFramework.ViewModels
{
    public class ViewModel
    {
        public Author Author { get; set; }
        public Book Book { get; set; }
        public Student Student { get; set; }

        public List<Student> Students { get; set; }
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }

        public ViewModel()
        {
            Students = new List<Student>();
            Books = new List<Book>();
            Authors = new List<Author>();
            Author = new Author();
            Book = new Book();
            Student = new Student();
        }
    }
}