using SPIC_200.DAL;
using SPIC200.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPIC_200
{
    public partial class CommList : Form
    {
        public CommList()
        {
            InitializeComponent();
            Init();
            BindIP();

        }

        private void Init()
        {
            txt_btl.Enabled = false;

            var com = "2";
            var count = "1";

            new DAL_CommList().GetCommon(ref com, ref count);

            cbb_com.Text = com;
            cbb_count.Text = count;
        }



        private void RB_WIFI_CheckedChanged(object sender, EventArgs e)
        {
            txt_btl.Enabled = false;
            txt_ip.Enabled = true;
        }

        private void RB_USB_CheckedChanged(object sender, EventArgs e)
        {
            txt_btl.Enabled = true;
            txt_ip.Enabled = false;
        }

        private void BindIP()
        {

            this.list_IP.Items.Clear();
            this.list_IP.Columns.Clear();
            this.list_IP.GridLines = true; //显示表格线
            this.list_IP.View = View.Details;//显示表格细节
            this.list_IP.LabelEdit = true; //是否可编辑,ListView只可编辑第一列。
            this.list_IP.Scrollable = true;//有滚动条
            this.list_IP.HeaderStyle = ColumnHeaderStyle.Clickable;//对表头进行设置
            this.list_IP.FullRowSelect = true;//是否可以选择行

            this.list_IP.Columns.Add("IP", 166);
            var list = new DAL_CommList().GetIp();

            ListViewItem[] p = new ListViewItem[list.Count()];

            for (int i = 0; i < list.Count; i++)
            {
                p[i] = new ListViewItem(new string[] { list[i] });
            }
            this.list_IP.Items.AddRange(p);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ip.Text))
            {
                MessageBox.Show("请填写IP");
                return;
            }

            if (int.Parse(SQLiteHelper.ExecuteDataRow("select count(*) from COMM_IP where IP = '" + txt_ip.Text + "'").Table.Rows[0][0].ToString()) > 0)
            {
                MessageBox.Show("IP重复");
                return;
            }

            if (SQLiteHelper.ExecuteNonQuery("insert into COMM_IP values('" + txt_ip.Text + "')") == 0)
                MessageBox.Show("添加失败");

            BindIP();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Program._SB_BTL = int.Parse(txt_btl.Text);
            Program._SB_COM = int.Parse(cbb_com.Text);
            Program._SB_Count = int.Parse(cbb_count.Text);
            new DAL_CommList().Add(cbb_com.Text, cbb_count.Text);
            MessageBox.Show("保存成功");
            this.Close();
        }

        private void list_IP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.cms_delete.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void cms_delete_Click(object sender, EventArgs e)
        {
            int length = list_IP.SelectedItems.Count;
            for (int i = 0; i < length; i++)
            {

                if (SQLiteHelper.ExecuteNonQuery("delete from COMM_IP where IP = '" + list_IP.SelectedItems[i].SubItems[0].Text + "'") > 0)
                    MessageBox.Show("删除成功");
                else
                    MessageBox.Show("删除失败");
                BindIP();
            }
        }
    }
}
