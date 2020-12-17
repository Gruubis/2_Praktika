using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Grade
    {
    private int Id;
    private int Value;
    private string Name;
    private string Surname;
    private string SubjName;
    private string Date;

        public Grade(int value, string name, string surname, string subjname)
        {
            Value = value;
            Name = name;
            Surname = surname;
            SubjName= subjname;
        }

  public void setId(int id)
        {
            Id = id;
        }
  public int getId()
        {
            return Id;
        }
  public int getValue()
        {
            return Value;
        }
  public string getName()
        {
            return Name;
        }
 public string getSurname()
        {
            return Surname;
        }
 public string getSubjectname()
           {
                return SubjName;

            }
        public void setDate(string date)
        {
            Date = date;
        }
        public string getDate()
        {
            return Date;
        }
        }
    }
