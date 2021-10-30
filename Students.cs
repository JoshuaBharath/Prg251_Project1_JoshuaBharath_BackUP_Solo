using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg251_Project1_JoshuaBharath_BackUP_Solo
{
    class Students
    {
        int StudentNumber;
        string name;
        string surname;
       byte [] images;
        string dob;
        string gender;
        string phoneNumber;
        string Address;
        int moduleCode;
        string username;
        string password;

        public Students(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public Students(int studentNumber, string name, string surname, string dob, string gender, string phoneNumber, string address, int moduleCode)
        {
            StudentNumber = studentNumber;
            this.name = name;
            this.surname = surname;
            this.dob = dob;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
            Address = address;
            this.moduleCode = moduleCode;
        }

        public Students(int studentNumber, string name, string surname, byte [] images, string dob, string gender, string phoneNumber, string address, int moduleCode)
        {
            StudentNumber = studentNumber;
            this.name = name;
            this.surname = surname;
            this.Images = images;
            this.dob = dob;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
            this.Address = address;
            this.moduleCode = moduleCode;
        }

        

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; } 
        public string Dob { get => dob; set => dob = value; }
        public string Gender { get => gender; set => gender = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address1 { get => Address; set => Address = value; }
        public int ModuleCode { get => moduleCode; set => moduleCode = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int StudentNumber1 { get => StudentNumber; set => StudentNumber = value; }
        public byte [] Images { get => images; set => images = value; }

        public override string ToString()
        {
            return $"{username},{password}";
        }

    }
}
