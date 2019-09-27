using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EarTrumpet.Interop.Helpers
{
    public class Win32Api
    {
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }
        [StructLayout(LayoutKind.Sequential)]
        public class MouseLLHookStruct
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);
    }

    public class MouseHook
    {
        public delegate int MouseWheelHandler(object sender, MouseEventArgs e);
        public event MouseWheelHandler MouseWheelEvent;
        public Win32Api.HookProc hProc;

        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WH_MOUSE_LL = 14;
        private int hHook;
        private bool hook_was_set = false;

        public void SetHook()
        {
            if (!hook_was_set)
            {
                hProc = new Win32Api.HookProc(MouseHookProc);
                hHook = Win32Api.SetWindowsHookEx(WH_MOUSE_LL, hProc, IntPtr.Zero, 0);
                hook_was_set = true;
            }
        }

        public void UnHook()
        {
            if (hook_was_set)
            {
                Win32Api.UnhookWindowsHookEx(hHook);
                hook_was_set = false;
            }
        }

        private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0 || MouseWheelEvent == null || (Int32)wParam != WM_MOUSEWHEEL)
            {
                return Win32Api.CallNextHookEx(hHook, nCode, wParam, lParam);
            }
            Win32Api.MouseLLHookStruct MyMouseHookStruct = (Win32Api.MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(Win32Api.MouseLLHookStruct));
            int result = MouseWheelEvent(this, new MouseEventArgs(MouseButtons.None, 0, MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y, MyMouseHookStruct.mouseData >> 16));
            if (result == 0)
            {
                return Win32Api.CallNextHookEx(hHook, nCode, wParam, lParam);
            }
            return result;
        }
    }
}