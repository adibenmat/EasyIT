using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowershellRepository.Interface
{
    interface ITableAble
    {
        IEnumerable<string> GetCommands();
    }
}
