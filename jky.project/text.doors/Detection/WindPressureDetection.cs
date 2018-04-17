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
using text.doors.Common;
using text.doors.Default;
using text.doors.Model;
using text.doors.Model.DataBase;
using text.doors.Service;

namespace text.doors.Detection
{
    public partial class WindPressureDetection : Form
    {
        private static Young.Core.Logger.ILog Logger = Young.Core.Logger.LoggerManager.Current();
        private TCPClient _tcpClient;
        //检验编号
        private string _tempCode = "";
        //当前樘号
        private string _tempTong = "";

        public DateTime dtnow { get; set; }


        public List<WindPressureDGV> windPressureDGV = new List<WindPressureDGV>();
        /// <summary>
        /// 抗风压数据位置
        /// </summary>
        private PublicEnum.WindPressureTest? windPressureTest = null;

        public WindPressureDetection(TCPClient tcpClient, string tempCode, string tempTong)
        {
            InitializeComponent();
            this._tcpClient = tcpClient;
            this._tempCode = tempCode;
            this._tempTong = tempTong;

            if (!DefaultBase.LockPoint)
            {
                rdb_DWDD1.Enabled = false;
                rdb_DWDD3.Enabled = false;
            }
            else
            {
                rdb_DWDD1.Enabled = true;
                rdb_DWDD3.Enabled = true;
            }

            BindData();
            BindSetPressure();
            FYchartInit();
        }
        /// <summary>
        /// 绑定设定压力
        /// </summary>
        private void BindSetPressure()
        {
            lbl_title.Text = string.Format("门窗抗风压性能检测  第{0}号 {1}", this._tempCode, this._tempTong);
        }

        /// <summary>
        /// 风速图标
        /// </summary>
        private void FYchartInit()
        {
            dtnow = DateTime.Now;
            qm_Line.GetVertAxis.SetMinMax(-5000, 5000);
        }


        private List<string> KFYPa = new List<string>() { "250", "500", "750", "1000", "1250", "1500", "1750", "2000" };

        private void BindData()
        {
            #region 绑定
            dgv_WindPressure.DataSource = GetWindPressureDGV();
            dgv_WindPressure.Height = 215;
            dgv_WindPressure.RowHeadersVisible = false;
            dgv_WindPressure.AllowUserToResizeColumns = false;
            dgv_WindPressure.AllowUserToResizeRows = false;

            dgv_WindPressure.Columns[0].HeaderText = "国际检测";
            dgv_WindPressure.Columns[0].Width = 75;
            dgv_WindPressure.Columns[0].ReadOnly = true;
            dgv_WindPressure.Columns[0].DataPropertyName = "Pa";


            dgv_WindPressure.Columns[1].HeaderText = "位移1";
            dgv_WindPressure.Columns[1].Width = 72;
            dgv_WindPressure.Columns[1].DataPropertyName = "zwy1";


            dgv_WindPressure.Columns[2].HeaderText = "位移2";
            dgv_WindPressure.Columns[2].Width = 72;
            dgv_WindPressure.Columns[2].DataPropertyName = "zwy2";

            dgv_WindPressure.Columns[3].HeaderText = "位移3";
            dgv_WindPressure.Columns[3].Width = 72;
            dgv_WindPressure.Columns[3].DataPropertyName = "zwy3";

            dgv_WindPressure.Columns[4].HeaderText = "挠度";
            dgv_WindPressure.Columns[4].Width = 72;
            dgv_WindPressure.Columns[4].DataPropertyName = "zzd";

            dgv_WindPressure.Columns[5].HeaderText = "I/x";
            dgv_WindPressure.Columns[5].Width = 72;
            dgv_WindPressure.Columns[5].DataPropertyName = "zix";



            dgv_WindPressure.Columns[6].HeaderText = "位移1";
            dgv_WindPressure.Columns[6].Width = 72;
            dgv_WindPressure.Columns[6].DataPropertyName = "fwy1";


            dgv_WindPressure.Columns[7].HeaderText = "位移2";
            dgv_WindPressure.Columns[7].Width = 72;
            dgv_WindPressure.Columns[7].DataPropertyName = "fwy2";

            dgv_WindPressure.Columns[8].HeaderText = "位移3";
            dgv_WindPressure.Columns[8].Width = 72;
            dgv_WindPressure.Columns[8].DataPropertyName = "fwy3";

            dgv_WindPressure.Columns[9].HeaderText = "挠度";
            dgv_WindPressure.Columns[9].Width = 72;
            dgv_WindPressure.Columns[9].DataPropertyName = "fzd";

            dgv_WindPressure.Columns[10].HeaderText = "I/x";
            dgv_WindPressure.Columns[10].Width = 72;
            dgv_WindPressure.Columns[10].DataPropertyName = "fix";


            dgv_WindPressure.Columns["zwy1"].DefaultCellStyle.Format = "N2";
            dgv_WindPressure.Columns["zwy2"].DefaultCellStyle.Format = "N2";
            dgv_WindPressure.Columns["zwy3"].DefaultCellStyle.Format = "N2";
            dgv_WindPressure.Columns["zzd"].DefaultCellStyle.Format = "N2";
            dgv_WindPressure.Columns["zix"].DefaultCellStyle.Format = "N2";

            dgv_WindPressure.Columns["fwy1"].DefaultCellStyle.Format = "N2";
            dgv_WindPressure.Columns["fwy2"].DefaultCellStyle.Format = "N2";
            dgv_WindPressure.Columns["fwy3"].DefaultCellStyle.Format = "N2";
            dgv_WindPressure.Columns["fzd"].DefaultCellStyle.Format = "N2";
            dgv_WindPressure.Columns["fix"].DefaultCellStyle.Format = "N2";
            #endregion
        }


        private List<WindPressureDGV> GetWindPressureDGV()
        {
            //List<WindPressureDGV> windPressureDGV = new List<WindPressureDGV>();
            var dt = new DAL_dt_kfy_Info().GetkfyByCodeAndTong(_tempCode, _tempTong);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                foreach (var value in KFYPa)
                {
                    windPressureDGV.Add(new WindPressureDGV()
                    {
                        Pa = value + "Pa",
                        zwy1 = string.IsNullOrWhiteSpace(dr["z_one_" + value].ToString()) ? 0 : double.Parse(dr["z_one_" + value].ToString()),
                        zwy2 = string.IsNullOrWhiteSpace(dr["z_two_" + value].ToString()) ? 0 : double.Parse(dr["z_two_" + value].ToString()),
                        zwy3 = string.IsNullOrWhiteSpace(dr["z_three_" + value].ToString()) ? 0 : double.Parse(dr["z_three_" + value].ToString()),
                        zzd = string.IsNullOrWhiteSpace(dr["z_nd_" + value].ToString()) ? 0 : double.Parse(dr["z_nd_" + value].ToString()),
                        zix = string.IsNullOrWhiteSpace(dr["z_ix_" + value].ToString()) ? 0 : double.Parse(dr["z_ix_" + value].ToString()),

                        fwy1 = string.IsNullOrWhiteSpace(dr["f_one_" + value].ToString()) ? 0 : double.Parse(dr["f_one_" + value].ToString()),
                        fwy2 = string.IsNullOrWhiteSpace(dr["f_two_" + value].ToString()) ? 0 : double.Parse(dr["f_two_" + value].ToString()),
                        fwy3 = string.IsNullOrWhiteSpace(dr["f_three_" + value].ToString()) ? 0 : double.Parse(dr["f_three_" + value].ToString()),
                        fzd = string.IsNullOrWhiteSpace(dr["f_nd_" + value].ToString()) ? 0 : double.Parse(dr["f_nd_" + value].ToString()),
                        fix = string.IsNullOrWhiteSpace(dr["f_ix_" + value].ToString()) ? 0 : double.Parse(dr["f_ix_" + value].ToString()),
                    });
                }
            }
            else
            {
                foreach (var value in KFYPa)
                {
                    windPressureDGV.Add(new WindPressureDGV()
                    {
                        Pa = value + "Pa",
                        zwy1 = 0,
                        zwy2 = 0,
                        zwy3 = 0,
                        zzd = 0,
                        zix = 0,
                        fwy1 = 0,
                        fwy2 = 0,
                        fwy3 = 0,
                        fzd = 0,
                        fix = 0,
                    });
                }
            }
            return windPressureDGV;
        }

        private void AnimateSeries(Steema.TeeChart.TChart chart, int yl)
        {
            this.qm_Line.Add(DateTime.Now, yl);
            this.tChart_qm.Axes.Bottom.SetMinMax(dtnow, DateTime.Now.AddSeconds(20));
        }

        private void tim_PainPic_Tick(object sender, EventArgs e)
        {
            if (_tcpClient.IsTCPLink)
            {
                var IsSeccess = false;
                var c = _tcpClient.GetCYXS(ref IsSeccess);
                int value = int.Parse(c.ToString());
                if (!IsSeccess)
                {
                    MessageBox.Show("获取差压异常！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return;
                }
                AnimateSeries(this.tChart_qm, value);
            }
        }

        private void btn_zyyb_Click(object sender, EventArgs e)
        {
            if (!_tcpClient.IsTCPLink)
                return;

            var res = _tcpClient.Send_FY_Btn(BFMCommand.风压正压预备);
            if (!res)
            {
                MessageBox.Show("正压预备异常！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }

            windPressureTest = PublicEnum.WindPressureTest.ZReady;
            DisableBtnType();
        }

        private void btn_zyks_Click(object sender, EventArgs e)
        {
            if (!_tcpClient.IsTCPLink)
                return;

            var res = _tcpClient.Send_FY_Btn(BFMCommand.风压正压开始);
            if (!res)
            {
                MessageBox.Show("正压开始异常！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }

            windPressureTest = PublicEnum.WindPressureTest.ZStart;
            DisableBtnType();

            this.tim_fy.Enabled = true;
        }

        private void btn_fyyb_Click(object sender, EventArgs e)
        {
            if (!_tcpClient.IsTCPLink)
            {
                return;
            }
            var res = _tcpClient.Send_FY_Btn(BFMCommand.风压正压预备);
            if (!res)
            {
                MessageBox.Show("负压预备异常！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }

            windPressureTest = PublicEnum.WindPressureTest.FReady;
            DisableBtnType();
        }

        private void btn_fyks_Click(object sender, EventArgs e)
        {
            if (!_tcpClient.IsTCPLink)
            {
                return;
            }
            var res = _tcpClient.Send_FY_Btn(BFMCommand.风压负压开始);
            if (!res)
            {
                MessageBox.Show("负压开始异常！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }
            windPressureTest = PublicEnum.WindPressureTest.FStart;
            DisableBtnType();
            this.tim_fy.Enabled = true;
        }

        private void btn_datahandle_Click(object sender, EventArgs e)
        {
            if (AddKfyInfo())
            {
                MessageBox.Show("处理成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        private bool AddKfyInfo()
        {
            DAL_dt_kfy_Info dal = new DAL_dt_kfy_Info();
            Model_dt_kfy_Info model = new Model_dt_kfy_Info();
            model.dt_Code = _tempCode;
            model.info_DangH = _tempTong;

            for (int i = 0; i < KFYPa.Count; i++)
            {
                #region 获取
                if (i == 0)
                {
                    model.z_one_250 = this.dgv_WindPressure.Rows[i].Cells["zwy1"].Value.ToString();
                    model.z_two_250 = this.dgv_WindPressure.Rows[i].Cells["zwy2"].Value.ToString();
                    model.z_three_250 = this.dgv_WindPressure.Rows[i].Cells["zwy3"].Value.ToString();
                    model.z_nd_250 = this.dgv_WindPressure.Rows[i].Cells["zzd"].Value.ToString();
                    model.z_ix_250 = this.dgv_WindPressure.Rows[i].Cells["zix"].Value.ToString();
                    model.f_one_250 = this.dgv_WindPressure.Rows[i].Cells["fwy1"].Value.ToString();
                    model.f_two_250 = this.dgv_WindPressure.Rows[i].Cells["fwy2"].Value.ToString();
                    model.f_three_250 = this.dgv_WindPressure.Rows[i].Cells["fwy3"].Value.ToString();
                    model.f_nd_250 = this.dgv_WindPressure.Rows[i].Cells["fzd"].Value.ToString();
                    model.f_ix_250 = this.dgv_WindPressure.Rows[i].Cells["fix"].Value.ToString();
                }
                if (i == 1)
                {
                    model.z_one_500 = this.dgv_WindPressure.Rows[i].Cells["zwy1"].Value.ToString();
                    model.z_two_500 = this.dgv_WindPressure.Rows[i].Cells["zwy2"].Value.ToString();
                    model.z_three_500 = this.dgv_WindPressure.Rows[i].Cells["zwy3"].Value.ToString();
                    model.z_nd_500 = this.dgv_WindPressure.Rows[i].Cells["zzd"].Value.ToString();
                    model.z_ix_500 = this.dgv_WindPressure.Rows[i].Cells["zix"].Value.ToString();
                    model.f_one_500 = this.dgv_WindPressure.Rows[i].Cells["fwy1"].Value.ToString();
                    model.f_two_500 = this.dgv_WindPressure.Rows[i].Cells["fwy2"].Value.ToString();
                    model.f_three_500 = this.dgv_WindPressure.Rows[i].Cells["fwy3"].Value.ToString();
                    model.f_nd_500 = this.dgv_WindPressure.Rows[i].Cells["fzd"].Value.ToString();
                    model.f_ix_500 = this.dgv_WindPressure.Rows[i].Cells["fix"].Value.ToString();
                }
                if (i == 2)
                {
                    model.z_one_750 = this.dgv_WindPressure.Rows[i].Cells["zwy1"].Value.ToString();
                    model.z_two_750 = this.dgv_WindPressure.Rows[i].Cells["zwy2"].Value.ToString();
                    model.z_three_750 = this.dgv_WindPressure.Rows[i].Cells["zwy3"].Value.ToString();
                    model.z_nd_750 = this.dgv_WindPressure.Rows[i].Cells["zzd"].Value.ToString();
                    model.z_ix_750 = this.dgv_WindPressure.Rows[i].Cells["zix"].Value.ToString();
                    model.f_one_750 = this.dgv_WindPressure.Rows[i].Cells["fwy1"].Value.ToString();
                    model.f_two_750 = this.dgv_WindPressure.Rows[i].Cells["fwy2"].Value.ToString();
                    model.f_three_750 = this.dgv_WindPressure.Rows[i].Cells["fwy3"].Value.ToString();
                    model.f_nd_750 = this.dgv_WindPressure.Rows[i].Cells["fzd"].Value.ToString();
                    model.f_ix_750 = this.dgv_WindPressure.Rows[i].Cells["fix"].Value.ToString();
                }
                if (i == 3)
                {
                    model.z_one_1000 = this.dgv_WindPressure.Rows[i].Cells["zwy1"].Value.ToString();
                    model.z_two_1000 = this.dgv_WindPressure.Rows[i].Cells["zwy2"].Value.ToString();
                    model.z_three_1000 = this.dgv_WindPressure.Rows[i].Cells["zwy3"].Value.ToString();
                    model.z_nd_1000 = this.dgv_WindPressure.Rows[i].Cells["zzd"].Value.ToString();
                    model.z_ix_1000 = this.dgv_WindPressure.Rows[i].Cells["zix"].Value.ToString();
                    model.f_one_1000 = this.dgv_WindPressure.Rows[i].Cells["fwy1"].Value.ToString();
                    model.f_two_1000 = this.dgv_WindPressure.Rows[i].Cells["fwy2"].Value.ToString();
                    model.f_three_1000 = this.dgv_WindPressure.Rows[i].Cells["fwy3"].Value.ToString();
                    model.f_nd_1000 = this.dgv_WindPressure.Rows[i].Cells["fzd"].Value.ToString();
                    model.f_ix_1000 = this.dgv_WindPressure.Rows[i].Cells["fix"].Value.ToString();
                }
                if (i == 4)
                {
                    model.z_one_1250 = this.dgv_WindPressure.Rows[i].Cells["zwy1"].Value.ToString();
                    model.z_two_1250 = this.dgv_WindPressure.Rows[i].Cells["zwy2"].Value.ToString();
                    model.z_three_1250 = this.dgv_WindPressure.Rows[i].Cells["zwy3"].Value.ToString();
                    model.z_nd_1250 = this.dgv_WindPressure.Rows[i].Cells["zzd"].Value.ToString();
                    model.z_ix_1250 = this.dgv_WindPressure.Rows[i].Cells["zix"].Value.ToString();
                    model.f_one_1250 = this.dgv_WindPressure.Rows[i].Cells["fwy1"].Value.ToString();
                    model.f_two_1250 = this.dgv_WindPressure.Rows[i].Cells["fwy2"].Value.ToString();
                    model.f_three_1250 = this.dgv_WindPressure.Rows[i].Cells["fwy3"].Value.ToString();
                    model.f_nd_1250 = this.dgv_WindPressure.Rows[i].Cells["fzd"].Value.ToString();
                    model.f_ix_1250 = this.dgv_WindPressure.Rows[i].Cells["fix"].Value.ToString();
                }
                if (i == 5)
                {
                    model.z_one_1500 = this.dgv_WindPressure.Rows[i].Cells["zwy1"].Value.ToString();
                    model.z_two_1500 = this.dgv_WindPressure.Rows[i].Cells["zwy2"].Value.ToString();
                    model.z_three_1500 = this.dgv_WindPressure.Rows[i].Cells["zwy3"].Value.ToString();
                    model.z_nd_1500 = this.dgv_WindPressure.Rows[i].Cells["zzd"].Value.ToString();
                    model.z_ix_1500 = this.dgv_WindPressure.Rows[i].Cells["zix"].Value.ToString();
                    model.f_one_1500 = this.dgv_WindPressure.Rows[i].Cells["fwy1"].Value.ToString();
                    model.f_two_1500 = this.dgv_WindPressure.Rows[i].Cells["fwy2"].Value.ToString();
                    model.f_three_1500 = this.dgv_WindPressure.Rows[i].Cells["fwy3"].Value.ToString();
                    model.f_nd_1500 = this.dgv_WindPressure.Rows[i].Cells["fzd"].Value.ToString();
                    model.f_ix_1500 = this.dgv_WindPressure.Rows[i].Cells["fix"].Value.ToString();
                }
                if (i == 6)
                {
                    model.z_one_1750 = this.dgv_WindPressure.Rows[i].Cells["zwy1"].Value.ToString();
                    model.z_two_1750 = this.dgv_WindPressure.Rows[i].Cells["zwy2"].Value.ToString();
                    model.z_three_1750 = this.dgv_WindPressure.Rows[i].Cells["zwy3"].Value.ToString();
                    model.z_nd_1750 = this.dgv_WindPressure.Rows[i].Cells["zzd"].Value.ToString();
                    model.z_ix_1750 = this.dgv_WindPressure.Rows[i].Cells["zix"].Value.ToString();
                    model.f_one_1750 = this.dgv_WindPressure.Rows[i].Cells["fwy1"].Value.ToString();
                    model.f_two_1750 = this.dgv_WindPressure.Rows[i].Cells["fwy2"].Value.ToString();
                    model.f_three_1750 = this.dgv_WindPressure.Rows[i].Cells["fwy3"].Value.ToString();
                    model.f_nd_1750 = this.dgv_WindPressure.Rows[i].Cells["fzd"].Value.ToString();
                    model.f_ix_1750 = this.dgv_WindPressure.Rows[i].Cells["fix"].Value.ToString();
                }
                if (i == 7)
                {
                    model.z_one_2000 = this.dgv_WindPressure.Rows[i].Cells["zwy1"].Value.ToString();
                    model.z_two_2000 = this.dgv_WindPressure.Rows[i].Cells["zwy2"].Value.ToString();
                    model.z_three_2000 = this.dgv_WindPressure.Rows[i].Cells["zwy3"].Value.ToString();
                    model.z_nd_2000 = this.dgv_WindPressure.Rows[i].Cells["zzd"].Value.ToString();
                    model.z_ix_2000 = this.dgv_WindPressure.Rows[i].Cells["zix"].Value.ToString();
                    model.f_one_2000 = this.dgv_WindPressure.Rows[i].Cells["fwy1"].Value.ToString();
                    model.f_two_2000 = this.dgv_WindPressure.Rows[i].Cells["fwy2"].Value.ToString();
                    model.f_three_2000 = this.dgv_WindPressure.Rows[i].Cells["fwy3"].Value.ToString();
                    model.f_nd_2000 = this.dgv_WindPressure.Rows[i].Cells["fzd"].Value.ToString();
                    model.f_ix_2000 = this.dgv_WindPressure.Rows[i].Cells["fix"].Value.ToString();
                }

                #endregion
            }
            return dal.Add_kfy_Info(model);
        }

        private void btn_zff_Click(object sender, EventArgs e)
        {
            if (!_tcpClient.IsTCPLink)
                return;

            double value = 0;
            var res = _tcpClient.Set_FY_Value(BFMCommand.正反复数值, BFMCommand.正反复, value);
            if (!res)
            {
                MessageBox.Show("正反复异常！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }

            windPressureTest = PublicEnum.WindPressureTest.ZRepeatedly;
            DisableBtnType();
        }

        private void btn_fff_Click(object sender, EventArgs e)
        {
            if (!_tcpClient.IsTCPLink)
                return;

            double value = 0;
            var res = _tcpClient.Set_FY_Value(BFMCommand.负反复数值, BFMCommand.负反复, value);
            if (!res)
            {
                MessageBox.Show("负反复异常！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }

            windPressureTest = PublicEnum.WindPressureTest.FRepeatedly;
            DisableBtnType();
        }

        private void btn_zaq_Click(object sender, EventArgs e)
        {
            if (!_tcpClient.IsTCPLink)
                return;

            double value = 0;
            var res = _tcpClient.Set_FY_Value(BFMCommand.正安全数值, BFMCommand.正安全, value);
            if (!res)
            {
                MessageBox.Show("正安全异常！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }
            windPressureTest = PublicEnum.WindPressureTest.ZSafety;
            DisableBtnType();


        }

        private void btnfaq_Click(object sender, EventArgs e)
        {
            if (!_tcpClient.IsTCPLink)
                return;

            double value = 0;
            var res = _tcpClient.Set_FY_Value(BFMCommand.负安全数值, BFMCommand.负安全, value);
            if (!res)
            {
                MessageBox.Show("负安全异常！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }
            windPressureTest = PublicEnum.WindPressureTest.FSafety;
            DisableBtnType();
        }

        private void dgv_WindPressure_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void btn_wygl_Click(object sender, EventArgs e)
        {
            if (!_tcpClient.IsTCPLink)
            {
                return;
            }
            _tcpClient.SendWYGL();
        }

        private void tim_wyData_Tick(object sender, EventArgs e)
        {
            if (_tcpClient.IsTCPLink)
            {
                var IsSeccess = true;
                //抗风压
                var displace1 = _tcpClient.GetDisplace1(ref IsSeccess).ToString();
                if (!IsSeccess) return;
                var displace2 = _tcpClient.GetDisplace2(ref IsSeccess).ToString();
                if (!IsSeccess) return;
                var displace3 = _tcpClient.GetDisplace3(ref IsSeccess).ToString();
                if (!IsSeccess) return;

                txt_wy1.Text = displace1.ToString();
                txt_wy2.Text = displace2.ToString();
                txt_wy3.Text = displace3.ToString();
            }
        }

        /// <summary>
        /// 记录当前锚点
        /// </summary>
        private int currentkPa = 0;


        private void tim_fy_Tick(object sender, EventArgs e)
        {
            if (_tcpClient.IsTCPLink)
            {
                return;
            }
            var IsSeccess = true;
            var value = _tcpClient.GetCYXS(ref IsSeccess);
            if (!IsSeccess)
            {
                MessageBox.Show("获取差压异常！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }
            if (windPressureTest == PublicEnum.WindPressureTest.ZStart)
            {
                lbl_dqyl.Text = value.ToString();
            }
            else if (windPressureTest == PublicEnum.WindPressureTest.FStart)
            {
                lbl_dqyl.Text = "-" + value.ToString();
            }

            var def_LX = 0;
            int.TryParse(txt_lx.Text, out def_LX);

            if (value > def_LX)
            {
                this.tim_fy.Enabled = false;

                //是否完成稳压
                var isCompleteStabilivolt = false;
                while (!isCompleteStabilivolt)
                {
                    if (tim_static.Enabled == false)
                    {
                        isCompleteStabilivolt = true;

                        var p = Calculate();
                        if (windPressureTest == PublicEnum.WindPressureTest.ZStart)
                        {
                            txt_p1.Text = p.ToString();
                            txt_p2.Text = (p * 2).ToString();
                            txt_p3.Text = (p * 3).ToString();
                        }
                        else if (windPressureTest == PublicEnum.WindPressureTest.FStart)
                        {
                            txt_f_p3.Text = p.ToString();
                            txt_f_p3.Text = (p * 2).ToString();
                            txt_f_p3.Text = (p * 3).ToString();
                        }
                    }
                    return;
                }

                if (value == 250)
                {
                    tim_static.Enabled = true;
                    currentkPa = 250;
                }
                else if (value == 500)
                {
                    tim_static.Enabled = true;
                    currentkPa = 500;
                }
                else if (value == 750)
                {
                    tim_static.Enabled = true;
                    currentkPa = 750;
                }
                else if (value == 1000)
                {
                    tim_static.Enabled = true;
                    currentkPa = 1000;
                }
                else if (value == 1250)
                {
                    tim_static.Enabled = true;
                    currentkPa = 1250;
                }
                else if (value == 1500)
                {
                    tim_static.Enabled = true;
                    currentkPa = 1500;
                }
                else if (value == 1750)
                {
                    tim_static.Enabled = true;
                    currentkPa = 1750;
                }
                else if (value == 2000)
                {
                    tim_static.Enabled = true;
                    currentkPa = 2000;
                }


                //读取设定值
                //if (windPressureTest == PublicEnum.WindPressureTest.ZStart)
                //{
                //    double yl = _tcpClient.ReadSetkPa(BFMCommand.正压开始_设定值, ref IsSeccess);
                //    if (!IsSeccess)
                //    {
                //        MessageBox.Show("获取正压预备异常！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                //        return;
                //    }
                //    lbl_setYL.Text = yl.ToString();
                //}
                //else if (windPressureTest == PublicEnum.WindPressureTest.FStart)
                //{
                //    double yl = _tcpClient.ReadSetkPa(BFMCommand.负压开始_设定值, ref IsSeccess);
                //    if (!IsSeccess)
                //    {
                //        MessageBox.Show("获取负压开始异常！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                //        return;
                //    }
                //    lbl_setYL.Text = "-" + yl.ToString();
                //}
                //if (IsStart)
                //{
                //    if (this.tim_Top10.Enabled == false)
                //        SetCurrType(value);
                //}
            }
        }
        //稳压次数
        private int staticIndex = 1;
        private List<Tuple<double, double, double>> average = new List<Tuple<double, double, double>>();
        /// <summary>
        /// 稳压5次取平均值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tim_static_Tick(object sender, EventArgs e)
        {
            if (staticIndex < 6)
            {
                var IsSeccess = false;
                double displace1 = _tcpClient.GetDisplace1(ref IsSeccess);
                if (!IsSeccess)
                {
                    return;
                }
                double displace2 = _tcpClient.GetDisplace2(ref IsSeccess);
                if (!IsSeccess)
                {
                    return;
                }
                double displace3 = _tcpClient.GetDisplace3(ref IsSeccess);
                if (!IsSeccess)
                {
                    return;
                }
                average.Add(new Tuple<double, double, double>(displace1, displace2, displace3));
            }
            else
            {
                double ave1 = 0, ave2 = 0, ave3 = 0;
                foreach (var item in average)
                {
                    ave1 += item.Item1;
                    ave2 += item.Item2;
                    ave3 += item.Item3;
                }

                var pa = windPressureDGV.Find(t => t.Pa == currentkPa + "Pa");
                if (windPressureTest == PublicEnum.WindPressureTest.ZStart)
                {
                    pa.zwy1 = Math.Round(ave1 / average.Count, 2);
                    pa.zwy2 = Math.Round(ave2 / average.Count, 2);
                    pa.zwy3 = Math.Round(ave3 / average.Count, 2);
                    pa.zzd = pa.zwy2 - (pa.zwy1 + pa.zwy3) / 2;
                    pa.zix = DefaultBase.BarLength / pa.zzd;
                }
                else if (windPressureTest == PublicEnum.WindPressureTest.FStart)
                {
                    pa.fwy1 = Math.Round(ave1 / average.Count, 2);
                    pa.fwy2 = Math.Round(ave2 / average.Count, 2);
                    pa.fwy3 = Math.Round(ave3 / average.Count, 2);
                    pa.fzd = pa.zwy2 - (pa.zwy1 + pa.zwy3) / 2;
                    pa.fix = DefaultBase.BarLength / pa.zzd;
                }
                //清空初始化
                this.tim_static.Enabled = false;
                average = new List<Tuple<double, double, double>>();
                staticIndex = 1;
            }
            staticIndex++;
        }

        /// <summary>
        /// 计算
        /// </summary>
        /// <returns></returns>

        private double Calculate()
        {
            var one = new WindPressureDGV();
            var two = new WindPressureDGV();

            one = windPressureDGV.Find(t => t.Pa == (currentkPa - 250) + "Pa");
            two = windPressureDGV.Find(t => t.Pa == currentkPa + "Pa");

            float k = 0, b = 0;
            Formula.Calculate(currentkPa - 250, currentkPa, float.Parse(one.zzd.ToString()), float.Parse(two.zzd.ToString()), ref k, ref b);

            double x = 0;
            double.TryParse(txt_lx.Text, out x);

            if (k == 0 && b == 0)
                return Math.Round(x, 2);

            return Math.Round(k * x + b, 2);
        }

        /// <summary>
        /// 是否开始
        /// </summary>
        private bool IsStart = false;
        private void tim_btnType_Tick(object sender, EventArgs e)
        {
            if (!_tcpClient.IsTCPLink)
                return;

            if (windPressureTest == null)
                return;

            var IsSeccess = false;
            if (windPressureTest == PublicEnum.WindPressureTest.ZReady)
            {
                int value = _tcpClient.Read_FY_BtnType(BFMCommand.风压正压预备结束, ref IsSeccess);
                if (!IsSeccess)
                {
                    MessageBox.Show("风压正压预备结束状态异常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return;
                }
                if (value == 3)
                {
                    windPressureTest = PublicEnum.WindPressureTest.Stop;
                    lbl_setYL.Text = "0";
                    OpenBtnType();
                    this.tim_fy.Enabled = false;
                }
            }
            else if (windPressureTest == PublicEnum.WindPressureTest.ZStart)
            {
                double value = _tcpClient.Read_FY_BtnType(BFMCommand.风压正压开始结束, ref IsSeccess);

                if (!IsSeccess)
                {
                    MessageBox.Show("风压正压开始结束状态异常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return;
                }
                if (value >= 15)
                {
                    windPressureTest = PublicEnum.WindPressureTest.Stop;
                    IsStart = false;
                    Thread.Sleep(1000);
                    lbl_setYL.Text = "0";
                    OpenBtnType();

                    this.tim_fy.Enabled = false;
                }
            }
            else if (windPressureTest == PublicEnum.WindPressureTest.FReady)
            {
                int value = _tcpClient.Read_FY_BtnType(BFMCommand.风压负压预备结束, ref IsSeccess);

                if (!IsSeccess)
                {
                    MessageBox.Show("风压负压预备结束状态异常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return;
                }
                if (value == 3)
                {
                    windPressureTest = PublicEnum.WindPressureTest.Stop;
                    lbl_setYL.Text = "0";
                    OpenBtnType();

                    this.tim_fy.Enabled = false;
                }
            }
            else if (windPressureTest == PublicEnum.WindPressureTest.FStart)
            {
                double value = _tcpClient.Read_FY_BtnType(BFMCommand.风压负压开始结束, ref IsSeccess);

                if (!IsSeccess)
                {
                    MessageBox.Show("风压负压开始结束状态异常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return;
                }
                if (value >= 15)
                {
                    IsStart = false;
                    Thread.Sleep(1000);
                    lbl_setYL.Text = "0";
                    OpenBtnType();

                    this.tim_fy.Enabled = false;
                }
            }
            else if (windPressureTest == PublicEnum.WindPressureTest.ZRepeatedly)
            {
                int value = _tcpClient.Read_FY_BtnType(BFMCommand.正反复结束, ref IsSeccess);
                if (!IsSeccess)
                {
                    MessageBox.Show("正反复结束状态异常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return;
                }
                if (value == 5)
                {
                    Thread.Sleep(1000);
                    lbl_setYL.Text = "0";
                    OpenBtnType();
                    this.tim_fy.Enabled = false;
                }
            }
            else if (windPressureTest == PublicEnum.WindPressureTest.FRepeatedly)
            {
                int value = _tcpClient.Read_FY_BtnType(BFMCommand.负反复结束, ref IsSeccess);
                if (!IsSeccess)
                {
                    MessageBox.Show("负反复结束状态异常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return;
                }
                if (value == 5)
                {
                    Thread.Sleep(1000);
                    lbl_setYL.Text = "0";
                    OpenBtnType();
                    this.tim_fy.Enabled = false;
                }
            }
            else if (windPressureTest == PublicEnum.WindPressureTest.ZSafety)
            {
                int value = _tcpClient.Read_FY_BtnType(BFMCommand.正安全结束, ref IsSeccess);
                if (!IsSeccess)
                {
                    MessageBox.Show("正安全结束状态异常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return;
                }
                if (value == 5)
                {
                    Thread.Sleep(1000);
                    lbl_setYL.Text = "0";
                    OpenBtnType();
                    this.tim_fy.Enabled = false;
                }
            }
            else if (windPressureTest == PublicEnum.WindPressureTest.FSafety)
            {
                int value = _tcpClient.Read_FY_BtnType(BFMCommand.负安全结束, ref IsSeccess);
                if (!IsSeccess)
                {
                    MessageBox.Show("负安全结束状态异常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return;
                }
                if (value == 5)
                {
                    Thread.Sleep(1000);
                    lbl_setYL.Text = "0";
                    OpenBtnType();
                    this.tim_fy.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 开启按钮
        /// </summary>
        private void OpenBtnType()
        {
            this.btn_zyyb.Enabled = true;
            this.btn_zyks.Enabled = true;
            this.btn_fyyb.Enabled = true;
            this.btn_fyks.Enabled = true;
            this.btn_zff.Enabled = true;
            this.btn_fff.Enabled = true;
            this.btn_zaq.Enabled = true;
            this.btnfaq.Enabled = true;
        }

        /// <summary>
        /// 禁用按钮
        /// </summary>
        private void DisableBtnType()
        {
            this.btn_zyyb.Enabled = false;
            this.btn_zyks.Enabled = false;
            this.btn_fyyb.Enabled = false;
            this.btn_fyks.Enabled = false;
            this.btn_zff.Enabled = false;
            this.btn_fff.Enabled = false;
            this.btn_zaq.Enabled = false;
            this.btnfaq.Enabled = false;
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            Stop();
            OpenBtnType();
            lbl_setYL.Text = "0";
            windPressureTest = PublicEnum.WindPressureTest.Stop;
        }

        /// <summary>
        /// 急停
        /// </summary>
        private void Stop()
        {
            var res = _tcpClient.Stop();
            if (!res)
                MessageBox.Show("急停异常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }

        private void tim_view_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_tcpClient.IsTCPLink)
                {
                    BindData();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tChart_qm.Export.ShowExportDialog();
        }

        private void tChart_qm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.char_cms_click.Show(MousePosition.X, MousePosition.Y);
            }
        }
    }
}
