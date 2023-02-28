using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СSharpLB4.Models
{
    public class Subject
    {
        public string Name { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public Subject(string name)
        {
            Name = name;
            Teachers = new List<Teacher>();
        }
    }
}
