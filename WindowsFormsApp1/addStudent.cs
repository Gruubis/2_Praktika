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
    public partial class addStudent : Form
    {
        UsersRepository repository = new UsersRepository();
        public addStudent()
        {
            InitializeComponent();

            var Groups = repository.GetGroups();

            foreach(Group g in Groups)
            {
                comboBox1.Items.Add(g.Name);
            }
        }

        private void addStudent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedItem!= null)
            {
                repository.AddUser(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), "student", 0);
                
                MessageBox.Show("Student added!");
                this.Close();
            }
            else
                MessageBox.Show("All fields must be filled");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
