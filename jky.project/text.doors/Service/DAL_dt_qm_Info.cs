using text.doors.Common;
using text.doors.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text.doors.Default;
using Young.Core.SQLite;
using text.doors.Service;

namespace text.doors.dal
{
    public class DAL_dt_qm_Info
    {
        /// <summary>
        /// 添加气密信息
        /// </summary>
        /// <param name="mode"></param>
        public bool Add(Model_dt_qm_Info model)
        {
            //删除结果
            SQLiteHelper.ExecuteNonQuery("delete from dt_qm_Info where dt_Code='" + model.dt_Code + "' and info_DangH = '" + model.info_DangH + "'");

            var sql = string.Format(@"insert into dt_qm_Info (dt_Code,info_DangH,qm_Z_FC,qm_F_FC,qm_Z_MJ,qm_F_MJ,
                qm_s_z_fj100,qm_s_z_fj150,qm_j_z_fj100,qm_s_z_zd100,qm_s_z_zd150,qm_j_z_zd100,qm_s_f_fj100,qm_s_f_fj150,qm_j_f_fj100,qm_s_f_zd100,qm_s_f_zd150,qm_j_f_zd100	) 
                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')",
                 model.dt_Code, model.info_DangH, model.qm_Z_FC, model.qm_F_FC, model.qm_Z_MJ, model.qm_F_MJ,
                 model.qm_s_z_fj100, model.qm_s_z_fj150, model.qm_j_z_fj100, model.qm_s_z_zd100, model.qm_s_z_zd150, model.qm_j_z_zd100, model.qm_s_f_fj100,
                 model.qm_s_f_fj150, model.qm_j_f_fj100, model.qm_s_f_zd100, model.qm_s_f_zd150, model.qm_j_f_zd100
                 );
            var res = SQLiteHelper.ExecuteNonQuery(sql) > 0 ? true : false;
            if (res)
            {
                new DAL_dt_Info().UpdateTestType(model.dt_Code, model.info_DangH, PublicEnum.SystemItem.Airtight, 1);
            }
            return true;
        }

        /// <summary>
        /// 更新气密信息
        /// </summary>
        /// <param name="mode"></param>
        public bool Update_qm_Info(Model_dt_qm_Info model)
        {
            string sql = string.Format(@"update dt_qm_Info  set 
                qm_Z_FC	='{0}',
                qm_F_FC	='{1}',
                qm_Z_MJ	='{2}',
                qm_F_MJ	='{3}'
 where dt_Code = '{4}' and info_DangH='{5}'
                ", model.qm_Z_FC, model.qm_F_FC, model.qm_Z_MJ, model.qm_F_MJ, model.dt_Code, model.info_DangH);
            return SQLiteHelper.ExecuteNonQuery(sql) > 0 ? true : false;

        }

        /// <summary>
        /// 根据编号获取本次检测信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetInfoByCode(string code, PublicEnum.DetectionItem? enum_DetectionItem)
        {
            string sql = "";
            if (enum_DetectionItem == PublicEnum.DetectionItem.enum_气密性能检测)
            {
                sql = @"select  t1.info_DangH,t1.qm_F_FC,t1.qm_F_MJ,t1.qm_Z_FC,t1.qm_Z_MJ from dt_Info t
                            join dt_qm_Info t1 on t.dt_Code = t1.dt_Code and t.info_DangH = t1.info_DangH
                            where t.dt_Code='" + code + "' order by t.info_DangH";
            }
            else if (enum_DetectionItem == PublicEnum.DetectionItem.enum_水密性能检测)
            {
                sql = @"select t2.* from dt_Info t
                            join dt_sm_Info t2 on t.dt_Code = t2.dt_Code and t.info_DangH = t2.info_DangH
                            where t.dt_Code='" + code + "' order by t.info_DangH";
            }
            else if (enum_DetectionItem == PublicEnum.DetectionItem.enum_气密性能及水密性能检测)
            {
                sql = @"select  t1.qm_F_FC,t1.qm_F_MJ,t1.qm_Z_FC,t1.qm_Z_MJ
                            ,t2.* ,t3.* from dt_Info t
                            join dt_qm_Info t1 on t.dt_Code = t1.dt_Code and t.info_DangH = t1.info_DangH
                            join dt_sm_Info t2 on t.dt_Code = t2.dt_Code and t.info_DangH = t2.info_DangH
                            join dt_kfy_Info t3 on  t.dt_Code = t2.dt_Code and t.info_DangH = t2.info_DangH
                            where t.dt_Code='" + code + "' order by t1.info_DangH";
            }
            DataRow dr = SQLiteHelper.ExecuteDataRow(sql);
            if (dr == null)
                return null;
            return dr.Table;
        }


        /// <summary>
        /// 根据编号获取本次检测信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Model_dt_Settings GetInfoByCode(string code)
        {
            Model_dt_Settings settings = new Model_dt_Settings();

            var dt_Info = SQLiteHelper.ExecuteDataRow("select * from dt_Info where dt_Code='" + code + "'   order by  info_DangH")?.Table;
            if (dt_Info != null)
            {
                List<Model_dt_Info> list = new List<Model_dt_Info>();
                foreach (DataRow item in dt_Info.Rows)
                {
                    #region
                    Model_dt_Info model = new Model_dt_Info();
                    model.dt_Code = item["dt_Code"].ToString();
                    model.info_Create = item["info_Create"].ToString();
                    model.info_DangH = item["info_DangH"].ToString();
                    model.Watertight = Convert.ToInt32(item["Watertight"].ToString());
                    model.WindPressure = Convert.ToInt32(item["WindPressure"].ToString());
                    model.Airtight = Convert.ToInt32(item["Airtight"].ToString());
                    list.Add(model);
                    #endregion
                }

                if (list.Count > 0)
                    settings.dt_InfoList = list;
            }
            var dt_qm_Info = SQLiteHelper.ExecuteDataRow("select * from dt_qm_Info where dt_Code='" + code + "' order by  info_DangH")?.Table;
            if (dt_qm_Info != null)
            {
                List<Model_dt_qm_Info> list = new List<Model_dt_qm_Info>();
                foreach (DataRow item in dt_qm_Info.Rows)
                {
                    #region
                    Model_dt_qm_Info model = new Model_dt_qm_Info();
                    model.dt_Code = item["dt_Code"].ToString();
                    model.info_DangH = item["info_DangH"].ToString();
                    model.qm_Z_FC = item["qm_Z_FC"].ToString();
                    model.qm_F_FC = item["qm_F_FC"].ToString();
                    model.qm_Z_MJ = item["qm_Z_MJ"].ToString();
                    model.qm_F_MJ = item["qm_F_MJ"].ToString();
                    model.qm_s_z_fj100 = item["qm_s_z_fj100"].ToString();
                    model.qm_s_z_fj150 = item["qm_s_z_fj150"].ToString();
                    model.qm_j_z_fj100 = item["qm_j_z_fj100"].ToString();
                    model.qm_s_z_zd100 = item["qm_s_z_zd100"].ToString();
                    model.qm_s_z_zd150 = item["qm_s_z_zd150"].ToString();
                    model.qm_j_z_zd100 = item["qm_j_z_zd100"].ToString();
                    model.qm_s_f_fj100 = item["qm_s_f_fj100"].ToString();
                    model.qm_s_f_fj150 = item["qm_s_f_fj150"].ToString();
                    model.qm_j_f_fj100 = item["qm_j_f_fj100"].ToString();
                    model.qm_s_f_zd100 = item["qm_s_f_zd100"].ToString();
                    model.qm_s_f_zd150 = item["qm_s_f_zd150"].ToString();
                    model.qm_j_f_zd100 = item["qm_j_f_zd100"].ToString();
                    list.Add(model);
                    #endregion
                }

                if (list.Count > 0)
                    settings.dt_qm_Info = list;
            }
            var dt_sm_Info = SQLiteHelper.ExecuteDataRow("select * from dt_sm_Info where dt_Code='" + code + "' order by  info_DangH")?.Table;
            if (dt_sm_Info != null)
            {
                List<Model_dt_sm_Info> list = new List<Model_dt_sm_Info>();
                foreach (DataRow item in dt_sm_Info.Rows)
                {
                    #region
                    Model_dt_sm_Info model = new Model_dt_sm_Info();
                    model.dt_Code = item["dt_Code"].ToString();
                    model.info_DangH = item["info_DangH"].ToString();
                    model.sm_PaDesc = item["sm_PaDesc"].ToString();
                    model.sm_Pa = item["sm_Pa"].ToString();
                    model.sm_Remark = item["sm_Remark"].ToString();
                    list.Add(model);
                    #endregion
                }
                if (list.Count > 0)
                    settings.dt_sm_Info = list;

            }
            var dt_kfy_Info = SQLiteHelper.ExecuteDataRow("select * from dt_kfy_Info where dt_Code='" + code + "' order by  info_DangH")?.Table;
            if (dt_kfy_Info != null)
            {
                List<Model_dt_kfy_Info> list = new List<Model_dt_kfy_Info>();
                foreach (DataRow item in dt_kfy_Info.Rows)
                {
                    #region
                    Model_dt_kfy_Info model = new Model.DataBase.Model_dt_kfy_Info();
                    model.z_one_250 = item["z_one_250"].ToString();
                    model.z_two_250 = item["z_two_250"].ToString();
                    model.z_three_250 = item["z_three_250"].ToString();
                    model.z_nd_250 = item["z_nd_250"].ToString();
                    model.z_ix_250 = item["z_ix_250"].ToString();
                    model.f_one_250 = item["f_one_250"].ToString();
                    model.f_two_250 = item["f_two_250"].ToString();
                    model.f_three_250 = item["f_three_250"].ToString();
                    model.f_nd_250 = item["f_nd_250"].ToString();
                    model.f_ix_250 = item["f_ix_250"].ToString();
                    model.z_one_500 = item["z_one_500"].ToString();
                    model.z_two_500 = item["z_two_500"].ToString();
                    model.z_three_500 = item["z_three_500"].ToString();
                    model.z_nd_500 = item["z_nd_500"].ToString();
                    model.z_ix_500 = item["z_ix_500"].ToString();
                    model.f_one_500 = item["f_one_500"].ToString();
                    model.f_two_500 = item["f_two_500"].ToString();
                    model.f_three_500 = item["f_three_500"].ToString();
                    model.f_nd_500 = item["f_nd_500"].ToString();
                    model.f_ix_500 = item["f_ix_500"].ToString();
                    model.z_one_750 = item["z_one_750"].ToString();
                    model.z_two_750 = item["z_two_750"].ToString();
                    model.z_three_750 = item["z_three_750"].ToString();
                    model.z_nd_750 = item["z_nd_750"].ToString();
                    model.z_ix_750 = item["z_ix_750"].ToString();
                    model.f_one_750 = item["f_one_750"].ToString();
                    model.f_two_750 = item["f_two_750"].ToString();
                    model.f_three_750 = item["f_three_750"].ToString();
                    model.f_nd_750 = item["f_nd_750"].ToString();
                    model.f_ix_750 = item["f_ix_750"].ToString();
                    model.z_one_1000 = item["z_one_1000"].ToString();
                    model.z_two_1000 = item["z_two_1000"].ToString();
                    model.z_three_1000 = item["z_three_1000"].ToString();
                    model.z_nd_1000 = item["z_nd_1000"].ToString();
                    model.z_ix_1000 = item["z_ix_1000"].ToString();
                    model.f_one_1000 = item["f_one_1000"].ToString();
                    model.f_two_1000 = item["f_two_1000"].ToString();
                    model.f_three_1000 = item["f_three_1000"].ToString();
                    model.f_nd_1000 = item["f_nd_1000"].ToString();
                    model.f_ix_1000 = item["f_ix_1000"].ToString();
                    model.z_one_1250 = item["z_one_1250"].ToString();
                    model.z_two_1250 = item["z_two_1250"].ToString();
                    model.z_three_1250 = item["z_three_1250"].ToString();
                    model.z_nd_1250 = item["z_nd_1250"].ToString();
                    model.z_ix_1250 = item["z_ix_1250"].ToString();
                    model.f_one_1250 = item["f_one_1250"].ToString();
                    model.f_two_1250 = item["f_two_1250"].ToString();
                    model.f_three_1250 = item["f_three_1250"].ToString();
                    model.f_nd_1250 = item["f_nd_1250"].ToString();
                    model.f_ix_1250 = item["f_ix_1250"].ToString();
                    model.z_one_1500 = item["z_one_1500"].ToString();
                    model.z_two_1500 = item["z_two_1500"].ToString();
                    model.z_three_1500 = item["z_three_1500"].ToString();
                    model.z_nd_1500 = item["z_nd_1500"].ToString();
                    model.z_ix_1500 = item["z_ix_1500"].ToString();
                    model.f_one_1500 = item["f_one_1500"].ToString();
                    model.f_two_1500 = item["f_two_1500"].ToString();
                    model.f_three_1500 = item["f_three_1500"].ToString();
                    model.f_nd_1500 = item["f_nd_1500"].ToString();
                    model.f_ix_1500 = item["f_ix_1500"].ToString();
                    model.z_one_1750 = item["z_one_1750"].ToString();
                    model.z_two_1750 = item["z_two_1750"].ToString();
                    model.z_three_1750 = item["z_three_1750"].ToString();
                    model.z_nd_1750 = item["z_nd_1750"].ToString();
                    model.z_ix_1750 = item["z_ix_1750"].ToString();
                    model.f_one_1750 = item["f_one_1750"].ToString();
                    model.f_two_1750 = item["f_two_1750"].ToString();
                    model.f_three_1750 = item["f_three_1750"].ToString();
                    model.f_nd_1750 = item["f_nd_1750"].ToString();
                    model.f_ix_1750 = item["f_ix_1750"].ToString();
                    model.z_one_2000 = item["z_one_2000"].ToString();
                    model.z_two_2000 = item["z_two_2000"].ToString();
                    model.z_three_2000 = item["z_three_2000"].ToString();
                    model.z_nd_2000 = item["z_nd_2000"].ToString();
                    model.z_ix_2000 = item["z_ix_2000"].ToString();
                    model.f_one_2000 = item["f_one_2000"].ToString();
                    model.f_two_2000 = item["f_two_2000"].ToString();
                    model.f_three_2000 = item["f_three_2000"].ToString();
                    model.f_nd_2000 = item["f_nd_2000"].ToString();
                    model.f_ix_2000 = item["f_ix_2000"].ToString();
                    list.Add(model);
                    #endregion
                }
                if (list.Count > 0)
                    settings.dt_kfy_Info = list;
            }
            return settings;
        }


        public void AddSM_QM(List<Model_dt_qm_Info> qm, List<Model_dt_sm_Info> sm, PublicEnum.DetectionItem? enum_DetectionItem)
        {
            if (enum_DetectionItem == PublicEnum.DetectionItem.enum_气密性能检测 || enum_DetectionItem == PublicEnum.DetectionItem.enum_气密性能及水密性能检测)
            {
                for (int i = 0; i < qm.Count; i++)
                {
                    Update_qm_Info(qm[i]);
                }
            }
            if (enum_DetectionItem == PublicEnum.DetectionItem.enum_水密性能检测 || enum_DetectionItem == PublicEnum.DetectionItem.enum_气密性能及水密性能检测)
            {
                DAL_dt_sm_Info dal = new DAL_dt_sm_Info();
                for (int i = 0; i < sm.Count; i++)
                {
                    dal.Add(sm[i]);
                }
            }
        }


    }
}
