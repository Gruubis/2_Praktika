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
    public partial class SubjectList : UserControl
    {
        UsersRepository repository = new UsersRepository();
        public SubjectList()
        {
            InitializeComponent();

            var Subjects = repository.GetSubjects();
            listView1.Items.Clear();
            foreach (var s in Subjects)
            {
                var row = new string[] { s.getId().ToString(), s.getName()};
                var lvi = new ListViewItem(row);

                lvi.Tag = s;
                listView1.Items.Add(lvi);
            }
        }

        private void SubjectList_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem.Selected == true)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete " + listView1.SelectedItems[0].SubItems[1].Text + "?", "Sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    repository.DeleteSubject(int.Parse(listView1.SelectedItems[0].SubItems[0].Text));
                    MessageBox.Show("Done");
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            else
                MessageBox.Show("No student selected!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSubject sub = new AddSubject();
            sub.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
