using text.doors.Common;
using text.doors.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text.doors.dal
{
    public class DAL_dt_qm_Info
    {
        /// <summary>
        /// 添加气密信息
        /// </summary>
        /// <param name="mode"></param>
        public bool Add_qm_Info(Model_dt_qm_Info model)
        {
            string sql = "";
            sql = "delete from dt_qm_Info where dt_Code='" + model.dt_Code + "' and info_DangH = '" + model.info_DangH + "'";
            SQLiteHelper.ExecuteNonQuery(sql);

            sql = string.Format(@"insert into dt_qm_Info (dt_Code,info_DangH,qm_Z_FC,qm_F_FC,qm_Z_MJ,qm_F_MJ,
                qm_s_z_fj100,qm_s_z_fj150,qm_j_z_fj100,qm_s_z_zd100,qm_s_z_zd150,qm_j_z_zd100,qm_s_f_fj100,qm_s_f_fj150,qm_j_f_fj100,qm_s_f_zd100,qm_s_f_zd150,qm_j_f_zd100	) 
                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')",
                model.dt_Code, model.info_DangH, model.qm_Z_FC, model.qm_F_FC, model.qm_Z_MJ, model.qm_F_MJ,
                model.qm_s_z_fj100, model.qm_s_z_fj150, model.qm_j_z_fj100, model.qm_s_z_zd100, model.qm_s_z_zd150, model.qm_j_z_zd100, model.qm_s_f_fj100,
                model.qm_s_f_fj150, model.qm_j_f_fj100, model.qm_s_f_zd100, model.qm_s_f_zd150, model.qm_j_f_zd100
                );
            return SQLiteHelper.ExecuteNonQuery(sql) > 0 ? true : false;

        }

        /// <summary>
        /// 添加气密信息
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
        /// 添加水密信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Adddt_sm_Info(Model_dt_sm_Info model)
        {
            string sql = "";
            sql = "delete from dt_sm_Info where dt_Code='" + model.dt_Code + "' and info_DangH = '" + model.info_DangH + "'";
            SQLiteHelper.ExecuteNonQuery(sql);

            sql = string.Format("insert into dt_sm_Info (dt_Code,info_DangH,sm_PaDesc,sm_Pa,sm_Remark) values('{0}','{1}','{2}','{3}','{4}')", model.dt_Code, model.info_DangH, model.sm_PaDesc, model.sm_Pa, model.sm_Remark);
            return SQLiteHelper.ExecuteNonQuery(sql) > 0 ? true : false;
        }


        /// <summary>
        /// 根据编号获取本次检测信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetInfoByCode(string code, text.doors.Common._Public_Enum.ENUM_DetectionItem? enum_DetectionItem)
        {
            string sql = "";
            if (enum_DetectionItem == text.doors.Common._Public_Enum.ENUM_DetectionItem.enum_气密性能检测)
            {
                sql = @"select  t1.info_DangH,t1.qm_F_FC,t1.qm_F_MJ,t1.qm_Z_FC,t1.qm_Z_MJ from dt_Info t
                            join dt_qm_Info t1 on t.dt_Code = t1.dt_Code and t.info_DangH = t1.info_DangH
                            where t.dt_Code='" + code + "' order by t.info_DangH";
            }
            else if (enum_DetectionItem == text.doors.Common._Public_Enum.ENUM_DetectionItem.enum_水密性能检测)
            {
                sql = @"select t2.* from dt_Info t
                            join dt_sm_Info t2 on t.dt_Code = t2.dt_Code and t.info_DangH = t2.info_DangH
                            where t.dt_Code='" + code + "' order by t.info_DangH";
            }
            else if (enum_DetectionItem == text.doors.Common._Public_Enum.ENUM_DetectionItem.enum_气密性能及水密性能检测)
            {
                sql = @"select  t1.qm_F_FC,t1.qm_F_MJ,t1.qm_Z_FC,t1.qm_Z_MJ
                            ,t2.* from dt_Info t
                            join dt_qm_Info t1 on t.dt_Code = t1.dt_Code and t.info_DangH = t1.info_DangH
                            join dt_sm_Info t2 on t.dt_Code = t2.dt_Code and t.info_DangH = t2.info_DangH
                            where t.dt_Code='" + code + "' order by t1.info_DangH";
            }

            DataRow dr = SQLiteHelper.ExecuteDataRow(sql);
            if (dr == null)
                return null;
            return dr.Table;
        }

        public void AddSM_QM(List<Model_dt_qm_Info> qmModel, List<Model_dt_sm_Info> smModel, text.doors.Common._Public_Enum.ENUM_DetectionItem? enum_DetectionItem)
        {
            if (enum_DetectionItem == text.doors.Common._Public_Enum.ENUM_DetectionItem.enum_气密性能检测 || enum_DetectionItem == text.doors.Common._Public_Enum.ENUM_DetectionItem.enum_气密性能及水密性能检测)
            {
                for (int i = 0; i < qmModel.Count; i++)
                {
                    Update_qm_Info(qmModel[i]);
                }
            }
            if (enum_DetectionItem == text.doors.Common._Public_Enum.ENUM_DetectionItem.enum_水密性能检测 || enum_DetectionItem == text.doors.Common._Public_Enum.ENUM_DetectionItem.enum_气密性能及水密性能检测)
            {
                for (int i = 0; i < qmModel.Count; i++)
                {
                    Adddt_sm_Info(smModel[i]);
                }
            }
        }


    }
}
