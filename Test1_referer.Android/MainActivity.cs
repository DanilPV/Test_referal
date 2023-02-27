using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.Collections.Generic;
using Xamarin.Forms;
using Test1_referer.Droid;
using Firebase.Analytics;
using Xamarin.Essentials;
using Firebase.DynamicLinks;
 
using Android.Content;
using Android.Gms.Extensions;
using System.Threading.Tasks;

namespace Test1_referer.Droid
{
    [Activity( Label = "Test1_referer", Icon = "@mipmap/icon", Theme = "@style/MainTheme",
        Exported =true,MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]


    [IntentFilter(new[]
        {
            Intent.ActionView
        },
        Categories = new[]
        {
            Intent.CategoryBrowsable,
            Intent.CategoryDefault
        },
        DataScheme = "https",
        DataHost = "test1odev.page.link")]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Preferences.Clear();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Firebase.FirebaseApp.InitializeApp(Android.App.Application.Context);
            LoadApplication(new App());
            await HandleDynamicLink(Intent);
        



        }

        async Task HandleDynamicLink(Intent intent)
        {
            var result = await FirebaseDynamicLinks.Instance.GetDynamicLink(intent);
            if (result != null)
            {
                var dynamicLink = (PendingDynamicLinkData)result;
                var deepLink = dynamicLink.Link;
                var utm_deepLink = dynamicLink.UtmParameters;
                if (deepLink != null)
                {
                    Console.WriteLine($"Deeplink {deepLink}");

                    var link_utm_source = deepLink.GetQueryParameter("utm_source");
                    Console.WriteLine("link_utm_source=" + link_utm_source);
                    Preferences.Set("link_utm_source", link_utm_source);

                    var link_utm_medium = deepLink.GetQueryParameter("utm_medium");
                    Console.WriteLine("link_utm_medium=" + link_utm_medium);
                    Preferences.Set("link_utm_medium", link_utm_medium);

                    var link_utm_campaign = deepLink.GetQueryParameter("utm_campaign");
                    Console.WriteLine("link_utm_campaign=" + link_utm_campaign);
                    Preferences.Set("link_utm_campaign", link_utm_campaign);

                    var link_utm_content = deepLink.GetQueryParameter("utm_content");
                    Console.WriteLine("link_utm_content=" + link_utm_content);
                    Preferences.Set("link_utm_content", link_utm_content);


                    var link_utm_term = deepLink.GetQueryParameter("utm_term");
                    Console.WriteLine("link_utm_term=" + link_utm_term);
                    Preferences.Set("link_utm_term", link_utm_term);

                    var utm_source = utm_deepLink.Get("utm_source");
                    Console.WriteLine("utm_source=" + utm_source);
                    Preferences.Set("utm_source", utm_source.ToString());

                    var utm_medium = utm_deepLink.Get("utm_medium");
                    Console.WriteLine("utm_medium=" + utm_medium);
                    Preferences.Set("utm_medium", utm_medium.ToString());

                    var utm_campaign = utm_deepLink.Get("utm_campaign");
                    Console.WriteLine("utm_campaign=" + utm_campaign);
                    Preferences.Set("utm_campaign", utm_campaign.ToString());

                    if (utm_deepLink.ContainsKey("utm_content"))
                    {
                        var utm_content = utm_deepLink.Get("utm_content");
                        Console.WriteLine("utm_content=" + utm_content);
                        Preferences.Set("utm_content", utm_content.ToString());
                    }
                    if (utm_deepLink.ContainsKey("utm_term"))
                    {
                        var utm_term = utm_deepLink.Get("utm_term");
                        Console.WriteLine("utm_term=" + utm_term);
                        Preferences.Set("utm_term", utm_term.ToString());
                    }

                   
                }
            }
        }


       




        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }





    
}