using text.doors.Common;
using text.doors.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text.doors.Model.DataBase;
using Young.Core.SQLite;

namespace text.doors.dal
{
    public class DAL_dt_Settings
    {
        /// <summary>
        /// 添加基本编号设置
        /// </summary>
        public bool AddSettings(Model_dt_Settings model, Model_dt_Info info)
        {
            var res = false;

            string delsql = "delete from dt_Settings where dt_Code='" + model.dt_Code + "'";
            SQLiteHelper.ExecuteNonQuery(delsql);

            #region 添加主表
            string sql = string.Format(@"
                                        insert into dt_Settings
                                        (
                                        WeiTuoBianHao,
                                        WeiTuoDanWei,
                                        WeiTuoRen ,
                                        YangPinMingCheng,
                                        CaiYangFangShi , -- int
                                        JianYanXiangMu , -- int
                                        GuiGeXingHao,
                                        GuiGeShuLiang ,
                                        JianYanRiQi ,
                                        KaiQiFangShi , -- int
                                        DaQiYaLi,
                                        BoLiPinZhong  , -- int
                                        DangQianWenDu ,
                                        BoLiHouDu ,
                                        ZongMianJi ,
                                        ZuiDaBoLi  ,
                                        KaiQiFengChang ,
                                        BoLiMiFeng ,   -- int
                                        XiangQianFangShi ,  -- int
                                        ShuiMiDengJiSheJiZhi ,
                                        KuangShanMiFang , -- int
                                        QiMiZhengYaDanWeiFengChangSheJiZhi ,
                                        ZhengYaQiMiDengJiSheJiZhi ,
                                        QiMiFuYaDanWeiFengChangSheJiZhi,
                                        FuYaQiMiDengJiSheJiZhi ,
                                        ShuiMiSheJiZhi ,
                                        QiMiZhengYaDanWeiMianJiSheJiZhi ,
                                        QiMiFuYaDanWeiMianJiSheJiZhi,
                                        JianYanYiJu , -- int
                                        GongChengMingCheng ,
                                        GongChengDiDian,
                                        ShengChanDanWei ,
                                        JianLiDanWei,
                                        JianZhengRen,
                                        JianZhengHao ,
                                        ShiGongDanWei ,
                                        WuJinJianZhuangKuang ,
                                        SuLiaoChuangChenJinChiCun ,
                                        ShiFouJiaLuoSi ,
                                        XingCaiGuiGe ,
                                        XingCaiBiHou ,
                                        XingCaiShengChanChang,
                                        dt_Code,
                                        dt_Create,
                                        GanJianChangDu,
                                        KangFengYaDengJiSheJiZhi,
                                        KangFengYaSheJiZhi,
                                        DanShanDanSuoDian
                                        )
                                        VALUES
                                        (
                                        '{0}','{1}','{2}' ,'{3}','{4}' , '{5}' , '{6}','{7}' ,'{8}' ,'{9}' , '{10}','{11}'  ,  '{12}' ,'{13}' ,'{14}' ,'{15}'  ,'{16}' ,'{17}','{18}' , '{19}' ,
                                        '{20}' , '{21}' ,'{22}' ,'{23}','{24}' ,'{25}' ,'{26}' ,'{27}','{28}' , '{29}' ,'{30}','{31}' ,'{32}','{33}','{34}' ,'{35}' ,'{36}' ,'{37}' ,'{38}' ,
                                        '{39}' ,'{40}' ,'{41}','{42}',datetime('now'),'{43}','{44}','{45}','{46}')",
                                        model.WeiTuoBianHao,
                                        model.WeiTuoDanWei,
                                        model.WeiTuoRen,
                                        model.YangPinMingCheng,
                                        model.CaiYangFangShi,
                                        model.JianYanXiangMu,
                                        model.GuiGeXingHao,
                                        model.GuiGeShuLiang,
                                        model.JianYanRiQi,
                                        model.KaiQiFangShi,
                                        model.DaQiYaLi,
                                        model.BoLiPinZhong,
                                        model.DangQianWenDu,
                                        model.BoLiHouDu,
                                        model.ZongMianJi,
                                        model.ZuiDaBoLi,
                                        model.KaiQiFengChang,
                                        model.BoLiMiFeng,
                                        model.XiangQianFangShi,
                                        model.ShuiMiDengJiSheJiZhi,
                                        model.KuangShanMiFang,
                                        model.QiMiZhengYaDanWeiFengChangSheJiZhi,
                                        model.ZhengYaQiMiDengJiSheJiZhi,
                                        model.QiMiFuYaDanWeiFengChangSheJiZhi,
                                        model.FuYaQiMiDengJiSheJiZhi,
                                        model.ShuiMiSheJiZhi,
                                        model.QiMiZhengYaDanWeiMianJiSheJiZhi,
                                        model.QiMiFuYaDanWeiMianJiSheJiZhi,
                                        model.JianYanYiJu,
                                        model.GongChengMingCheng,
                                        model.GongChengDiDian,
                                        model.ShengChanDanWei,
                                        model.JianLiDanWei,
                                        model.JianZhengRen,
                                        model.JianZhengHao,
                                        model.ShiGongDanWei,
                                        model.WuJinJianZhuangKuang,
                                        model.SuLiaoChuangChenJinChiCun,
                                        model.ShiFouJiaLuoSi,
                                        model.XingCaiGuiGe,
                                        model.XingCaiBiHou,
                                        model.XingCaiShengChanChang,
                                        model.dt_Code,
                                        model.GanJianChangDu,
                                        model.KangFengYaDengJiSheJiZhi,
                                        model.KangFengYaSheJiZhi,
                                        model.DanShanDanSuoDian
                                        );
            res = SQLiteHelper.ExecuteNonQuery(sql) > 0 ? true : false;
            #endregion
            res = new DAL_dt_Info().Adddt_dt_Info(info, model.dt_Code);
            return res;
        }

        /// <summary>
        /// 删除设置
        /// </summary>
        public bool Delete_Settings(string code)
        {
            string sql = "delete from  dt_Settings where dt_Code=" + code + "";
            return SQLiteHelper.ExecuteNonQuery(sql) > 0 ? true : false;
        }

        /// <summary>
        /// 查询编号，如编号等于null，则查询最近一次数据
        /// </summary>
        /// <param name="code">编号</param>
        /// <returns></returns>
        public DataTable Getdt_SettingsByCode(string code)
        {
            string sql = "";
            if (string.IsNullOrWhiteSpace(code))
            {
                sql = @"select t.*,t1.info_DangH from (select * from dt_Settings order by  dt_Create desc  LIMIT(1) ) t
                        join dt_Info  t1 on t.dt_Code = t1.dt_Code
                        where t1.Is_Check = 1";
            }
            else
            {

                sql = @"select t.*,t1.info_DangH from dt_Settings  t
                            join dt_Info  t1 on t.dt_Code = t1.dt_Code
                            where t.dt_Code ='" + code + "' and t1.Is_Check = 1 ";
            }
            DataRow dr = SQLiteHelper.ExecuteDataRow(sql);
            if (dr == null)
                return null;
            return dr.Table;
        }


        /// <summary>
        /// 获取本次检测的结果
        /// </summary>
        /// <param name="code">编号</param>
        /// <returns></returns>
        public Model_dt_Settings Getdt_SettingsResByCode(string code)
        {
            string sql = @"select t.*,t1.info_DangH,t2.qm_Z_FC,t2.qm_F_FC,t2.qm_Z_MJ,t2.qm_F_MJ,t3.sm_PaDesc,t3.sm_Pa,t3.sm_Remark,
    qm_s_z_fj100,qm_s_z_fj150,qm_j_z_fj100,qm_s_z_zd100,qm_s_z_zd150,qm_j_z_zd100,qm_s_f_fj100,qm_s_f_fj150,qm_j_f_fj100,qm_s_f_zd100,qm_s_f_zd150,qm_j_f_zd100	
from dt_Settings  t
                            left join dt_Info  t1 on t.dt_Code = t1.dt_Code
                            left join dt_qm_Info t2  on t2.dt_Code = t1.dt_Code and t1.info_DangH = t2.info_DangH 
                            left join dt_sm_Info t3  on t3.dt_Code = t1.dt_Code and t1.info_DangH = t3.info_DangH 
                            where t.dt_Code ='" + code + "'";



            DataRow dr = SQLiteHelper.ExecuteDataRow(sql);
            if (dr == null)
                return null;
            DataTable dt = dr.Table;

            Model_dt_Settings dt_Settings = new Model_dt_Settings();

            List<Model_dt_Info> dt_InfoList = new List<Model_dt_Info>();
            List<Model_dt_qm_Info> dt_qm_InfoList = new List<Model_dt_qm_Info>();
            List<Model_dt_sm_Info> dt_sm_InfoList = new List<Model_dt_sm_Info>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Model_dt_Info dt_Info = new Model_dt_Info();
                Model_dt_qm_Info dt_qm_Info = new Model_dt_qm_Info();
                Model_dt_sm_Info dt_sm_Info = new Model_dt_sm_Info();
                if (i == 0)
                {
                    dt_Settings.WeiTuoBianHao = dt.Rows[i]["WeiTuoBianHao"].ToString();
                    dt_Settings.WeiTuoDanWei = dt.Rows[i]["WeiTuoDanWei"].ToString();
                    dt_Settings.WeiTuoRen = dt.Rows[i]["WeiTuoRen"].ToString();
                    dt_Settings.YangPinMingCheng = dt.Rows[i]["YangPinMingCheng"].ToString();
                    dt_Settings.CaiYangFangShi = dt.Rows[i]["CaiYangFangShi"].ToString();
                    dt_Settings.JianYanXiangMu = dt.Rows[i]["JianYanXiangMu"].ToString();
                    dt_Settings.GuiGeXingHao = dt.Rows[i]["GuiGeXingHao"].ToString();
                    dt_Settings.GuiGeShuLiang = dt.Rows[i]["GuiGeShuLiang"].ToString();
                    dt_Settings.JianYanRiQi = dt.Rows[i]["JianYanRiQi"].ToString();
                    dt_Settings.KaiQiFangShi = dt.Rows[i]["KaiQiFangShi"].ToString();
                    dt_Settings.DaQiYaLi = dt.Rows[i]["DaQiYaLi"].ToString();
                    dt_Settings.BoLiPinZhong = dt.Rows[i]["BoLiPinZhong"].ToString();
                    dt_Settings.DangQianWenDu = dt.Rows[i]["DangQianWenDu"].ToString();
                    dt_Settings.BoLiHouDu = dt.Rows[i]["BoLiHouDu"].ToString();
                    dt_Settings.ZongMianJi = dt.Rows[i]["ZongMianJi"].ToString();
                    dt_Settings.ZuiDaBoLi = dt.Rows[i]["ZuiDaBoLi"].ToString();
                    dt_Settings.KaiQiFengChang = dt.Rows[i]["KaiQiFengChang"].ToString();
                    dt_Settings.BoLiMiFeng = dt.Rows[i]["BoLiMiFeng"].ToString();
                    dt_Settings.XiangQianFangShi = dt.Rows[i]["XiangQianFangShi"].ToString();
                    dt_Settings.ShuiMiDengJiSheJiZhi = dt.Rows[i]["ShuiMiDengJiSheJiZhi"].ToString();
                    dt_Settings.KuangShanMiFang = dt.Rows[i]["KuangShanMiFang"].ToString();
                    dt_Settings.QiMiZhengYaDanWeiFengChangSheJiZhi = dt.Rows[i]["QiMiZhengYaDanWeiFengChangSheJiZhi"].ToString();
                    dt_Settings.ZhengYaQiMiDengJiSheJiZhi = dt.Rows[i]["ZhengYaQiMiDengJiSheJiZhi"].ToString();
                    dt_Settings.QiMiFuYaDanWeiFengChangSheJiZhi = dt.Rows[i]["QiMiFuYaDanWeiFengChangSheJiZhi"].ToString();
                    dt_Settings.FuYaQiMiDengJiSheJiZhi = dt.Rows[i]["FuYaQiMiDengJiSheJiZhi"].ToString();
                    dt_Settings.ShuiMiSheJiZhi = dt.Rows[i]["ShuiMiSheJiZhi"].ToString();
                    dt_Settings.QiMiZhengYaDanWeiMianJiSheJiZhi = dt.Rows[i]["QiMiZhengYaDanWeiMianJiSheJiZhi"].ToString();
                    dt_Settings.QiMiFuYaDanWeiMianJiSheJiZhi = dt.Rows[i]["QiMiFuYaDanWeiMianJiSheJiZhi"].ToString();
                    dt_Settings.JianYanYiJu = dt.Rows[i]["JianYanYiJu"].ToString();
                    dt_Settings.GongChengMingCheng = dt.Rows[i]["GongChengMingCheng"].ToString();
                    dt_Settings.GongChengDiDian = dt.Rows[i]["GongChengDiDian"].ToString();
                    dt_Settings.ShengChanDanWei = dt.Rows[i]["ShengChanDanWei"].ToString();
                    dt_Settings.JianLiDanWei = dt.Rows[i]["JianLiDanWei"].ToString();
                    dt_Settings.JianZhengRen = dt.Rows[i]["JianZhengRen"].ToString();
                    dt_Settings.JianZhengHao = dt.Rows[i]["JianZhengHao"].ToString();
                    dt_Settings.ShiGongDanWei = dt.Rows[i]["ShiGongDanWei"].ToString();
                    dt_Settings.WuJinJianZhuangKuang = dt.Rows[i]["WuJinJianZhuangKuang"].ToString();
                    dt_Settings.SuLiaoChuangChenJinChiCun = dt.Rows[i]["SuLiaoChuangChenJinChiCun"].ToString();
                    dt_Settings.ShiFouJiaLuoSi = dt.Rows[i]["ShiFouJiaLuoSi"].ToString();
                    dt_Settings.XingCaiGuiGe = dt.Rows[i]["XingCaiGuiGe"].ToString();
                    dt_Settings.XingCaiBiHou = dt.Rows[i]["XingCaiBiHou"].ToString();
                    dt_Settings.XingCaiShengChanChang = dt.Rows[i]["XingCaiShengChanChang"].ToString();
                    dt_Settings.dt_Code = dt.Rows[i]["dt_Code"].ToString();
                    dt_Settings.dt_Create = DateTime.Parse(dt.Rows[i]["dt_Create"].ToString());
                    dt_Settings.GanJianChangDu = dt.Rows[i]["GanJianChangDu"].ToString();
                    dt_Settings.KangFengYaDengJiSheJiZhi = dt.Rows[i]["KangFengYaDengJiSheJiZhi"].ToString();
                    dt_Settings.KangFengYaSheJiZhi = dt.Rows[i]["KangFengYaSheJiZhi"].ToString();
                    dt_Settings.DanShanDanSuoDian = dt.Rows[i]["DanShanDanSuoDian"].ToString();
                }

                dt_Info.dt_Code = dt.Rows[i]["dt_Code"].ToString();
                dt_Info.info_Create = "";
                dt_Info.info_DangH = dt.Rows[i]["info_DangH"].ToString();
                dt_InfoList.Add(dt_Info);

                dt_qm_Info.dt_Code = dt.Rows[i]["dt_Code"].ToString();
                dt_qm_Info.info_DangH = dt.Rows[i]["info_DangH"].ToString();
                dt_qm_Info.qm_F_FC = dt.Rows[i]["qm_F_FC"].ToString();
                dt_qm_Info.qm_F_MJ = dt.Rows[i]["qm_F_MJ"].ToString();
                dt_qm_Info.qm_Z_FC = dt.Rows[i]["qm_Z_FC"].ToString();
                dt_qm_Info.qm_Z_MJ = dt.Rows[i]["qm_Z_MJ"].ToString();

                dt_qm_Info.qm_s_z_fj100 = dt.Rows[i]["qm_s_z_fj100"].ToString();
                dt_qm_Info.qm_s_z_fj150 = dt.Rows[i]["qm_s_z_fj150"].ToString();
                dt_qm_Info.qm_j_z_fj100 = dt.Rows[i]["qm_j_z_fj100"].ToString();
                dt_qm_Info.qm_s_z_zd100 = dt.Rows[i]["qm_s_z_zd100"].ToString();
                dt_qm_Info.qm_s_z_zd150 = dt.Rows[i]["qm_s_z_zd150"].ToString();
                dt_qm_Info.qm_j_z_zd100 = dt.Rows[i]["qm_j_z_zd100"].ToString();
                dt_qm_Info.qm_s_f_fj100 = dt.Rows[i]["qm_s_f_fj100"].ToString();
                dt_qm_Info.qm_s_f_fj150 = dt.Rows[i]["qm_s_f_fj150"].ToString();
                dt_qm_Info.qm_j_f_fj100 = dt.Rows[i]["qm_j_f_fj100"].ToString();
                dt_qm_Info.qm_s_f_zd100 = dt.Rows[i]["qm_s_f_zd100"].ToString();
                dt_qm_Info.qm_s_f_zd150 = dt.Rows[i]["qm_s_f_zd150"].ToString();
                dt_qm_Info.qm_j_f_zd100 = dt.Rows[i]["qm_j_f_zd100"].ToString();



                dt_qm_InfoList.Add(dt_qm_Info);

                dt_sm_Info.dt_Code = dt.Rows[i]["dt_Code"].ToString();
                dt_sm_Info.info_DangH = dt.Rows[i]["info_DangH"].ToString();
                dt_sm_Info.sm_Pa = dt.Rows[i]["sm_Pa"].ToString();
                dt_sm_Info.sm_PaDesc = dt.Rows[i]["sm_PaDesc"].ToString();
                dt_sm_Info.sm_Remark = dt.Rows[i]["sm_Remark"].ToString();
                dt_sm_InfoList.Add(dt_sm_Info);
            }
            dt_Settings.dt_sm_Info = dt_sm_InfoList;
            dt_Settings.dt_qm_Info = dt_qm_InfoList;
            dt_Settings.dt_InfoList = dt_InfoList;

            return dt_Settings;
        }


        /// <summary>
        /// 查询编号是否存在
        /// </summary>
        public bool Getdt_SettingsByCodeIsExist(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return false;
            }
            string sql = "select * from dt_Settings where  dt_Code = '" + code + "'";
            DataRow dr = SQLiteHelper.ExecuteDataRow(sql);
            if (dr == null)
                return false;
            return true;
        }

    }
}
