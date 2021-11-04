using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (textBox1.Text=="Student Number")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Student Number";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void serachBtn_Click(object sender, EventArgs e)
        {
            DataHandler dh = new DataHandler();
            List<Students> myList = dh.Search(Convert.ToInt32(textBox1.Text));
            BindingSource bs = new BindingSource();
            bs.DataSource = myList;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns["Username"].Visible = false;
            dataGridView1.Columns["Password"].Visible = false;
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

        }
    }
}
