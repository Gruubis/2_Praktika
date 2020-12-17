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
    public partial class StudentList : Form
    {
        UsersRepository repository = new UsersRepository();

        public StudentList()
        {
            InitializeComponent();

           

            var Students = repository.GetStudentList(UsersRepository.LoggedInUser.getSubject_id());
            listView1.Items.Clear();
            foreach (var student in Students)
            {
                var row = new string[] { student.getId().ToString(), student.getName(), student.getSurname(), student.getGroup(),  };
                var lvi = new ListViewItem(row);

                lvi.Tag = student;
                listView1.Items.Add(lvi);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && listView1.FocusedItem != null)
            {
                repository.AddGrade(int.Parse(listView1.SelectedItems[0].SubItems[0].Text), int.Parse(textBox1.Text));
                MessageBox.Show("Done!");
                this.Close();
            }
            else
                MessageBox.Show("There is no value to be added or no student selected!");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StudentList_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0].SubItems[0].Text !="")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?" , "Sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    repository.DeleteUser(int.Parse(listView1.SelectedItems[0].SubItems[0].Text));
                    MessageBox.Show("Done");
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
                MessageBox.Show("No student selected!");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            addStudent a = new addStudent();
        }
    }
}
