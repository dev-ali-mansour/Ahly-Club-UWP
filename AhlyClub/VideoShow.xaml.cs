using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AhlyClub
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VideoShow : Page
    {
        string StrHeight;
        string StrWidth;
        public VideoShow()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily.ToString() == "Windows.Mobile")
            {
                StrHeight = "250";
                StrWidth = "380";
            }
            else if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily.ToString() == "Windows.Desktop")
            {
                StrHeight = "480";
                StrWidth = "950";
            }

            var NewsLink = (string)e.Parameter;
            string HTML = String.Format("<iframe width='{0}' height='{1}' src='http://www.youtube.com/embed/{2}'?rel='0' frameborder='0' allowfullscreen></iframe>",StrWidth,StrHeight,NewsLink);
            VideoWebView.NavigateToString(HTML);
        }
    }
}
