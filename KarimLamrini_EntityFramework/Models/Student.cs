
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace KarimLamrini_EntityFramework.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required, StringLength(30)]
        public string FirstName { get; set; }

        [Required, StringLength(30)]
        public string LastName  { get; set; }
        
        public virtual ICollection<Book> Books { get; set; }
     
        public Student()
        {
         
            Books = new List<Book>();
        }

      
    }
}