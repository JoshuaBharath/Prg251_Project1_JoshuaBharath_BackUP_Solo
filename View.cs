using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Prg251_Project1_JoshuaBharath_BackUP_Solo
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            try
            {
                DataHandler dh = new DataHandler();
                List<Students> myList = dh.View();

                
                
                BindingSource bs = new BindingSource();
                bs.DataSource = myList;
                dataGridView1.DataSource = bs;
                dataGridView1.Columns["Username"].Visible = false;
                dataGridView1.Columns["Password"].Visible = false;
                //dataGridView1.Columns["Images"].Visible=false;
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           

            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
