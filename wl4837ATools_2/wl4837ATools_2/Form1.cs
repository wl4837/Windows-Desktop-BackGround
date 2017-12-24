using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace wl4837ATools_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private IntPtr programIntPtr = IntPtr.Zero;
        public void Init()
        {
            // 通过类名查找一个窗口，返回窗口句柄。
            programIntPtr = Win32.FindWindow("Progman", null);

            // 窗口句柄有效
            if (programIntPtr != IntPtr.Zero)
            {

                IntPtr result = IntPtr.Zero;

                // 向 Program Manager 窗口发送 0x52c 的一个消息，超时设置为0x3e8（1秒）。
                Win32.SendMessageTimeout(programIntPtr, 0x52c, IntPtr.Zero, IntPtr.Zero, 0, 0x3e8, result);

                // 遍历顶级窗口
                Win32.EnumWindows((hwnd, lParam) =>
                {
                    // 找到包含 SHELLDLL_DefView 这个窗口句柄的 WorkerW
                    if (Win32.FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null) != IntPtr.Zero)
                    {
                        // 找到当前 WorkerW 窗口的，后一个 WorkerW 窗口。 
                        IntPtr tempHwnd = Win32.FindWindowEx(IntPtr.Zero, hwnd, "WorkerW", null);

                        // 隐藏这个窗口
                        Win32.ShowWindow(tempHwnd, 0);
                    }
                    return true;
                }, IntPtr.Zero);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_load_Ck() {
            Form2 bgWinform = new Form2();
            Init();
            Win32.SetParent(bgWinform.Handle, programIntPtr);
            bgWinform.StartPosition = FormStartPosition.CenterScreen;
            bgWinform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 bgWinform = new Form2();
            Init();
            Win32.SetParent(bgWinform.Handle, programIntPtr);
            bgWinform.StartPosition = FormStartPosition.CenterScreen;
            bgWinform.Show();
            this.Hide();
        }
    }
}
