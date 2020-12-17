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
    public partial class TeacherList : UserControl
    {
        UsersRepository repository = new UsersRepository();
        public TeacherList()
        {
            InitializeComponent();
            var Teachers = repository.getUsersList("teacher");

            listView1.Items.Clear();
            foreach (var teacher in Teachers)
            {
                
                var row = new string[] { teacher.getId().ToString(), teacher.getName(), teacher.getSurname(), repository.GetSubjectName(teacher.getSubjectId()) };
                var lvi = new ListViewItem(row);

                lvi.Tag = teacher;
                listView1.Items.Add(lvi);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addTeacher at = new addTeacher();
            at.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                
                
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete "+ listView1.SelectedItems[0].SubItems[1].Text +" " + listView1.SelectedItems[0].SubItems[1].Text + " ?", "Sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    repository.DeleteUser(int.Parse(listView1.SelectedItems[0].SubItems[0].Text));
                    MessageBox.Show("Done");
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            else
                MessageBox.Show("No Teacher selected!");
        }

        private void TeacherList_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
