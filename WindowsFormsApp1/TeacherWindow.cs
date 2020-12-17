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
    public partial class TeacherWindow : Form
    {
        UsersRepository repository = new UsersRepository();
        public TeacherWindow()
        {
            InitializeComponent();
            var Grades = repository.GetTeacherGrades();
            listView1.Items.Clear();
            foreach (var grade in Grades)
            {
                var row = new string[] { grade.getId().ToString(), grade.getName()+ " " + grade.getSurname(), grade.getValue().ToString(), grade.getDate() };
                var lvi = new ListViewItem(row);

                lvi.Tag = grade;
                listView1.Items.Add(lvi);
            }
            if (listView1.Items == null)
            {
                listView1.Enabled = false;
                label1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
           
                if (listView1.FocusedItem != null && textBox1.Text != "")
                {
            repository.UpdateGrade(int.Parse(listView1.SelectedItems[0].SubItems[0].Text), int.Parse(textBox1.Text));
                    MessageBox.Show("Done!");
                    textBox1.Clear();
                    var Grades = repository.GetTeacherGrades();
                    listView1.Items.Clear();
                    foreach (var grade in Grades)
                    {
                        var row = new string[] { grade.getId().ToString(), grade.getName() + " " + grade.getSurname(), grade.getValue().ToString(), grade.getDate() };
                        var lvi = new ListViewItem(row);

                        lvi.Tag = grade;
                        listView1.Items.Add(lvi);
                    }

                }
                else
                    MessageBox.Show("Need select line");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void listView1_Load(object sender, EventArgs e)
        {
            listView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.FocusedItem != null)
                {
                    repository.DeleteGrade(listView1.SelectedItems[0].SubItems[0].Text);
                    MessageBox.Show("Grade deleted");
                    listView1.Refresh();
                    var Grades = repository.GetTeacherGrades();
                    listView1.Items.Clear();
                    foreach (var grade in Grades)
                    {
                        var row = new string[] { grade.getId().ToString(), grade.getName() + " " + grade.getSurname(), grade.getValue().ToString(), grade.getDate() };
                        var lvi = new ListViewItem(row);

                        lvi.Tag = grade;
                        listView1.Items.Add(lvi);
                    }
                }
                else
                    MessageBox.Show("Need select line");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentList st = new StudentList();
            st.ShowDialog();
        }
    }
}
