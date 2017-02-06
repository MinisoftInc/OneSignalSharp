using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalSharp.AppModels
{
    public class AppBodyParamters
    {
        public AppBodyParamters(string Name)
        {
            this.name = Name;

        }
        public string name { get; set; }
        //IOS Paramters
        public string apns_env { get; set; } = null;
        public string apns_p12 { get; set; } = null;
        public string apns_p12_password { get; set; } = null;
        //GCM
        public string gcm_key { get; set; } = null;
        public string android_gcm_sender_id { get; set; } = null;
        //Chrome
        public string chrome_web_origin { get; set; } = null;
        public string chrome_web_default_notification_icon { get; set; } = null;
        public string chrome_web_sub_domain { get; set; } = null;
        //Safari Paramters
        public string safari_apns_p12 { get; set; } = null;
        public string safari_apns_p12_password { get; set; } = null;
        public string site_name { get; set; } = null;
        public string safari_site_origin { get; set; } = null;
        public string safari_icon_256_256 { get; set; } = null;
        //Chrome Key
        public string chrome_key { get; set; } = null;

        internal void PopulateDynamicObject(IDictionary<String, Object> dynObject) {

            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop.GetValue(this, null) != null)
                {
                    dynObject.Add(prop.Name, prop.GetValue(this, null));
                }
            }
        }

    }
}
