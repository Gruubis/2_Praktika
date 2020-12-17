using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Group
    {
        public string Name { get; set; }
        public int SubjectId { get; set; }

       public  Group(string name)
        {
            Name = name;
        }
    }
}
