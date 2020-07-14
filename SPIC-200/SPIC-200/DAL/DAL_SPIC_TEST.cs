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
    public class DAL_SPIC_TEST
    {
        /// <summary>
        /// 增加结果
        /// </summary>
        /// <param name="list">数据集</param>
        /// <param name="TEST_TYPE_ENUM"></param>
        /// <param name="Equipment_TYPE_ENUM"></param>
        /// <returns></returns>
        public bool AddLightData(List<LightData> list, string code, TEST_TYPE TEST_TYPE_ENUM, string desc)
        {

            string del_sql = string.Format("delete from spic_test where code='{0}' and test_enum='{1}'", code, TEST_TYPE_ENUM);
            SQLiteHelper.ExecuteNonQuery(del_sql);

            string SB = "";
            if (TEST_TYPE_ENUM == TEST_TYPE.透光投射指数检测_安装 || TEST_TYPE_ENUM == TEST_TYPE.透光投射指数检测_卸载)
                SB = "照度计";
            else if (TEST_TYPE_ENUM == TEST_TYPE.颜色投射指数检测)
                SB = "光谱仪";

            List<string> strList = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Index < 998)
                {
                    var value = list[i].First + "," + list[i].Second + "," + list[i].Third;
                    strList.Add(string.Format("insert into SPIC_TEST (ID,DATA_ENUM,VALUE,Code,TEST_ENUM)values('{0}','{1}','{2}','{3}','{4}')",
                        Guid.NewGuid().ToString(), SB + (i + 1), value, code, TEST_TYPE_ENUM.ToString()));
                }
                else
                {
                    var value = list[i].First + "," + list[i].Second + "," + list[i].Third;
                    strList.Add(string.Format("insert into SPIC_TEST (ID,DATA_ENUM,VALUE,Code,TEST_ENUM)values('{0}','{1}','{2}','{3}','{4}')",
                        Guid.NewGuid().ToString(), DATA_ENUM.平均值, value, code, TEST_TYPE_ENUM.ToString()));
                }
            }
            strList.Add(string.Format("insert into SPIC_TEST (ID,DATA_ENUM,VALUE,Code,TEST_ENUM)values('{0}','{1}','{2}','{3}','{4}')",
            Guid.NewGuid().ToString(), DATA_ENUM.描述, desc, code, TEST_TYPE_ENUM.ToString()));
            try
            {
                foreach (var item in strList)
                {
                    SQLiteHelper.ExecuteNonQuery(item);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<LightData> Selete(TEST_TYPE TEST_TYPE, ref string desc)
        {
            List<LightData> list = null;

            DataRow resRow = SQLiteHelper.ExecuteDataRow("select * from SPIC_TEST where TEST_ENUM='" + TEST_TYPE + "'  and  Code ='" + Program.GetCode() + "'");
            if (resRow != null)
            {
                list = new List<LightData>();
                DataTable dt = resRow.Table;
                foreach (DataRow dr in dt.Rows)
                {
                    LightData lightData = new LightData();
                    var DATA_ENUM = dr["DATA_ENUM"].ToString();
                    var valueStr = dr["VALUE"].ToString();
                    var value = valueStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (DATA_ENUM == "平均值")
                    {
                        lightData.EquipmentName = DATA_ENUM;
                        lightData.Index = 999;
                    }
                    else if (DATA_ENUM == "描述")
                    {
                        desc = value[0].ToString();
                        continue;
                    }
                    else
                    {
                        lightData.EquipmentName = DATA_ENUM;
                        //判断当前设备数
                        var index = int.Parse(DATA_ENUM.Substring(3, 1));

                        if (TEST_TYPE == TEST_TYPE.透光投射指数检测_安装 || TEST_TYPE == TEST_TYPE.透光投射指数检测_卸载)
                        {
                            if (index > Program._TTNum)
                                continue;
                        }
                        else if (TEST_TYPE == TEST_TYPE.颜色投射指数检测)
                        {
                            if (index > Program._SB_Count)
                                continue;
                        }
                        lightData.Index = index;
                    }
                    lightData.First = double.Parse(value[0].ToString());
                    lightData.Second = double.Parse(value[1].ToString());
                    lightData.Third = double.Parse(value[2].ToString());
                    list.Add(lightData);
                }
            }
            return list;
        }
    }
    public enum DATA_ENUM
    {
        第1次采集,
        第2次采集,
        第3次采集,
        第4次采集,
        平均值,
        描述,
    }
}
