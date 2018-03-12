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
using Young.Core.Common;
using Young.Core.SQLite;

namespace text.doors.Detection
{
    public partial class SystemManager : Form
    {
        public SystemManager()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            string sql = "select * from  dt_BaseSet";
            DataRow dr = SQLiteHelper.ExecuteDataRow(sql);
            if (dr != null)
            {
                DataTable dt = dr.Table;
                txt_IP.Text = dt.Rows[0]["IP"].ToString();
                txt_prot.Text = dt.Rows[0]["PROT"].ToString();
                txt_mm.Text = dt.Rows[0]["D"].ToString();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            var res = MessageUtil.ConfirmYesNo("设置完成后，请重启系统");
            if (res)
            {
                var sql = "delete from dt_BaseSet ";
                SQLiteHelper.ExecuteNonQuery(sql);

                sql = string.Format(@"insert into dt_BaseSet (IP,PROT,D) 
                values('{0}','{1}','{2}')", txt_IP.Text, txt_prot.Text, txt_mm.Text);
                if (SQLiteHelper.ExecuteNonQuery(sql) == 0)
                {
                    MessageBox.Show("保存失败！");
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }
            else { this.Hide(); }
        }
    }
}
