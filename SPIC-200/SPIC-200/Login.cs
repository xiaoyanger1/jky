using SPIC200.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Young.Core.Common;

namespace SPIC_200
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Init()
        {
            //WindowsIdentity identity = WindowsIdentity.GetCurrent();
            //WindowsPrincipal principal = new WindowsPrincipal(identity);
            //if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            //{
            txt_userID.Focus();
            //txt_userID.Text = UserName;
            //this.txt_passWord.Focus();
            //}
            //else
            //{
            //    lbl_LoginType.Text = "请使用管理员身份登录！";
            //    btn_login.Enabled = false;
            //}
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_userID.Text == "")
            {
                lbl_LoginType.Text = "账号不能为空";
                return;
            }

            if (txt_passWord.Text == "")
            {
                lbl_LoginType.Text = "密码不能为空";
                return;
            }

            string sql = "select * from  User where User_Name='" + txt_userID.Text + "'";
            DataTable dt = SQLiteHelper.ExecuteDataRow(sql).Table;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageUtil.ShowTips("账户出现问题，请联系管理员！");
            }

            if (!string.IsNullOrWhiteSpace(dt.Rows[0]["User_PassWord"].ToString()))
            {
                if (txt_passWord.Text == dt.Rows[0]["User_PassWord"].ToString())
                {
                    this.DialogResult = DialogResult.OK;//关键:设置登陆成功状态  
                    this.Close();
                }
                else
                {
                    lbl_LoginType.Text = "密码输入错误！";
                    return;
                }
            }
        }
    }
}
