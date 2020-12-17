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
    public partial class Grouplist : UserControl
    {
        UsersRepository repository = new UsersRepository();
        public Grouplist()
        {
            InitializeComponent();
            
            var Groups = repository.GetGroups();
            foreach(Group g in Groups)
            {

                var row = new string[] {g.Name };
                var lvi = new ListViewItem(row)
                {
                    Tag = g
                };
                listView1.Items.Add(lvi);
                
            }
        }

        private void Grouplist_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }   

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            addGroup ag = new addGroup();
            ag.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                repository.DeleteGroup(listView1.SelectedItems[0].SubItems[0].Text);
                MessageBox.Show("Deleted");

            }
            else
                MessageBox.Show("select Group to delete");
        }
    }
}
