using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace KarimLamrini_EntityFramework.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required,DataType(DataType.Date)]
        public DateTime Published { get; set; }

        Student Student { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public Book()
        {
            Authors = new List<Author>();
        }
    }
}