using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGWP.Models.Templates
{
    public class IndexList
    {
        public List<Property> _properties { get; }
        public IndexList()
        {
            _properties = new List<Property>();
        }

        public void Add(Property p)
        {
            _properties.Add(p);
        }

        public String this[String propertyName]
        {
            get { return _properties.FirstOrDefault(x => x.Name == propertyName)?.Value; }
        }
    }
}
