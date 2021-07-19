using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MouseMoveApp
{
    public static class NativeMethods
    {

        // 
        public const int MOD_ALT = 0x0001;
        public const int MOD_CONTROL = 0x0002;
        public const int MOD_SHIFT = 0x0004;
        public const int MOD_WIN = 0x0008;

        // ホットキーのイベントを示すメッセージID
        public const int WM_HOTKEY = 0x0312;

        // ホットキー押下時、OSから受け取るID
        // 0x0000〜0xbfff 内の適当な値を指定
        public const int APP_START_HOTKEY_ID = 0x0001;
        public const int APP_STOP_HOTKEY_ID = 0x0002;

        // マウスイベント関連の定数
        public const int MOUSEEVENTF_MOVED = 0x0001;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const int screen_length = 0x10000;


        [DllImport("user32.dll")]
        public extern static bool SetCursorPos(int X, int Y);

        // ホットキーの登録
        [DllImport("user32.dll")]
        public extern static int RegisterHotKey(IntPtr HWnd, int ID, int MOD_KEY, int KEY);

        // ホットキーの解除
        [DllImport("user32.dll")]
        public  extern static int UnregisterHotKey(IntPtr HWnd, int ID);

        // マウス操作を制御するためのMOUSEINPUT構造体
        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }
        // SendInputメソッド用の構造体
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public int type;
            public MOUSEINPUT mi;
        }

        // SendInputメソッドを宣言
        [DllImport("user32.dll")]
        public  extern static uint SendInput(
            uint nInputs,     // INPUT 構造体の数(イベント数)
            INPUT[] pInputs,  // INPUT 構造体
            int cbSize        // INPUT 構造体のサイズ
        );
    }
}
