using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PreventLock {
    class WindowManager {

        //Minimize/Unminimize all windown
        private const int WM_COMMAND = 0x111;
        private const int MIN_ALL = 419;
        private const int MIN_ALL_UNDO = 416;

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow( string lpClassName, string lpWindowName );

        [DllImport("user32.dll")]
        private static extern int SendMessage( IntPtr hWnd, int Msg, int wParam, int lParam );

        public static void minimizeAll() {
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
            SendMessage(lHwnd, WM_COMMAND, MIN_ALL, 0);
        }

        public static void undoMinimizeAll() {
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
            SendMessage(lHwnd, WM_COMMAND, MIN_ALL_UNDO, 0);
        }
    }
}
