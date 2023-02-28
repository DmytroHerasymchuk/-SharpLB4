using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace СSharpLB4
{
    public class ViewModel
    {
        
        private readonly MessageBroker _messager = MessageBroker.GetInstance();
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ViewModel()
        {
            Teachers = new ObservableCollection<Teacher>();
            Subjects = new ObservableCollection<Subject>();
        }

        public void AddTeacher(Teacher teacher)
        {
            if (!IsAlreadyExistTeacher(teacher))
            {
                Teachers.Add(teacher);
                _messager.RaiseMessage($"{teacher.FullName} Added!");
                return;
            }

            _messager.RaiseMessage($"{teacher.FullName} is already exist in list.");
        }

        public void AddSubject(Subject subject)
        {
            if (!IsAlreadyExistSubject(subject))
            {
                Subjects.Add(subject);
                _messager.RaiseMessage($"{subject.Name} Added!");
                return;
            }
            _messager.RaiseMessage($"{subject.Name} is already exist in list.");
        }

        public void RemoveTeacher(Teacher teacher)
        {
            if (IsAlreadyExistTeacher(teacher))
            {
                foreach(Subject subject in Subjects)
                {
                    subject.Teachers.Remove(teacher);
                }
                Teachers.Remove(teacher);
                _messager.RaiseMessage($"{teacher.FullName} Deleted!");
                return;
            }
            _messager.RaiseMessage($"{teacher.FullName} doesn't exist in list.");
        }
        public void RemoveSubject(Subject subject)
        {
            if (IsAlreadyExistSubject(subject))
            {
                foreach(Teacher teacher in Teachers)
                {
                    teacher.Subjects.Remove(subject);
                }
                Subjects.Remove(subject);
                _messager.RaiseMessage($"{subject.Name} Deleted!");
                return;
            }
            _messager.RaiseMessage($"{subject.Name} doesn't exist in list.");
        }
        public void SetRelation(Teacher teacher, Subject subject)
        {
            FindTeacher(teacher).Subjects.Add(subject);
            FindSubject(subject).Teachers.Add(teacher);
            _messager.RaiseMessage($"{teacher.FullName} now teaches {subject.Name}!"); 
        }
        public void RemoveRelation(Teacher teacher, Subject subject)
        {
            FindTeacher(teacher).Subjects.Remove(subject);
            FindSubject(subject).Teachers.Remove(teacher);
            _messager.RaiseMessage($"{teacher.FullName} no longer teaches {subject.Name}!");
        }

        public void Serialize()
        {
            using (StreamWriter file = File.CreateText("Teachers.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, Teachers);
            }
            using (StreamWriter file = File.CreateText("Subjects.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, Subjects);
            }
        }

        public void Deserialize()
        {
            using (StreamReader file = File.OpenText("Teachers.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Teachers = (ObservableCollection<Teacher>)serializer.Deserialize(file, typeof(ObservableCollection<Teacher>));
            }

            using (StreamReader file = File.OpenText("Subjects.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Subjects = (ObservableCollection<Subject>)serializer.Deserialize(file, typeof(ObservableCollection<Subject>));
            }
        }
        private Teacher FindTeacher(Teacher teacher)
        {
            return Teachers.FirstOrDefault(x => x.Name == teacher.Name && x.Surname == teacher.Surname);
        }
        private Subject FindSubject(Subject subject)
        {
            return Subjects.FirstOrDefault(x => x.Name == subject.Name);
        }
        private bool IsAlreadyExistTeacher(Teacher teacher)
        {
            if (Teachers.Contains(FindTeacher(teacher)))
            {
                return true;
            }
            return false;
        }
        private bool IsAlreadyExistSubject(Subject subject)
        {
            if (Subjects.Contains(FindSubject(subject)))
            {
                return true;
            }
            return false;
        }


        
    }
}
