using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseMoveApp
{
    public partial class MouseMoveApp : Form
    {


        // 機能の開始／停止を制御するフラグ
        bool isMouseMoveRun = false;

        bool moved;

        const int intervalMiliSecDefault = 30000;

        const int maxIntervalSec = 3600;

        const int movePosition = 150;

        public MouseMoveApp()
        {
            InitializeComponent();

            Toggle(false);
            intervalTextBox.Text = (intervalMiliSecDefault / 1000).ToString();

            // ホットキーの登録
            // CTRL + SHIFT + S　で機能開始
            if (NativeMethods.RegisterHotKey(this.Handle, NativeMethods.APP_START_HOTKEY_ID, NativeMethods.MOD_CONTROL | NativeMethods.MOD_SHIFT, (int)Keys.S) == 0)
            {
                MessageBox.Show("「CTRL + SHIFT + S」をホットキーに登録できませんでした。");
                
            }
            // CTRL + SHIFT + D　で機能停止
            if (NativeMethods.RegisterHotKey(this.Handle, NativeMethods.APP_STOP_HOTKEY_ID, NativeMethods.MOD_CONTROL | NativeMethods.MOD_SHIFT, (int)Keys.D) == 0)
            {
                MessageBox.Show("「CTRL + SHIFT + D」をホットキーに登録できませんでした。");
                
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // マウスポインタの位置を取得する
            // X座標を取得する
            int x = (System.Windows.Forms.Cursor.Position.X * 65536 + Screen.PrimaryScreen.Bounds.Width - 1) / Screen.PrimaryScreen.Bounds.Width;
            // Y座標を取得する
            int y = (System.Windows.Forms.Cursor.Position.Y * 65536 + Screen.PrimaryScreen.Bounds.Height - 1) / Screen.PrimaryScreen.Bounds.Height;

            // マウス操作イベントの作成
            NativeMethods.INPUT[] input = new NativeMethods.INPUT[2];
            input[0].mi.dx = x;
            input[0].mi.dy = y;
            input[0].mi.dwFlags = NativeMethods.MOUSEEVENTF_MOVED | NativeMethods.MOUSEEVENTF_ABSOLUTE;

            input[1].mi.dx = x;
            input[1].mi.dy = y;
            input[1].mi.dwFlags = NativeMethods.MOUSEEVENTF_MOVED | NativeMethods.MOUSEEVENTF_ABSOLUTE;


            if (!moved)
            {
                input[1].mi.dx = x + movePosition;
            }
            else
            {
                input[1].mi.dx = x - movePosition;
            }

            // イベントの実行
            NativeMethods.SendInput(2, input, Marshal.SizeOf(input[0]));
            moved = !moved;

        }

        private void intervalTextBox_Validating(object sender, CancelEventArgs e)
        {
            int interval;
            bool parseResult = int.TryParse(intervalTextBox.Text, out interval);
            if (!parseResult)
            {
                MessageBox.Show("数値が正しくありません。");
                intervalTextBox.Text = (intervalMiliSecDefault / 1000).ToString();
                e.Cancel = true;
                return;
            }
            else if (interval < 1)
            {
                MessageBox.Show("1以上を指定してください。");
                e.Cancel = true;
                return;
            }
            else if (maxIntervalSec < interval)
            {
                MessageBox.Show(maxIntervalSec + "以下を指定してください。");
                e.Cancel = true;
                return;
            }
        }

        private int getIntervalMiliSec()
        {
            int textInterval;
            bool parseResult = int.TryParse(intervalTextBox.Text, out textInterval);
            if (!parseResult)
            {
                return intervalMiliSecDefault;
            }
            else if (textInterval < 1)
            {
                return intervalMiliSecDefault;
            }
            else if (maxIntervalSec < textInterval)
            {
                return intervalMiliSecDefault;
            }
            else
            {
                return textInterval * 1000;
            }
        }

        private void Toggle(bool isStart)
        {
            if (!isStart)
            {
                isMouseMoveRun = false;
                kidoJotaiLabel.Text = "停止中";
                kidoJotaiLabel.ForeColor = Color.Black;
                ToggleButton.Text = "起動";
                timer1.Enabled = false;
                intervalTextBox.Enabled = true;
                moved = false;
            }
            else
            {
                isMouseMoveRun = true;
                kidoJotaiLabel.Text = "起動中";
                kidoJotaiLabel.ForeColor = Color.Red;
                ToggleButton.Text = "停止";
                intervalTextBox.Enabled = false;
                timer1.Interval = getIntervalMiliSec();
                timer1.Enabled = true;
                moved = false;
            }


        }

        // 機能開始
        private void autoMouseRunStart()
        {

            Toggle(true);

        }

        // 機能停止
        private void autoMouseRunStop()
        {
            Toggle(false);

           // MessageBox.Show("停止しました。");
        }

        // 開始停止ボタンクリック
        private void ToggleButton_Click(object sender, EventArgs e)
        {
            if (isMouseMoveRun)
            {
                autoMouseRunStop();
            }
            else
            {
                autoMouseRunStart();
            }
        }

        //　終了ボタン押下
        private void closeButton_Click(object sender, EventArgs e)
        {
            AppExit();
        }

        // タスクトレイ終了押下
        private void AppExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppExit();
        }

        // アプリケーションの終了
        private void AppExit()
        {
            // アプリ終了
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        // 終了時
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ホットキーの解除
            NativeMethods.UnregisterHotKey(this.Handle, NativeMethods.APP_START_HOTKEY_ID);
            NativeMethods.UnregisterHotKey(this.Handle, NativeMethods.APP_STOP_HOTKEY_ID);
        }

        // OSから渡されるメッセージ処理をオーバーライド
        protected override void WndProc(ref Message m)
        {
            //　×ボタン無効
            const int WM_SYSCOMMAND = 0x112;
            const long SC_CLOSE = 0xF060L;

            if (m.Msg == WM_SYSCOMMAND &&
                (m.WParam.ToInt64() & 0xFFF0L) == SC_CLOSE)
            {
                return;
            }

            base.WndProc(ref m);

            if (m.Msg == NativeMethods.WM_HOTKEY)
            {
                if ((int)m.WParam == NativeMethods.APP_START_HOTKEY_ID)
                {
                    // 機能開始
                    autoMouseRunStart();
                }
                else if ((int)m.WParam == NativeMethods.APP_STOP_HOTKEY_ID)
                {
                    // 機能停止
                    autoMouseRunStop();
                }
            }
        }
    }
}
