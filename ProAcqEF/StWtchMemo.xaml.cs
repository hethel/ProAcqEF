using System;
using System.Windows;

namespace ProAcqEF
{
    /// <summary>
    /// Stop Watch Memo on spezific time span
    /// </summary>
    public partial class StWtchMemo : Window
    {
        StopWatch swm = new StopWatch();

        // Entity Process Data variables
        string swm_Date;                    // stop watch memo time
        string swm_AbsTime;                 // stop watch memo time
        string swm_RelTime;                 // stop watch memo time
        string swm_Memo;                    // stop watch memo memo
        int stWtchMemo_count;               // memo window counter

        EFTools swm_efTools = new EFTools();

        public StWtchMemo()
        {
            InitializeComponent();

            ++stWtchMemo_count;

            labelSWM.Content = swm.MemoTime();
            swm_Date = DateTime.Now.ToString("yyyyMMdd");
            swm_AbsTime = DateTime.Now.ToString("HH:mm:ss"); // show the time 
            swm_RelTime = labelSWM.Content.ToString();       // set the relevant time span
        }

        // get stWtchMemo_count for StopWatch object
        public int get_stWtchMemo_count()
        {
            return stWtchMemo_count;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (labelSWM.Content.ToString() != String.Empty) // when stop watch still not started
                swm_Memo = textBox.Text.ToString();          // desription from textbox
            else
            {
                swm_Memo = "Stop watch clock not started";
                swm_RelTime = "0";
            }

            swm_efTools.ef_Insert(swm_Date, swm_AbsTime, swm_RelTime, swm_Memo);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            swm = null;
            swm_efTools = null;
        }

        ~StWtchMemo()
        {
            GC.Collect();
        }
    }
}
