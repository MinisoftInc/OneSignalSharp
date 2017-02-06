using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalSharp.Posting
{
    public class ContentAndLanguage
    {
        public readonly Dictionary<string, string> contents = null;
        public readonly Dictionary<string, string> headings = null;
        public readonly Dictionary<string, string> subtitle = null;
        public readonly string template_id = null;
        public readonly bool content_available = false;
        public readonly bool mutable_content = false;
        internal void PopulateDynamicObject(IDictionary<String, Object> dynObject)
        {


            if (contents != null)
                dynObject.Add("contents", contents);
            if (headings != null)
                dynObject.Add("headings", headings);
            if (subtitle != null)
                dynObject.Add("subtitle", subtitle);
            if (template_id != null)
                dynObject.Add("template_id", template_id);
            if (!content_available)
                dynObject.Add("subtitle", subtitle);


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Contents">The notification's content (excluding the title), a map of language codes to text for each language using a dictionary.</param>
        public ContentAndLanguage(Dictionary<string, string> Contents)
        {
            this.contents = Contents;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Contents">The notification's content (excluding the title), a map of language codes to text for each language using a dictionary.</param>
        /// <param name="Heading">The notification's title, a map of language codes to text for each language using dictionary</param>
        /// <param name="Subtitle">The notification's subtitle, a map of language codes to text for each language. </param>
        /// <param name="Mutable_content">Only ON iOS ,Sending true allows you to change the notification content in your app before it is displayed. </param>
        public ContentAndLanguage(Dictionary<string, string> Contents,
            Dictionary<string, string> Heading,
            Dictionary<string, string> Subtitle,
            bool Mutable_content)
        {
            this.contents = Contents;
            this.headings = Heading;
            this.subtitle = Subtitle;
            this.mutable_content = Mutable_content;

        }
        /// <param name="ContentAvailabe">IOS Only Sending true wakes your app to run custom native code (Apple interprets this as content-available=1). Omit contents field to make notification silent.</param>
        /// <param name="Heading">The notification's title, a map of language codes to text for each language using dictionary</param>
        /// <param name="Subtitle">The notification's subtitle, a map of language codes to text for each language. </param>
        /// <param name="Mutable_content">Only ON iOS ,Sending true allows you to change the notification content in your app before it is displayed. </param>
        public ContentAndLanguage(bool ContentAvailabe,
           Dictionary<string, string> Heading,
           Dictionary<string, string> Subtitle,
           bool Mutable_content)
        {
            this.content_available = ContentAvailabe;
            this.headings = Heading;
            this.subtitle = Subtitle;
            this.mutable_content = Mutable_content;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TemplateId">Use a template you setup on our dashboard. You can override the template values by sending other parameters with the request.</param>
        /// <param name="Heading">The notification's title, a map of language codes to text for each language using dictionary</param>
        /// <param name="Subtitle">The notification's subtitle, a map of language codes to text for each language. </param>
        /// <param name="Mutable_content">Only ON iOS ,Sending true allows you to change the notification content in your app before it is displayed. </param>
        public ContentAndLanguage(string TemplateId,
         Dictionary<string, string> Heading,
         Dictionary<string, string> Subtitle,
         bool Mutable_content)
        {
            this.template_id = TemplateId;
            this.headings = Heading;
            this.subtitle = Subtitle;
            this.mutable_content = Mutable_content;
        }

    }
}
