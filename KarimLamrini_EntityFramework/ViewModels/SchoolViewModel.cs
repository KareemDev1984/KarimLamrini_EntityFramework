using KarimLamrini_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KarimLamrini_EntityFramework.ViewModels
{
    public class SchoolViewModel
    {
        public Book Book { get; set; }
        public List<Book> Books { get; set; }
        public Author Author { get; set; }
        public List<Author> AvailableAuthors { get; set; }

        public int[] idsOfSelectedAuthors { get; set; }

        public SchoolViewModel()
        {
            Book = new Book();
            Books = new List<Book>();
            Author = new Author();
            AvailableAuthors = new List<Author>();
        }
    }
}