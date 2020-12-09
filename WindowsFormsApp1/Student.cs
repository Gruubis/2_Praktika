using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Student : User
    {
        private string Name;
        private string Surname;
        private string Group;

        public Student(string username, string password, string name, string surname) : base(username, password)
        {

        }

    }
}
