using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Subject
    {
        private int id;
        private string name;

        public Subject(int ID, string Name)
        {
            id = ID;
            name = Name;
        }

        public int getId()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }
        
    }
}
