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
    public partial class Studentlist1 : UserControl
    {
        UsersRepository repository = new UsersRepository();
        public Studentlist1()
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
        }

        private void Studentlist1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addStudent a = new addStudent();
            a.ShowDialog();
        }


        private void button2_Click(object sender, EventArgs e)
        {

            if (listView1.FocusedItem != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete?", "Sure?", MessageBoxButtons.YesNo);
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
                MessageBox.Show("No student selected!");
        }
    }
    }

