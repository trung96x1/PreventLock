using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PreventLock {
    class GearDetector {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx( int idHook, CallBackFunction lpfn, IntPtr hMod, uint dwThreadId );

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx( IntPtr hhk );

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx( IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle( string lpModuleName );

        //1. Keyboard
        private static int WH_KEYBOARD_LL = 13;
        private static int WM_KEYDOWN = 0x0100;
        private static int WM_KEYUP = 0x0101;

        //2. Mouse
        private static int WH_MOUSE_LL = 14;
        public static int WM_LBUTTONDOWN = 0x0201;
        public static int WM_LBUTTONUP = 0x0202;
        public static int WM_MBUTTONDOWN = 0x0207;
        public static int WM_MBUTTONUP = 0x0208;
        public static int WM_MOUSEMOVE = 0x0200;
        public static int WM_MOUSEWHEEL = 0x020A;
        public static int WM_RBUTTONDOWN = 0x0204;
        public static int WM_RBUTTONUP = 0x0205;

        private static IntPtr SetHook( CallBackFunction proc, int idHook ) {
            using(Process curProcess = Process.GetCurrentProcess())
            using(ProcessModule curModule = curProcess.MainModule) {
                return SetWindowsHookEx(idHook, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr CallBackFunction( int nCode, IntPtr wParam, IntPtr lParam );
        private static CallBackFunction _proc;
        private static IntPtr _hookID = IntPtr.Zero;

        //Call callback with WM_KEYDOWN event
        public delegate void KeyBoardCallback( int key );
        public static IntPtr RegisterKeyBoardCallBack( KeyBoardCallback keyboardCallback ) {
            _proc = ( nCode, wParam, lParam ) => {
                if(wParam == (IntPtr)GearDetector.WM_KEYDOWN && nCode >= 0) {
                    int vkCode = Marshal.ReadInt32(lParam);
                    keyboardCallback(vkCode);
                }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            };
            _hookID = SetHook(_proc, WH_KEYBOARD_LL);
            return _hookID;
        }

        //Call callback with mouse event
        public delegate void MouseCallback( IntPtr mouseEvent );
        public static IntPtr RegisterMouseCallBack( MouseCallback mouseCallBack ) {
            _proc = ( nCode, wParam, lParam ) => {
                mouseCallBack(wParam);
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            };
            _hookID = SetHook(_proc, WH_MOUSE_LL);
            return _hookID;
        }
    }
}
