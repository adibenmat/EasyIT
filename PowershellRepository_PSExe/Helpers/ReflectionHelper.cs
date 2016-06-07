using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PowershellRepository.PSInstace.Helpers
{
    public class ReflectionHelper
    {

       public ReflectionHelper()
        {                
        }
        
        public IEnumerable<string> GetObjectPropertiesNamesNotFromInterface(object obj, params Type[] interfacesTypes)
        {
            if (interfacesTypes != null)
            {
                foreach (var interfaceType in interfacesTypes)
                {
                    foreach (var objProperty in obj.GetType().GetProperties())
                    {
                        if (!IsPropertyInInterface(objProperty, interfaceType))
                            yield return objProperty.Name;
                    }

                }
            }
        }

        public bool IsPropertyInInterface(PropertyInfo propertyInfo, Type interfaceType)
        {
            foreach (var interfaceProperty in interfaceType.GetProperties())
            {
                if (propertyInfo.Name.Equals(interfaceProperty.Name))
                    return true;
            }
            return false;
        }

        public object GetInstanceFromFQDN(string fqdnClass)
        {         
            Type itemType = Type.GetType(fqdnClass);
            var itemInstance = Activator.CreateInstance(itemType);
            return itemInstance;
        }

        public void AddValueToObjectByPropertyName(ref object obj, object value, string propertyName)
        {            
            var propertyInfo = obj.GetType().GetProperty(propertyName);
            propertyInfo.SetValue(obj, value, null);
        }
    }
}
