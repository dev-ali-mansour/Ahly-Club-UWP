using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Advertising.WinRT.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AhlyClub
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewsDetailsPage : Page
    {
        string NewsLink;
        public NewsDetailsPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NewsLink = (string)e.Parameter;
            NewsWebView.Navigate(new Uri(NewsLink, UriKind.Absolute));
        }
        
        //private void AppBarShareButton_Click(object sender, RoutedEventArgs e)
        //{
        //    RegisterForShare();
        //}

        //private void RegisterForShare()
        //{
        //    DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
        //    dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager,
        //        DataRequestedEventArgs>(this.ShareLinkHandler);
        //}

        //private void ShareLinkHandler(DataTransferManager sender, DataRequestedEventArgs e)
        //{
        //    DataRequest request = e.Request;
        //    request.Data.Properties.Title = "أخبار الأهلي - مشاركة رابط";
        //    request.Data.Properties.Description = "تم مشاركة هذا الخبر من تطبيق أخبار الأهلي";
        //    request.Data.SetWebLink(new Uri(NewsLink, UriKind.Absolute));
        //}

    }
}
