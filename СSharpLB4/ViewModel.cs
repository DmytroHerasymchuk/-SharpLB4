using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace СSharpLB4
{
    public class ViewModel
    {
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ViewModel()
        {
            Teachers = new ObservableCollection<Teacher>();
            Subjects = new ObservableCollection<Subject>();
        }

        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }

        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
        }

        public void SetRelation(Teacher teacher, Subject subject)
        {
            Teachers.FirstOrDefault(x => x.Name == teacher.Name).Subjects.Add(subject);
            Subjects.FirstOrDefault(x => x.Name == subject.Name).Teachers.Add(teacher);
        }

    }
}
