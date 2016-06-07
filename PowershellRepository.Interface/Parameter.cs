using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowershellRepository.Interface
{
    public class Parameter
    {
        public string Name { get; set; }
        public string Value { get; set; }         
        public bool IsRequired { get; set; }


        public Parameter(string name)
        {
            Name = name;
            Value = null;
            IsRequired = false;
        }
        public Parameter(string name,bool isRequired)
        {
            Name = name;
            Value = null;
            IsRequired = isRequired;
        }
        public Parameter(string name,string value)
        {
            Name = name;
            Value = value;
            IsRequired = false;
        }
        public Parameter(string name, string value,bool isRequired)
        {
            Name = name;
            Value = value;
            IsRequired = isRequired;
        }

    }
}
