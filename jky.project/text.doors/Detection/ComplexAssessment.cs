using text.doors.Common;
using text.doors.dal;
using text.doors.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using text.doors.Model.DataBase;
using text.doors.Default;

namespace text.doors.Detection
{
    public partial class ComplexAssessment : Form
    {
        private static Young.Core.Logger.ILog Logger = Young.Core.Logger.LoggerManager.Current();
        public string _code = "";
        public int con = 0;
        /// <summary>
        /// 检验项目
        /// </summary>
        public PublicEnum.DetectionItem? DetectionItemEnum = null;
        public ComplexAssessment(string code)
        {
            InitializeComponent();
            this._code = code;
            InitResult();
        }


        /// <summary>
        /// 绑定检测结果
        /// </summary>
        private void InitResult()
        {
            try
            {
                DataTable dtSettings = new DAL_dt_Settings().Getdt_SettingsByCode(_code);

                var jyxm = dtSettings.Rows[0]["JianYanXiangMu"].ToString();
                var ischeck = GetItem(jyxm);
                if (ischeck == false)
                {
                    MessageBox.Show("请先检测设定", "检测", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    this.Hide();
                    DefaultBase.IsOpenComplexAssessment = false;
                    return;
                }

                DataTable dt = new DAL_dt_qm_Info().GetInfoByCode(_code, DetectionItemEnum);
                if (dt == null)
                {
                    MessageBox.Show("请先检测设定", "检测", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return;
                }

                con = int.Parse(dtSettings.Rows[0]["GuiGeShuLiang"].ToString());
                if (con > dt.Rows.Count)
                {
                    MessageBox.Show("未检测完成，请完成" + con + "樘检测", "检测", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    this.Hide();
                    DefaultBase.IsOpenComplexAssessment = false;
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        groupBox1.Text = dt.Rows[i]["info_DangH"].ToString();
                        if (DetectionItemEnum == PublicEnum.DetectionItem.enum_气密性能检测)
                        {
                            txt_1zfc.Text = dt.Rows[i]["qm_Z_FC"].ToString();
                            txt_1ffc.Text = dt.Rows[i]["qm_F_FC"].ToString();
                            txt_1zmj.Text = dt.Rows[i]["qm_Z_MJ"].ToString();
                            txt_1fmj.Text = dt.Rows[i]["qm_F_MJ"].ToString();
                        }
                        else if (DetectionItemEnum == PublicEnum.DetectionItem.enum_水密性能检测)
                        {
                            lbl_1desc.Text = dt.Rows[i]["sm_Remark"].ToString();
                            lbl_1resdesc.Text = dt.Rows[i]["sm_PaDesc"].ToString();
                            txt_1fy.Text = dt.Rows[i]["sm_Pa"].ToString();
                        }
                        else if (DetectionItemEnum == PublicEnum.DetectionItem.enum_气密性能及水密性能检测)
                        {
                            lbl_1desc.Text = dt.Rows[i]["sm_Remark"].ToString();
                            lbl_1resdesc.Text = dt.Rows[i]["sm_PaDesc"].ToString();
                            txt_1fy.Text = dt.Rows[i]["sm_Pa"].ToString();
                            txt_1zfc.Text = dt.Rows[i]["qm_Z_FC"].ToString();
                            txt_1ffc.Text = dt.Rows[i]["qm_F_FC"].ToString();
                            txt_1zmj.Text = dt.Rows[i]["qm_Z_MJ"].ToString();
                            txt_1fmj.Text = dt.Rows[i]["qm_F_MJ"].ToString();
                        }
                    }
                    if (i == 1)
                    {
                        groupBox2.Text = dt.Rows[i]["info_DangH"].ToString();
                        if (DetectionItemEnum == PublicEnum.DetectionItem.enum_气密性能检测)
                        {
                            txt_2zfc.Text = dt.Rows[i]["qm_Z_FC"].ToString();
                            txt_2ffc.Text = dt.Rows[i]["qm_F_FC"].ToString();
                            txt_2zmj.Text = dt.Rows[i]["qm_Z_MJ"].ToString();
                            txt_2fmj.Text = dt.Rows[i]["qm_F_MJ"].ToString();
                        }
                        else if (DetectionItemEnum == PublicEnum.DetectionItem.enum_水密性能检测)
                        {
                            lbl_2desc.Text = dt.Rows[i]["sm_Remark"].ToString();
                            lbl_2resdesc.Text = dt.Rows[i]["sm_PaDesc"].ToString();
                            txt_2fy.Text = dt.Rows[i]["sm_Pa"].ToString();
                        }
                        else if (DetectionItemEnum == PublicEnum.DetectionItem.enum_气密性能及水密性能检测)
                        {
                            lbl_2desc.Text = dt.Rows[i]["sm_Remark"].ToString();
                            lbl_2resdesc.Text = dt.Rows[i]["sm_PaDesc"].ToString();
                            txt_2fy.Text = dt.Rows[i]["sm_Pa"].ToString();
                            txt_2zfc.Text = dt.Rows[i]["qm_Z_FC"].ToString();
                            txt_2ffc.Text = dt.Rows[i]["qm_F_FC"].ToString();
                            txt_2zmj.Text = dt.Rows[i]["qm_Z_MJ"].ToString();
                            txt_2fmj.Text = dt.Rows[i]["qm_F_MJ"].ToString();
                        }
                    }
                    if (i == 2)
                    {
                        groupBox3.Text = dt.Rows[i]["info_DangH"].ToString();
                        if (DetectionItemEnum == PublicEnum.DetectionItem.enum_气密性能检测)
                        {
                            txt_3zfc.Text = dt.Rows[i]["qm_Z_FC"].ToString();
                            txt_3ffc.Text = dt.Rows[i]["qm_F_FC"].ToString();
                            txt_3zmj.Text = dt.Rows[i]["qm_Z_MJ"].ToString();
                            txt_3fmj.Text = dt.Rows[i]["qm_F_MJ"].ToString();
                        }
                        else if (DetectionItemEnum == PublicEnum.DetectionItem.enum_水密性能检测)
                        {
                            lbl_3desc.Text = dt.Rows[i]["sm_Remark"].ToString();
                            lbl_3resdesc.Text = dt.Rows[i]["sm_PaDesc"].ToString();
                            txt_3fy.Text = dt.Rows[i]["sm_Pa"].ToString();
                        }
                        else if (DetectionItemEnum == PublicEnum.DetectionItem.enum_气密性能及水密性能检测)
                        {
                            lbl_3desc.Text = dt.Rows[i]["sm_Remark"].ToString();
                            lbl_3resdesc.Text = dt.Rows[i]["sm_PaDesc"].ToString();
                            txt_3fy.Text = dt.Rows[i]["sm_Pa"].ToString();
                            txt_3zfc.Text = dt.Rows[i]["qm_Z_FC"].ToString();
                            txt_3ffc.Text = dt.Rows[i]["qm_F_FC"].ToString();
                            txt_3zmj.Text = dt.Rows[i]["qm_Z_MJ"].ToString();
                            txt_3fmj.Text = dt.Rows[i]["qm_F_MJ"].ToString();
                        }
                    }
                }
                DefaultBase.IsOpenComplexAssessment = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.Error(ex);
            }
        }

        private bool GetItem(string jyxm)
        {
            if (jyxm == "气密性能检测")
                DetectionItemEnum = PublicEnum.DetectionItem.enum_气密性能检测;
            else if (jyxm == "水密性能检测")
                DetectionItemEnum = PublicEnum.DetectionItem.enum_水密性能检测;
            else if (jyxm == "气密性能及水密性能检测")
                DetectionItemEnum = PublicEnum.DetectionItem.enum_气密性能及水密性能检测;
            else
                return false;

            return true;
        }



        /// <summary>
        /// 气密属性
        /// </summary>
        public double qm_z_FC = 0, qm_f_FC = 0, qm_z_MJ = 0, qm_f_MJ = 0;
        /// <summary>
        /// 水密属性
        /// </summary>
        public int sm_value = 999;

        #region --分级计算
        /// <summary>
        /// 获取水密等级
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int Get_SMLevel(DataTable dt)
        {
            int qmValue = 0;
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count == 3)
                    {
                        List<int> list = new List<int>() { int.Parse(dt.Rows[0]["sm_Pa"].ToString()), int.Parse(dt.Rows[1]["sm_Pa"].ToString()), int.Parse(dt.Rows[2]["sm_Pa"].ToString()) };
                        list.Sort();

                        int min = list[0], intermediate = list[1], max = list[2];
                        //int minlevel = new QM_Dict.AirtightLevel().GetList().Find(t => t.value == min).level,
                        //    intermediatelevel = new QM_Dict.AirtightLevel().GetList().Find(t => t.value == intermediate).level,
                        //    maxlevel = new QM_Dict.AirtightLevel().GetList().Find(t => t.value == max).level;
                        //todo  update
                        int minlevel = DefaultBase.AirtightLevel.ContainsKey(min) ? DefaultBase.AirtightLevel[min] : 0;
                        int intermediatelevel = DefaultBase.AirtightLevel.ContainsKey(intermediate) ? DefaultBase.AirtightLevel[intermediate] : 0;
                        int maxlevel = DefaultBase.AirtightLevel.ContainsKey(max) ? DefaultBase.AirtightLevel[max] : 0;

                        if ((maxlevel - intermediatelevel) > 2)
                        {
                            //todo update
                            foreach (var item in DefaultBase.AirtightLevel)
                            {
                                if (item.Value == (intermediatelevel + 2))
                                {
                                    max = item.Key;
                                    break;
                                }
                            }
                        }

                        qmValue = (min + intermediate + max) / 3;
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            qmValue += int.Parse(dt.Rows[i]["sm_Pa"].ToString());
                        }
                        qmValue = qmValue / dt.Rows.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.Error(ex);
            }
            return Formula.GetWaterTightLevel(qmValue);

        }

        /// <summary>
        /// 获取不标准的等级
        /// 范式 气密正负缝长平均值等级 与 气密正负压缝长平均值等级 最大的最次
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int Get_QMLevel(DataTable dt)
        {
            qm_z_FC = 0; qm_f_FC = 0; qm_z_MJ = 0; qm_f_MJ = 0;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    qm_z_FC += double.Parse(dt.Rows[i]["qm_Z_FC"].ToString());
                    qm_f_FC += double.Parse(dt.Rows[i]["qm_F_FC"].ToString());

                    qm_z_MJ += double.Parse(dt.Rows[i]["qm_Z_MJ"].ToString());
                    qm_f_MJ += double.Parse(dt.Rows[i]["qm_F_MJ"].ToString());
                }
                qm_z_FC = Math.Round(qm_z_FC / dt.Rows.Count, 2);
                qm_f_FC = Math.Round(qm_f_FC / dt.Rows.Count, 2);

                qm_z_MJ = Math.Round(qm_z_MJ / dt.Rows.Count, 2);
                qm_f_MJ = Math.Round(qm_f_MJ / dt.Rows.Count, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.Error(ex);
            }
            return GetQM_MaxLevel(qm_z_FC, qm_f_FC, qm_z_MJ, qm_f_MJ);
        }

       


        /// <summary>
        /// 获取气密最大等级
        /// </summary>
        /// <param name="fc"></param>
        /// <param name="mj"></param>
        /// <returns></returns>
        public int GetQM_MaxLevel(double qm_z_FC, double qm_f_FC, double qm_z_MJ, double qm_f_MJ)
        {
            int level_z_FJ = 0, level_f_FJ = 0, level_z_MJ = 0, level_f_MJ = 0;
            level_z_FJ = Formula.GetStitchLengthLevel(qm_z_FC);
            level_f_FJ = Formula.GetStitchLengthLevel(qm_f_FC);
            level_z_MJ = Formula.GetAreaLevel(qm_z_MJ);
            level_f_MJ = Formula.GetAreaLevel(qm_f_MJ);

            int[] arr = { level_z_FJ, level_f_FJ, level_z_MJ, level_f_MJ };
            ArrayList list = new ArrayList(arr);
            list.Sort();
            return Convert.ToInt32(list[0]);
        }


        #endregion

        private void btn_audit_Click(object sender, EventArgs e)
        {
            #region 修改监测数据
            List<Model_dt_qm_Info> qmList = new List<Model_dt_qm_Info>();

            try
            {
                if (DetectionItemEnum == PublicEnum.DetectionItem.enum_气密性能检测 || DetectionItemEnum == PublicEnum.DetectionItem.enum_气密性能及水密性能检测)
                {
                    for (int i = 0; i < con; i++)
                    {
                        Model_dt_qm_Info model = new Model_dt_qm_Info();
                        model.dt_Code = _code;
                        if (i == 0)
                        {
                            model.info_DangH = groupBox1.Text;
                            model.qm_Z_FC = txt_1zfc.Text;
                            model.qm_F_FC = txt_1ffc.Text;
                            model.qm_Z_MJ = txt_1zmj.Text;
                            model.qm_F_MJ = txt_1fmj.Text;
                            qmList.Add(model);
                        }
                        if (i == 1)
                        {
                            model.info_DangH = groupBox2.Text;
                            model.qm_Z_FC = txt_2zfc.Text;
                            model.qm_F_FC = txt_2ffc.Text;
                            model.qm_Z_MJ = txt_2zmj.Text;
                            model.qm_F_MJ = txt_2fmj.Text;
                            qmList.Add(model);
                        }
                        if (i == 2)
                        {
                            model.info_DangH = groupBox3.Text;
                            model.qm_Z_FC = txt_3zfc.Text;
                            model.qm_F_FC = txt_3ffc.Text;
                            model.qm_Z_MJ = txt_3zmj.Text;
                            model.qm_F_MJ = txt_3fmj.Text;
                            qmList.Add(model);
                        }
                    }
                }


                List<Model_dt_sm_Info> smList = new List<Model_dt_sm_Info>();
                if (DetectionItemEnum == PublicEnum.DetectionItem.enum_水密性能检测 || DetectionItemEnum == PublicEnum.DetectionItem.enum_气密性能及水密性能检测)
                {
                    for (int i = 0; i < con; i++)
                    {
                        Model_dt_sm_Info model = new Model_dt_sm_Info();
                        model.dt_Code = _code;
                        if (i == 0)
                        {
                            model.info_DangH = groupBox1.Text;
                            model.sm_Pa = txt_1fy.Text;
                            model.sm_PaDesc = lbl_1resdesc.Text;
                            model.sm_Remark = lbl_1desc.Text;
                            smList.Add(model);
                        }
                        if (i == 1)
                        {
                            model.info_DangH = groupBox2.Text;
                            model.sm_Pa = txt_2fy.Text;
                            model.sm_PaDesc = lbl_2resdesc.Text;
                            model.sm_Remark = lbl_2desc.Text;
                            smList.Add(model);
                        }
                        if (i == 2)
                        {
                            model.info_DangH = groupBox3.Text;
                            model.sm_Pa = txt_3fy.Text;
                            model.sm_PaDesc = lbl_3resdesc.Text;
                            model.sm_Remark = lbl_3desc.Text;
                            smList.Add(model);
                        }
                    }
                }

                new DAL_dt_qm_Info().AddSM_QM(qmList, smList, DetectionItemEnum);

                #endregion

                #region 获取设置后的樘号信息 --   判定
                InitResult();

                DataTable settings = new DAL_dt_Settings().Getdt_SettingsByCode(_code);
                if (settings != null && settings.Rows.Count > 0)
                {
                    txt_sjz1.Text = settings.Rows[0]["ShuiMiSheJiZhi"].ToString();
                    txt_sjz2.Text = settings.Rows[0]["QiMiZhengYaDanWeiFengChangSheJiZhi"].ToString();
                    txt_sjz3.Text = settings.Rows[0]["QiMiFuYaDanWeiFengChangSheJiZhi"].ToString();
                    txt_sjz4.Text = settings.Rows[0]["QiMiZhengYaDanWeiMianJiSheJiZhi"].ToString();
                    txt_sjz5.Text = settings.Rows[0]["QiMiFuYaDanWeiMianJiSheJiZhi"].ToString();
                }
                DataTable dt = new DAL_dt_qm_Info().GetInfoByCode(_code, DetectionItemEnum);
                if (DetectionItemEnum == PublicEnum.DetectionItem.enum_气密性能检测 || DetectionItemEnum == PublicEnum.DetectionItem.enum_气密性能及水密性能检测)
                {
                    txt_dj1.Text = Get_QMLevel(dt).ToString();
                    if (qm_z_FC >= double.Parse(txt_sjz2.Text))
                        txt_jg2.Text = "合格";
                    else
                        txt_jg2.Text = "不合格";

                    if (qm_f_FC >= double.Parse(txt_sjz3.Text))
                        txt_jg3.Text = "合格";
                    else
                        txt_jg3.Text = "不合格";

                    if (qm_z_MJ >= double.Parse(txt_sjz4.Text))
                        txt_jg4.Text = "合格";
                    else
                        txt_jg4.Text = "不合格";

                    if (qm_f_MJ <= double.Parse(txt_sjz4.Text))
                        txt_jg5.Text = "合格";
                    else
                        txt_jg5.Text = "不合格";
                }
                if (DetectionItemEnum == PublicEnum.DetectionItem.enum_水密性能检测 || DetectionItemEnum == PublicEnum.DetectionItem.enum_气密性能及水密性能检测)
                {
                    txt_dj2.Text = Get_SMLevel(dt).ToString();

                    if (sm_value >= int.Parse(txt_sjz1.Text))
                        txt_jg1.Text = "合格";
                    else
                        txt_jg1.Text = "不合格";
                }

                #endregion
                MessageBox.Show("生成成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.Error(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportReport er = new ExportReport(_code);
            er.Show();
        }
    }
}
