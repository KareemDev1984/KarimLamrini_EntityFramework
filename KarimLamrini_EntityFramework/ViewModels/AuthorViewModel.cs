using KarimLamrini_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KarimLamrini_EntityFramework.ViewModels
{
    public class AuthorViewModel
    {

        public Author Author { get; set; }
        public Book Book { get; set; }
        public List<Author> Authors { get; set; }

        public AuthorViewModel()
        {
            Author = new Author();
            Book = new Book();
            Authors = new List<Author>();
        }

    }
}