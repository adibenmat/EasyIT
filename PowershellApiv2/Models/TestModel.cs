using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowershellApiv2.Models
{
    public class TestModel
    {
        public string FirstName { get; set; }
        public string LastName {get;set;}


        public TestModel(string fName,string lName)
        {
            FirstName = fName;
            LastName = lName;
        }

    }

    public class PSProccess
    {
       
        public string Name { get; set; }
        public string Something { get; set; }
        public PSProccess()
        {

        }
    }
}