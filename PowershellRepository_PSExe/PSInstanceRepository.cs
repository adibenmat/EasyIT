using PowershellRepository.Interface;
using PowershellRepository.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ParseAndReflectionMethods;


namespace PowershellRepository.PSInstance
{
    public class PSInstanceRepository : IPowershellRepository
    {
        public string ModelFQDN { get; set; }

        public PSInstanceRepository(string modelFqdn)
        {
            this.ModelFQDN = modelFqdn;
        }
        //TODO://GET This class from a web config       
      ReflectionHelper reflecInsance = new ReflectionHelper();        

        public IEnumerable<IPowershellItem> GetPowershellItemsEnumerable()
         {            
            PowershellExecute psExecute = new PowershellExecute();
            IPowershellItem psItemInstance = reflecInsance.GetInstanceFromFQDN(this.ModelFQDN) as IPowershellItem;            
            var psresult = psExecute.InokePipeline(psItemInstance.GetItemsCommand.GetCommandString());
            foreach(var psitem in psresult.Result)
            {
                var tempPowershellItem = reflecInsance.GetInstanceFromFQDN(this.ModelFQDN);

                foreach (var propertyName in reflecInsance.GetObjectPropertiesNamesNotFromInterface(psItemInstance, typeof(IPowershellItem)))
                {
                   reflecInsance.AddValueToObjectByPropertyName(ref tempPowershellItem, psitem.Properties[propertyName].Value.ToString(), propertyName);                    
                }
                yield return (IPowershellItem)tempPowershellItem;
            }

        }



        /* trying to create IsPropertyIsPartOfASpecifiedInterfaceOfAnObject
        //this method check if a propertyName is part of a specified interface that object obj is implements
        //Use this method cautiously, there is some hidden interfaces implementation too
        //could split this method to 2 parts but GetType().IsInterface don's always works
        private bool IsPropertyIsPartOfASpecifiedInterfaceOfAnObject(object obj,string propertyName,params string[] interfacesName)
        {
            if (interfacesName != null)
            {   
                //Gets interfacesName to check theirs Properties
                foreach (var interfaceName in interfacesName)
                {
                    foreach (var interfaceInstance in obj.GetType().GetInterfaces())
                    {   //check if obj implements the specified interface                     
                        if (interfaceInstance.Name.Contains(interfaceName))
                        {
                            //check if the specified propertyname is part of the interface properties
                            foreach (var interfaceProperty in interfaceInstance.GetType().GetProperties())
                            {
                                if (propertyName.Equals(interfaceProperty.Name))
                                {
                                    return true;
                                }
                            }                
                        }

                    }
                }
            }
         
            return false;
        }
        */
        
        
        public IPowershellItem GetPowershellItem(string targetIdentifier)
        {
            PowershellExecute psExecute = new PowershellExecute();
            IPowershellItem psItemInstance = reflecInsance.GetInstanceFromFQDN(this.ModelFQDN) as IPowershellItem;            
            var command = psItemInstance.GetCommand;
            command.AddParameter(new Parameter(psItemInstance.IdentifierProperty,targetIdentifier));
            var psresult = psExecute.InokePipeline(command.GetCommandString());
            foreach (var psitem in psresult.Result)
            {
                var tempPowershellItem = reflecInsance.GetInstanceFromFQDN(this.ModelFQDN);
                object obj = new object();

                foreach (var propertyName in reflecInsance.GetObjectPropertiesNamesNotFromInterface(psItemInstance, typeof(IPowershellItem)))
                {                    
                    reflecInsance.AddValueToObjectByPropertyName(ref tempPowershellItem, psitem.Properties[propertyName].Value.ToString(), propertyName);
                }

                 return (IPowershellItem)tempPowershellItem;
            }
            return null;
        }

        public void AddPowershelItem(IPowershellItem item)
        {
                throw new NotImplementedException();
        }

        public void UpdatePowershellItem(string targetIdentifier, IPowershellItem updatedItem)
        {
            throw new NotImplementedException();
        }

        public void DeletePowershelItem(string targetIdentifier)
        {
            throw new NotImplementedException();
        }

        public void UpdatePowershelItemsEnumerable(IEnumerable<IPowershellItem> updatedPowershellItems)
        {
            throw new NotImplementedException();
        }
    }
}
