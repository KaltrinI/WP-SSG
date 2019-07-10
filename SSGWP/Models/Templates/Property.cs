using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGWP.Models.Templates
{
    public class Property
    {
        public Property(String name, PropertyType type, String value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
        public String Name { get; set; }
        public PropertyType Type { get; set; }
        public String Value { get; set; }
    }
}
