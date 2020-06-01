using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace RecordLib.CommonTools
{
    public static class WindowActivateHelper
    {

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
        public static extern Int32 SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hwnd, int nIndex);
        public static void SetNonActive(this Window window)
        {
            window.ShowActivated = false;
            window.SourceInitialized += (sender, e) =>
            {
                WindowInteropHelper helper = new WindowInteropHelper(window);
                int exStyle = GetWindowLong(helper.Handle, -20);
                SetWindowLong(helper.Handle, -20, exStyle | 0x08000000);
            };
        }

    }
}
