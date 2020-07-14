using Jky.Public.Common;
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

namespace SPIC_200
{
    public partial class ExportReport : Form
    {
        public ExportReport()
        {
            InitializeComponent();
            cm_Report.SelectedIndex = 0;
        }


        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (cm_Report.SelectedIndex == 0)
            {
                MessageBox.Show("请选择模板！", "请选择模板！",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.ServiceNotification
                           );
                return;
            }

            Eexport(cm_Report.SelectedItem.ToString());
        }

        private void Eexport(string fileName)
        {
            try
            {
                string strResult = string.Empty;
                string strPath = Application.StartupPath + "\\template";
                string strFile = string.Format(@"{0}\{1}", strPath, "建筑外墙采光" + fileName);

                FolderBrowserDialog path = new FolderBrowserDialog();
                path.ShowDialog();

                label3.Visible = true;

                btn_ok.Enabled = false;
                cm_Report.Enabled = false;
                btn_close.Enabled = false;

                string[] name = fileName.Split('.');

                string _name = name[0] + "_" + Program.GetCode() + "." + name[1];

                var saveExcelUrl = path.SelectedPath + "\\" + _name;

                Model_SPIC_TEST_SET SPIC_TEST_SET = new DAL_SPIC_TEST_SET().SeleteByTime(Program.GetCode());

                if (SPIC_TEST_SET == null)
                {
                    MessageBox.Show("未查询到相关编号");
                    return;
                }

                var dc = new Dictionary<string, string>();
                if (fileName == "性能分级及检测报告.doc")
                {
                    dc = GetResult(SPIC_TEST_SET);
                }
                else if (fileName == "性能分级及检测记录.doc")
                {
                    dc = GetDataResult(SPIC_TEST_SET);
                }

                WordUtility wu = new WordUtility(strFile, saveExcelUrl);
                if (wu.GenerateWordByBookmarks(dc))
                {
                    label3.Visible = false;

                    MessageBox.Show("导出成功", "导出成功",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.None,
                             MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.ServiceNotification
                            );
                    this.Hide();
                }
                else { this.Hide(); }
            }
            catch (Exception ex)
            {
                Log.Error("ExportReport.Eexport", "message:" + ex.Message + "\r\nsource:" + ex.Source + "\r\nStackTrace:" + ex.StackTrace);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
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
            dc.Add("样品名称1", SPIC_TEST_SET.SJMC);

            var az = "0";
            var xz = "0";
            var color = "0";
            List<LightData> List_LightData_AZ = new LightData().GetListData(TEST_TYPE.透光投射指数检测_安装, Program._TTNum, ref  az);

            List<LightData> List_LightData_XZ = new LightData().GetListData(TEST_TYPE.透光投射指数检测_卸载, Program._TTNum, ref  xz);

            List<LightData> List_ColorData = new LightData().GetListData(TEST_TYPE.颜色投射指数检测, Program._SB_Count, ref  color);

            dc.Add("透光折减系数2", az);
            dc.Add("透光折减系数级数2", GetTG(double.Parse(az)).ToString());
            dc.Add("颜色投射指数2", color);
            dc.Add("颜色投射指数级别2", GetYS(double.Parse(color)));
            return dc;
        }



        /// <summary>
        /// 获取报告数据详情
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetDataResult(Model_SPIC_TEST_SET SPIC_TEST_SET)
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
            dc.Add("样品名称1", SPIC_TEST_SET.SJMC);


            var az = "0";
            var xz = "0";
            var color = "0";
            List<LightData> List_LightData_AZ = new LightData().GetListData(TEST_TYPE.透光投射指数检测_安装, Program._TTNum, ref  az);
            if (List_LightData_AZ != null && List_LightData_AZ.Count > 0)
            {
                var data_1 = List_LightData_AZ.Find(t => t.Index == 1);
                if (data_1 != null)
                {
                    dc.Add("安装1_1", data_1.First.ToString());
                    dc.Add("安装1_2", data_1.Second.ToString());
                    dc.Add("安装1_3", data_1.Third.ToString());
                }
                var data_2 = List_LightData_AZ.Find(t => t.Index == 2);
                if (data_2 != null)
                {
                    dc.Add("安装2_1", data_2.First.ToString());
                    dc.Add("安装2_2", data_2.Second.ToString());
                    dc.Add("安装2_3", data_2.Third.ToString());
                }
                var data_3 = List_LightData_AZ.Find(t => t.Index == 3);
                if (data_3 != null)
                {
                    dc.Add("安装3_1", data_3.First.ToString());
                    dc.Add("安装3_2", data_3.Second.ToString());
                    dc.Add("安装3_3", data_3.Third.ToString());
                }
                var data_4 = List_LightData_AZ.Find(t => t.Index == 4);
                if (data_4 != null)
                {
                    dc.Add("安装4_1", data_4.First.ToString());
                    dc.Add("安装4_2", data_4.Second.ToString());
                    dc.Add("安装4_3", data_4.Third.ToString());
                }
                var data_5 = List_LightData_AZ.Find(t => t.Index == 999);
                if (data_5 != null)
                {
                    dc.Add("安装vga_1", data_5.First.ToString());
                    dc.Add("安装vga_2", data_5.Second.ToString());
                    dc.Add("安装vga_3", data_5.Third.ToString());
                }
                dc.Add("安装vga_4", az);
            }
            List<LightData> List_LightData_XZ = new LightData().GetListData(TEST_TYPE.透光投射指数检测_卸载, Program._TTNum, ref  xz);
            if (List_LightData_XZ != null && List_LightData_XZ.Count > 0)
            {
                var data_1 = List_LightData_XZ.Find(t => t.Index == 1);
                if (data_1 != null)
                {
                    dc.Add("卸载1_1", data_1.First.ToString());
                    dc.Add("卸载1_2", data_1.Second.ToString());
                    dc.Add("卸载1_3", data_1.Third.ToString());
                }
                var data_2 = List_LightData_XZ.Find(t => t.Index == 2);
                if (data_2 != null)
                {
                    dc.Add("卸载2_1", data_2.First.ToString());
                    dc.Add("卸载2_2", data_2.Second.ToString());
                    dc.Add("卸载2_3", data_2.Third.ToString());
                }
                var data_3 = List_LightData_XZ.Find(t => t.Index == 3);
                if (data_3 != null)
                {
                    dc.Add("卸载3_1", data_3.First.ToString());
                    dc.Add("卸载3_2", data_3.Second.ToString());
                    dc.Add("卸载3_3", data_3.Third.ToString());
                }
                var data_4 = List_LightData_XZ.Find(t => t.Index == 4);
                if (data_4 != null)
                {
                    dc.Add("卸载4_1", data_4.First.ToString());
                    dc.Add("卸载4_2", data_4.Second.ToString());
                    dc.Add("卸载4_3", data_4.Third.ToString());
                }
                var data_5 = List_LightData_XZ.Find(t => t.Index == 999);
                if (data_5 != null)
                {
                    dc.Add("卸载vga_1", data_5.First.ToString());
                    dc.Add("卸载vga_2", data_5.Second.ToString());
                    dc.Add("卸载vga_3", data_5.Third.ToString());
                }
                dc.Add("卸载vga_4", xz);
            }
            List<LightData> List_ColorData = new LightData().GetListData(TEST_TYPE.颜色投射指数检测, Program._SB_Count, ref  color);
            if (List_ColorData != null && List_ColorData.Count > 0)
            {
                var data_1 = List_ColorData.Find(t => t.Index == 1);
                if (data_1 != null)
                {
                    dc.Add("颜色1_1", data_1.First.ToString());
                    dc.Add("颜色1_2", data_1.Second.ToString());
                    dc.Add("颜色1_3", data_1.Third.ToString());
                }
                var data_2 = List_ColorData.Find(t => t.Index == 2);
                if (data_2 != null)
                {
                    dc.Add("颜色2_1", data_2.First.ToString());
                    dc.Add("颜色2_2", data_2.Second.ToString());
                    dc.Add("颜色2_3", data_2.Third.ToString());
                }
                var data_5 = List_ColorData.Find(t => t.Index == 999);
                if (data_5 != null)
                {
                    dc.Add("颜色vga_1", data_5.First.ToString());
                    dc.Add("颜色vga_2", data_5.Second.ToString());
                    dc.Add("颜色vga_3", data_5.Third.ToString());
                }
                dc.Add("颜色vga_4", color);
            }

            dc.Add("透光折减系数2", az);
            dc.Add("透光折减系数级数2", GetTG(double.Parse(az)).ToString());
            dc.Add("颜色投射指数2", color);
            dc.Add("颜色投射指数级别2", GetYS(double.Parse(color)));
            return dc;
        }


        /// <summary>
        /// 获取透光 折减系数
        /// </summary>
        /// <returns></returns>
        private int GetTG(double value)
        {
            if (value < 0.2)
            {
                return 0;
            }
            else if (value >= 0.2 && 0.3 > value)
            {
                return 1;
            }
            else if (value >= 0.3 && 0.4 > value)
            {
                return 2;
            }
            else if (value >= 0.4 && 0.5 > value)
            {
                return 3;
            }
            else if (value >= 0.5 && 0.6 > value)
            {
                return 4;
            }
            else if (value <= 0.6)
            {
                return 5;
            }
            return 0;
        }

        /// <summary>
        /// 获取颜色 折减系数
        /// </summary>
        /// <returns></returns>
        private string GetYS(double value)
        {
            if (value >= 90)
            {
                return "1A";
            }
            else if (value >= 80 && 90 > value)
            {
                return "1B";
            }
            else if (value >= 70 && 80 > value)
            {
                return "2A";
            }
            else if (value >= 60 && 70 > value)
            {
                return "2B";
            }
            else if (value >= 40 && 60 > value)
            {
                return "3";
            }
            else if (value >= 20 && 40 > value)
            {
                return "4";
            }
            return "0";
        }

    }
}
