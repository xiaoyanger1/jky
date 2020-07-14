using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPIC_200
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            RegDLL.RegClass reg = new RegDLL.RegClass(System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetAssembly(typeof(Login)).Location).ToShortDateString());
            if (reg.MiStart_Infos() && reg.MiEnd_Infos())
            {
                Process instance = RunningInstance();
                if (instance == null)
                {
                    //Application.EnableVisualStyles();
                    //Application.SetCompatibleTextRenderingDefault(false);
                    Form Login = new Login();
                    Login.ShowDialog();//显示登陆窗体  
                    if (Login.DialogResult == DialogResult.OK)
                        Application.Run(new MainForm());//判断登陆成功时主进程显示主窗口  
                    else return;
                }
                else
                {
                    // 已经有一个实例在运行
                    HandleRunningInstance(instance);
                }
            }
            else
            {
                Application.Exit();
            }
        }

        #region  确保程序只运行一个实例

        /// <summary>
        /// 遍历系统进程
        /// </summary>
        /// <returns></returns>
        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            //遍历与当前进程名称相同的进程列表 
            foreach (Process process in processes)
            {
                //如果实例已经存在则忽略当前进程 
                if (process.Id != current.Id)
                {
                    //保证要打开的进程同已经存在的进程来自同一文件路径
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //返回已经存在的进程
                        return process;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 已经有了就把它激活，并将其窗口放置最前端
        /// </summary>
        /// <param name="instance"></param>
        private static void HandleRunningInstance(Process instance)
        {
            MessageBox.Show("该程序已经在运行！", "运行提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowWindowAsync(instance.MainWindowHandle, 1);  //调用api函数，正常显示窗口
            SetForegroundWindow(instance.MainWindowHandle); //将窗口放置最前端
        }

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);

        #endregion

        private static string _CODE = "";
        public static void SetCode(string Code)
        {
            _CODE = Code;
        }
        public static string GetCode()
        {
            return _CODE;
        }

        
        /// <summary>
        /// COM口
        /// </summary>
        public static int _SB_COM = 1;
        /// <summary>
        /// 波特率
        /// </summary>
        public static int _SB_BTL = 9600;
        /// <summary>
        /// 设备数
        /// </summary>
        public static int _SB_Count =0;
        /// <summary>
        /// 探头数
        /// </summary>
        public static int _TTNum = 1;


    }
}
