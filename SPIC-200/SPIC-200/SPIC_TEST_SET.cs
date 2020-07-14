using SPIC_200.DAL;
using SPIC_200.Model;
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
    public partial class SPIC_TEST_SET : Form
    {
        public SPIC_TEST_SET()
        {
            InitializeComponent();
            _Init();
        }

        private void _Init()
        {
            DAL_SPIC_TEST_SET dal = new DAL_SPIC_TEST_SET();
            var model_SPIC_TEST_SET = dal.SeleteByTime(Program.GetCode());
            if (model_SPIC_TEST_SET != null)
            {
                this.txt_jcbh.Text = model_SPIC_TEST_SET.JCBH;
                this.txt_wtdw.Text = model_SPIC_TEST_SET.WTDW;
                this.txt_jzdw.Text = model_SPIC_TEST_SET.JZDW;
                this.txt_scdw.Text = model_SPIC_TEST_SET.SCDW;
                this.txt_jydw.Text = model_SPIC_TEST_SET.JYDW;
                this.txt_jyxm.Text = model_SPIC_TEST_SET.JYXM;
                this.txt_sjmc.Text = model_SPIC_TEST_SET.SJMC;
                this.txt_sjlx.Text = model_SPIC_TEST_SET.SJLX;
                this.txt_cgclzl.Text = model_SPIC_TEST_SET.CGCLZL;
                this.txt_clhd.Text = model_SPIC_TEST_SET.CLHD;
                this.txt_ktlx.Text = model_SPIC_TEST_SET.KTLX;
                this.cbb_gylx.Text = model_SPIC_TEST_SET.GYLX;
                this.txt_sjrq.Text = model_SPIC_TEST_SET.SJRQ;
                this.txt_ktys.Text = model_SPIC_TEST_SET.KTYS;
                this.txt_clys.Text = model_SPIC_TEST_SET.CLYS;
                this.txt_clxh.Text = model_SPIC_TEST_SET.CLXH;
                this.txt_sjcc.Text = model_SPIC_TEST_SET.SJCC;
                this.txt_sbbh.Text = model_SPIC_TEST_SET.SBBH;
                this.txt_jysb.Text = model_SPIC_TEST_SET.JYSB;
                this.txt_jylb.Text = model_SPIC_TEST_SET.JYLB;
                this.cbb_cyfs.Text = model_SPIC_TEST_SET.CYFS;
                this.txt_jzr.Text = model_SPIC_TEST_SET.JZR;
                this.txt_wtr.Text = model_SPIC_TEST_SET.WTR;
                this.txt_wtbh.Text = model_SPIC_TEST_SET.WTBH;
                this.txt_msgzstj.Text = model_SPIC_TEST_SET.MSGZSTJ;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (check())
            {
                if (new DAL_SPIC_TEST_SET().IsExist(txt_jcbh.Text))
                {
                    var res = MessageUtil.ConfirmYesNo("已存在编号，是否覆盖？");
                    if (res)
                    {
                        new DAL_SPIC_TEST_SET().Delete(txt_jcbh.Text);
                    }
                    else
                    {
                        return;
                    }
                }

                Program.SetCode(txt_jcbh.Text);

                Model_SPIC_TEST_SET model_SPIC_TEST_SET = new Model_SPIC_TEST_SET();
                model_SPIC_TEST_SET.JCBH = txt_jcbh.Text;
                model_SPIC_TEST_SET.WTDW = txt_wtdw.Text;
                model_SPIC_TEST_SET.JZDW = txt_jzdw.Text;
                model_SPIC_TEST_SET.SCDW = txt_scdw.Text;
                model_SPIC_TEST_SET.JYDW = txt_jydw.Text;
                model_SPIC_TEST_SET.JYXM = txt_jyxm.Text;
                model_SPIC_TEST_SET.SJMC = txt_sjmc.Text;
                model_SPIC_TEST_SET.SJLX = txt_sjlx.Text;
                model_SPIC_TEST_SET.CGCLZL = txt_cgclzl.Text;
                model_SPIC_TEST_SET.CLHD = txt_clhd.Text;
                model_SPIC_TEST_SET.KTLX = txt_ktlx.Text;
                model_SPIC_TEST_SET.GYLX = cbb_gylx.Text;
                model_SPIC_TEST_SET.SJRQ = txt_sjrq.Text;
                model_SPIC_TEST_SET.KTYS = txt_ktys.Text;
                model_SPIC_TEST_SET.CLYS = txt_clys.Text;
                model_SPIC_TEST_SET.CLXH = txt_clxh.Text;
                model_SPIC_TEST_SET.SJCC = txt_sjcc.Text;
                model_SPIC_TEST_SET.SBBH = txt_sbbh.Text;
                model_SPIC_TEST_SET.JYSB = txt_jysb.Text;
                model_SPIC_TEST_SET.JYLB = txt_jylb.Text;
                model_SPIC_TEST_SET.CYFS = cbb_cyfs.Text;
                model_SPIC_TEST_SET.JZR = txt_jzr.Text;
                model_SPIC_TEST_SET.WTR = txt_wtr.Text;
                model_SPIC_TEST_SET.WTBH = txt_wtbh.Text;
                model_SPIC_TEST_SET.MSGZSTJ = txt_msgzstj.Text;
                if (!new DAL_SPIC_TEST_SET().Add(model_SPIC_TEST_SET))
                {
                    MessageUtil.ShowError("新设失败！");
                }
                else
                {
                    var res = MessageUtil.ConfirmYesNo("新设成功，是否开始检测？");
                    this.Hide();
                    deleBottomTypeEvent(SetType(res));
                }
            }
        }
        #region 底部状态栏赋值

        private BottomType SetType(bool ISOK)
        {
            BottomType bt = new BottomType(txt_jcbh.Text, ISOK);
            return bt;
        }

        //委托
        public delegate void deleBottomType(BottomType bottomType);
        public deleBottomType deleBottomTypeEvent;//委托事件

        /// <summary>
        /// 底部状态栏
        /// </summary>
        public class BottomType
        {
            public string _Code;
            public bool IsOpenTest;

            public BottomType(string code, bool IsOpenTest)
            {
                this._Code = code;
                this.IsOpenTest = IsOpenTest;
            }
        }
        #endregion


        /// <summary>
        /// 验证填写数据
        /// </summary>
        /// <returns></returns>
        private bool check()
        {
            if (string.IsNullOrWhiteSpace(txt_jcbh.Text))
            {
                MessageUtil.ShowWarning("请填写检测编号！");
                return false;
            }
            return true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_jcbh.Text))
            {
                MessageBox.Show("请输入编号");
            }
            var arr = txt_jcbh.Text.Split('-');
            if (arr.Length == 1)
            {
                MessageBox.Show("编号格式有误，请输入如d-1格式");
                return;
            }
            txt_jcbh.Text = arr[0] + "-" + (int.Parse(arr[1]) + 1).ToString();

            this.btn_add.Enabled = false;
            this.btn_select.Enabled = false;
            this.btn_delete.Enabled = false;
            this.btn_Ok.Enabled = true;
        }

        private void selectCode(object sender, SeleteData.TransmitEventArgs e)
        {
            _Init();
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            SeleteData sd = new SeleteData();
            sd.Transmit += new SeleteData.TransmitHandler(selectCode);
            sd.Show();
            sd.TopLevel = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var res = MessageUtil.ConfirmYesNo("是否删除？");
            if (res)
            {
                if (new DAL_SPIC_TEST_SET().Delete(txt_jcbh.Text))
                {
                    MessageBox.Show("成功");
                    Program.SetCode("");
                    _Init();
                }
            }
        }
    }
}
