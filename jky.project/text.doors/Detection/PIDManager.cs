using text.doors.Common;
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
        private TcpConnection tcpConnection;
        public PIDManager(TcpConnection tcpConnection)
        {

            InitializeComponent();
            this.tcpConnection = tcpConnection;
            Init();
        }
        private void Init()
        {
            if (tcpConnection.IsOpen)
            {
                bool IsSuccess = false;
                var P = tcpConnection.GetPID(ref IsSuccess, "P");
                var I = tcpConnection.GetPID(ref IsSuccess, "I");
                var D = tcpConnection.GetPID(ref IsSuccess, "D");

                txthp.Text = P.ToString();
                txthi.Text = I.ToString();
                txthd.Text = D.ToString();
            }
            else
            {
                MessageBox.Show("连接未打开暂时不能设置PID");
            }

        }

        private void btnhp_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpConnection.IsOpen)
                {
                    bool IsSuccess = false;
                    double P = int.Parse(txthp.Text);
                    tcpConnection.SendPid(ref IsSuccess, "P", P);
                }
                else
                {
                    MessageBox.Show("连接未打开暂时不能设置PID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("P设置异常");
            }

        }

        private void btnhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpConnection.IsOpen)
                {
                    bool IsSuccess = false;
                    double I = int.Parse(txthi.Text);

                    tcpConnection.SendPid(ref IsSuccess, "I", I);
                }
                else
                {
                    MessageBox.Show("连接未打开暂时不能设置PID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("I设置异常");
            }
        }

        private void btnhd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpConnection.IsOpen)
                {
                    bool IsSuccess = false;
                    double D = int.Parse(btnhd.Text);

                    tcpConnection.SendPid(ref IsSuccess, "D", D);
                }
                else
                {
                    MessageBox.Show("连接未打开暂时不能设置PID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("D设置异常");
            }
        }
    }
}
