using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Configuration;
using System.Net;
using System.Windows.Threading;
using System.Xml;


namespace HomeScreen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DispatcherTimer timer;
        static System.Timers.Timer timer;
        // counter to track images.
        int ctr = 0;

        void timer_Tick(object sender, EventArgs e)
        {
            ctr++;
            if (ctr > 3)
            // Move to first image after last image.
            {
                ctr = 1;
            }
            PlaySlideShow(ctr);
        }

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                /* 
                 * 1)Date and Time setting:                    
                 */
                lblTime.Content = string.Format("{0:hh:mm tt}", DateTime.Now);
                lblDate.Content = string.Format("{0:dddd}", DateTime.Now).Substring(0, 3) + ", " + string.Format("{0:MMMM}", DateTime.Now).Substring(0, 3) + " " + string.Format("{0:dd}", DateTime.Now) + string.Format("{0}", (DateTime.Now.Day % 10 == 1 && DateTime.Now.Day != 11) ? "st" : (DateTime.Now.Day % 10 == 2 && DateTime.Now.Day != 12) ? "nd" : (DateTime.Now.Day % 10 == 3 && DateTime.Now.Day != 13) ? "rd" : "th");
               
                /*
                 * 2) Temperature and Weather Conditions                            
                 */
                string appId = ConfigurationSettings.AppSettings["AppId"];
                string weburl = "http://api.openweathermap.org/data/2.5/weather?lat=" + "24.91" + "&lon=" + "67.08" + "&APPID=" + appId + "&mode=xml";
                
                var xml = new WebClient().DownloadString(new Uri(weburl));
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string szTemp = doc.DocumentElement.SelectSingleNode("temperature").Attributes["value"].Value;
                double temp = double.Parse(szTemp) - 273.16;
                lblTemperature.Content = temp.ToString("N2") + "°c";

                string weatherCondition = doc.DocumentElement.SelectSingleNode("weather").Attributes["value"].Value;
                string weatherIcon = doc.DocumentElement.SelectSingleNode("weather").Attributes["icon"].Value;

                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri("http://openweathermap.org/img/w/" + weatherIcon + ".png");
                logo.EndInit();

                imgWeatherConditions.Source = logo;
                lblConditions.Content = weatherCondition;

                //Uri videoUri = new Uri(@"C:\Users\Mohammad\Downloads\2-Video\Movies\Cars 2 {2011} DVDRIP. Jaybob.avi");
                //Uri videoUri = new Uri(@"https://www.youtube.com/watch?v=QwievZ1Tx-8");                
                //VideoControl.Source = videoUri;

                // Initialize the timer.
                //timer = new System.Timers.Timer();
                //timer.Interval = 2000;
                //timer.Elapsed += timer_Tick;
                //timer.Enabled = true;

                //timer = new DispatcherTimer();
                // Specify timer interval.
                //timer.Interval = new TimeSpan(0, 0, 2);
                // Specify timer event handler function.
                //timer.Tick += new EventHandler(timer_Tick);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Unable get updated data, Retry later");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ctr = 1;
            //PlaySlideShow(ctr);
        }

        private void PlaySlideShow(int ctr)
        // Function to display image.
        {            
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            //string filename = ((ctr < 10) ? "images/Plane0" + ctr +
            //       ".jpeg" : "images/Plane" + ctr + ".jpeg");

            //Valid extensions:  ".png", ".jpg", ".jpeg", ".bmp", ".gif"

            string filename = "Images/" + ctr + ".JPG";
            // Specify image file name in the Images folder in the application.
            image.UriSource = new Uri(filename, UriKind.Relative);
            image.EndInit();
            // Set image source.
            myImage.Source = image;
            // Specify stretch mode.
            myImage.Stretch = Stretch.Uniform;
            // Update progress bar.
            //progressBar1.Value = ctr;
        }
    }
}
