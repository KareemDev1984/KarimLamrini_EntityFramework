using KarimLamrini_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KarimLamrini_EntityFramework.ViewModels
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public List<Student> Students { get; set; }
       
        public StudentViewModel()
        {
            Student = new Student();
            Students = new List<Student>();
        }
    }
}