using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg251_Project1_JoshuaBharath_BackUP_Solo
{
    class StudentException : Exception
    {
        public StudentException()
        {
        }

        public StudentException(string message) : base(message)
        {
        }

        public StudentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
