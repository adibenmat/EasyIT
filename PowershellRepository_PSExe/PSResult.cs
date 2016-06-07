using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Web;

namespace PowershellRepository.PSInstance
{
    public class PSResult
    {
        public Collection<PSObject> Result { get; set; }
        public string Error { get; set; }

        public PSResult(Collection<PSObject> result, string error)
        {
            Result = result;
            Error = error;
        }
        public PSResult()
        { 
        }
        public PSResult(Collection<PSObject> result)
        {
            Result = result;            
        }
    }
}