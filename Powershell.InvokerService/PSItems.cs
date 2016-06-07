using Common;
using Common.Models;
using Powershell.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powershell.InvokerService
{
    public static class PSItems
    {
        private static Dictionary<string, Type> _objectsDictionary { get; set; }

        static PSItems()
        {
            _objectsDictionary.Add("PSService", typeof(PSService));
        }        

        public static Type GetTypeByName(string psItemTypeName)
        {
            return _objectsDictionary[psItemTypeName];
        }
    }
}
