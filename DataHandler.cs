using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;



namespace Prg251_Project1_JoshuaBharath_BackUP_Solo
{
    class DataHandler
    {
        SqlConnection conn = new SqlConnection("Server=.;Initial Catalog=StudentDB;Integrated Security=SSPI");
        
        public void Create(int stdNumber_,string stdName_,string stdSurname_,string Dob_,string gender_,string phone_ ,string address_,int modul_,byte [] IMAGES)
        {
            try
            {
                conn.Open();
                if (phone_.Length!=10)
                {
                    throw new StudentException("Phone number needs to be 10 degits");
                }
                SqlCommand cmd = new SqlCommand($"INSERT INTO tblStudent Values('{stdNumber_}','{stdName_}','{stdSurname_}','{IMAGES}','{Dob_}','{gender_}','{phone_}','{address_}','{modul_}')",conn);
                 
                  cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
           {

               MessageBox.Show(ex.Message);
          }
        }
        public List <Students> View()
        {
            List<Students> stdList = new List<Students>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * From tblStudent", conn);
          
                
                SqlDataReader read;
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    byte [] arr = (byte[])read[3];
                    
                    
                    Students s = new Students(Convert.ToInt32(read[0]),read[1].ToString(), read[2].ToString(), arr, read[4].ToString(), read[5].ToString(), read[6].ToString(), read[7].ToString(), Convert.ToInt32(read[8].ToString()));
                    stdList.Add(s);
                }
                
                conn.Close();
                return stdList;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return stdList;
            }
        }
        public List<Students> Search(int num)
        {
            List<Students> stdList = new List<Students>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"Select * From tblStudent where stdNumber='{num}'", conn);


                SqlDataReader read;
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    byte[] arr = (byte[])read[3];


                    Students s = new Students(Convert.ToInt32(read[0]), read[1].ToString(), read[2].ToString(), arr, read[4].ToString(), read[5].ToString(), read[6].ToString(), read[7].ToString(), Convert.ToInt32(read[8].ToString()));
                    stdList.Add(s);
                }

                conn.Close();
                if (stdList.Count() == 0)
                {
                    throw new StudentException("item did not exists");
                }
                return stdList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return stdList;
            }
        }

        public void Update(int user,int module)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"Update tblStudent set ModuleCode_FK='{module}' Where stdNumber='{user}'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("record was updated");
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"Delete From tblStudent WHERE stdNumber='{id}'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Item Is Deleted Permanently");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
