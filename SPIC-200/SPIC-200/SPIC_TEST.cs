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
using Young.Core.Common;

namespace SPIC_200
{
    public partial class SPIC_TEST : Form
    {

        /// <summary>
        /// 当前选择设置选项
        /// </summary>
        private TEST_TYPE TEST_TYPE_ENUM = TEST_TYPE.透光投射指数检测_安装;

        private string _CODE = Program.GetCode();

        /// <summary>
        /// 安装
        /// </summary>
        private List<LightData> List_LightData_AZ = new List<LightData>();

        /// <summary>
        /// 卸载
        /// </summary>
        private List<LightData> List_LightData_XZ = new List<LightData>();

        /// <summary>
        /// 卸载
        /// </summary>
        private List<LightData> List_ColorData = new List<LightData>();

        public List<string> IPLIST = new DAL_CommList().GetIp();

        /// <summary>
        /// 探头数量
        /// </summary>
        //private int TTNum = 0;

        public SPIC_TEST()
        {
            InitializeComponent();
            _Init();
        }

        private void _Init()
        {
            GetZDJCount();
            DataInit();
            BindLight_AZ();
            BindLight_XZ();
            BindColorData();
        }
        /// <summary>
        /// 数据初始化
        /// </summary>
        private void DataInit()
        {
            var az = "0";
            var xz = "0";
            var color = "0";
            List_LightData_AZ = new LightData().GetListData(TEST_TYPE.透光投射指数检测_安装, Program._TTNum, ref  az);
            List_LightData_XZ = new LightData().GetListData(TEST_TYPE.透光投射指数检测_卸载, Program._TTNum, ref  xz);
            List_ColorData = new LightData().GetListData(TEST_TYPE.颜色投射指数检测, Program._SB_Count, ref  color);

            txt_az.Text = az;
            txt_xz.Text = xz;
            txt_color.Text = color;
        }

        /// <summary>
        /// 获取照度计及初始化
        /// </summary>
        private void GetZDJCount()
        {
            var res = Z10API.Z10DLL_SetCom(Program._SB_COM, Program._SB_BTL);
            if (res == 0)
            {
                MessageBox.Show("设置通讯口失败！");
                tss_ibl_jcz.Text = "设置通讯口失败！";
            }
            //iNum返回探头数
            int iCurNo = 0; int[] iAllNo = new[] { 1, 1 };
            res = Z10API.Z10DLL_GetHeadNum(ref Program._TTNum, ref iCurNo, iAllNo);
            if (res == 0)
            {
                MessageBox.Show("未获取探头");
                tss_ibl_jcz.Text = "设置探头错误！";
            }
        }

        #region 绑定gridview
        /// <summary>
        /// 光安装
        /// </summary>
        private void BindLight_AZ()
        {
            dgv_azjc.DataSource = List_LightData_AZ;
            dgv_azjc.Height = 140;
            dgv_azjc.RowHeadersVisible = false;
            dgv_azjc.AllowUserToResizeColumns = false;
            dgv_azjc.AllowUserToResizeRows = false;

            dgv_azjc.Columns[0].HeaderText = "设备";
            dgv_azjc.Columns[0].Width = 100;
            dgv_azjc.Columns[0].ReadOnly = true;
            dgv_azjc.Columns[0].DataPropertyName = "EquipmentName";

            dgv_azjc.Columns[1].HeaderText = "第一次采集";
            dgv_azjc.Columns[1].Width = 100;
            dgv_azjc.Columns[1].DataPropertyName = "First";

            dgv_azjc.Columns[2].HeaderText = "第二次采集";
            dgv_azjc.Columns[2].Width = 100;
            dgv_azjc.Columns[2].DataPropertyName = "Second";

            dgv_azjc.Columns[3].HeaderText = "第三次采集";
            dgv_azjc.Columns[3].Width = 100;
            dgv_azjc.Columns[3].DataPropertyName = "Third";

            dgv_azjc.Columns[4].HeaderText = "设备编号";
            dgv_azjc.Columns[4].Width = 100;
            dgv_azjc.Columns[4].DataPropertyName = "Index";
            dgv_azjc.Columns[4].Visible = false;

        }

        /// <summary>
        /// 光卸载
        /// </summary>
        private void BindLight_XZ()
        {
            dgv_xzjc.DataSource = List_LightData_XZ;
            dgv_xzjc.Height = 140;
            dgv_xzjc.RowHeadersVisible = false;
            dgv_xzjc.AllowUserToResizeColumns = false;
            dgv_xzjc.AllowUserToResizeRows = false;
            dgv_xzjc.Columns[0].HeaderText = "设备";
            dgv_xzjc.Columns[0].Width = 100;
            dgv_xzjc.Columns[0].ReadOnly = true;
            dgv_xzjc.Columns[0].DataPropertyName = "EquipmentName";

            dgv_xzjc.Columns[1].HeaderText = "第一次采集";
            dgv_xzjc.Columns[1].Width = 100;
            dgv_xzjc.Columns[1].DataPropertyName = "First";

            dgv_xzjc.Columns[2].HeaderText = "第二次采集";
            dgv_xzjc.Columns[2].Width = 100;
            dgv_xzjc.Columns[2].DataPropertyName = "Second";

            dgv_xzjc.Columns[3].HeaderText = "第三次采集";
            dgv_xzjc.Columns[3].Width = 100;
            dgv_xzjc.Columns[3].DataPropertyName = "Third";

            dgv_xzjc.Columns[4].HeaderText = "设备编号";
            dgv_xzjc.Columns[4].Width = 100;
            dgv_xzjc.Columns[4].DataPropertyName = "Index";
            dgv_xzjc.Columns[4].Visible = false;
        }

        /// <summary>
        /// 颜色采集
        /// </summary>
        private void BindColorData()
        {
            dgv_color.DataSource = List_ColorData;
            dgv_color.Height = 140;
            dgv_color.RowHeadersVisible = false;
            dgv_color.AllowUserToResizeColumns = false;
            dgv_color.AllowUserToResizeRows = false;
            dgv_color.Columns[0].HeaderText = "设备";
            dgv_color.Columns[0].Width = 100;
            dgv_color.Columns[0].ReadOnly = true;
            dgv_color.Columns[0].DataPropertyName = "EquipmentName";
            dgv_color.Columns[1].HeaderText = "第一次采集";
            dgv_color.Columns[1].Width = 100;
            dgv_color.Columns[1].DataPropertyName = "First";
            dgv_color.Columns[2].HeaderText = "第二次采集";
            dgv_color.Columns[2].Width = 100;
            dgv_color.Columns[2].DataPropertyName = "Second";
            dgv_color.Columns[3].HeaderText = "第三次采集";
            dgv_color.Columns[3].Width = 100;
            dgv_color.Columns[3].DataPropertyName = "Third";
            dgv_color.Columns[4].HeaderText = "设备编号";
            dgv_color.Columns[4].Width = 100;
            dgv_color.Columns[4].DataPropertyName = "Index";
            dgv_color.Columns[4].Visible = false;

        }

        #endregion

        #region --按钮事件

      
        /// <summary>
        /// 选择安装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pl_lbl_az_Click(object sender, EventArgs e)
        {
            TEST_TYPE_ENUM = TEST_TYPE.透光投射指数检测_安装;
            pl_az.BackColor = Color.PaleGreen;
            pl_xz.BackColor = Color.Transparent;
        }
        /// <summary>
        /// 选择卸载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_pl_xz_Click(object sender, EventArgs e)
        {
            pl_xz.BackColor = Color.PaleGreen;
            pl_az.BackColor = Color.Transparent;
            TEST_TYPE_ENUM = TEST_TYPE.透光投射指数检测_卸载;
        }

        /// <summary>
        /// 选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tab_set_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tc = (TabControl)sender;
            int index = tab_set.SelectedIndex;

            if (tc.TabPages[index].Text == "透光折减系数（Tr）")
            {
                TEST_TYPE_ENUM = TEST_TYPE.透光投射指数检测_安装;
            }
            else if (tc.TabPages[index].Text == "颜色投射指数（Ra）")
            {
                TEST_TYPE_ENUM = TEST_TYPE.颜色投射指数检测;
                tss_ibl_jcz.Text = "光谱仪准备就绪";
            }
        }
        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (TEST_TYPE_ENUM == TEST_TYPE.透光投射指数检测_安装 || TEST_TYPE_ENUM == TEST_TYPE.透光投射指数检测_卸载)
            {

            }
            else if (TEST_TYPE_ENUM == TEST_TYPE.颜色投射指数检测)
            {
                if (IPLIST.Count == 0)
                {
                    MessageBox.Show("请设置设备IP");
                }
                SPIC200BAPI.SPIC_SetCommType(1);
                SPIC200BAPI.SPIC_SetTestDlgShow(0);
            }

            tss_ibl_jcz.Text = TEST_TYPE_ENUM.ToString() + ",检测中..";

            Thread t = new Thread(GetValue);
            t.Start();
        }
        /// <summary>
        /// 赋值获取的值
        /// </summary>
        public void GetValue()
        {
            for (int i = 1; i <= 3; i++)
            {
                if (TEST_TYPE_ENUM == TEST_TYPE.透光投射指数检测_安装 || TEST_TYPE_ENUM == TEST_TYPE.透光投射指数检测_卸载)
                {
                    Thread.Sleep(8000);
                    float value = 0;
                    for (int j = 1; j <= Program._TTNum; j++)
                    {
                        if (Z10API.Z10DLL_SwitchHead(j) == 0)
                        {
                            MessageBox.Show("设置探头错误！");

                            Invoke(new MethodInvoker(delegate()
                            {
                                tss_ibl_jcz.Text = "设置探头错误！";
                                return;
                            }));
                        }

                        float fE = 0; Int32 time = 0; double fIntE = 0;

                        if (Z10API.Z10DLL_CommE(ref  fE, ref  time, ref fIntE) == 0)
                        {
                            MessageBox.Show("获取数据错误！");
                            Invoke(new MethodInvoker(delegate()
                            {
                              
                                tss_ibl_jcz.Text = "获取数据错误！";
                                return;
                            }));
                        }
                        else
                        {
                            value = fE;
                        }
                        if (TEST_TYPE_ENUM == TEST_TYPE.透光投射指数检测_安装)
                        {
                            SetList_LightData_AZ(i, value);
                            BindLight_AZ();
                            Invoke(new MethodInvoker(delegate()
                            {
                                this.dgv_azjc.Refresh();
                            }));
                        }
                        else if (TEST_TYPE_ENUM == TEST_TYPE.透光投射指数检测_卸载)
                        {
                            SetList_LightData_XZ(i, value);
                            BindLight_XZ();
                            Invoke(new MethodInvoker(delegate()
                            {
                                this.dgv_xzjc.Refresh();
                            }));
                        }
                    }
                }
                else if (TEST_TYPE_ENUM == TEST_TYPE.颜色投射指数检测)
                {
                    for (int j = 1; j <= Program._SB_Count; j++)
                    {
                        if (j > Program._SB_Count)
                        {
                            continue;
                        }
                        var item = IPLIST[j - 1];
                        int ip1 = 0, ip2 = 0, ip3 = 0, ip4 = 0;
                        var ips = item.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            ip1 = int.Parse(ips[0]); ip2 = int.Parse(ips[1]); ip3 = int.Parse(ips[2]); ip4 = int.Parse(ips[3]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("设置IP格式存在问题,请重新设置！");
                            Invoke(new MethodInvoker(delegate()
                            {
                              
                                tss_ibl_jcz.Text = TEST_TYPE_ENUM.ToString() + ",已就绪";
                            }));

                            return;
                        }
                        string error = "";
                        bool IsSuccess = true;

                        var value = SetZDJ(ip1, ip2, ip3, ip4, item, ref IsSuccess, ref error);
                        if (!IsSuccess)
                        {
                            MessageBox.Show(error);
                            return;
                        }
                        SetList_ColorData(i, value);
                        BindColorData();
                        Invoke(new MethodInvoker(delegate()
                        {
                            this.dgv_color.Refresh();
                        }));
                    }
                }
                if (i == 3)
                {
                    switch (TEST_TYPE_ENUM)
                    {
                        case TEST_TYPE.透光投射指数检测_安装:
                            Invoke(new MethodInvoker(delegate()
                           {
                               txt_az.Text = Math.Round(decimal.Parse(((List_LightData_AZ[Program._TTNum].First + List_LightData_AZ[Program._TTNum].Second + List_LightData_AZ[Program._TTNum].Third) / 3).ToString()), 2).ToString();
                           }));
                            break;
                        case TEST_TYPE.透光投射指数检测_卸载:
                            Invoke(new MethodInvoker(delegate()
                            {

                                txt_xz.Text = Math.Round(decimal.Parse(((List_LightData_XZ[Program._TTNum].First + List_LightData_XZ[Program._TTNum].Second + List_LightData_XZ[Program._TTNum].Third) / 3).ToString()), 2).ToString(); ;
                            }));
                            break;
                        case TEST_TYPE.颜色投射指数检测:
                            Invoke(new MethodInvoker(delegate()
                            {
                                txt_color.Text = Math.Round(decimal.Parse(((List_ColorData[Program._TTNum].First + List_ColorData[Program._TTNum].Second + List_ColorData[Program._TTNum].Third) / 3).ToString()), 2).ToString();
                            }));
                            break;
                    }

                    Invoke(new MethodInvoker(delegate()
                    {
                     
                        tss_ibl_jcz.Text = TEST_TYPE_ENUM.ToString() + ",已就绪";
                    }));
                }
            }
        }
        #endregion


        /// <summary>
        /// 设置照度计
        /// </summary>
        private float SetZDJ(int ip1, int ip2, int ip3, int ip4, string ip, ref bool IsSuccess, ref string error)
        {
            if (0 == SPIC200BAPI.SPIC_SetServerIPAndPort(ip1, ip2, ip3, ip4, 5000))
            {
                error = "设置" + ip + "失败!";
                Invoke(new MethodInvoker(delegate()
                               {
                                 
                                   tss_ibl_jcz.Text = TEST_TYPE_ENUM.ToString() + ",已就绪";
                               }));
                IsSuccess = false;
            }

            SPIC200BAPI.MeasureConditionData mesData = new SPIC200BAPI.MeasureConditionData();
            mesData.spectrumPrecision1 = 0;
            mesData.spectrumPrecision2 = 0;
            mesData.spectrumIntegralTime1 = 100;
            mesData.spectrumIntegralTime2 = 100;
            mesData.autoIntegralTimeUpLimit1 = 10000;
            mesData.autoIntegralTimeUpLimit2 = 10000;
            mesData.spectrumModel1 = 1;
            mesData.spectrumModel2 = 1;
            mesData.averageNum1 = 1;
            mesData.averageNum2 = 1;
            if (0 == SPIC200BAPI.SPIC_SetMeasureCondition(ref mesData))
            {
                error = ip + "测试失败,请检查设备是否打开!";
                Invoke(new MethodInvoker(delegate()
                               {
                                 
                                   tss_ibl_jcz.Text = TEST_TYPE_ENUM.ToString() + ",已就绪";
                               }));
                IsSuccess = false;
            }

            SPIC200BAPI.ReadMeasureResultData resData = new SPIC200BAPI.ReadMeasureResultData();
            if (-1 == SPIC200BAPI.SPIC_GetMeasureReslut(ref resData))
            {
                error = ip + "读取结果失败!";
                Invoke(new MethodInvoker(delegate()
                               {
                                
                                   tss_ibl_jcz.Text = TEST_TYPE_ENUM.ToString() + ",已就绪";
                               }));
                IsSuccess = false;
            }
            return resData.Ra;
        }


        #region 赋值检测变量
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IpCount">设备个数</param>
        /// <param name="scanningIndex">当前扫描次数</param>
        private void SetList_LightData_AZ(int scanningIndex, float value)
        {
            for (int i = 1; i <= Program._TTNum; i++)
            {
                if (scanningIndex == 1)
                {
                    List_LightData_AZ[i - 1].First = Math.Round(value, 2);
                    List_LightData_AZ[Program._TTNum].First = List_LightData_AZ.FindAll(t => t.Index < 999).Average(t => t.First);
                }
                else if (scanningIndex == 2)
                {
                    List_LightData_AZ[i - 1].Second = Math.Round(value, 2);
                    List_LightData_AZ[Program._TTNum].Second = List_LightData_AZ.FindAll(t => t.Index < 999).Average(t => t.Second);
                }
                else if (scanningIndex == 3)
                {
                    List_LightData_AZ[i - 1].Third = Math.Round(value, 2);
                    List_LightData_AZ[Program._TTNum].Third = List_LightData_AZ.FindAll(t => t.Index < 999).Average(t => t.Third);
                }
            }
        }
        /// <summary>
        /// 卸载
        /// </summary>
        /// <param name="IpCount">设备数量</param>
        private void SetList_LightData_XZ(int scanningIndex, float value)
        {
            for (int i = 1; i <= Program._TTNum; i++)
            {
                if (scanningIndex == 1)
                {
                    List_LightData_XZ[i - 1].First = Math.Round(value, 2);
                    List_LightData_XZ[Program._TTNum].First = List_LightData_XZ.FindAll(t => t.Index < 999).Average(t => t.First);
                }
                else if (scanningIndex == 2)
                {
                    List_LightData_XZ[i - 1].Second = Math.Round(value, 2);
                    List_LightData_XZ[Program._TTNum].Second = List_LightData_XZ.FindAll(t => t.Index < 999).Average(t => t.Second);
                }
                else if (scanningIndex == 3)
                {
                    List_LightData_XZ[i - 1].Third = Math.Round(value, 2);
                    List_LightData_XZ[Program._TTNum].Third = List_LightData_XZ.FindAll(t => t.Index < 999).Average(t => t.Third);
                }
            }
        }

        /// <summary>
        ///颜色采光
        /// </summary>
        /// <param name="scanningIndex"></param>
        /// <param name="value"></param>
        private void SetList_ColorData(int scanningIndex, float value)
        {
            for (int i = 1; i <= Program._SB_Count; i++)
            {
                if (scanningIndex == 1)
                {
                    List_ColorData[i - 1].First = Math.Round(value, 2);
                    List_ColorData[Program._SB_Count].First = List_ColorData.FindAll(t => t.Index < 999).Average(t => t.First);
                }
                else if (scanningIndex == 2)
                {
                    List_ColorData[i - 1].Second = Math.Round(value, 2);
                    List_ColorData[Program._SB_Count].Second = List_ColorData.FindAll(t => t.Index < 999).Average(t => t.Second);
                }
                else if (scanningIndex == 3)
                {
                    List_ColorData[i - 1].Third = Math.Round(value, 2);
                    List_ColorData[Program._SB_Count].Third = List_ColorData.FindAll(t => t.Index < 999).Average(t => t.Third);
                }
            }
        }
        #endregion

        /// <summary>
        /// 停止检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_stop_Click(object sender, EventArgs e)
        {
         
            tss_ibl_jcz.Text = "";
        }


        private void btn_az_Click(object sender, EventArgs e)
        {
            if (new DAL_SPIC_TEST().AddLightData(List_LightData_AZ, _CODE, TEST_TYPE.透光投射指数检测_安装, txt_az.Text))
                MessageUtil.ShowTips("处理成功");
            else
                MessageUtil.ShowError("处理失败");
        }

        private void btn_xz_Click(object sender, EventArgs e)
        {
            if (new DAL_SPIC_TEST().AddLightData(List_LightData_XZ, _CODE, TEST_TYPE.透光投射指数检测_卸载, txt_xz.Text))
                MessageUtil.ShowTips("处理成功");
            else
                MessageUtil.ShowError("处理失败");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new DAL_SPIC_TEST().AddLightData(List_ColorData, _CODE, TEST_TYPE.颜色投射指数检测, txt_color.Text))
                MessageUtil.ShowTips("处理成功");
            else
                MessageUtil.ShowError("处理失败");
        }

        private void dgv_azjc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var r_index = e.RowIndex;
            var c_index = e.ColumnIndex;
            if (r_index != -1 && c_index != -1)
            {
                double value = 0;
                try
                {
                    value = double.Parse(this.dgv_azjc.Rows[r_index].Cells[c_index].Value.ToString());
                }
                catch (Exception ex)
                {
                    this.dgv_azjc.Rows[r_index].Cells[c_index].Value = 0;
                    value = 0;
                }

                if (c_index == 1)
                {
                    List_LightData_AZ[r_index].First = value;
                    List_LightData_AZ[Program._TTNum].First = List_LightData_AZ.FindAll(t => t.Index < 999).Average(t => t.First);
                }
                if (c_index == 2)
                {
                    List_LightData_AZ[r_index].Second = value;
                    List_LightData_AZ[Program._TTNum].Second = List_LightData_AZ.FindAll(t => t.Index < 999).Average(t => t.Second);
                }
                if (c_index == 3)
                {
                    List_LightData_AZ[r_index].Third = value;
                    List_LightData_AZ[Program._TTNum].Third = List_LightData_AZ.FindAll(t => t.Index < 999).Average(t => t.Third);
                }
                BindLight_AZ();
                this.dgv_azjc.Refresh();
            }
        }

        private void dgv_xzjc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            var r_index = e.RowIndex;
            var c_index = e.ColumnIndex;
            if (r_index != -1 && c_index != -1)
            {
                double value = 0;
                try
                {
                    value = double.Parse(this.dgv_xzjc.Rows[r_index].Cells[c_index].Value.ToString());
                }
                catch (Exception ex)
                {
                    this.dgv_xzjc.Rows[r_index].Cells[c_index].Value = 0;
                    value = 0;
                }

                if (c_index == 1)
                {
                    List_LightData_XZ[r_index].First = value;
                    List_LightData_XZ[Program._TTNum].First = List_LightData_XZ.FindAll(t => t.Index < 999).Average(t => t.First);
                }
                if (c_index == 2)
                {
                    List_LightData_XZ[r_index].Second = value;
                    List_LightData_XZ[Program._TTNum].Second = List_LightData_XZ.FindAll(t => t.Index < 999).Average(t => t.Second);
                }
                if (c_index == 3)
                {
                    List_LightData_XZ[r_index].Third = value;
                    List_LightData_XZ[Program._TTNum].Third = List_LightData_XZ.FindAll(t => t.Index < 999).Average(t => t.Third);
                }
                BindLight_XZ();
                this.dgv_xzjc.Refresh();
            }
        }

        private void dgv_color_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var r_index = e.RowIndex;
            var c_index = e.ColumnIndex;
            if (r_index != -1 && c_index != -1)
            {
                double value = 0;
                try
                {
                    value = double.Parse(this.dgv_color.Rows[r_index].Cells[c_index].Value.ToString());
                }
                catch (Exception ex)
                {
                    this.dgv_color.Rows[r_index].Cells[c_index].Value = 0;
                    value = 0;
                }

                if (c_index == 1)
                {
                    List_ColorData[r_index].First = value;
                    List_ColorData[Program._SB_Count].First = List_ColorData.FindAll(t => t.Index < 999).Average(t => t.First);
                }
                if (c_index == 2)
                {
                    List_ColorData[r_index].Second = value;
                    List_ColorData[Program._SB_Count].Second = List_ColorData.FindAll(t => t.Index < 999).Average(t => t.Second);
                }
                if (c_index == 3)
                {
                    List_ColorData[r_index].Third = value;
                    List_ColorData[Program._SB_Count].Third = List_ColorData.FindAll(t => t.Index < 999).Average(t => t.Third);
                }
                BindColorData();

                this.dgv_color.Refresh();
            }
        }

        private void btn_cjaz_Click(object sender, EventArgs e)
        {
            TEST_TYPE_ENUM = TEST_TYPE.透光投射指数检测_安装;
            tss_ibl_jcz.Text = TEST_TYPE_ENUM.ToString() + ",检测中..";

            Thread t = new Thread(GetValue);
            t.Start();
        }

        private void btn_cjxz_Click(object sender, EventArgs e)
        {
            TEST_TYPE_ENUM = TEST_TYPE.透光投射指数检测_卸载;
            tss_ibl_jcz.Text = TEST_TYPE_ENUM.ToString() + ",检测中..";

            Thread t = new Thread(GetValue);
            t.Start();
        }

        private void btn_cjColor_Click(object sender, EventArgs e)
        {
            if (IPLIST.Count == 0)
            {
                MessageBox.Show("请设置设备IP");
            }
            SPIC200BAPI.SPIC_SetCommType(1);
            SPIC200BAPI.SPIC_SetTestDlgShow(0);

            tss_ibl_jcz.Text = TEST_TYPE_ENUM.ToString() + ",检测中..";

            Thread t = new Thread(GetValue);
            t.Start();
        }
    }

    public enum TEST_TYPE
    {
        透光投射指数检测_安装,
        透光投射指数检测_卸载,
        颜色投射指数检测
    }
}
