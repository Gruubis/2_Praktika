using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace _2praktika.Repositories
{
    class UsersRepository
    {
        public static User LoggedInUser;
        private SqlConnection conn;
        public UsersRepository()
        {
            conn = new SqlConnection(@"Server=.;Database=education_db;Integrated Security=true;");
        }
        public Student Login(string username, string password)
        {
            try
            {
                string sql = "select * from users " +
                "where username=@username and password=@password";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int id = int.Parse(reader["userId"].ToString());
                        string name = reader["name"].ToString();
                        string surname = reader["surname"].ToString();
                        DateTime birthdate = DateTime.Parse(reader["birthdate"].ToString());
                        string usrname = reader["username"].ToString();
                        string pasword = reader["password"].ToString();
                        string group = reader["group"].ToString();
                        string userType = reader["userType"].ToString();
                        Student student = new Student(usrname, pasword, name, surname);

                        return student;
                    }
                }
                conn.Close();

            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);

            }
            throw new Exception("wrong username or password");
        }
    }
}

