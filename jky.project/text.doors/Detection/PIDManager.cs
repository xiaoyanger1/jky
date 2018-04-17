﻿using text.doors.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace text.doors.Detection
{
    public partial class PIDManager : Form
    {
        private TCPClient tcpClient;
        public PIDManager(TCPClient tcpConnection)
        {
            InitializeComponent();
            this.tcpClient = tcpConnection;
            Init();
        }
        private void Init()
        {
            if (!tcpClient.IsTCPLink)
                MessageBox.Show("连接未打开暂时不能设置PID！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

            bool IsSuccess = false;
            var P = tcpClient.GetPID("P", ref IsSuccess);
            var I = tcpClient.GetPID("I", ref IsSuccess);
            var D = tcpClient.GetPID("D", ref IsSuccess);

            var _P = tcpClient.GetPID("_P", ref IsSuccess);
            var _I = tcpClient.GetPID("_I", ref IsSuccess);
            var _D = tcpClient.GetPID("_D", ref IsSuccess);

            txthp.Text = P.ToString();
            txthi.Text = I.ToString();
            txthd.Text = D.ToString();

            txth_p.Text = _P.ToString();
            txth_i.Text = _I.ToString();
            txth_d.Text = _D.ToString();
        }

        private void btnhp_Click(object sender, EventArgs e)
        {
            double P = int.Parse(txthp.Text);
            var res = tcpClient.SendPid("P", P);
            if (!res)
            {
                MessageBox.Show("连接未打开暂时不能设置PID！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }

        }

        private void btnhi_Click(object sender, EventArgs e)
        {
            double I = int.Parse(txthi.Text);
            var res = tcpClient.SendPid("I", I);
            if (!res)
            {
                MessageBox.Show("连接未打开暂时不能设置PID！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        private void btnhd_Click(object sender, EventArgs e)
        {
            double D = int.Parse(btnhd.Text);
            var res = tcpClient.SendPid("D", D);
            if (!res)
            {
                MessageBox.Show("连接未打开暂时不能设置PID！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        private void btnh_p_Click(object sender, EventArgs e)
        {
            double p = int.Parse(btnh_p.Text);
            var res = tcpClient.SendPid("_P", p);
            if (!res)
            {
                MessageBox.Show("连接未打开暂时不能设置PID！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        private void btnh_i_Click(object sender, EventArgs e)
        {
            double i = int.Parse(btnh_i.Text);
            var res = tcpClient.SendPid("_I", i);
            if (!res)
            {
                MessageBox.Show("连接未打开暂时不能设置PID！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }

        }

        private void btnh_d_Click(object sender, EventArgs e)
        {
            double D = int.Parse(btnh_d.Text);
            var res = tcpClient.SendPid("_D", D);
            if (!res)
            {
                MessageBox.Show("连接未打开暂时不能设置PID！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }
    }
}
