
using SPIC_200.Model;
using SPIC200.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIC_200.DAL
{
    public class DAL_SPIC_TEST_SET
    {

        public bool Add(Model_SPIC_TEST_SET model_SPIC_TEST_SET)
        {
            string sql = string.Format(@"
            insert into SPIC_TEST_SET(ID,JCBH,WTDW,JZDW,SCDW,JYDW,JYXM,SJMC,SJLX,CGCLZL,CLHD,KTLX,GYLX,SJRQ,KTYS,CLYS,CLXH,SJCC,SBBH,JYSB,JYLB,CYFS,JZR,WTR,WTBH,MSGZSTJ,CreateTime) 
            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}')",
             Guid.NewGuid().ToString(), model_SPIC_TEST_SET.JCBH,
             model_SPIC_TEST_SET.WTDW,
             model_SPIC_TEST_SET.JZDW, model_SPIC_TEST_SET.SCDW,
             model_SPIC_TEST_SET.JYDW, model_SPIC_TEST_SET.JYXM,
             model_SPIC_TEST_SET.SJMC, model_SPIC_TEST_SET.SJLX,
             model_SPIC_TEST_SET.CGCLZL, model_SPIC_TEST_SET.CLHD,
             model_SPIC_TEST_SET.KTLX, model_SPIC_TEST_SET.GYLX,
             model_SPIC_TEST_SET.SJRQ, model_SPIC_TEST_SET.KTYS,
             model_SPIC_TEST_SET.CLYS, model_SPIC_TEST_SET.CLXH,
             model_SPIC_TEST_SET.SJCC, model_SPIC_TEST_SET.SBBH,
             model_SPIC_TEST_SET.JYSB, model_SPIC_TEST_SET.JYLB,
             model_SPIC_TEST_SET.CYFS, model_SPIC_TEST_SET.JZR,
             model_SPIC_TEST_SET.WTR, model_SPIC_TEST_SET.WTBH,
             model_SPIC_TEST_SET.MSGZSTJ, DateTime.Now.ToString());
            return SQLiteHelper.ExecuteNonQuery(sql) > 0 ? true : false;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool IsExist(string code)
        {
            string sql = "select count() as con from SPIC_TEST_SET where JCBH ='" + code + "'";
            DataRow dr = SQLiteHelper.ExecuteDataRow(sql);
            return int.Parse(dr.Table.Rows[0]["con"].ToString()) > 0 ? true : false;
        }
        public Model_SPIC_TEST_SET SeleteByCode(string code)
        {
            return new Model_SPIC_TEST_SET();
        }
        /// <summary>
        /// 获取最近一条
        /// </summary>
        /// <returns></returns>
        public Model_SPIC_TEST_SET SeleteByTime(string code = null)
        {
            Model_SPIC_TEST_SET model_SPIC_TEST_SET = null;
            string sql = "";
            if (string.IsNullOrWhiteSpace(code))
            {
               sql= "select  * from SPIC_TEST_SET order by createtime desc limit(1)";
            }
            else {
                sql = "select  * from SPIC_TEST_SET where JCBH='" + code + "' limit(1)";
            }
            DataRow dr = SQLiteHelper.ExecuteDataRow(sql);
            if (dr == null)
                return model_SPIC_TEST_SET;
            var dt = dr.Table;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                model_SPIC_TEST_SET = new Model_SPIC_TEST_SET();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["JCBH"].ToString()))
                    model_SPIC_TEST_SET.JCBH = dt.Rows[i]["JCBH"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["WTDW"].ToString()))
                    model_SPIC_TEST_SET.WTDW = dt.Rows[i]["WTDW"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["JZDW"].ToString()))
                    model_SPIC_TEST_SET.JZDW = dt.Rows[i]["JZDW"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["SCDW"].ToString()))
                    model_SPIC_TEST_SET.SCDW = dt.Rows[i]["SCDW"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["JYDW"].ToString()))
                    model_SPIC_TEST_SET.JYDW = dt.Rows[i]["JYDW"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["JYXM"].ToString()))
                    model_SPIC_TEST_SET.JYXM = dt.Rows[i]["JYXM"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["SJMC"].ToString()))
                    model_SPIC_TEST_SET.SJMC = dt.Rows[i]["SJMC"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["SJLX"].ToString()))
                    model_SPIC_TEST_SET.SJLX = dt.Rows[i]["SJLX"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["CGCLZL"].ToString()))
                    model_SPIC_TEST_SET.CGCLZL = dt.Rows[i]["CGCLZL"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["CLHD"].ToString()))
                    model_SPIC_TEST_SET.CLHD = dt.Rows[i]["CLHD"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["KTLX"].ToString()))
                    model_SPIC_TEST_SET.KTLX = dt.Rows[i]["KTLX"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["GYLX"].ToString()))
                    model_SPIC_TEST_SET.GYLX = dt.Rows[i]["GYLX"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["SJRQ"].ToString()))
                    model_SPIC_TEST_SET.SJRQ = dt.Rows[i]["SJRQ"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["KTYS"].ToString()))
                    model_SPIC_TEST_SET.KTYS = dt.Rows[i]["KTYS"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["CLYS"].ToString()))
                    model_SPIC_TEST_SET.CLYS = dt.Rows[i]["CLYS"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["CLXH"].ToString()))
                    model_SPIC_TEST_SET.CLXH = dt.Rows[i]["CLXH"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["SJCC"].ToString()))
                    model_SPIC_TEST_SET.SJCC = dt.Rows[i]["SJCC"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["SBBH"].ToString()))
                    model_SPIC_TEST_SET.SBBH = dt.Rows[i]["SBBH"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["JYSB"].ToString()))
                    model_SPIC_TEST_SET.JYSB = dt.Rows[i]["JYSB"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["JYLB"].ToString()))
                    model_SPIC_TEST_SET.JYLB = dt.Rows[i]["JYLB"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["CYFS"].ToString()))
                    model_SPIC_TEST_SET.CYFS = dt.Rows[i]["CYFS"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["JZR"].ToString()))
                    model_SPIC_TEST_SET.JZR = dt.Rows[i]["JZR"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["WTR"].ToString()))
                    model_SPIC_TEST_SET.WTR = dt.Rows[i]["WTR"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["WTBH"].ToString()))
                    model_SPIC_TEST_SET.WTBH = dt.Rows[i]["WTBH"].ToString();
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["MSGZSTJ"].ToString()))
                    model_SPIC_TEST_SET.MSGZSTJ = dt.Rows[i]["MSGZSTJ"].ToString();
                break;
            }
            return model_SPIC_TEST_SET;
        }


        public bool Delete(string codeID)
        {
            string sql = "delete from spic_test_set  where JCBH = '" + codeID + "'";
            return SQLiteHelper.ExecuteNonQuery(sql) > 0 ? true : false;
        }
        public bool Update(Model_SPIC_TEST_SET SPIC_TEST_SET)
        {
            return true;
        }
    }
}