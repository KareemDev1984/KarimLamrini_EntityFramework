using KarimLamrini_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KarimLamrini_EntityFramework.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public List<Book> Books { get; set; }
       public Author Author { get; set; }
        public List<Author> Authors { get; set; }


        public BookViewModel()
        {
            Book = new Book();
            Books = new List<Book>();
            Author = new Author();
            Authors = new List<Author>();
        }
    }
}