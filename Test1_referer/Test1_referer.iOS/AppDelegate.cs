using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.DynamicLinks;
using Foundation;
using Java.Util.Logging;
using Test1_referer.iOS;
using UIKit;
using Xamarin.Essentials;
 
namespace Test1_referer.iOS
{

    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
       
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            Firebase.Core.App.Configure();
            return base.FinishedLaunching(app, options);
        }



    

  public override bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
        {
            Console.WriteLine("Error 2");

            return DynamicLinks.SharedInstance.HandleUniversalLink(userActivity.WebPageUrl, (dynamicLink, error) => {
                try
                {
                    if (error != null)
                    {
                    
                        Console.WriteLine( "Error while getting dynamic link.");
                        return;
                    }

                    var dinamicLinks = dynamicLink.Url.ToString();
                var utm_param =    dynamicLink.UtmParametersDictionary;

                



                }
                catch (Exception e)
                {
                    Console.WriteLine("Error while handeling URL callback in appdelegate."+ e);  
                }
            });
        }

        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            var dynamicLink = DynamicLinks.SharedInstance?.FromCustomSchemeUrl(url);

            if (dynamicLink == null)
                return false;

            Console.WriteLine("Error 1" );

            if (url != null)
            {
                NSUrlComponents urlComponents = new NSUrlComponents(url, false);

                string sberpay = "";
                NSUrlQueryItem[] allItems = urlComponents.QueryItems;
                foreach (NSUrlQueryItem item in allItems)
                {
                    if (item.Name == "utm_source")
                    {
                        string utm_source = "";
                        utm_source = item.Value;
                        Preferences.Set("utm_source", utm_source);
                    }

                    if (item.Name == "utm_medium")
                    {
                        string utm_medium = "";
                        utm_medium = item.Value;
                        Preferences.Set("utm_medium", utm_medium);
                    }
                    if (item.Name == "utm_campaign")
                    {
                        string utm_campaign = "";
                        utm_campaign = item.Value;
                        Preferences.Set("utm_campaign", utm_campaign);
                    }
                    if (item.Name == "utm_content")
                    {
                        string utm_content = "";
                        utm_content = item.Value;
                        Preferences.Set("utm_content", utm_content);
                    }
                    if (item.Name == "utm_term")
                    {
                        string utm_term = "";
                        utm_term = item.Value;
                        Preferences.Set("utm_term", utm_term);
                    }

                }


            }

            return true;
        }


    }





}

