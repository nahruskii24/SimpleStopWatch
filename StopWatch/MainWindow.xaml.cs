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
using System.Windows.Threading;

namespace StopWatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // setting our global vars
        DispatcherTimer timer = new DispatcherTimer();
        int millisec = 0;
        int seconds = 0;
        int minutes = 0;
        int hours = 0;
       
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///soon as the start button is clicked set the interval 
        ///call the Timer_Tick method for each tick and start
        ///the timer
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        /// <summary>
        /// This method is called every time there is a tick.So for each tick 
        /// first check if the numbers for each gruop is less than 10 then add 
        /// a zero in front if need be. Next we display the time to show the time 
        /// to the user. and we set limits for the milliseconds, seconds, minutes,
        /// and hours.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            string ms = "";
            string sec = "";
            string min = "";
            string hr = "";
            if (millisec < 10) { ms = "0"; } else { ms = ""; }
            if (seconds < 10) { sec = "0"; } else { sec = ""; }
            if (minutes < 10) { min = "0"; } else { min = ""; }
            if (hours < 10) { hr = "0"; } else { hr = ""; }
            time_Text.Content = hr + hours + ":" + min + minutes + ":" + sec + seconds + "." + ms + millisec.ToString();
            if (hours == 23 & minutes == 59 & seconds == 59 & millisec == 96) { }
            if (millisec == 92) { seconds++; millisec = 0; } else { millisec++; }
            if (seconds == 60) { minutes++; seconds = 0; }
            if (minutes == 60) { hours++; minutes = 0; }
        }

        /// <summary>
        /// Stop the timer
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        /// <summary>
        /// reset all, meaning setting everything back to zero
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            millisec = 0;
            seconds = 0;
            minutes = 0;
            hours = 0;
            time_Text.Content = "00:00:00:00";
        }
    }
}
