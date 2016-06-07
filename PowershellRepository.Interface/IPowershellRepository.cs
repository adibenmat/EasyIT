using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowershellRepository.Interface
{
    public interface IPowershellRepository
    {
        IEnumerable<IPowershellItem> GetPowershellItemsEnumerable();

        IPowershellItem GetPowershellItem(string targetIdentifier);

        void AddPowershelItem(IPowershellItem item);

        void UpdatePowershellItem(string targetIdentifier, IPowershellItem updatedItem);

        void DeletePowershelItem(string targetIdentifier);

        void UpdatePowershelItemsEnumerable(IEnumerable<IPowershellItem> updatedPowershellItems);
    }
}
