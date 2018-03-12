﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text.doors.Service;

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


        #region  IP相关
        /// <summary>
        /// IP端口
        /// </summary>
        public static int TCPPort
        {
            get
            {
                var res = 502;
                try
                {
                    var dt = new DAL_dt_BaseSet().GetSystemBaseSet();
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
        public static string IPAddress
        {
            get
            {
                var res = "192.168.2.5";
                try
                {
                    var dt = new DAL_dt_BaseSet().GetSystemBaseSet();
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
                    var dt = new DAL_dt_BaseSet().GetSystemBaseSet();
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

        #endregion
    }
}