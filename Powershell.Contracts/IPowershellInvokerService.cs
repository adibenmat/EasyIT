using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Powershell.Contracts
{
    [ServiceContract]
    public interface IPowershellInvokerService
    {
        [OperationContract]
        IEnumerable<PSItem> GetPowershellItemsEnumerable(PSItem item);

        [OperationContract]
        void AddPowershelItem(PSItem item);

        [OperationContract]
        void UpdatePowershellItem(PSItem updatedItem);

        [OperationContract]
        void DeletePowershelItem(PSItem item);

        //void UpdatePowershelItemsEnumerable(IEnumerable<PSItem> updatedPowershellItems);
    }
}
