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
    public partial class LoginWindow : Form
    {
        UsersRepository repository = new UsersRepository();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                WindowsFormsApp1.repositories.UsersRepository.LoggedInUser = repository.Login(textBox1.Text, textBox2.Text);
                if (WindowsFormsApp1.repositories.UsersRepository.LoggedInUser.getType() == "student")
                {
                    UserWindow uw = new UserWindow();
                    uw.ShowDialog();
                    Close();
                }
                else if(WindowsFormsApp1.repositories.UsersRepository.LoggedInUser.getType() == "teacher")
                {
                    TeacherWindow tw = new TeacherWindow();
                    tw.ShowDialog();
                    Close();
                }
                else
                {
                    AdminWindow aw = new AdminWindow();
                    aw.ShowDialog();
                    Close();
                }
             
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
