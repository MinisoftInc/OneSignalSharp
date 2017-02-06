using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using OneSignalSharp.Posting;
using System.Dynamic;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using OneSignalSharp.AppModels;

namespace OneSignalSharp
{
    public class OneSignalClient
    {
        //TODO : Add Appearance
        //TODO : Add Delivery
        //TODO : Add Grouping & Collapsing
        //TODO : Add Platform to Deliver To

        private readonly string _app_id; // Application ID
        private readonly string _rest_api_key; //Your Rest Api Code
        private readonly string _user_auth; // Your User Auth


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId">Your application id which can be found at Keys & Ids at App Setting</param>
        /// <param name="restKey">Your Rest Key which can be found at Keys & Ids at App Setting</param>
        /// <param name="userAuth">Your User Auth Key which can be found at user setting</param>
        public OneSignalClient(string appId, string restKey, string userAuth)
        {
            this._app_id = appId;
            this._rest_api_key = restKey;
            this._user_auth = userAuth;
        }
        //Send notifications 
        /// <summary>
        /// The method can be used to send a notification to a specific segment
        /// </summary>
        /// <param name="segmant">a segmant object which represents the recipient (Required)</param>
        /// <param name="content">a Content object which represet the content of the notifications (Required)</param>
        /// <param name="attachment">an attachment object which describe the attachments of the notifications</param>
        /// <param name="actionButton">an ActionButton which represent the buttons of the notifications</param>
        /// <returns>the server response</returns>
        public string SendNotification(Segmant segmant, ContentAndLanguage content,
            Attachment attachment, Buttons actionButton)
        {
            var dynObject = new ExpandoObject() as IDictionary<String, Object>;
            dynObject.Add("app_id", _app_id);

            //Gather the data into one object


            //Segment
            if (segmant != null)
                segmant.PopulateDynamicObject(dynObject);
            else
                throw new Exception("Segmant can't be null");
            //Content and Language
            if (content != null)
                content.PopulateDynamicObject(dynObject);
            else
                throw new Exception("Content can't be null");
            //Content and Language
            if (attachment != null)
                attachment.PopulateDynamicObject(dynObject);
            //Content and Language
            if (actionButton != null)
                actionButton.PopulateDynamicObject(dynObject);

            string Link = "https://onesignal.com/api/v1/notifications";
            string Method = "POST";

            return SendRequest(Link, Method, _rest_api_key, dynObject);


        }



        /// <summary>
        /// The method can be used to send a notification based on a specific filter
        /// </summary>
        /// <param name="filter">a filter object which contains the expressions</param>
        /// <param name="content">a Content object which represet the content of the notifications (Required)</param>
        /// <param name="attachment">an attachment object which describe the attachments of the notifications</param>
        /// <param name="actionButton">an ActionButton which represent the buttons of the notifications</param>
        /// <returns>the server response</returns>
        public string SendNotification(Filter filter, ContentAndLanguage content,
           Attachment attachment, Buttons actionButton)
        {
            var dynObject = new ExpandoObject() as IDictionary<String, Object>;
            dynObject.Add("app_id", _app_id);

            //Gather the data into one object


            //Segment
            if (filter != null)
                filter.PopulateDynamicObject(dynObject);
            else
                throw new Exception("Filter can't be null");
            //Content and Language
            if (content != null)
                content.PopulateDynamicObject(dynObject);
            else
                throw new Exception("Content can't be null");
            //Content and Language
            if (attachment != null)
                attachment.PopulateDynamicObject(dynObject);
            //Content and Language
            if (actionButton != null)
                actionButton.PopulateDynamicObject(dynObject);

            string Link = "https://onesignal.com/api/v1/notifications";
            string Method = "POST";

            return SendRequest(Link, Method, _rest_api_key, dynObject);


        }



        /// <summary>
        /// The method can be used to send a notification to a specific list of devices
        /// </summary>
        /// <param name="devices">a Device object which contains the list of recepient</param>
        /// <param name="content">a Content object which represet the content of the notifications (Required)</param>
        /// <param name="attachment">an attachment object which describe the attachments of the notifications</param>
        /// <param name="actionButton">an ActionButton which represent the buttons of the notifications</param>
        /// <returns>the server response</returns>
        public string SendNotification(Device devices, ContentAndLanguage content,
                   Attachment attachment, Buttons actionButton)
        {
            var dynObject = new ExpandoObject() as IDictionary<String, Object>;
            dynObject.Add("app_id", _app_id);

            //Gather the data into one object


            //Segment
            if (devices != null)
                devices.PopulateDynamicObject(dynObject);
            else
                throw new Exception("Devices can't be null");
            //Content and Language
            if (content != null)
                content.PopulateDynamicObject(dynObject);
            else
                throw new Exception("Content can't be null");
            //Content and Language
            if (attachment != null)
                attachment.PopulateDynamicObject(dynObject);
            //Content and Language
            if (actionButton != null)
                actionButton.PopulateDynamicObject(dynObject);

            string Link = "https://onesignal.com/api/v1/notifications";
            string Method = "POST";

            return SendRequest(Link, Method, _rest_api_key, dynObject);


        }


        private string SendRequest(string Link, string Method, string AuthorizationCode, IDictionary<String, Object> dynObject)
        {
            var request = WebRequest.Create(Link) as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = Method;
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic " + AuthorizationCode);
            string responseContent = null;

            var param = JsonConvert.SerializeObject(dynObject);
            byte[] byteArray = Encoding.UTF8.GetBytes(param);
            using (var writer = request.GetRequestStream())
            {
                writer.Write(byteArray, 0, byteArray.Length);
            }

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();
                }
            }
            return responseContent;
        }
        private string SendRequest(string Link, string Method, string AuthorizationCode)
        {
            var request = WebRequest.Create(Link) as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = Method;
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic " + AuthorizationCode);

            string responseContent = null;



            using (var response = request.GetResponse() as HttpWebResponse)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();
                }
            }
            return responseContent;
        }
        //Delete Notifications
        /// <summary>
        /// Cancel a specific notification
        /// </summary>
        /// <param name="NotificationId">Notification Id</param>
        /// <returns>the server response</returns>
        public string CancelNotifications(string NotificationId)
        {
            string Link = $"https://onesignal.com/api/v1/{NotificationId}?app_id={_app_id}";
            string Method = "Delete";
            return SendRequest(Link, Method, _rest_api_key);
        }
        /// <summary>
        /// Get all the apps in your account
        /// </summary>
        /// <returns>The server response</returns>
        public string ViewAllApps()
        {
            string Link = "https://onesignal.com/api/v1/apps";
            string Method = "GET";
            return SendRequest(Link, Method, _user_auth);
        }
        /// <summary>
        ///View a specific app in your account
        /// </summary>
        /// <param name="Id">App Id</param>
        /// <returns>The server response</returns>
        public string ViewApp(string Id)
        {
            string Link = "https://onesignal.com/api/v1/apps/" + Id;
            string Method = "GET";
            return SendRequest(Link, Method, _user_auth);
        }
        /// <summary>
        /// Create an Application
        /// </summary>
        /// <param name="body">a Body object represents the information of the application</param>
        /// <returns>The server response</returns>
        public string CreateAnApp(AppBodyParamters body)
        {
            var dynObject = new ExpandoObject() as IDictionary<String, Object>;
            body.PopulateDynamicObject(dynObject);
            string Method = "POST";
            string Link = "https://onesignal.com/api/v1/apps";
            return SendRequest(Link, Method, _user_auth, dynObject);
        }
        /// <summary>
        /// Updates the info of the Application
        /// </summary>
        /// <param name="Id">Application Id</param>
        /// <param name="body">New Info</param>
        /// <returns>The server response</returns>
        public string UpdateAnApp(string Id, AppBodyParamters body)
        {
            var dynObject = new ExpandoObject() as IDictionary<String, Object>;
            body.PopulateDynamicObject(dynObject);
            string Method = "POST";
            string Link = "https://onesignal.com/api/v1/apps/" + Id;
            return SendRequest(Link, Method, _user_auth, dynObject);
        }
        /// <summary>
        /// View All the devices of the application
        /// </summary>
        /// <param name="limit">The limit per response (Max is 300)</param>
        /// <param name="offset">the offset (Default is 0)</param>
        /// <returns>Server response</returns>
        public string ViewDevices(string limit = "300", string offset = "0")
        {
            string Link = $"https://onesignal.com/api/v1/players?app_id={_app_id}&limit={limit}&offset={offset}";
            string Method = "GET";
            return SendRequest(Link, Method, _rest_api_key);
        }
        /// <summary>
        /// View a device data
        /// </summary>
        /// <param name="Id">The Device Id</param>
        /// <returns>Server response</returns>
        public string ViewDevice(string Id, bool UseAppID)
        {
            string Link = "https://onesignal.com/api/v1/players/" + Id;
            if (UseAppID)
                Link += "?app_id=" + _app_id;
            string Method = "GET";
            return SendRequest(Link, Method, _rest_api_key);


        }
        /// <summary>
        /// Expoert all the users data to a CSV file
        /// </summary>
        /// <param name="extra_fields">Additional fields that you wish to include. Currently supports location, country, and rooted.</param>
        /// <returns>Server Response</returns>
        public string CSVExport(params string[] extra_fields)
        {
            string Link = "https://onesignal.com/api/v1/players/csv_export?app_id=" + _app_id;
            string Method = "POST";
            var body = new Dictionary<string, object>();
            body.Add("extra_fields", extra_fields);
            return SendRequest(Link, Method, _rest_api_key, body);

        }
        /// <summary>
        /// View the details of a single notification
        /// </summary>
        /// <param name="NotificationId"> Notification ID</param>
        /// <returns>Server Response</returns>
        public string ViewNotification(string NotificationId)
        {
            string Link = $"https://onesignal.com/api/v1/notifications/{NotificationId}?app_id={_app_id}";
            string Method = "GET";
            return SendRequest(Link, Method, _user_auth);
        }
        /// <summary>
        /// View the details of multiple notifications
        /// </summary>
        /// <param name="limit">How many notifications to return. Max is 50. Default is 50</param>
        /// <param name="offset">Result offset. Default is 0. Results are sorted by queued_at in descending order. queued_at is the unixtime representation of the time that the notification was queued.</param>
        /// <returns></returns>
        public string ViewNotifications(string limit = "50", string offset = "0")
        {
            string Link = $"https://onesignal.com/api/v1/notifications?app_id={_app_id}&limit={limit}&offset={offset}";
            string Method = "GET";
            return SendRequest(Link, Method, _rest_api_key);
        }
    }


}

