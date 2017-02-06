using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalSharp.Posting
{
    public class Filter
    {
        List<object> Data = new List<object>();

        /// <summary>
        /// Add a filter to the object based on the official documentation
        /// </summary>
        /// <param name="operation"> an object with the right attributes</param>
        public void AddFilter(object operation)
        {
            Data.Add(operation);
        }
        internal void PopulateDynamicObject(IDictionary<String, Object> dynObject)
        {
            dynObject.Add("filters", this.Data);
        }
    }
   
}
