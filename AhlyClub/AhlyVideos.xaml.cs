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
    public sealed partial class AhlyVideos : Page
    {
        public RSSGrapper Grapper = new RSSGrapper();
        public AhlyVideos()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            Grapper.ViewRSS(ref VideosList, "https://www.youtube.com/feeds/videos.xml?channel_id=UCA86pBGxVPZGrTeTecOtjew", "Youtube", ref Prog);
            Grapper.ViewRSS(ref VideoGridView, "https://www.youtube.com/feeds/videos.xml?channel_id=UCA86pBGxVPZGrTeTecOtjew", "Youtube", ref ProgRing);
        }

        private void VideoGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var News = (Feed)e.ClickedItem;
            string Link = News.Link;
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VideoShow), Link);
        }
        
        private void VideosList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var News = (Feed)e.ClickedItem;
            string Link = News.Link;
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(VideoShow), Link);
        }
    }
}
