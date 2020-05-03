using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreventLock
{
    public partial class Form1 : Form
    {
        UserSetting userSetting = null;
        private Thread mPVLock;
        System.Windows.Forms.Timer mainLoop = null;
        public Form1()
        {
            InitializeComponent();
            userSetting = UserSetting.getInstance();

            mPVLock = new Thread(preventLock);
            mPVLock.IsBackground = true;
            mPVLock.Start();
            this.preventLockToolStripMenuItem.CheckState = CheckState.Checked;

            mainLoop = new System.Windows.Forms.Timer();
            mainLoop.Interval = 1000;
            mainLoop.Tick += mainLoop_Tick;
            mainLoop.Start();
            


        }

        //DRAG FORM FROM PICTURE
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //PREVENT LOCK
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED    = 0x00000040,
            ES_CONTINUOUS           = 0x80000000,
            ES_DISPLAY_REQUIRED     = 0x00000002,
            ES_SYSTEM_REQUIRED      = 0x00000001
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }
        private void preventLock()
        {
            while(true)
            {
                SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_DISPLAY_REQUIRED);
                Thread.Sleep(1000);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void preventLockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.preventLockToolStripMenuItem.Checked)
                mPVLock.Suspend();
            else
                mPVLock.Resume();
        }

        private void currentPossitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.currentPossitionToolStripMenuItem.Checked){
                userSetting.setString(UserSetting.TAG_ENABLE_ANCHOR_POSITION,"TRUE");
                userSetting.setString(UserSetting.TAG_POSITON_LEFT,this.Left.ToString());
                userSetting.setString(UserSetting.TAG_POSITON_TOP,this.Top.ToString());
            }else{
                userSetting.setString(UserSetting.TAG_ENABLE_ANCHOR_POSITION,"FALSE");
            }
            userSetting.save();
        }

        private void mainLoop_Tick( object sender, EventArgs e ) {
            //wait 1s to load UserSetting
            mainLoop.Stop();
            String leftValue = userSetting.getString(UserSetting.TAG_POSITON_LEFT, "0");
            String topValue = userSetting.getString(UserSetting.TAG_POSITON_TOP, "0");
            this.Left = Int32.Parse(leftValue);
            this.Top = Int32.Parse(topValue);
            String anchorValue = userSetting.getString(UserSetting.TAG_ENABLE_ANCHOR_POSITION, "FALSE");
            Boolean isAnchor = Boolean.Parse(anchorValue);
            if(isAnchor)      
                this.currentPossitionToolStripMenuItem.CheckState = CheckState.Checked;
        }

        private void Form1_LocationChanged( object sender, EventArgs e ) {
            String anchorValue = userSetting.getString(UserSetting.TAG_ENABLE_ANCHOR_POSITION, "FALSE");
            Boolean isAnchor = Boolean.Parse(anchorValue);
            if(isAnchor) {
                String leftValue = userSetting.getString(UserSetting.TAG_POSITON_LEFT, "0");
                String topValue = userSetting.getString(UserSetting.TAG_POSITON_TOP, "0");
                this.Left = Int32.Parse(leftValue);
                this.Top = Int32.Parse(topValue);
                this.currentPossitionToolStripMenuItem.CheckState = CheckState.Checked;
            }
        }
    }
}
