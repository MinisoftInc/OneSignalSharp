using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalSharp.Posting
{
    public class Segmant
    {
        public enum Users
        {
            Active_Users,
            Inactive_Users,
            All,
            Engaged_Users
        }
        private List<string> included_segments = new List<string>();
        private List<string> excluded_segments = new List<string>();

        
        internal void PopulateDynamicObject(IDictionary<String,Object> dynObject)
        {
            if (included_segments.Intersect(excluded_segments).Count() > 0)
            {
                throw new Exception("A value can't exist in both excluded segmant and included segmant");
            }

            if (included_segments.Count >0)
                dynObject.Add("included_segments", included_segments);
            if (excluded_segments.Count > 0)
                dynObject.Add("excluded_segments", excluded_segments);


        }
        /// <summary>
        /// Add a Segmant to included data
        /// </summary>
        /// <param name="segmant">a system defiend segmant</param>
        public void IncludeSegmant(Users segmant) {
            if (!included_segments.Contains(segmant.ToString()))
            {
                included_segments.Add(segmant.ToString());
            }
        }
        /// <summary>
        /// Add a Segmant to included data
        /// </summary>
        /// <param name="customsegmant">a user defined segmant</param>
        public void IncludeSegmant(string customsegmant)
        {
            if (!included_segments.Contains(customsegmant))
            {
                included_segments.Add(customsegmant);
            }
        }
        /// <summary>
        /// Add a Segmant to excluded data
        /// </summary>
        /// <param name="segmant">a system defiend segmant</param>

        public void ExcludeSegmant(Users segmant)
        {
            if (!excluded_segments.Contains(segmant.ToString()))
            {
                excluded_segments.Add(segmant.ToString());
            }
        }
        /// <summary>
        /// Add a Segmant to excluded data
        /// </summary>
        /// <param name="customsegmant">a user defined segmant</param>
        public void ExcludeSegmant(string customsegmant)
        {
            if (!excluded_segments.Contains(customsegmant))
            {
                excluded_segments.Add(customsegmant);
            }
        }

   
    }
}
