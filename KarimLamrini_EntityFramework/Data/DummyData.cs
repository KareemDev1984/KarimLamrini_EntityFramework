using KarimLamrini_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KarimLamrini_EntityFramework.Data
{
    public class DummyData
    {
        public static void AddData(SchoolContext schoolContext)
        {
            var student = new Student() { FirstName = "Karim", LastName = "Lamrini" };
            var student2 = new Student() { FirstName = "Jan", LastName = "Alonso" };
            var student3 = new Student() { FirstName = "Joost", LastName = "Troost" };

            var book = new Book() { Title = "The Alchemist", Published = DateTime.Today };
            var book2 = new Book() { Title = "Voorbij Goed en kwaad", Published = DateTime.Today };
            var book3 = new Book() { Title = "Programmeren met Kenan", Published = DateTime.Today };

            var author = new Author() { Name = "Paulo Coelho", SurName = "Poco" };
            var author2 = new Author() { Name = "Nietzsche", SurName = "Fred" };
            var author3 = new Author() { Name = "Einstein", SurName = "Albert" };
            var author4 = new Author() { Name = "Kenan", SurName = "Kurda" };
            var author5 = new Author() { Name = "Zlatan", SurName = "Ibrahimovich" };

            book.Authors.Add(author);
            book.Authors.Add(author3);
            book.Authors.Add(author5);

            book2.Authors.Add(author2);
            book2.Authors.Add(author4);
            book2.Authors.Add(author3);

            book3.Authors.Add(author2);
            book3.Authors.Add(author4);
            book3.Authors.Add(author5);
            book3.Authors.Add(author);
            book3.Authors.Add(author3);

            student.Books.Add(book);

            student2.Books.Add(book2);
            student3.Books.Add(book3);

         

            schoolContext.Students.Add(student);
            schoolContext.Students.Add(student2);
            schoolContext.Students.Add(student3);
            schoolContext.SaveChanges();

        }
    }
}