using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text.doors.Common
{
    public class _Public_Enum
    {
        public enum ENUM_FS
        {
            YL_S100,
            YL_S150,
            YL_J100
        }

        public enum ENUM_DetectBtn
        {
            em_水密,
            em_气密
        }

        /// <summary>
        /// 气密性能检测
        /// </summary>
        public enum ENUM_QMXNJC_Btn
        {
            /// <summary>
            /// 正压预备
            /// </summary>
            ZYYB,
            /// <summary>
            /// 正压开始
            /// </summary>
            ZYKS,
            /// <summary>
            /// 负压预备
            /// </summary>
            FYYB,
            /// <summary>
            /// 负压开始
            /// </summary>
            FYKS,
            /// <summary>
            /// 停止
            /// </summary>
            TZ
        }


        /// <summary>
        /// 气密性能检测
        /// </summary>
        public enum ENUM_SMXNJC_Btn
        {
            /// <summary>
            /// 预备
            /// </summary>
            YB,
            /// <summary>
            /// 开始
            /// </summary>
            KS,
            /// <summary>
            /// 下一级
            /// </summary>
            XYJ,
            YCJY,
            TZ
        }

        /// <summary>
        /// 标定
        /// </summary>
        public enum ENUM_Demarcate
        {
            enum_风速传感器,
            enum_差压传感器,
            enum_温度传感器,
            enum_大气压力传感器
        }

        /// <summary>
        /// 检测项
        /// </summary>
        public enum ENUM_DetectionItem
        {
            enum_气密性能检测,
            enum_水密性能检测,
            enum_气密性能及水密性能检测
        }

    }
}