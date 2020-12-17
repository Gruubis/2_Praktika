using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class User
    {
        private string Name;
        private string Surname;
        private string Username;
        private string Password;
        private string Type;
        private string Group;
        private int Id;
        private int SubjectId;
        public User(int id, string username, string password, string name, string surname, string type, string group, int subjectId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Type = type;
            Group = group;
            SubjectId = subjectId;
            
        }
      public string GetName()
        {
            return Name;
        }
        
      public string GetSurname()
        {
            return Surname;
        }
      public string GetGroup()
        {
            return Group;
        }
        public int getId()
        {
            return Id;
        }
        public string getType()
        {
            return Type;
        }
        public int getSubject_id()
        {
            return SubjectId;
        }
    }
}
