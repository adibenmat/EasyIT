using Powershell.Contracts;
using System;
using System.Collections.Generic;

namespace Powershell.InvokerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class InvokerService : IPowershellInvokerService
    {
        public void AddPowershelItem(PSItem item)
        {
            var PSItemType = PSItems.GetTypeByName(item.Name);
            Invoker
        }

        public void DeletePowershelItem(PSItem item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PSItem> GetPowershellItemsEnumerable(PSItem item)
        {
            throw new NotImplementedException();
        }

        public void UpdatePowershellItem(PSItem updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
