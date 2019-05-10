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
        private SchoolContext schoolContext;
        public SchoolRepository()
        {
            schoolContext = new SchoolContext();
        }

        public void Add_Student(Student student)
        {
            using (var context = new SchoolContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }

        }

        public void Add_Book(Book book)
        {
            using (var context = new SchoolContext())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        public void Add_Author(Author author)
        {
            using (var context = new SchoolContext())
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }

        public List<Student> Get_Students()
        {
            using (schoolContext)
            {
                var students = schoolContext.Students
                    .Include(m => m.Books)
                    .Include(x => x.Books.Select(a => a.Authors))
                    .ToList();
                return students;
            }
        }

        public List<Book> Get_Books()
        {
            using (schoolContext)
            {
                var books = schoolContext.Books
                    .Include(a => a.Authors)
                    .ToList();
                return books;
            }

        }

        public List<Author> Get_Authors()
        {
            using (schoolContext)
            {
                var authors = schoolContext.Authors
                    .Include(a => a.Books)
                    .ToList();

                return authors;
            }
        }
      
    }
}