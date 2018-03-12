using text.doors.Common;
using text.doors.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text.doors.dal
{
    public class DAL_dt_Info
    {
        /// <summary>
        /// 添加樘号
        /// </summary>
        /// <returns></returns>
        public bool Adddt_dt_Info(Model_dt_Info model, string code)
        {
            string sql = "";
            sql = @"delete from dt_Info where info_DangH = '" + model.info_DangH + "' and dt_Code='" + code + "'; update dt_Info set Is_Check=0 where dt_Code='" + code + "'";
            SQLiteHelper.ExecuteNonQuery(sql);

            sql = string.Format("insert into dt_Info (info_DangH,Is_Check,info_Create,dt_Code) values('{0}','{1}','{2}','{3}')", model.info_DangH, model.Is_Check, model.info_Create, code);
            return SQLiteHelper.ExecuteNonQuery(sql) > 0 ? true : false;
        }

        /// <summary>
        /// 删除当前编号数据
        /// </summary>
        /// <returns></returns>
        public bool delete_dt_Info(string code)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("delete from dt_Settings where dt_Code ='{0}';", code);
            sb.AppendFormat("delete from dt_Info where dt_Code ='{0}';", code);
            sb.AppendFormat("delete from dt_qm_Info where dt_Code ='{0}';", code);
            sb.AppendFormat("delete from dt_sm_Info where dt_Code ='{0}';", code);
            return SQLiteHelper.ExecuteNonQuery(sb.ToString()) > 0 ? true : false;
        }




    }
}
