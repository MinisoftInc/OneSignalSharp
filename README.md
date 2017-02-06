# One Signal Sharp

One Signal Sharp is a software library which aims to simplify the operations on OneSignal.com in Asp.net Server.

### Dependencies :-
  - Newtonsoft.Json

### You can use it to:
  - Customize the notification style
  - Send notification to a specific Segmant.
  - Send notification based on a specific filter.
  - Send notification based to a list of users.
  - Controll the apps on your account
  - Get the statistics of your notifications
  - Export all your data to a CSV File
### How to :
  - Refrenece the dll in your project.
  -  In most cases you will work with an existing app so create a new app in your account. Here is a [refrence]( https://documentation.onesignal.com/docs/mobile-sdk-setup)
  -  Initialize a OneSignalClient Object
  - All function are based on this [documentation](https://documentation.onesignal.com/reference)
```
  OneSignalClient client = new OneSignalClient(
                "YOU APP ID",
                "APP REST KEY ",
                "USER AUTH");
```
-  - APP ID & REST API Key: can be found at App Settings -> Key & Ids
   - User Auth: Can be found at User Settings -> Key & Ids

## An Example to send a notification based on Segmants
```
 Segmant segmant = new Segmant();
            segmant.IncludeSegmant(Segmant.Users.All);
            Dictionary<string, string> contentMsgs = new Dictionary<string, string>();
            contentMsgs.Add("en", "Hello World !");
            contentMsgs.Add("ar", "مرحبا بالعالم !");
            ContentAndLanguage content = new ContentAndLanguage(contentMsgs);           
            client.SendNotification(segmant, content, null, null);
```
### Todos

 - Write Tests
 - Parse server response as an object
 - Add Support for Tweet Appearance
 - Add Support for a specific delivery
 - Add Support for Grouping & Collapsing
 - Add Support to deliver to a specific platform
 
### License
MIT



