using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysDetection.model
{
    public class Model_dt_Info
    {
        /// <summary>
        /// 主表外键
        /// </summary>
        public string dt_Code { get; set; }
        /// <summary>
        /// 当前樘号
        /// </summary>
        public string info_DangH { get; set; }
        /// <summary>
        /// 是否选中
        /// </summary>
        public int Is_Check { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string info_Create { get; set; }
    }
}
