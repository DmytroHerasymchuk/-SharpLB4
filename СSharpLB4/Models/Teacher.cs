using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СSharpLB4.Models
{
    public class Teacher
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string FullName => $"{Surname} {Name.FirstOrDefault()}.";
        public int CountOfSubjects => Subjects.Count;
        public ICollection<Subject> Subjects { get; set; }
        public Teacher(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Subjects = new List<Subject>();
        }

        
    }
}
