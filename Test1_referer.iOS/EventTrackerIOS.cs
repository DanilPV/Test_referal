using System;
using Foundation;
using System.Collections.Generic;
using Test1_referer.iOS;
using Xamarin.Forms;
using Firebase.Analytics;
[assembly: Dependency(typeof(EventTrackerIOS))]
namespace Test1_referer.iOS
{

    public class EventTrackerIOS : IEventTracker
    {
        public void SendEvent(string eventId)
        {
            Console.WriteLine($"Firebase 1:  ");
            SendEvent(eventId, (IDictionary<string, string>)null);
        }

        public void SendEvent(string eventId, string paramName, string value)
        {
            Console.WriteLine($"Firebase 2:  " + paramName);
            SendEvent(eventId, new Dictionary<string, string>
            {
                { paramName, value }
            
        });
        }

        public void SendEvent(string eventId, IDictionary<string, string> parameters)
        {
            Console.WriteLine($"Firebase 3:  ");
            if (parameters == null)
            {
                Analytics.LogEvent(eventId, (Dictionary<object, object>)null);
                return;
            }

            var keys = new List<NSString>();
            var values = new List<NSString>();
            foreach (var item in parameters)
            {
                keys.Add(new NSString(item.Key));
                Console.WriteLine($"Firebase 3:  "+ item.Key);
                values.Add(new NSString(item.Value));
            }

            var parametersDictionary =
                NSDictionary<NSString, NSObject>.FromObjectsAndKeys(values.ToArray(), keys.ToArray(), keys.Count);
            Analytics.LogEvent(eventId, parametersDictionary);
        }
    }
}

