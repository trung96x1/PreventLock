using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PreventLock {
    class WindowSpeaker {
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessageW( IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam );

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        //Mute/UnMute Windows Volume
        public static void switchMute() {    
            SendMessageW(GetForegroundWindow(), WM_APPCOMMAND, GetForegroundWindow(), (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }
    }
}
