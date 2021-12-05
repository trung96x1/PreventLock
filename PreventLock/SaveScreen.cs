using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreventLock {
    public partial class SaveScreen : Form {

        System.Windows.Forms.Timer clockTimer = null;
        public SaveScreen(Screen monitor) {
            InitializeComponent();

            //Set form full screen
            this.Width = monitor.Bounds.Width;
            this.Height = monitor.Bounds.Height;
            this.Top = monitor.Bounds.Top;
            this.Left = monitor.Bounds.Left;

            //Set label lbClock to center form
            lbClock.Left = (this.ClientSize.Width - lbClock.Width) / 2;
            lbClock.Top = (this.ClientSize.Height - lbClock.Height) / 2;

            //Start clock timer
            clockTimer = new System.Windows.Forms.Timer();
            clockTimer.Interval = 1000;
            clockTimer.Tick += clockTimer_Tick;
            clockTimer.Start();
        }

        void clockTimer_Tick( object sender, EventArgs e ) {
            DateTime timeNow = DateTime.Now;
            String hour = timeNow.Hour < 10 ? ("0" + timeNow.Hour) : ("" + timeNow.Hour);
            String minute = timeNow.Minute < 10 ? ("0" + timeNow.Minute) : ("" + timeNow.Minute);
            String second = timeNow.Second < 10 ? ("0" + timeNow.Second) : ("" + timeNow.Second);
            String time = hour + ":" + minute + ":" + second;
            lbClock.Text = time;
        }

        //Double click to save screen to close all sub screen
        private void SaveScreen_DoubleClick( object sender, EventArgs e ) {
            ((Form1)this.Owner).closeAllSubWindown();
        }
    }
}
