using System.Runtime.Serialization;

namespace Common.Models
{
    [DataContract]
    public class Parameter
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public bool IsRequired { get; set; }


        public Parameter(string name)
        {
            Name = name;
            Value = null;
            IsRequired = false;
        }
        public Parameter(string name,bool isRequired)
        {
            Name = name;
            Value = null;
            IsRequired = isRequired;
        }
        public Parameter(string name,string value)
        {
            Name = name;
            Value = value;
            IsRequired = false;
        }
        public Parameter(string name, string value,bool isRequired)
        {
            Name = name;
            Value = value;
            IsRequired = isRequired;
        }

    }
}
