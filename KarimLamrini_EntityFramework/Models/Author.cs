using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KarimLamrini_EntityFramework.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        [Required, StringLength(30)]
        public string SurName { get; set; }

     
        [NotMapped]
        public string DisplayName
        {
            get {
                return $"{SurName} {Name}";
            }
            
        }


        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }
    }
}