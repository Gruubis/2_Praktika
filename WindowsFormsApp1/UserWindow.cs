using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.repositories;

namespace WindowsFormsApp1
{
    public partial class UserWindow : Form
    {
        UsersRepository repository = new UsersRepository();
        public UserWindow()
        {
            InitializeComponent();
            label1.Text = WindowsFormsApp1.repositories.UsersRepository.LoggedInUser.GetName() + " " + WindowsFormsApp1.repositories.UsersRepository.LoggedInUser.GetSurname();
                label3.Text = WindowsFormsApp1.repositories.UsersRepository.LoggedInUser.GetGroup();

            var Grades = repository.GetGrades();
            listView1.Items.Clear();
            foreach (var grade in Grades)
            {
                var row = new string[] { grade.getSubjectname(), grade.getValue().ToString(), grade.getName() + " " + grade.getSurname(), grade.getDate() };
                var lvi = new ListViewItem(row);

                lvi.Tag = grade;
                listView1.Items.Add(lvi);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UserWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsersRepository.LoggedInUser = null;
            this.Close();
        }
    }
}
