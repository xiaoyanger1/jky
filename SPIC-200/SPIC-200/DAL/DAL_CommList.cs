using SPIC200.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIC_200.DAL
{
    public class DAL_CommList
    {

        public List<string> GetIp()
        {
            List<string> list = new List<string>();
            string sql = "select * from COMM_IP";
            DataRow dr = SQLiteHelper.ExecuteDataRow(sql);
            if (dr == null)
                return list;
            foreach (DataRow _dr in dr.Table.Rows)
            {
                list.Add(_dr["IP"].ToString());
            }
            return list;
        }

        public bool Add(string com, string count)
        {
            string del_sql = string.Format("delete from Common");
            SQLiteHelper.ExecuteNonQuery(del_sql);

            del_sql = "insert into Common (com,Equipment_Count) values('" + com + "','" + count + "')";
            return SQLiteHelper.ExecuteNonQuery(del_sql) > 0;
        }

        public bool GetCommon(ref string com, ref string count)
        {
            string del_sql = string.Format("select * from Common");
            DataRow dr = SQLiteHelper.ExecuteDataRow(del_sql);
            if (dr == null)
            {
                return false;
            }
            com = dr.Table.Rows[0]["COM"].ToString();
            count = dr.Table.Rows[0]["Equipment_Count"].ToString();
            return true;
        }


    }
}
