using SysDetection.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysDetection.Detection
{
    public class Conversions
    {
        
        /// <summary>
        /// 计算流量
        /// 公式为 Q = 3.1415*D的平方（配置）/4*v(风速平均值)*3600
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double MathLL(double value)
        {
            if (value == 0)
            {
                return 0;
            }
            double _D = _GetConfig._D;

            return Math.Round(3.1415 * _D * _D / 4 * value * 3600, 2);
        }

    }
}
