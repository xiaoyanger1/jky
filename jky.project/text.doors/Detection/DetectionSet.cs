using text.doors.Common;
using text.doors.dal;
using text.doors.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using text.doors.Model.DataBase;

namespace text.doors.Detection
{
    public partial class DetectionSet : Form
    {
        //当前温度
        public double _DQWD { set; get; }
        //当前压力
        public double _DQYL { set; get; }

        private string CurrCode = "";
        private string CurrDangH = "";

        public DetectionSet(double dqwd, double dqyl, string JYBH, string DQDH)
        {
            this._DQWD = dqwd;
            this._DQYL = dqyl;
            this.CurrCode = JYBH;
            this.CurrDangH = DQDH;
            InitializeComponent();
            Init();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            string code = btn_JianYanBianHao.Text;
            if (string.IsNullOrWhiteSpace(cb_DangQianDangHao.Text))
            {
                MessageBox.Show("请设置樘号！", "请设置樘号！", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("请设置当前编号！", "请设置当前编号！", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }

            DAL_dt_Settings dal = new DAL_dt_Settings();
          

            var setting = GetSettings();
            var Info = Getdt_Info(setting.dt_Code);
            if (dal.AddSettings(setting, Info))
            {
                MessageBox.Show("设定完成！", "设定完成！", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                //获取樘号
                deleBottomTypeEvent(GetBottomType(true));

                this.btn_add.Enabled = true;
                this.btn_select.Enabled = true;
                this.btn_delete.Enabled = true;
                this.btn_Ok.Enabled = true;

                this.Close();
            }
        }

        private object Getdt_Info()
        {
            throw new NotImplementedException();
        }
        public void GetDangHaoTrigger()
        {
            //获取樘号
            deleBottomTypeEvent(GetBottomType(false));
        }

        private void Init()
        {
            BindInfoText();
            BindDangQianDangHao();
        }
        private void SelectDangHao(object sender, text.doors.Detection.Select_Code.TransmitEventArgs e)
        {
            CurrCode = e.Code;
            CurrDangH = e.DangHao;
            Init();
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            Select_Code sc = new Select_Code();
            sc.Transmit += new Select_Code.TransmitHandler(SelectDangHao);
            sc.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            MessageBox.Show("您是否删除", " 永久性删除",
                               MessageBoxButtons.OKCancel,
                               MessageBoxIcon.Warning,
                               MessageBoxDefaultButton.Button2,
                              MessageBoxOptions.ServiceNotification
                              );

            if (new DAL_dt_Info().delete_dt_Info(btn_JianYanBianHao.Text))
            {
                CurrCode = "";
                Init();
            }
        }


        #region Info



        /// <summary>
        /// 绑定控件
        /// </summary>
        private void BindInfoText()
        {
            DataTable dt = new DAL_dt_Settings().Getdt_SettingsByCode(CurrCode);
            if (dt != null)
            {
                btn_WeiTuoBianHao.Text = dt.Rows[0]["WeiTuoBianHao"].ToString();
                btn_WeiTuoDanWei.Text = dt.Rows[0]["WeiTuoDanWei"].ToString();
                btn_WeiTuoRen.Text = dt.Rows[0]["WeiTuoRen"].ToString();
                btn_YangPinMingCheng.Text = dt.Rows[0]["YangPinMingCheng"].ToString();
                cb_CaiYangFangShi.Text = dt.Rows[0]["CaiYangFangShi"].ToString();
                cb_JianYanXiangMu.Text = dt.Rows[0]["JianYanXiangMu"].ToString();
                btn_GuiGeXingHao.Text = dt.Rows[0]["GuiGeXingHao"].ToString();
                btn_GuiGeShuLiang.Text = dt.Rows[0]["GuiGeShuLiang"].ToString();
                btn_JianYanRiQi.Text = dt.Rows[0]["JianYanRiQi"].ToString();
                cb_KaiQiFangShi.Text = dt.Rows[0]["KaiQiFangShi"].ToString();
                btn_DaQiYaLi.Text = dt.Rows[0]["DaQiYaLi"].ToString();
                cb_BoLiPinZhong.Text = dt.Rows[0]["BoLiPinZhong"].ToString();
                btn_DangQianWenDu.Text = dt.Rows[0]["DangQianWenDu"].ToString();
                btn_BoLiHouDu.Text = dt.Rows[0]["BoLiHouDu"].ToString();
                btn_ZongMianJi.Text = dt.Rows[0]["ZongMianJi"].ToString();
                btn_ZuiDaBoLi.Text = dt.Rows[0]["ZuiDaBoLi"].ToString();
                btn_KaiQiFengChang.Text = dt.Rows[0]["KaiQiFengChang"].ToString();
                cb_BoLiMiFeng.Text = dt.Rows[0]["BoLiMiFeng"].ToString();
                cb_XiangQianFangShi.Text = dt.Rows[0]["XiangQianFangShi"].ToString();
                btn_ShuiMiDengJiSheJiZhi.Text = dt.Rows[0]["ShuiMiDengJiSheJiZhi"].ToString();
                cb_KuangShanMiFang.Text = dt.Rows[0]["KuangShanMiFang"].ToString();
                btn_QiMiZhengYaDanWeiFengChangSheJiZhi.Text = dt.Rows[0]["QiMiZhengYaDanWeiFengChangSheJiZhi"].ToString();
                btn_ZhengYaQiMiDengJiSheJiZhi.Text = dt.Rows[0]["ZhengYaQiMiDengJiSheJiZhi"].ToString();
                btn_QiMiFuYaDanWeiFengChangSheJiZhi.Text = dt.Rows[0]["QiMiFuYaDanWeiFengChangSheJiZhi"].ToString();
                btn_FuYaQiMiDengJiSheJiZhi.Text = dt.Rows[0]["FuYaQiMiDengJiSheJiZhi"].ToString();
                btn_ShuiMiSheJiZhi.Text = dt.Rows[0]["ShuiMiSheJiZhi"].ToString();
                btn_QiMiZhengYaDanWeiMianJiSheJiZhi.Text = dt.Rows[0]["QiMiZhengYaDanWeiMianJiSheJiZhi"].ToString();
                btn_QiMiFuYaDanWeiMianJiSheJiZhi.Text = dt.Rows[0]["QiMiFuYaDanWeiMianJiSheJiZhi"].ToString();
                cb_JianYanYiJu.Text = dt.Rows[0]["JianYanYiJu"].ToString();
                btn_GongChengMingCheng.Text = dt.Rows[0]["GongChengMingCheng"].ToString();
                btn_GongChengDiDian.Text = dt.Rows[0]["GongChengDiDian"].ToString();
                btn_ShengChanDanWei.Text = dt.Rows[0]["ShengChanDanWei"].ToString();
                btn_JianLiDanWei.Text = dt.Rows[0]["JianLiDanWei"].ToString();
                btn_JianZhengRen.Text = dt.Rows[0]["JianZhengRen"].ToString();
                btn_JianZhengHao.Text = dt.Rows[0]["JianZhengHao"].ToString();
                btn_ShiGongDanWei.Text = dt.Rows[0]["ShiGongDanWei"].ToString();
                btn_WuJinJianZhuangKuang.Text = dt.Rows[0]["WuJinJianZhuangKuang"].ToString();
                btn_SuLiaoChuangChenJinChiCun.Text = dt.Rows[0]["SuLiaoChuangChenJinChiCun"].ToString();
                btn_ShiFouJiaLuoSi.Text = dt.Rows[0]["ShiFouJiaLuoSi"].ToString();
                btn_XingCaiGuiGe.Text = dt.Rows[0]["XingCaiGuiGe"].ToString();
                btn_XingCaiBiHou.Text = dt.Rows[0]["XingCaiBiHou"].ToString();
                btn_XingCaiShengChanChang.Text = dt.Rows[0]["XingCaiShengChanChang"].ToString();

                CurrCode = dt.Rows[0]["dt_Code"].ToString();
                CurrDangH = dt.Rows[0]["info_DangH"].ToString();
                cb_DangQianDangHao.Text = dt.Rows[0]["info_DangH"].ToString();
                btn_JianYanBianHao.Text = dt.Rows[0]["dt_Code"].ToString();
            }

            if (string.IsNullOrEmpty(btn_GuiGeShuLiang.Text))
            {
                btn_GuiGeShuLiang.Text = "3";
            } if (_DQYL != 0 && _DQWD != 0)
            {
                btn_DaQiYaLi.Text = _DQYL.ToString();
                btn_DangQianWenDu.Text = _DQWD.ToString();
            }
        }


        private Model_dt_Settings GetSettings()
        {
            Model_dt_Settings model = new Model_dt_Settings();
            model.dt_Create = DateTime.Now.ToString();
            model.dt_Code = this.btn_JianYanBianHao.Text;
            model.WeiTuoBianHao = this.btn_WeiTuoBianHao.Text;
            model.WeiTuoDanWei = this.btn_WeiTuoDanWei.Text;
            model.WeiTuoRen = this.btn_WeiTuoRen.Text;
            model.YangPinMingCheng = this.btn_YangPinMingCheng.Text;
            model.CaiYangFangShi = this.cb_CaiYangFangShi.Text;
            model.JianYanXiangMu = this.cb_JianYanXiangMu.Text;
            model.GuiGeXingHao = this.btn_GuiGeXingHao.Text;
            model.GuiGeShuLiang = this.btn_GuiGeShuLiang.Text;
            model.JianYanRiQi = this.btn_JianYanRiQi.Text;
            model.KaiQiFangShi = this.cb_KaiQiFangShi.Text;
            model.DaQiYaLi = this.btn_DaQiYaLi.Text;
            model.BoLiPinZhong = this.cb_BoLiPinZhong.Text;
            model.DangQianWenDu = this.btn_DangQianWenDu.Text;
            model.BoLiHouDu = this.btn_BoLiHouDu.Text;
            model.ZongMianJi = this.btn_ZongMianJi.Text;
            model.ZuiDaBoLi = this.btn_ZuiDaBoLi.Text;
            model.KaiQiFengChang = this.btn_KaiQiFengChang.Text;
            model.BoLiMiFeng = this.cb_BoLiMiFeng.Text;
            model.XiangQianFangShi = this.cb_XiangQianFangShi.Text;
            model.ShuiMiDengJiSheJiZhi = this.btn_ShuiMiDengJiSheJiZhi.Text;
            model.KuangShanMiFang = this.cb_KuangShanMiFang.Text;
            model.QiMiZhengYaDanWeiFengChangSheJiZhi = this.btn_QiMiZhengYaDanWeiFengChangSheJiZhi.Text;
            model.ZhengYaQiMiDengJiSheJiZhi = this.btn_ZhengYaQiMiDengJiSheJiZhi.Text;
            model.QiMiFuYaDanWeiFengChangSheJiZhi = this.btn_QiMiFuYaDanWeiFengChangSheJiZhi.Text;
            model.FuYaQiMiDengJiSheJiZhi = this.btn_FuYaQiMiDengJiSheJiZhi.Text;
            model.ShuiMiSheJiZhi = this.btn_ShuiMiSheJiZhi.Text;
            model.QiMiZhengYaDanWeiMianJiSheJiZhi = this.btn_QiMiZhengYaDanWeiMianJiSheJiZhi.Text;
            model.QiMiFuYaDanWeiMianJiSheJiZhi = this.btn_QiMiFuYaDanWeiMianJiSheJiZhi.Text;
            model.JianYanYiJu = this.cb_JianYanYiJu.Text;
            model.GongChengMingCheng = this.btn_GongChengMingCheng.Text;
            model.GongChengDiDian = this.btn_GongChengDiDian.Text;
            model.ShengChanDanWei = this.btn_ShengChanDanWei.Text;
            model.JianLiDanWei = this.btn_JianLiDanWei.Text;
            model.JianZhengRen = this.btn_JianZhengRen.Text;
            model.JianZhengHao = this.btn_JianZhengHao.Text;
            model.ShiGongDanWei = this.btn_ShiGongDanWei.Text;
            model.WuJinJianZhuangKuang = this.btn_WuJinJianZhuangKuang.Text;
            model.SuLiaoChuangChenJinChiCun = this.btn_SuLiaoChuangChenJinChiCun.Text;
            model.ShiFouJiaLuoSi = this.btn_ShiFouJiaLuoSi.Text;
            model.XingCaiGuiGe = this.btn_XingCaiGuiGe.Text;
            model.XingCaiBiHou = this.btn_XingCaiBiHou.Text;
            model.XingCaiShengChanChang = this.btn_XingCaiShengChanChang.Text;
            return model;
        }


        private Model_dt_Info Getdt_Info(string code)
        {
            Model_dt_Info model = new Model_dt_Info();
            model.info_DangH = this.cb_DangQianDangHao.Text;
            model.dt_Code = code;
            model.Is_Check = 1;
            model.info_Create = DateTime.Now.ToString();
            return model;
        }

        #endregion


        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(btn_JianYanBianHao.Text))
            {
                MessageBox.Show("请输入编号");
            }
            var arr = btn_JianYanBianHao.Text.Split('-');
            if (arr.Length == 1)
            {
                MessageBox.Show("编号格式有误，请输入如d-1格式");
                return;
            }
            btn_JianYanBianHao.Text = arr[0] + "-" + (int.Parse(arr[1]) + 1).ToString();

            this.btn_add.Enabled = false;
            this.btn_select.Enabled = false;
            this.btn_delete.Enabled = false;
            this.btn_Ok.Enabled = true;

            BindDangQianDangHao();
        }


        private void BindDangQianDangHao()
        {
            try
            {
                cb_DangQianDangHao.Items.Clear();
                int count = int.Parse(btn_GuiGeShuLiang.Text);
                for (int i = 1; i <= count; i++)
                {
                    cb_DangQianDangHao.Items.Add("第" + i + "樘");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("规格数量请输入数字");
            }
        }
        private void btn_GuiGeShuLiang_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                if (int.Parse(btn_GuiGeShuLiang.Text) > 3)
                {
                    MessageBox.Show("最大只能输入三樘");
                    btn_GuiGeShuLiang.Text = "";
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("最大只能输入三樘");
                return;
            }

            if (string.IsNullOrWhiteSpace(btn_GuiGeShuLiang.Text))
            {
                MessageBox.Show("请填写规格数量");
                return;
            }
            BindDangQianDangHao();
        }

        #region 底部状态栏赋值

        private BottomType GetBottomType(bool ISOK)
        {
            BottomType bt = new BottomType(cb_DangQianDangHao.Text, btn_JianYanBianHao.Text, ISOK);
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
            private string _BianHao;
            private string _DangHao;
            private bool _ISOK;

            public BottomType(string dangHao, string bianHao, bool isOK)
            {
                this._BianHao = bianHao;
                this._DangHao = dangHao;
                this._ISOK = isOK;

            }
            public string BianHao { get { return _BianHao; } }
            public string DangHao { get { return _DangHao; } }
            public bool ISOK { get { return _ISOK; } }
        }
        #endregion

    }
}
