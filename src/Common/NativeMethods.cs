using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BundleVisualizer.Common {
    public class NativeMethods {

        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public static void SetToolstripTextBoxPlaceHolder(ToolStripTextBox txt, string text) {
            SendMessage(txt.TextBox.Handle, EM_SETCUEBANNER, 0, text);            
        }
    }
}
