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
    public partial class addTeacher : Form
    {
        UsersRepository repository = new UsersRepository();
        public addTeacher()
        {
            InitializeComponent();

            var Subjects = repository.GetSubjects();
            foreach (var c in Subjects)
            {
                comboBox1.Items.Add($"{c.getName()}");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedItem != null)
            {
 
                repository.AddUser(textBox1.Text, textBox2.Text, "NULL", "teacher", repository.GetSubjedId(comboBox1.SelectedItem.ToString()));
               
                MessageBox.Show("Teacher added!");
                this.Close();
            }
            else
                MessageBox.Show("All fields must be filled");
        }

        private void addTeacher_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
