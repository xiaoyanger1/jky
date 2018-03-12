using text.doors.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jky.Public.Common
{
    public class _SlopeCompute
    {

        private static List<Dict> DemarcateList = GetData();
        //<summary>
        //温度传感器
        //</summary>
        static List<Dict> _温度传感器Dict = null;
        private static List<Dict> 温度传感器Dict
        {
            get
            {
                if (_温度传感器Dict == null)
                    温度传感器Dict = DemarcateList.FindAll(t => t.Enum == text.doors.Common._Public_Enum.ENUM_Demarcate.enum_温度传感器.ToString()).OrderBy(t => t.x).ToList();
                return _温度传感器Dict;
            }
            set
            {
                _温度传感器Dict = value;
            }
        }

        //<summary>
        //差压传感器
        //</summary>
        static List<Dict> _差压传感器Dict = null;
        private static List<Dict> 差压传感器Dict
        {
            get
            {
                if (_差压传感器Dict == null)
                    差压传感器Dict = DemarcateList.FindAll(t => t.Enum == text.doors.Common._Public_Enum.ENUM_Demarcate.enum_差压传感器.ToString()).OrderBy(t => t.x).ToList();
                return _差压传感器Dict;
            }
            set
            {
                _差压传感器Dict = value;
            }
        }

        //<summary>
        //风速传感器
        //</summary>
        static List<Dict> _风速传感器Dict = null;
        private static List<Dict> 风速传感器Dict
        {
            get
            {
                if (_风速传感器Dict == null)
                    风速传感器Dict = DemarcateList.FindAll(t => t.Enum == text.doors.Common._Public_Enum.ENUM_Demarcate.enum_风速传感器.ToString()).OrderBy(t => t.x).ToList();
                return _风速传感器Dict;
            }
            set
            {
                _风速传感器Dict = value;
            }
        }

        //<summary>
        //大气压力传感器
        //</summary>
        static List<Dict> _大气压力传感器Dict = null;
        private static List<Dict> 大气压力传感器Dict
        {
            get
            {
                if (_大气压力传感器Dict == null)
                    大气压力传感器Dict = DemarcateList.FindAll(t => t.Enum == text.doors.Common._Public_Enum.ENUM_Demarcate.enum_大气压力传感器.ToString()).OrderBy(t => t.x).ToList();
                return _大气压力传感器Dict;
            }
            set
            {
                _温度传感器Dict = value;
            }
        }

        /// <summary>
        /// 计算斜率k及纵截距b值
        /// </summary>
        /// <param name="x1">坐标点x1</param>
        /// <param name="x2">坐标点x2</param>
        /// <param name="y1">坐标点y1</param>
        /// <param name="y2">坐标点y2</param>
        /// <param name="kvalue">斜率k值</param>
        /// <param name="bvalue">纵截距b值</param>
        private static void Calculate(float x1, float x2, float y1, float y2, ref float kvalue, ref float bvalue)//求方程y=kx+b 系数 k ,b
        {
            float coefficient = 1;//系数值
            try
            {
                if ((x1 == 0) || (x2 == 0) || (x1 == x2)) return; //排除为零的情况以及x1，x2相等时无法运算的情况
                //if (y1 == y2) return; //根据具体情况而定，如何这两个值相等，得到的就是一条直线
                float temp = 0;
                if (x1 >= x2)
                {
                    coefficient = (x1 / x2);
                    temp = y2 * coefficient; //将对应的函数乘以系数
                    bvalue = (temp - y1) / (coefficient - 1);
                    kvalue = (y1 - bvalue) / x1; //求出k值
                }
                else
                {
                    coefficient = x2 / x1;
                    temp = y1 * coefficient;
                    bvalue = (temp - y2) / (coefficient - 1); //求出b值
                    kvalue = (y2 - bvalue) / x2; //求出k值
                }
            }
            catch
            {
                bvalue = 0;
                kvalue = 0;
            }
        }

        /// <summary>
        /// 获取标定后值
        /// </summary>
        /// <returns></returns>
        public static double GetValues(text.doors.Common._Public_Enum.ENUM_Demarcate enum_Demarcate, float x)
        {
            //if (x < 0)
            //{
            //    x = 0;
            //}
            List<Dict> dict = GetListByEnum(enum_Demarcate);

            if (dict == null || dict.Count == 0)
            {
                return Math.Round(x,2);
            }

            if (dict.Find(t => t.y == x) != null)
            {
                return dict.Find(t => t.y == x).x;
            }

            float k = 0, b = 0;

            Compute_KB(dict, x, ref k, ref b);

            if (k == 0 && b == 0)
                return Math.Round(x,2);
            return Math.Round(k * x + b, 2);
        }

        /// <summary>
        /// 根据枚举获取字典数据
        /// </summary>
        /// <param name="enum_Demarcate"></param>
        /// <returns></returns>
        private static List<Dict> GetListByEnum(text.doors.Common._Public_Enum.ENUM_Demarcate enum_Demarcate)
        {
            if (enum_Demarcate == text.doors.Common._Public_Enum.ENUM_Demarcate.enum_差压传感器)
            {
                return 差压传感器Dict;
            }
            if (enum_Demarcate == text.doors.Common._Public_Enum.ENUM_Demarcate.enum_大气压力传感器)
            {
                return 大气压力传感器Dict;
            }
            if (enum_Demarcate == text.doors.Common._Public_Enum.ENUM_Demarcate.enum_风速传感器)
            {
                return 风速传感器Dict;
            }
            if (enum_Demarcate == text.doors.Common._Public_Enum.ENUM_Demarcate.enum_温度传感器)
            {
                return 温度传感器Dict;
            }
            return new List<Dict>();
        }



        // private Queue<Dict> queue = new Queue<Dict>();

        /// <summary>
        /// 获取KB
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="x"></param>
        /// <param name="k"></param>
        /// <param name="b"></param>
        private static void Compute_KB(List<Dict> dictList, float x, ref  float k, ref float b)
        {
            // 对数据合计
            for (int i = 0; i < dictList.Count; i++)
            {
                if (dictList.Count < i + 1)
                {
                    break;
                }

                if (dictList[i].x > x && i == 0)
                {
                    break;
                }

                if (dictList[i].y > x && dictList[i - 1].y < x)
                {
                    Calculate(dictList[i - 1].y, dictList[i].y, dictList[i - 1].x, dictList[i].x, ref k, ref b);

                    // queue.Enqueue(new Dict() { Enum = dictList[i - 1].Enum, x = dictList[i - 1].x, y = dictList[i - 1].y, b = b, k = k, });
                }
            }
        }

        private static List<Dict> GetData()
        {
            List<Dict> list = new List<Dict>();
            string sql = string.Format("select * from Demarcate_Dict");

            DataTable dt = SQLiteHelper.ExecuteDataset(sql).Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                Dict model = new Dict();
                if (!string.IsNullOrWhiteSpace(dr["Enum"].ToString()))
                {
                    model.Enum = dr["Enum"].ToString();
                } if (!string.IsNullOrWhiteSpace(dr["D_Key"].ToString()))
                {
                    model.x = float.Parse(dr["D_Key"].ToString());
                }
                if (!string.IsNullOrWhiteSpace(dr["D_Value"].ToString()))
                {
                    model.y = float.Parse(dr["D_Value"].ToString());
                }

                //if (!string.IsNullOrWhiteSpace(dr["D_K"].ToString()))
                //{
                //    model.y = float.Parse(dr["D_K"].ToString());
                //}

                //if (!string.IsNullOrWhiteSpace(dr["D_B"].ToString()))
                //{
                //    model.y = float.Parse(dr["D_B"].ToString());
                //}

                list.Add(model);
            }
            return list;
        }
    }

    //}
    /// <summary>
    /// 获取标定范围字典
    /// </summary>
    public class Dict
    {
        public float x { get; set; }
        public float y { get; set; }
        public string Enum { get; set; }
        public float k { get; set; }
        public float b { get; set; }
    }
}
