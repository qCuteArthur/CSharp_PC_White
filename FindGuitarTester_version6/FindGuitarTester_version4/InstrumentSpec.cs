using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version5
{
    class InstrumentSpec
    {
        private Dictionary<string,object> properties;

        public InstrumentSpec(Dictionary<string, object> properties)
        {
            this.properties = properties;
        }
        public object getProperty(string propertyName)
        {
            if(this.properties.ContainsKey(propertyName))
                return this.properties[propertyName];
            else
                return null;      
        }

        public Dictionary<string, object> getProperties()
        {
            return this.properties;
        }

        public bool matches(InstrumentSpec otherSpec)
        {
            Dictionary<string, object> otherProperties = otherSpec.getProperties();
            foreach (string key in otherProperties.Keys)
            {
                if (this.properties.ContainsKey(key))
                {
                    if (!this.properties[key].Equals(otherProperties[key]))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
