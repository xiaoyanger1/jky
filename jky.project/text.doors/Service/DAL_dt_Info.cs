using text.doors.Common;
using text.doors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text.doors.Model.DataBase;
using Young.Core.SQLite;
using static text.doors.Default.PublicEnum;

namespace text.doors.dal
{
    public class DAL_dt_Info
    {
        /// <summary>
        /// 更新实验状态
        /// type:0未完成，1完成
        /// </summary>
        /// <returns></returns>
        public bool UpdateTestType(string code, string info_DangH, SystemItem systemItem, int type)
        {
            string sql = "update dt_Info  set";
            if (systemItem == SystemItem.Airtight)
            {
                sql += "Airtight=" + type + "";
            }
            else if (systemItem == SystemItem.Watertight)
            {
                sql += "Watertight=" + type + "";
            }
            else if (systemItem == SystemItem.AirPressure)
            {
                sql += "WindPressure=" + type + "";
            }
            sql += "where info_DangH = '" + info_DangH + "' and dt_Code='" + code + "'";
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
            sb.AppendFormat("delete from dt_kfy_Info where dt_Code ='{0}';", code);
            return SQLiteHelper.ExecuteNonQuery(sb.ToString()) > 0 ? true : false;
        }
    }
}
