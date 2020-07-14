using SPIC_200.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPIC_200
{
    public partial class SeleteData : Form
    {
        public SeleteData()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Code.Text))
            {
                MessageBox.Show("请输入编号", " 请输入编号",
                             MessageBoxButtons.OKCancel,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.ServiceNotification
                            );
                return;
            }

            if (!new DAL_SPIC_TEST_SET().IsExist(txt_Code.Text))
            {
                MessageBox.Show("暂未查询此编号内容！");
                return;
            }
            Program.SetCode(txt_Code.Text);

            var args = new TransmitEventArgs();
            Transmit(this, args);
            this.Dispose();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //委托
        public delegate void TransmitHandler(object sender, TransmitEventArgs e);

        //声明一个的事件
        public event TransmitHandler Transmit;
        public class TransmitEventArgs : System.EventArgs
        {
            public TransmitEventArgs()
            {
            }
        }

    }
}
