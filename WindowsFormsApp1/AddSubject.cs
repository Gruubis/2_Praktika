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
    public partial class AddSubject : Form
    {
        UsersRepository repository = new UsersRepository();
        public AddSubject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                repository.TeacherSubject(textBox1.Text);
                MessageBox.Show("Subject added!");
                this.Close();
            }
            else
                MessageBox.Show("Subject name cannot be empty!");
        }
    }
}
