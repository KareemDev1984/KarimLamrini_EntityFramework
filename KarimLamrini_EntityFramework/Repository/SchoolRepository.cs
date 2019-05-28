using KarimLamrini_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using KarimLamrini_EntityFramework.ViewModels;

namespace KarimLamrini_EntityFramework.Repository
{
    public class SchoolRepository
    {
        private SchoolContext context;
        public SchoolRepository()
        {
            context = new SchoolContext();
        }

        public void Add_Student(Student student)
        {
            using (context)
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public void Add_Book(Book book)
        {
            using (context)
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        public void Add_Author(Author author)
        {
            using (context)
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }

        public List<Student> Get_Students()
        {
            using (context)
            {
                var students = context.Students
                    .Include(m => m.Books)
                    .Include(x => x.Books.Select(a => a.Authors))
                    .ToList();
                return students;
            }
        }

    

        public List<Book> Get_Books()
        { 
                var books = context.Books.OrderBy(m => m.BookId)
                    .Include(a => a.Authors)
                    .ToList();
                return books;
            
        }

        public List<Author> Get_Authors()
        {
    
                var authors = context.Authors
                    .Include(b => b.Books)
                    .ToList();

                return authors;
        }
    }
}

