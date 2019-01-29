using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Xml.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Syndication;

namespace AhlyClub
{
    public class Feed
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }

    }

    public class RSSGrapper
    {
        private async void LoadRSS(ListView NewsList, Uri uri, string Type, ProgressBar Prog)
        {
            try
            {
                Prog.IsIndeterminate = true;
                SyndicationClient client = new SyndicationClient();
                SyndicationFeed feed = await client.RetrieveFeedAsync(uri);
                if (feed != null)
                {
                    Prog.IsIndeterminate = false;
                    Prog.Visibility = Visibility.Collapsed;
                    List<Feed> FL = new List<Feed>();
                    foreach (SyndicationItem item in feed.Items)
                    {
                        Feed F = new Feed();
                        F.Title = item.Title.Text;
                        F.Date = item.PublishedDate.DateTime.ToString();
                        if (Type == "Ahly" || Type == "LEGA")
                        {
                            F.Image = item.Summary.Text;
                            F.Image = F.Image.Remove(0, F.Image.IndexOf("\"") + 1);
                            F.Image = F.Image.Remove(F.Image.IndexOf("\""));
                            F.Link = item.Links[0].Uri.ToString();
                        }
                        else if (Type == "Youtube")
                        {
                            F.Image = item.ElementExtensions[2].ElementExtensions[2].AttributeExtensions[0].Value;
                            F.Link = item.Links[0].Uri.ToString();
                            F.Link = F.Link.Remove(0, F.Link.IndexOf("=") + 1);
                        }
                        else if (Type == "Sport")
                        {
                            F.Image = item.Links[1].Uri.ToString();
                            F.Link = item.Links[0].Uri.ToString();
                        }
                        FL.Add(F);
                    }
                    NewsList.ItemsSource = FL;
                }

            }
            catch (Exception)
            {

            }
        }

        private async void LoadRSS(GridView NewsGridView, Uri uri, string Type, ProgressRing ProgRing)
        {
            try
            {
                ProgRing.IsActive = true;
                SyndicationClient client = new SyndicationClient();
                SyndicationFeed feed = await client.RetrieveFeedAsync(uri);
                if (feed != null)
                {
                    ProgRing.IsActive = false;
                    ProgRing.Visibility = Visibility.Collapsed;
                    List<Feed> FL = new List<Feed>();
                    foreach (SyndicationItem item in feed.Items)
                    {
                        Feed F = new Feed();
                        F.Title = item.Title.Text;
                        F.Date = item.PublishedDate.DateTime.ToString();
                        if (Type == "Ahly" || Type == "LEGA")
                        {
                            F.Image = item.Summary.Text;
                            F.Image = F.Image.Remove(0, F.Image.IndexOf("\"") + 1);
                            F.Image = F.Image.Remove(F.Image.IndexOf("\""));
                            F.Link = item.Links[0].Uri.ToString();
                        }
                        else if (Type == "Youtube")
                        {
                            F.Image = item.ElementExtensions[2].ElementExtensions[2].AttributeExtensions[0].Value;
                            F.Link = item.Links[0].Uri.ToString();
                            F.Link = F.Link.Remove(0, F.Link.IndexOf("=") + 1);
                        }
                        else if (Type == "Sport")
                        {
                            F.Image = item.Links[1].Uri.ToString();
                            F.Link = item.Links[0].Uri.ToString();
                        }
                        FL.Add(F);
                    }
                    NewsGridView.ItemsSource = FL;
                }

            }
            catch (Exception)
            {

            }
        }

        public void ViewRSS(ref ListView NewsList, string RSSLink, string Type, ref ProgressBar Prog)
        {
            try
            {
                LoadRSS(NewsList, new Uri(RSSLink), Type, Prog);
            }
            catch (Exception)
            {

            }
        }

        public void ViewRSS(ref GridView NewsGridView, string RSSLink, string Type, ref ProgressRing ProgRing)
        {
            try
            {
                LoadRSS(NewsGridView, new Uri(RSSLink), Type, ProgRing);
            }
            catch (Exception)
            {

            }
        }

    }
}

