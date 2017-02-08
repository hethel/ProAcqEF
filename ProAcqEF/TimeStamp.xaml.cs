using System;
using System.Windows;

namespace ProAcqEF
{
    /// <summary>
    /// TimeStamp - absolut time reference
    /// </summary>

    public partial class TimeStamp : Window
    {
        string ts_Date;             // current Date
        string ts_AbsTime;          // absolute Tine
        string ts_RelTime;          // relative Time
        string ts_Memo;             // process description

        EFTools ts_efTools = new EFTools();

        public TimeStamp()
        {
            InitializeComponent();
            ts_Date = DateTime.Now.ToString("yyyyMMdd");
            label.Content = DateTime.Now.ToString("HH:mm:ss"); // show a relevant time 
            ts_AbsTime = label.Content.ToString();    // set a relevant time
            ts_RelTime = "0";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // desription from textbox
            ts_Memo = textBox.Text.ToString();

            ts_efTools.ef_Insert(ts_Date, ts_AbsTime, ts_RelTime, ts_Memo);
        }
    }
}
