using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Prg251_Project1_JoshuaBharath_BackUP_Solo
{
    class FileHandler
    { string fileName = @"StudentCredential.txt";
        public void StudentCredentials(string Username_,string Password_)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    FileStream fs = new FileStream(fileName, FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);
                    Students s = new Students(Username_,Password_);
                    sw.WriteLine(s.ToString());
                    sw.Close();
                    fs.Close();
                }
                else
                {
                    FileStream fs = new FileStream(fileName, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    Students s = new Students(Username_, Password_);
                    sw.WriteLine(s.ToString());
                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public bool ReadLogin(string username_,string password_)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {

                    string read;
                    bool found = false;
                    while ((read = sr.ReadLine()) != null)
                    {
                        string[] holder = read.Split(',');
                        if (holder[0].ToString() == username_ && holder[1].ToString() == password_)
                        {
                            found = true;
                            return true;

                        }
                    }
                    if (found == false)
                    {
                        return false;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
            
        }
    }
}
