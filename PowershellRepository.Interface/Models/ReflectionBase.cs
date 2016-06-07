using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PowershellRepository.Interface.Models
{
    public class ReflectionBase
    {
        public Dictionary<string, string> GetBasePropertiesDictionary()
        {
            
            Dictionary<string, string> json = new Dictionary<string, string>();
            foreach (var propertyName in GetObjectPropertiesNamesNotFromInterface(this, this.GetType().GetInterfaces()))
            {
                object propertyValue = this.GetType().GetProperty(propertyName).GetValue(this);
                json.Add(propertyName, propertyValue != null ? propertyValue.ToString() : "");
            }

            return json;
        }

        public IEnumerable<CommandLoader> GetCommands()
        {

            Dictionary<string, string> json = new Dictionary<string, string>();
            var properties = this.GetType().GetProperties();
            foreach (var property in properties.Where(prop => prop.GetType() == typeof(CommandLoader)))
            {
                yield return property.GetValue(this) as CommandLoader;

            }
                        
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
        
    }
}
