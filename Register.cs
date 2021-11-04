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
using System.Data.SqlClient;

namespace Prg251_Project1_JoshuaBharath_BackUP_Solo
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void txtStdNumber_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtStdNumber_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtStdName_Enter(object sender, EventArgs e)
        {
            if (txtStdName.Text == "Student Name")
            {
                txtStdName.Text = "";
                txtStdName.ForeColor = Color.MediumPurple;
            }
        }

        private void txtStdName_Leave(object sender, EventArgs e)
        {
            if (txtStdName.Text == "")
            {
                txtStdName.Text = "Student Name";
                txtStdName.ForeColor = Color.Gray;
            }
        }

        private void txtStdSurname_Enter(object sender, EventArgs e)
        {
            if (txtStdSurname.Text == "Student Surname")
            {
                txtStdSurname.Text = "";
                txtStdSurname.ForeColor = Color.MediumPurple;
            }
        }

        private void txtStdSurname_Leave(object sender, EventArgs e)
        {
            if (txtStdSurname.Text == "")
            {
                txtStdSurname.Text = "Student Surname";
                txtStdSurname.ForeColor = Color.Gray;
            }
        }

        private void txtstdDOB_Enter(object sender, EventArgs e)
        {
            if (txtstdDOB.Text=="Date Of Birth")
            {
                txtstdDOB.Text = "";
                txtstdDOB.ForeColor = Color.MediumPurple;
            }
        }

        private void txtstdDOB_Leave(object sender, EventArgs e)
        {
            if (txtstdDOB.Text == "")
            {
                txtstdDOB.Text = "Date Of Birth";
                txtstdDOB.ForeColor = Color.Gray;
            }
        }

        private void txtStdPhone_Enter(object sender, EventArgs e)
        {
            if (txtStdPhone.Text == "Phone")
            {
                txtStdPhone.Text = "";
                txtStdPhone.ForeColor = Color.MediumPurple;
            }
        }

        private void txtStdPhone_Leave(object sender, EventArgs e)
        {
            if (txtStdPhone.Text == "")
            {
                txtStdPhone.Text = "Phone";
                txtStdPhone.ForeColor = Color.MediumPurple;
            }
        }

        private void txtStdAddress_Enter(object sender, EventArgs e)
        {
            if (txtStdAddress.Text == "Address")
            {
                txtStdAddress.Text = "";
                txtStdAddress.ForeColor = Color.MediumPurple;
            }
        }

        private void txtStdAddress_Leave(object sender, EventArgs e)
        {
            if (txtStdAddress.Text == "")
            {
                txtStdAddress.Text = "Address";
                txtStdAddress.ForeColor = Color.Gray;
            }
        }

        private void txtModuleCodes_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtModuleCodes_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtStdSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbStdGender_Enter(object sender, EventArgs e)
        {
            if (cbStdGender.Text == "Gender")
            {
                cbStdGender.Text = "";
                cbStdGender.ForeColor = Color.MediumPurple;
            }
        }

        private void cbStdGender_Leave(object sender, EventArgs e)
        {
            if (cbStdGender.Text == "")
            {
                cbStdGender.Text = "Gender";
                cbStdGender.ForeColor = Color.MediumPurple;
            }
        }

        private void cbStdGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Register_Load(object sender, EventArgs e)
        {
            
            cbStdGender.Items.Add("Male");
            cbStdGender.Items.Add("Female");

            DataHandler dh = new DataHandler();
            foreach (var item in dh.ShowItemsInModelTbl())
            {
                ListViewItem i = new ListViewItem(item.ModuleId.ToString());
                i.SubItems.Add(item.ModuleName);
                listView1.Items.Add(i);
                comboBox1.Items.Add(item.ModuleId);
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.MediumPurple;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtStdPassword_Enter(object sender, EventArgs e)
        {
            if (txtStdPassword.Text == "Password")
            {
                txtStdPassword.Text = "";
                txtStdPassword.ForeColor = Color.MediumPurple;
            }
        }

        private void txtStdPassword_Leave(object sender, EventArgs e)
        {
            if (txtStdPassword.Text == "")
            {
                txtStdPassword.Text = "Password";
                txtStdPassword.ForeColor = Color.Gray;
            }
        }
        string ImgLocation = "";
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                string jpg = "JPG Files (*.jpg)|*.jpg";
                string AllFiles = "All Files (*.*)|*.*";
                ofd.Filter =$"{jpg}|{AllFiles}" ;
                ofd.Title = "Select student picture";
                if (ofd.ShowDialog()==DialogResult.OK)
                {
                    ImgLocation = ofd.FileName.ToString();
                    pictureBox1.ImageLocation = ImgLocation;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }
        byte[] img = null;
        private void button2_Click(object sender, EventArgs e)
        {
           try
           {
               
                FileStream fs = new FileStream(ImgLocation,FileMode.Open,FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                DataHandler dh = new DataHandler();
                if (txtStdPhone.Text.Length!=10)
                {
                    throw new StudentException("number needs to be 10 digits with no spaces");
                }
                dh.Create(txtStdName.Text, txtStdSurname.Text, txtstdDOB.Text, cbStdGender.Text, txtStdPhone.Text, txtStdAddress.Text, Convert.ToInt32(comboBox1.Text),img, txtUsername.Text, txtStdPassword.Text);
                this.Hide();
                Login l = new Login();
                l.Show();
           }
           catch (Exception ex)
           {

               MessageBox.Show(ex.Message);
               
           }

            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void txtStdName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtstdDOB_Enter_1(object sender, EventArgs e)
        {
           
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Text=listView1.SelectedItems[0].SubItems[0].Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text=="Module Code")
            {
                comboBox1.Text = "";
                comboBox1.ForeColor = Color.MediumPurple;
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = "Module Code";
                comboBox1.ForeColor = Color.MediumPurple;
            }
        }
    }
}
