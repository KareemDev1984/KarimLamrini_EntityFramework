namespace KarimLamrini_EntityFramework
{
    using KarimLamrini_EntityFramework.Models;
    using System.Data.Entity;


    public class SchoolContext : DbContext
    {
      
        public SchoolContext()
            : base("name=SchoolContext")
        {

        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}