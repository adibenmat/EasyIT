using Common.Models;
using System.Collections.Generic;

namespace  Common
{
    public interface IPowershellItem
    {
        // this property wiil be used as the target identifier in the Update and Delete Methods
        string IdentifierProperty { get; set; }
        //this method will return the string of the update method of the Powershell Item
        //example "set-service","set-adfsrelyingParty"
        CommandLoader UpdateCommand { get; set; }
        //this method will return the string of the Delete method of the Powershell Item
        //example "delete-service","delete-adfsrelyingParty"
        CommandLoader DeleteCommand { get; set; }
        //this method will return the string of the Create method of the Powershell Item
        //example "Create-service","Create-adfsrelyingParty"
        CommandLoader CreateCommand { get; set; }

        CommandLoader GetCommand  { get; set; }
        
        CommandLoader GetItemsCommand { get; set; }
    }
}
