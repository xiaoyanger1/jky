using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text.doors.Default
{
    /// <summary>
    /// 默认配置
    /// </summary>
    public static class DefaultBase
    {
        #region --系统默认
        /// <summary>
        /// 是否打开审核页面
        /// </summary>
        public static bool IsOpenComplexAssessment { get; set; }

        /// <summary>
        /// 气密、水密等级字典
        /// </summary>
        public static Dictionary<int, int> AirtightLevel = new Dictionary<int, int>()
        {
            {1,0 },{2,100},{3,150},{4,200},{5,250},{6,300},{7,350},{8,400},{9,500},{10,600},{11,700}
        };
        #endregion
    }
}
