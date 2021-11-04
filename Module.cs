using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg251_Project1_JoshuaBharath_BackUP_Solo
{
    class Module
    {
        int moduleId;
        string moduleName;

        public Module(int moduleId, string moduleName)
        {
            this.ModuleId = moduleId;
            this.ModuleName = moduleName;
        }

        public int ModuleId { get => moduleId; set => moduleId = value; }
        public string ModuleName { get => moduleName; set => moduleName = value; }
    }
}
