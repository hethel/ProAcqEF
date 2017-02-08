using System;
using System.Windows;

namespace ProAcqEF
{
    /// <summary>
    /// StopWatch - relativ time reference
    /// </summary>

    public partial class StopWatch : Window
    {
        private System.Windows.Threading.DispatcherTimer timer;
        private DateTime dateDiff;
        StWtchMemo stWtchMemo;          // memo requests

        EFTools sw_efTools = new EFTools();
        
        // Entity Process Data variables
        string sw_Date;         // stop watch memo time
        string sw_AbsTime;     // stop watch memo time
        string sw_RelTime;     // stop watch memo time
        string sw_Memo;         // stop watch memo memo

        // deliver time for memo window
        private static string memoTime = String.Empty;
        public string MemoTime() { return memoTime; }

        public bool Stopwatch_active { get; set; }

        public StopWatch()
        {
            InitializeComponent();

            // for job documentation 
            sw_Date = DateTime.Now.ToString("yyyyMMdd");
            sw_RelTime = "0";

            // Stop watch init and set Millisecands
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += new EventHandler(showTime);

            btnStop.IsEnabled = false;
            Stopwatch_active = true;    // StopWatch-Window open
        }

        // Message Entry for Stop watch job start
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // desription from textbox
            sw_Memo = "Stop Watch Job started";
            sw_AbsTime = DateTime.Now.ToString("HH:mm:ss"); // show the time 

            sw_efTools.ef_Insert(sw_Date, sw_AbsTime, sw_RelTime, sw_Memo);
        }


        private void showTime(object sender, EventArgs e)
        {
            dateDiff = dateDiff.AddMilliseconds(100);
            labelSW.Content = dateDiff.ToString("HH:mm:ss");
            memoTime = dateDiff.ToString("HH:mm:ss:f");
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();

            btnStop.IsEnabled = true;
            btnStart.IsEnabled = false;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            labelSW.Content = dateDiff.ToString("HH:mm:ss:f");

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        // Memo Button
        private void btnMemo_Click(object sender, RoutedEventArgs e)
        {
            stWtchMemo = new StWtchMemo();
             
            stWtchMemo.Owner = this;
            stWtchMemo.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            stWtchMemo.Show();   
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();   // stop timer

            // for job documentation
            //  No StWtchMemo Object || only at least one referenc exist    
            if (stWtchMemo == null || (stWtchMemo != null && stWtchMemo.get_stWtchMemo_count() <= 1))
            { 
                sw_Memo = "Stop Watch Job completed";
                sw_AbsTime = DateTime.Now.ToString("HH:mm:ss"); // show a relevant time 
                sw_efTools.ef_Insert(sw_Date, sw_AbsTime, sw_RelTime, sw_Memo);
            }
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            Stopwatch_active = false;   // Window closed
        }

        ~StopWatch()
        {
            GC.Collect();
        }

    }
}
