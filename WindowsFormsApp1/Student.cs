using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Student
    {
        private int Id;
        private string Name;
        private string Surname;
        private string Group;
        private int subject_id;

        public Student(int id, string name, string surname, string group, int Subject_id)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Group = group;
            subject_id = Subject_id;
        }
        public int getId()
        {
            return Id;
        }
        public string getName()
        {
            return Name;
        }
        public string getSurname()
        {
            return Surname;
        }
        public string getGroup()
        {
            return Group;
        }
        public void setSubjectId(int id)
        {
            subject_id = id;
        }
        public int getSubjectId()
        {
            return subject_id;
        }
        
    }
}
