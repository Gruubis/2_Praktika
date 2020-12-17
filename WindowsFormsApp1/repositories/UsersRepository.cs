using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WindowsFormsApp1.repositories
{
    class UsersRepository
    {
        public static User LoggedInUser;
        private SqlConnection conn;
        public UsersRepository()
        {
            conn = new SqlConnection(@"Server=.;Database=education_db;Integrated Security=true;");
        }
        public User Login(string username, string password)
        {
            try
            {
                string sql = "select * from Users " +
                "where username=@username and password=@password";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int id = int.Parse(reader["id"].ToString());
                        string name = reader["name"].ToString();
                        string surname = reader["surname"].ToString();
                        string usrname = reader["username"].ToString();
                        string pasword = reader["password"].ToString();
                        string group = reader["grupe"].ToString();
                        string userType = reader["type"].ToString();
                        int subjectId = int.Parse(reader["subject_id"].ToString());
                        User user = new User(id, usrname, pasword, name, surname, userType, group, subjectId);

                        conn.Close();
                        return user;
                    }
                }

            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);

            }
            throw new Exception("wrong username or password");
        }
        public List<Grade> GetGrades()
        {
            List<Grade> GradeList = new List<Grade>();

            string sql = "select users.name, users.surname, grade.value, grade.Date, Subject.name " +
            "from((grade inner join users on grade.subject_id = users.subject_id) " +
            "inner join Subject on Subject.id = grade.subject_id) where grade.user_id = " + LoggedInUser.getId();
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int value = int.Parse(reader[2].ToString());
                    string name = reader[0].ToString();
                    string surname = reader[1].ToString();
                    string subjname = reader[4].ToString();
                    string date = reader[3].ToString();
                    Grade grade = new Grade(value, name, surname, subjname);
                    grade.setDate(date);
                    GradeList.Add(grade);

                }
                conn.Close();
                return GradeList;

            }
        }
        public List<Grade> GetTeacherGrades()
        {
            List<Grade> GradeList = new List<Grade>();

            string sql = "select grade.id, Users.name, Users.surname, Subject.name, grade.value, grade.Date from(( grade " +
            "inner join  Subject on grade.subject_id = Subject.id) " +
            "inner join Users on grade.user_id = Users.id) where grade.teacher_id = " + LoggedInUser.getId();
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader[0].ToString());
                    int value = int.Parse(reader[4].ToString());
                    string name = reader[1].ToString();
                    string surname = reader[2].ToString();
                    string subjname = reader[3].ToString();
                    string date = reader[5].ToString();
                    Grade grade = new Grade(value, name, surname, subjname);
                    grade.setId(id);
                    grade.setDate(date);
                    GradeList.Add(grade);
                }
                conn.Close();
                return GradeList;

            }
        }
        public void DeleteGrade(string id)
        {
            if (id == "")
                throw new Exception("nothing to delete");


            string sql = "delete from grade where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", int.Parse(id));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateGrade(int id, int value)
        {
            string sql = "update grade set value=@value where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<Student> getUsersList(string type)
        {
            List<Student> StudentList = new List<Student>();

            string sql = "select id, name, surname, grupe, subject_id from Users where type=@type";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@type", type);
            conn.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader[0].ToString());
                    string group = reader[3].ToString();
                    string name = reader[1].ToString();
                    string surname = reader[2].ToString();
                    int subjectid = int.Parse(reader[4].ToString());
                    Student student = new Student(id, name, surname, group, subjectid);
                    StudentList.Add(student);
                }
                conn.Close();
                return StudentList;
            }
        }
        public void AddGrade(int id, int value)
        {
            string sql = "insert into grade (value, subject_id,  user_id, teacher_id, Date ) values(@value, @subject_id, @user_id, @teacher_id, @Date)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.Parameters.AddWithValue("@subject_id", LoggedInUser.getSubject_id());
            cmd.Parameters.AddWithValue("@user_id", id);
            cmd.Parameters.AddWithValue("@teacher_id", LoggedInUser.getId());
            cmd.Parameters.AddWithValue("@Date", DateTime.Today);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteUser(int id)
        {
            conn.Close();
            string sql = "delete from users where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void AddUser(string name, string surname, string group, string type, int subjectId)
        {
            string sql = "insert into users (username, password, name , surname, type, GRUPE, subject_id) values (@username, @password, @name, @surname, @type, @GRUPE, @subject_id)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", name);
            cmd.Parameters.AddWithValue("@password", surname);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@Grupe", group);
            cmd.Parameters.AddWithValue("@subject_id", subjectId);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public string GetSubjectName(int subject)
        {
            
            string sql = "select name from Subject where Subject.id = " + subject;
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
            {
                string subjectName = reader[0].ToString();
                conn.Close();
                return subjectName;
            }
            conn.Close();
            return null;

        }
        public void  TeacherSubject(string name)
        {
            string sql = "insert into Subject (name) values (@name)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", name);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Subject> GetSubjects()
        {
            List<Subject> SubjectList = new List<Subject>();

            string sql = "select id, name from Subject";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader[0].ToString());
                    string name = reader[1].ToString();
                    /*int Teacher_Id = int.Parse(reader[2].ToString());*/
                    Subject subject = new Subject(id, name);
                    SubjectList.Add(subject);
                }
                conn.Close();
                return SubjectList;
            }

        }
        public void DeleteSubject(int id)
        {
            string sql = "delete from Subject where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public string GetTeacherName(int id)
        {

            string sql = "select name, username from Users where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    string Name = reader[0].ToString();
                    string Surname = reader[0].ToString();
                    conn.Close();
                    return Name +" "+ Surname;
                }
            conn.Close();
            return null;
        }
        public int GetSubjedId(string name)
        {
            string sql = "select id from Subject where name=@name";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", name);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    int id = int.Parse(reader[0].ToString());

                    conn.Close();
                    return id;
                }
            conn.Close();
            return 0;
        }
        public List<Group> GetGroups()
        {
            List<Group> GroupList = new List<Group>();

            string sql = "select distinct name from Groups";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                   
                    string name = reader["name"].ToString();
                    Group group = new Group(name);
                    GroupList.Add(group);
                }
                conn.Close();
                return GroupList;
            }
        }
        public void AddGroup(string name)
        {
            string sql = "insert into groups (name) values (@name);";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", name);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void StudentToGroup(int studentId, string GroupName)
        {
            string sql = "update Users set Grupe=@GroupName where id=@studentId";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@GroupName", GroupName);
            cmd.Parameters.AddWithValue("@studentId", studentId);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void SubjectToGroup(int subjectId, string groupName)
        {
            string sql = "if not exists(select * from Groups where Name = @groupName and subject_id=@subjectId ) begin insert into Groups(Name, subject_id) values(@groupName, @subjectId) end";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("groupName", groupName);
            cmd.Parameters.AddWithValue("subjectId", subjectId);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<Student> GetStudentList(int subjId)
        {
            List<Student> StudentList = new List<Student>();

            string sql = "select users.id, users.name, surname, grupe, users.subject_id from (Users inner join Groups on groups.Name = users.GRUPE) where groups.subject_id =@subjId";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@subjId", subjId);
            conn.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader[0].ToString());
                    string group = reader[3].ToString();
                    string name = reader[1].ToString();
                    string surname = reader[2].ToString();
                    int subjectid = int.Parse(reader[4].ToString());
                    Student student = new Student(id, name, surname, group, subjectid);
                    StudentList.Add(student);
                }
                conn.Close();
                return StudentList;
            }
        }
        public void DeleteGroup(string name)
        {
            string sql = "delete from Groups where name=@name";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", name);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
    }



