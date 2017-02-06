using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalSharp.Posting
{
    public class Buttons
    {
        private List<ActionButton> buttons = null;
        private List<WebButton> web_buttons = null;
        private string ios_category = null;
        /// <summary>
        /// Adding buttons to the notifications. Works on iOS 8.0+, ANDROID 4.1+
        /// </summary>
        /// <param name="Buttons">List of Buttons to add to the notification. Icon only works for Android.</param>
        public Buttons(List<ActionButton> Buttons)
        {
            this.buttons = Buttons;
        }
        /// <summary>
        /// We notifications works on CHROME 48+
        /// </summary>
        /// <param name="WebButtons">Add action buttons to the notification</param>
        public Buttons(List<WebButton> WebButtons)
        {
            this.web_buttons = WebButtons;
        }
        /// <summary>
        /// Category APS payload, use with registerUserNotificationSettings:categories in your Objective-C / Swift code.
        /// </summary>
        /// <param name="iOSCategory">Example: calendar category which contains actions like accept and decline iOS 10+ This will trigger your UNNotificationContentExtension whose ID matches this category.</param>
        public Buttons(string iOSCategory)
        {
            this.ios_category = iOSCategory;
        }
        internal void PopulateDynamicObject(IDictionary<String, Object> dynObject)
        {


            if (buttons != null)
                dynObject.Add("data", buttons);
            if (web_buttons != null)
                dynObject.Add("headings", web_buttons);
            if (ios_category != null)
                dynObject.Add("subtitle", ios_category);

        }
    }
    public class ActionButton
    {
        public string Id { get; set; }
        public string text { get; set; }
        public string icon { get; set; }

    }
    public class WebButton
    {
        public string Id { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public string url { get; set; }
    }

}
