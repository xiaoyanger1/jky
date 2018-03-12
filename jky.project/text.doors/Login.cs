using text.doors.Common;
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

namespace text.doors
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Init();
        }


        private string UserName = "administrator";
        private void Init()
        {
            //WindowsIdentity identity = WindowsIdentity.GetCurrent();
            //WindowsPrincipal principal = new WindowsPrincipal(identity);
            //if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            //{
            txt_userID.Text = UserName;
            this.txt_passWord.Focus();
            //}
            //else
            //{
            //    lbl_LoginType.Text = "请使用管理员身份登录！";
            //    btn_login.Enabled = false;
            //}
        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            if (txt_passWord.Text == "")
            {
                lbl_LoginType.Text = "密码不能为空";
                return;
            }

            string sql = "select * from  User where User_Name='" + UserName + "'";
            DataTable dt = SQLiteHelper.ExecuteDataRow(sql).Table;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("账户出现问题，请联系管理员！");
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
