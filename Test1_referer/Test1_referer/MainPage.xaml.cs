using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Test1_referer
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        IEventTracker eventTracker;

        public MainPage()
        {
            InitializeComponent();
           
            eventTracker = DependencyService.Get<IEventTracker>();


    
        }


            void Refresh_utm (System.Object sender, System.EventArgs e)
        {
            utm_source.Text = "utm_source=" + Preferences.Get("utm_source", "0");
            utm_medium.Text = "utm_medium=" + Preferences.Get("utm_medium", "0");
            utm_campaign.Text = "utm_campaign=" + Preferences.Get("utm_campaign", "0");
            utm_content.Text = "utm_content=" + Preferences.Get("utm_content", "0");
            utm_term.Text = "utm_term=" + Preferences.Get("utm_term", "0");
        }
    }


}