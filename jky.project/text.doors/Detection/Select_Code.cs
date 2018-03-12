using text.doors.Common;
using text.doors.dal;
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
    public partial class Select_Code : Form
    {
        public Select_Code()
        {
            InitializeComponent();
        }

        private void btn_Clone_Click(object sender, EventArgs e)
        {
            this.Close();
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

            DataTable dt = new DAL_dt_Settings().Getdt_SettingsByCode(txt_Code.Text);

            if (dt == null)
            {
                MessageBox.Show("暂未查询此编号内容！");
                return;
            }

            var args = new TransmitEventArgs(dt.Rows[0]["dt_Code"].ToString(), dt.Rows[0]["info_DangH"].ToString());
            Transmit(this, args);
            this.Dispose();
        }

        //委托
        public delegate void TransmitHandler(object sender, TransmitEventArgs e);

        //声明一个的事件
        public event TransmitHandler Transmit;
        public class TransmitEventArgs : System.EventArgs
        {
            private string _Code;
            private string _DangHao;

            public TransmitEventArgs(string code, string dangHao)
            {
                this._Code = code;
                this._DangHao = dangHao;

            }
            public string Code { get { return _Code; } }
            public string DangHao { get { return _DangHao; } }
        }

    }
}
