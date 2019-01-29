using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AhlyClub
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(AhlyNews));
            AhlyNewsItem.IsSelected = true;
        }

        private void HumburgerMenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (AhlyNewsItem.IsSelected)
                {
                    MainFrame.Navigate(typeof(AhlyNews));
                    PageTitleTextBlock.Text = "أخبار النادي الأهلي";
                }
                else if (LegaNewsItem.IsSelected)
                {
                    MainFrame.Navigate(typeof(LegaNews));
                    PageTitleTextBlock.Text = "أخبار الدوري المصري";
                }
                else if (AhlyVideosItem.IsSelected)
                {
                    MainFrame.Navigate(typeof(AhlyVideos));
                    PageTitleTextBlock.Text = "فيديوهات الأهلي";
                }
                else if (SportNewsItem.IsSelected)
                {
                    MainFrame.Navigate(typeof(SportNews));
                    PageTitleTextBlock.Text = "أخبار رياضية منوعة";
                }
            }
            catch (Exception)
            {
                //Handling Exceptions
            }
        }

        private void HumburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MainSplitView.IsPaneOpen = !MainSplitView.IsPaneOpen;
        }
    }
}
