using Jky.Public.Common;
using SPIC_200.API;
using SPIC_200.DAL;
using SPIC_200.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPIC_200
{
    public partial class MainForm : Form
    {
        private static string _code = "";
        public MainForm()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {


            var com = "2";
            var count = "1";

            new DAL_CommList().GetCommon(ref com, ref count);

            Program._SB_COM = int.Parse(com);
            Program._SB_Count = int.Parse(count);

            Thread t = new Thread(InitSB);
            t.Start();
            ShowSPIC_TEST_SET();
        }
        private void InitSB()
        {
            //初始化光谱仪
            SPIC200BAPI.SPIC_Initialization();

            Invoke(new MethodInvoker(delegate()
            {
                tss_Init.Text = "设备初始化完成！";
            }));
        }

        /// <summary>
        /// 参数设置
        /// </summary>
        private void ShowSPIC_TEST_SET()
        {
            SPIC_TEST_SET ds = new SPIC_TEST_SET();
            ds.deleBottomTypeEvent += new SPIC_TEST_SET.deleBottomType(SetCode);
            ds.Show();
            ds.TopLevel = true;
        }

        private void SetCode(SPIC_TEST_SET.BottomType bt)
        {
            this.tssl_code.Text = bt._Code;
            _code = bt._Code;
            if (bt.IsOpenTest)
            {
                ShowSPIC_TEST();
            }
        }
        /// <summary>
        /// 检测
        /// </summary>
        private void ShowSPIC_TEST()
        {
            SPIC_TEST ds = new SPIC_TEST();
            ds.Show();
            ds.TopLevel = true;
        }

        private void tsb_DetectionSet_Click(object sender, EventArgs e)
        {

        }

        private void tsb_RealTimeSurveillance_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Program.GetCode()))
                ShowSPIC_TEST();
            else
            {
                var res = MessageUtil.ConfirmYesNo("未完成检测设定，是否设置？");
                if (res)
                    ShowSPIC_TEST_SET();
            }
        }

        #region --下载
        private void tsb_生成报告_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Program.GetCode()))
            {
                ExportReport er = new ExportReport();
                er.Show();
            }
            else
            {
                var res = MessageUtil.ConfirmYesNo("未完成检测设定，是否设置？");
                if (res)
                {
                    ShowSPIC_TEST_SET();
                }
            }
        }




        /// <summary>
        /// 获取报告文档
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetResult(Model_SPIC_TEST_SET SPIC_TEST_SET)
        {
            Dictionary<string, string> dc = new Dictionary<string, string>();
            dc.Add("光源类型2", SPIC_TEST_SET.GYLX);
            dc.Add("委托人2", SPIC_TEST_SET.WTR);
            dc.Add("委托单位1", SPIC_TEST_SET.WTDW);
            dc.Add("委托单位2", SPIC_TEST_SET.WTDW);
            dc.Add("日期2", SPIC_TEST_SET.SJRQ);
            dc.Add("日期3", SPIC_TEST_SET.SJRQ);
            dc.Add("日期4", SPIC_TEST_SET.SJRQ);
            dc.Add("送检日期2", SPIC_TEST_SET.SJRQ);
            dc.Add("材料厚度2", SPIC_TEST_SET.CLHD);
            dc.Add("材料型号2", SPIC_TEST_SET.CLXH);
            dc.Add("材料颜色2", SPIC_TEST_SET.CLYS);
            dc.Add("框挺类型2", SPIC_TEST_SET.KTLX);
            dc.Add("框挺颜色2", SPIC_TEST_SET.KTYS);
            dc.Add("检验单位2", SPIC_TEST_SET.JYDW);
            dc.Add("检验类别1", SPIC_TEST_SET.JYLB);
            dc.Add("检验类别2", SPIC_TEST_SET.JYLB);
            dc.Add("检验编号1", SPIC_TEST_SET.JCBH);
            dc.Add("检验编号2", SPIC_TEST_SET.JCBH);
            dc.Add("检验编号3", SPIC_TEST_SET.JCBH);
            dc.Add("检验编号4", SPIC_TEST_SET.JCBH);
            dc.Add("检验设备2", SPIC_TEST_SET.JYSB);
            dc.Add("检验项目2", SPIC_TEST_SET.JYSB);
            dc.Add("漫射光照射条件2", SPIC_TEST_SET.MSGZSTJ);
            dc.Add("生产单位2", SPIC_TEST_SET.SCDW);
            dc.Add("见证人2", SPIC_TEST_SET.JZR);
            dc.Add("见证单位2", SPIC_TEST_SET.JZDW);
            dc.Add("设备编号2", SPIC_TEST_SET.SBBH);
            dc.Add("试件名称2", SPIC_TEST_SET.SJMC);
            dc.Add("试件尺寸2", SPIC_TEST_SET.SJCC);
            dc.Add("试件类型2", SPIC_TEST_SET.SJLX);
            dc.Add("采光材料种类2", SPIC_TEST_SET.CGCLZL);
            dc.Add("采样方式2", SPIC_TEST_SET.CYFS);
            dc.Add("审核人2", "");
            dc.Add("审核人3", "");
            dc.Add("审核人4", "");
            dc.Add("批准人2", "");
            dc.Add("批准人3", "");
            dc.Add("批准人4", "");
            dc.Add("样品名称1", "");
            dc.Add("检验人2", "");
            dc.Add("检验人3", "");
            dc.Add("检验人4", "");

            dc.Add("透光折减系数2", "");
            dc.Add("透光折减系数级数2", "");
            dc.Add("颜色投射指数2", "");
            dc.Add("颜色投射指数级别2", "");
            return dc;
        }

        #endregion




        private void tsbtn_about_Click(object sender, EventArgs e)
        {
            SPIC_ABOUT SPIC_ABOUT_Form = new SPIC_ABOUT();
            SPIC_ABOUT_Form.Show();
            SPIC_ABOUT_Form.TopMost = true;
        }

        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sys_pwd sys = new Sys_pwd();
            sys.Show();
            sys.TopMost = true;
        }

        private void 通讯设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CommList cl = new CommList();
            cl.Show();
            //cl.TopMost = true;
        }

        //<summary>
        //解决关闭按钮bug
        //</summary>
        //<param name="msg"></param>
        //protected override void WndProc(ref Message msg)
        //{
        //    try
        //    {
        //        const int WM_SYSCOMMAND = 0x0112;
        //        const int SC_CLOSE = 0xF060;
        //        if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
        //        {
        //            // 点击winform右上关闭按钮 
        //            this.Dispose();
        //            // 加入想要的逻辑处理
        //            System.Environment.Exit(0);
        //            return;
        //        }
        //        base.WndProc(ref msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("", ex.Message);
        //    }
        //}
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShowSPIC_TEST_SET();
        }

    }
}
