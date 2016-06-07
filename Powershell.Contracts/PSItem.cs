using System.Runtime.Serialization;

namespace Powershell.Contracts
{
    [DataContract]
    public class PSItem
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string TypeName { get; set; }

        public PSItem(string name, string displayName, string status,string typeName)
        {
            Name = name;
            DisplayName = displayName;
            Status = status;
            TypeName = typeName;
        }

        public PSItem()
        {
        }
    }
    
}