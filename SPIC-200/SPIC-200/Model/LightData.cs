using SPIC_200.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIC_200.Model
{

    /// <summary>
    /// 透光折减系数数据
    /// </summary>
    public class LightData
    {
        /// <summary>
        /// 获取上次数据
        /// </summary>
        /// <param name="TEST_TYPE"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<LightData> GetListData(TEST_TYPE TEST_TYPE, int count, ref string desc)
        {
            List<LightData> LightData = new DAL_SPIC_TEST().Selete(TEST_TYPE, ref desc);

            if (LightData == null)
            {
                LightData = GetInit(TEST_TYPE, count);
            }
            else if (TEST_TYPE == TEST_TYPE.颜色投射指数检测)
            {
                if ((LightData.Count - 1) < count)
                {
                    for (int i = 0; i < count -( LightData.Count - 1); i++)
                    {
                        LightData.Add(new LightData() { EquipmentName = "光谱仪" + LightData.Count, First = 0, Second = 0, Third = 0, Index = LightData.Count });
                    }
                }
            }

            return LightData.OrderBy(t => t.Index).ToList();
        }
        /// <summary>
        /// 获取初始化数据
        /// </summary>
        /// <param name="TEST_TYPE"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<LightData> GetInit(TEST_TYPE TEST_TYPE, int count)
        {
            string SB = "";
            if (TEST_TYPE == TEST_TYPE.透光投射指数检测_安装 || TEST_TYPE == TEST_TYPE.透光投射指数检测_卸载)
            {
                SB = "照度计";
            }
            else if (TEST_TYPE == TEST_TYPE.颜色投射指数检测)
            {
                SB = "光谱仪";
            }

            List<LightData> LightData = new List<LightData>();
            for (int i = 1; i <= count; i++)
            {
                LightData.Add(new LightData() { EquipmentName = SB + i, First = 0, Second = 0, Third = 0, Index = i });
            }

            LightData.Add(new LightData() { EquipmentName = "平均值", First = 0, Second = 0, Third = 0, Index = 999 });
            return LightData;
        }


        public string EquipmentName { get; set; }
        public double? First { get; set; }
        public double? Second { get; set; }
        public double? Third { get; set; }

        public int Index { get; set; }
    }


    public class Dict
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}
