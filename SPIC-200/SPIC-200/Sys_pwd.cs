using SPIC200.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Young.Core.Common;

namespace SPIC_200
{
    public partial class Sys_pwd : Form
    {
        public Sys_pwd()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string userName = "admin";
            if (string.IsNullOrWhiteSpace(txt_oldPassWord.Text))
            {
                MessageUtil.ShowTips("请输入原始密码:");
            }
            if (string.IsNullOrWhiteSpace(txt_NewPassWord.Text))
            {
                MessageUtil.ShowTips("请输入新密码:");
            }
            string sql = "select User_PassWord from User where User_Name='" + userName + "'";
            DataTable dt = SQLiteHelper.ExecuteDataRow(sql).Table;
            if (dt != null && dt.Rows.Count > 0)
            {
                var passWord = "";
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["User_PassWord"].ToString()))
                {
                    passWord = dt.Rows[0]["User_PassWord"].ToString();
                }
                if (passWord == txt_oldPassWord.Text)
                {
                    string sqlUpdate = @"update User set User_PassWord='" + txt_NewPassWord.Text + "' where User_Name='" + userName + "'";
                    var i = SQLiteHelper.ExecuteNonQuery(sqlUpdate);
                    if (i > 0)
                    {
                        MessageUtil.ShowTips("修改成功！");
                        this.Close();
                    }
                }
                else
                {
                    MessageUtil.ShowTips("原始密码输入错误！");
                }
            }
            else
            {
                MessageUtil.ShowTips("暂未找到用户，请联系系统管理员！");
            }
        }
    }
}
