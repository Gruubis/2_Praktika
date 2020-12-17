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
    public partial class StudenttoGroup : UserControl
    {
        UsersRepository repository = new UsersRepository();
        public StudenttoGroup()
        {
            InitializeComponent();

            var Students = repository.getUsersList("student");
            listView1.Items.Clear();
            foreach (var student in Students)
            {
                var row = new string[] { student.getId().ToString(), student.getName(), student.getSurname(), student.getGroup(), };
                var lvi = new ListViewItem(row);

                lvi.Tag = student;
                listView1.Items.Add(lvi);
            }
            var Groups = repository.GetGroups();
            foreach (Group g in Groups)
            {

                var row = new string[] { g.Name };
                var lvi = new ListViewItem(row)
                {
                    Tag = g
                };
                listView2.Items.Add(lvi);

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null && listView2.FocusedItem != null)
            {
                repository.StudentToGroup(int.Parse(listView1.SelectedItems[0].SubItems[0].Text), listView2.SelectedItems[0].SubItems[0].Text);
                MessageBox.Show("Student asigned to group");
            }
            else
                MessageBox.Show("No student or group selected");
        }
    }
}
