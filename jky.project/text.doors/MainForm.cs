﻿
using text.doors.Common;
using text.doors.Detection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Controls;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using Young.Core.Common;
using text.doors.Default;

namespace text.doors
{
    public partial class MainForm : Form
    {

        private static TcpConnection tcpConnection = new TcpConnection();
        /// <summary>
        /// 操作状态
        /// </summary>
        private bool IsSeccess = false;

        /// <summary>
        /// 确定是否设置樘号
        /// </summary>
        bool NetSetIsOk = false;

        /// <summary>
        /// 传输设置页面
        /// </summary>
        private double _DQWD = 0;
        private double _DQYL = 0;

        /// <summary>
        /// 检验编号
        /// </summary>
        private string JYBH = "";
        /// <summary>
        /// 当前樘号
        /// </summary>
        private string DQDH = "";


        public MainForm()
        {
            InitializeComponent();
            //comboBox1.Text = "单扇开启";
            tcpConnection.OpenTcpConnection();
            if (tcpConnection.IsOpen)
            {
                //隐藏打开按钮
                tsb_open.Visible = false;
                tcpConnection.SendGYBD(ref IsSeccess, true);

                GetRegister();
                ShowDetectionSet();
                this.yf_time.Enabled = true;

                Thread thread = new Thread(OpenTcp);
                thread.Start();

            }
            else
            {
                MessageBox.Show("通信连接异常", "Tcp打开失败",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                       MessageBoxOptions.ServiceNotification
                       );
            }
        }

        private void OpenTcp()
        {
            while (true)
            {
                if (tcpConnection.IsOpen == false)
                {
                    tcpConnection.OpenTcpConnection();
                }
            }
        }

        private void SelectDangHao(text.doors.Detection.DetectionSet.BottomType bt)
        {
            this.tssl_SetCode.Text = string.Format("{0}  {1}", bt.BianHao, bt.DangHao);
            if (bt.ISOK == true)
            { this.tsl_type.Visible = false; }
            else { this.tsl_type.Visible = true; }

            JYBH = bt.BianHao;
            DQDH = bt.DangHao;
            NetSetIsOk = bt.ISOK;
            if (bt.ISOK)
            {
                ShowRealTimeSurveillance();
            }
        }

        /// <summary>
        /// 参数设置
        /// </summary>
        private void ShowDetectionSet()
        {
            this.pl_showItem.Controls.Clear();
            DetectionSet ds = new DetectionSet(_DQWD, _DQYL, JYBH, DQDH);
            ds.deleBottomTypeEvent += new DetectionSet.deleBottomType(SelectDangHao);
            ds.GetDangHaoTrigger();
            ds.TopLevel = false;
            ds.Parent = this.pl_showItem;
            ds.Show();
        }

        /// <summary>
        /// 检测监控
        /// </summary>
        private void ShowRealTimeSurveillance()
        {
            RealTimeSurveillance rts = new RealTimeSurveillance(tcpConnection, JYBH, DQDH);
            this.pl_showItem.Controls.Clear();
            rts.TopLevel = false;
            rts.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            rts.Parent = this.pl_showItem;
            rts.Show();
        }

        private void GetRegister()
        {
            _DQWD = tcpConnection.GetWDXS(ref IsSeccess);
            if (!IsSeccess)
            {
                MessageBox.Show("读取温度异常"); return;
            }


            _DQYL = tcpConnection.GetDQYLXS(ref IsSeccess);
            if (!IsSeccess)
            {
                MessageBox.Show("读取大气压力异常"); return;
            }

            lbl_fscgq.Text = tcpConnection.GetFSXS(ref IsSeccess).ToString();
            if (!IsSeccess)
            {
                MessageBox.Show("读取风速异常"); return;
            }
            lbl_cycgq.Text = tcpConnection.GetCYXS(ref IsSeccess).ToString();
            if (!IsSeccess)
            {
                MessageBox.Show("读取差压异常"); return;
            }

            lbl_wdcgq.Text = tcpConnection.GetWDXS(ref IsSeccess).ToString();
            if (!IsSeccess)
            {
                MessageBox.Show("读取温度异常"); return;
            }
            lbl_dqylcgq.Text = tcpConnection.GetDQYLXS(ref IsSeccess).ToString();
            if (!IsSeccess)
            {
                MessageBox.Show("读取大气压力异常"); return;
            }
            selectZFYFType();
        }

        /// <summary>
        /// 检测正负压阀状态
        /// </summary>
        private void selectZFYFType()
        {
            bool z = false;
            bool f = false;

            tcpConnection.GetZFYF(ref IsSeccess, ref z, ref f);

            if (!IsSeccess)
            {
                MessageBox.Show("读取压阀状态异常");
            }
            if (z)
                btn_z.BackColor = Color.Green;
            else
                btn_z.BackColor = Color.Transparent;
            if (f)
                btn_f.BackColor = Color.Green;
            else
                btn_f.BackColor = Color.Transparent;
        }

        private void hsb_WindControl_Scroll(object sender, ScrollEventArgs e)
        {
            if (hsb_WindControl.Value == 0)
                txt_hz.Text = "0.00";
            else
                txt_hz.Text = (hsb_WindControl.Value * 0.01).ToString();

            double value = (hsb_WindControl.Value * 0.01) * 80;

            tcpConnection.SendFJKZ(value, ref IsSeccess);

            if (!IsSeccess)
            {
                MessageBox.Show("风机控制异常");
            }
        }

        //关闭
        private void tsm_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //收起
        private void tsb_fewer_Click(object sender, EventArgs e)
        {
            this.pl_set.Visible = false;
            this.tsb_fewer.Visible = false;
            this.tsb_open.Visible = true;
        }

        //打开
        private void tsb_open_Click(object sender, EventArgs e)
        {
            this.pl_set.Visible = true;
            this.tsb_open.Visible = false;
            this.tsb_fewer.Visible = true;
        }

        //监控
        private void tsb_RealTimeSurveillance_Click(object sender, EventArgs e)
        {
            if (NetSetIsOk)
            {
                ShowRealTimeSurveillance();
            }
            else
            {
                MessageBox.Show("请先检测设定。");
            }
        }

        private void tsm_surveillance_Click(object sender, EventArgs e)
        {
            if (NetSetIsOk)
            {
                ShowRealTimeSurveillance();
            }
            else
            {
                MessageBox.Show("请先检测设定。");
            }
        }

        //检测设定
        private void tsb_DetectionSet_Click(object sender, EventArgs e)
        {
            NetSetIsOk = false;
            ShowDetectionSet();
        }

        private void tms_DetectionSet_Click(object sender, EventArgs e)
        {
            ShowDetectionSet();
        }

        private void tsm_UpdatePassWord_Click(object sender, EventArgs e)
        {
            UpdatePassWord up = new UpdatePassWord();
            up.Show();
            up.TopMost = true;
        }


        /// <summary>解决关闭按钮bug
        /// 
        /// </summary>
        /// <param name="msg"></param>
        protected override void WndProc(ref Message msg)
        {
            try
            {
                const int WM_SYSCOMMAND = 0x0112;
                const int SC_CLOSE = 0xF060;
                if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
                {
                    // 点击winform右上关闭按钮 
                    this.Dispose();
                    // 加入想要的逻辑处理
                    System.Environment.Exit(0);
                    return;
                }
                base.WndProc(ref msg);
            }
            catch (Exception ex)
            {
                Log.Error("", ex.Message);
            }
        }

        private void tsm_sensorSet_Click(object sender, EventArgs e)
        {
            SensorSet ss = new SensorSet(tcpConnection);
            ss.Show();
            ss.TopMost = true;
        }

        private void tsb_生成报告_Click(object sender, EventArgs e)
        {
            if (NetSetIsOk)
            {
                ExportReport ep = new ExportReport(JYBH);
                ep.Show();
                ep.TopMost = true;
            }
            else
                MessageBox.Show("请先检测设定。");
        }

        /// <summary>
        /// 高压归零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_gyZero_Click(object sender, EventArgs e)
        {
            tcpConnection.SendGYBD(ref IsSeccess);
            if (!IsSeccess)
            {
                MessageBox.Show("高压归零异常");
            }
        }
        /// <summary>
        /// 风速归零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_fsgl_Click(object sender, EventArgs e)
        {
            tcpConnection.SendFSGL(ref IsSeccess);
            if (!IsSeccess)
            {
                MessageBox.Show("风速归零异常");
            }
        }

        private void btn_z_Click(object sender, EventArgs e)
        {
            tcpConnection.SendZYF(ref IsSeccess);

            if (!IsSeccess)
            {
                MessageBox.Show("设置正压阀异常");
            }
            Thread.Sleep(3 * 1000);
            selectZFYFType();
        }

        private void btn_f_Click(object sender, EventArgs e)
        {
            tcpConnection.SendFYF(ref IsSeccess);

            if (!IsSeccess)
            {
                MessageBox.Show("设置负压阀异常");
            }

            Thread.Sleep(3 * 1000);

            selectZFYFType();
        }

        private void btn_OkFj_Click(object sender, EventArgs e)
        {
            //0-50HZ滚动条 标示0-4000值
            double value = double.Parse(txt_hz.Text) * 80;
            tcpConnection.SendFJKZ(value, ref IsSeccess);

            if (!IsSeccess)
            {
                MessageBox.Show("风机控制异常");
            }
        }

        private void yf_time_Tick(object sender, EventArgs e)
        {
            if (tcpConnection.IsOpen)
            {
                GetRegister();
            }
            tcp_type.Text = tcpConnection.IsCommon == true ? "网络连接：开启" : "网络连接：断开";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
            a.TopMost = true;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (NetSetIsOk)
            {
                ComplexAssessment ca = new ComplexAssessment(JYBH);
                if (DefaultBase.IsOpenComplexAssessment)
                {
                    ca.Show();
                    ca.TopMost = true;
                }
            }
            else
                MessageBox.Show("请先检测设定。");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NetSetIsOk)
            {
                pic pic = new pic(JYBH);
                pic.Show();
                pic.TopMost = true;
            }
            else
                MessageBox.Show("请先检测设定。");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SystemManager sm = new SystemManager();
            sm.Show();
            sm.TopMost = true;
        }

    }
}
