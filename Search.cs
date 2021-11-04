using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Prg251_Project1_JoshuaBharath_BackUP_Solo
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void serachBtn_Click(object sender, EventArgs e)
        {
            DataHandler dh = new DataHandler();
            List<Students> myList = dh.Search(Convert.ToInt32(comboBox1.Text));
            BindingSource bs = new BindingSource();
            bs.DataSource = myList;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns["Username"].Visible = false;
            dataGridView1.Columns["Password"].Visible = false;
            myList.Sort();
            //dataGridView1.Columns["Images"].Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            DataHandler dh = new DataHandler();
            foreach (var item in dh.ShowItemsInModelTbl())
            {
                ListViewItem i = new ListViewItem(item.ModuleId.ToString());
                i.SubItems.Add(item.ModuleName);
                listView1.Items.Add(i);
                comboBox1.Items.Add(item.ModuleId);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text=="Model Number")
            {
                comboBox1.Text = "";
                comboBox1.ForeColor = Color.MediumPurple;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = "Model Number";
                comboBox1.ForeColor = Color.MediumPurple;
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                comboBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            }
            catch (Exception)
            {

                MessageBox.Show("This model number hasnt been used yet please try again");
            }
        }
    }
}
