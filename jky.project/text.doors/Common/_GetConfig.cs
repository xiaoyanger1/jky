using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text.doors.Common
{
    public static class _GetConfig
    {
        /// <summary>
        /// IP端口
        /// </summary>
        public static int _TCPPort
        {
            get
            {
                var res = 502;
                try
                {
                    var dt = _GetBase();
                    if (dt != null)
                        res = int.Parse(dt.Rows[0]["PROT"].ToString());
                }
                catch (Exception ex)
                {
                    return res;
                }
                return res;
            }
        }
        /// <summary>
        /// IP地址
        /// </summary>
        public static string _IPAddress
        {
            get
            {
                var res = "192.168.2.5";
                try
                {
                    var dt = _GetBase();
                    if (dt != null)
                        res = dt.Rows[0]["IP"].ToString();
                }
                catch (Exception ex)
                {
                    return res;
                }
                return res;
            }
        }

        /// <summary>
        /// IP地址
        /// </summary>
        public static double _D
        {
            get
            {
                var res = 0.08;
                try
                {
                    var dt = _GetBase();
                    if (dt != null)
                        res = Convert.ToDouble(dt.Rows[0]["D"].ToString());
                }
                catch (Exception ex)
                {
                    return res;
                }
                return res;
            }
        }



        public static System.Data.DataTable _GetBase()
        {
            string sql = "select * from  dt_BaseSet";
            DataRow dr = SQLiteHelper.ExecuteDataRow(sql);
            if (dr != null)
            {
                return dr.Table;
            }
            return null;
        }
    }
}
