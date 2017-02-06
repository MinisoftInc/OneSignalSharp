using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalSharp.Posting
{
    public class Device
    {
        private HashSet<string> include_player_ids = new HashSet<string>();
     
        /// <param name="Ids">a Hashset contains the recpients Ids</param>
        public Device(HashSet<string> Ids)
        {
            if (Ids == null || Ids.Count == 0)
                throw new Exception("List can't be empty");
            if (Ids.Count > 2000)
                throw new Exception("Maximum is 2000");
            include_player_ids = Ids;
            
        }
        internal void PopulateDynamicObject(IDictionary<String, Object> dynObject)
        {
            dynObject.Add("include_player_ids", include_player_ids);
        }
    }
}
