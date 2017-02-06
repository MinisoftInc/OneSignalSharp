using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalSharp.Posting
{
    public class Attachment
    {
        public Dictionary<string, string> data { get; set; } = null;
        public string url { get; set; } = null;
        public Dictionary<string, string> ios_attachments { get; set; } = null;
        public string big_picture { get; set; } = null;

        public string adm_big_picture { get; set; } = null;

        public string chrome_big_picture { get; set; } = null;
        internal void PopulateDynamicObject(IDictionary<String, Object> dynObject)
        {


            if (data != null)
                dynObject.Add("data", data);
            if (url != null)
                dynObject.Add("headings", url);
            if (big_picture != null)
                dynObject.Add("subtitle", big_picture);
            if (adm_big_picture != null)
                dynObject.Add("template_id", adm_big_picture);
            if (adm_big_picture != null)
                dynObject.Add("chrome_big_picture", chrome_big_picture);

        }

    }
}
