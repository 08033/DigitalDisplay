﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace HomeScreen
{
    /// <summary>
    /// Interaction logic for MixScreenWindow.xaml
    /// </summary>
    public partial class MixScreenWindow : Window
    {
        string[] vdoArray;
        int currentVdo = 0;
        Uri videoUri;

        static System.Timers.Timer timer;

        private DispatcherTimer timerImageChange;
        private Image[] ImageControls;
        private List<ImageSource> Images = new List<ImageSource>();
        private static string[] ValidImageExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };
        private static string[] TransitionEffects = new[] { "Fade" };
        private string TransitionType, strImagePath = "";
        private int CurrentSourceIndex, CurrentCtrlIndex, EffectIndex = 0, IntervalTimer = 1;

        public MixScreenWindow()
        {
            InitializeComponent();
            //myVideoControl.MediaOpened += myVideoControl_MediaOpened;
            myVideoControl.MediaEnded += myVideoControl_MediaEnded;
            myVideoControl.LoadedBehavior = MediaState.Manual;

            //Initialize Image control, Image directory path and Image timer.
            IntervalTimer = Convert.ToInt32(ConfigurationManager.AppSettings["IntervalTime"]);
            strImagePath = ConfigurationManager.AppSettings["ImagePath"];
            ImageControls = new[] { myImage, myImage2 };

            LoadImageFolder(strImagePath);

            timerImageChange = new DispatcherTimer();
            timerImageChange.Interval = new TimeSpan(0, 0, IntervalTimer);
            timerImageChange.Tick += new EventHandler(timerImageChange_Tick);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //1) Load header---------------------
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("header.jpg", UriKind.Relative);
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();
            // Set image source.
            myHeaderImage.Source = image;
            // Specify stretch mode.
            myHeaderImage.Stretch = Stretch.Fill;
            //1 end) header loaded---------------------

            //2) Setting date time temperature----------------------------------------------------            
            setDateTimeTemperature();
            // Initialize the timer.
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;
            //2 end) info set----------------------------------------------------

            //3) Play Videos----------------------
            //vdoArray = new string[] { "Ability", "Fatiha" };
            string vDoPath = ConfigurationManager.AppSettings["VideoPath"];

            var filesInfo = new DirectoryInfo(vDoPath).GetFiles();
            vdoArray = new string[filesInfo.Length];
            int c = 0;

            foreach (FileInfo fI in filesInfo)
            {
                vdoArray[c] = fI.Name;
                c++;
            }

            videoUri = new Uri(string.Format(@"Videos/{0}", vdoArray[currentVdo]), UriKind.Relative);
            currentVdo++;
            myVideoControl.Source = videoUri;
            myVideoControl.Play();
            //3 end) Videos played----------------

            //4) Play Images------------------------------------------------------
            PlaySlideShow();
            timerImageChange.IsEnabled = true;
            //4 end) Images played

            //5) Ticker start-----------------------------------------------------
            // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader("ticker.txt"))
            {
                // Read the stream to a string, and write the string to the console.
                String line = sr.ReadToEnd();                
                myTicker.Text = line;
            }
            startTicker();
            //5 end) ticker
        }

        void myVideoControl_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (currentVdo == vdoArray.Length)
                currentVdo = 0;

            videoUri = new Uri(string.Format(@"Videos/{0}", vdoArray[currentVdo]), UriKind.Relative);
            currentVdo++;
            myVideoControl.Source = videoUri;
            myVideoControl.Play();
        }

        //void myVideoControl_MediaOpened(object sender, RoutedEventArgs e)
        //{
        //    var totalDurationTime = myVideoControl.NaturalDuration.TimeSpan.TotalSeconds;
        //}

        /// <summary>
        ///Date time temperature setting functions -------------------------------
        /// </summary>
        public void setDateTimeTemperature()
        {
            /* 
                 * 2a)Date and Time setting:                    
            */
            myDateTime.Content = string.Format("{0:dddd}", DateTime.Now).Substring(0, 3) + ", " + string.Format("{0:MMMM}", DateTime.Now).Substring(0, 3) + " " + string.Format("{0:dd}", DateTime.Now) + string.Format("{0}", (DateTime.Now.Day % 10 == 1 && DateTime.Now.Day != 11) ? "st" : (DateTime.Now.Day % 10 == 2 && DateTime.Now.Day != 12) ? "nd" : (DateTime.Now.Day % 10 == 3 && DateTime.Now.Day != 13) ? "rd" : "th") + " " +
                                 string.Format("{0:hh:mm:ss tt}", DateTime.Now);

            /*
                * 2b) Temperature and Weather Conditions                            
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
        }        

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Whenever you update your UI elements from a thread other than the main thread
            this.Dispatcher.Invoke(() =>
            {
                setDateTimeTemperature();
            });
        }

        ///----------------------------------Image Slide functions
        ///

        private void LoadImageFolder(string folder)
        {
            ErrorText.Visibility = Visibility.Collapsed;
            var sw = System.Diagnostics.Stopwatch.StartNew();
            if (!System.IO.Path.IsPathRooted(folder))
                folder = System.IO.Path.Combine(Environment.CurrentDirectory, folder);
            if (!System.IO.Directory.Exists(folder))
            {
                ErrorText.Text = "The specified folder does not exist: " + Environment.NewLine + folder;
                ErrorText.Visibility = Visibility.Visible;
                return;
            }
            Random r = new Random();
            var sources = from file in new System.IO.DirectoryInfo(folder).GetFiles().AsParallel()
                          where ValidImageExtensions.Contains(file.Extension, StringComparer.InvariantCultureIgnoreCase)
                          orderby r.Next()
                          select CreateImageSource(file.FullName, true);
            Images.Clear();
            Images.AddRange(sources);
            sw.Stop();
            Console.WriteLine("Total time to load {0} images: {1}ms", Images.Count, sw.ElapsedMilliseconds);
        }

        private ImageSource CreateImageSource(string file, bool forcePreLoad)
        {
            if (forcePreLoad)
            {
                var src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(file, UriKind.Absolute);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                src.Freeze();
                return src;
            }
            else
            {
                var src = new BitmapImage(new Uri(file, UriKind.Absolute));
                src.Freeze();
                return src;
            }
        }

        private void timerImageChange_Tick(object sender, EventArgs e)
        {
            PlaySlideShow();
        }

        private void PlaySlideShow()
        {
            try
            {
                if (Images.Count == 0)
                    return;
                var oldCtrlIndex = CurrentCtrlIndex;
                CurrentCtrlIndex = (CurrentCtrlIndex + 1) % 2;
                CurrentSourceIndex = (CurrentSourceIndex + 1) % Images.Count;

                Image imgFadeOut = ImageControls[oldCtrlIndex];
                Image imgFadeIn = ImageControls[CurrentCtrlIndex];
                ImageSource newSource = Images[CurrentSourceIndex];
                imgFadeIn.Source = newSource;

                TransitionType = TransitionEffects[EffectIndex].ToString();

                Storyboard StboardFadeOut = (Resources[string.Format("{0}Out", TransitionType.ToString())] as Storyboard).Clone();
                StboardFadeOut.Begin(imgFadeOut);
                Storyboard StboardFadeIn = Resources[string.Format("{0}In", TransitionType.ToString())] as Storyboard;
                StboardFadeIn.Begin(imgFadeIn);
            }
            catch (Exception ex) { }
        }

        ///------------------------------Ticker text
        ///
        private void startTicker()
        {
            myTicker.UseLayoutRounding = true;
            
            DoubleAnimation doubleAnimation = new DoubleAnimation();            
            doubleAnimation.From = this.ActualWidth;
            doubleAnimation.To = -myTicker.ActualWidth;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(20)); // provide an appropriate  duration 
            myTicker.BeginAnimation(Canvas.LeftProperty, doubleAnimation);            
        }
    }
}