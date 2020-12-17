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
    public partial class SubjectToGroup : UserControl
    {
        UsersRepository repository = new UsersRepository();
        public SubjectToGroup()
        {
            InitializeComponent();
            var Subjects = repository.GetSubjects();
            listView1.Items.Clear();
            foreach (var s in Subjects)
            {
                var row = new string[] { s.getId().ToString(), s.getName() };
                var lvi = new ListViewItem(row);

                lvi.Tag = s;
                listView2.Items.Add(lvi);
            }
            var Groups = repository.GetGroups();
            foreach (Group g in Groups)
            {

                var row = new string[] { g.Name };
                var lvi = new ListViewItem(row)
                {
                    Tag = g
                };
                listView1.Items.Add(lvi);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null && listView2.FocusedItem != null)
            {
                repository.SubjectToGroup(int.Parse(listView2.SelectedItems[0].SubItems[0].Text), listView1.SelectedItems[0].SubItems[0].Text);
                MessageBox.Show("Subject asigned to group!");
            }
            else
                MessageBox.Show("No Subject or group selected");
        }

        private void SubjectToGroup_Load(object sender, EventArgs e)
        {

        }
    }
}
