using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminWindow : Form
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Studentlist1 st1 = new Studentlist1();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(st1);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SubjectList sl = new SubjectList();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(sl);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            StudenttoGroup stg = new StudenttoGroup();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(stg);
        }

        private void AdminWindow_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            TeacherList tl = new TeacherList();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(tl);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Grouplist gp = new Grouplist();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(gp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SubjectToGroup stg = new SubjectToGroup();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(stg);
        }
    }
}
