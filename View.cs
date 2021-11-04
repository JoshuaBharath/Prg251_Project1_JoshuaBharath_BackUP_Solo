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
                myList.Sort();

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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                var imgRow = (Byte[])(row.Cells["images"].Value);
                var stream = new MemoryStream(imgRow);
                pictureBox1.Image = Image.FromStream(stream);
                stdnum.Text = row.Cells["StudentNumber1"].Value.ToString();
                stdName.Text = row.Cells["name"].Value.ToString();
                stdSurname.Text = row.Cells["surname"].Value.ToString();
                stdGender.Text = row.Cells["gender"].Value.ToString();
                stdPhone.Text = row.Cells["phoneNumber"].Value.ToString();
                stdAddress.Text = row.Cells["Address1"].Value.ToString();
                stdModelNumber.Text = row.Cells["moduleCode"].Value.ToString();
                stdDob.Text = row.Cells["Dob"].Value.ToString();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
