﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text.doors.Default
{
    public class PublicEnum
    {
        /// <summary>
        /// 压力级别枚举
        /// </summary>
        public enum Kpa_Level
        {
            liter100,//升100 
            liter150,//升150
            drop100//降100
        }

        /// <summary>
        /// 系统项
        /// </summary>
        public enum SystemItem
        {
            /// <summary>
            /// 水密
            /// </summary>
            Watertight,
            /// <summary>
            /// 气密
            /// </summary>
            Airtight,
            /// <summary>
            /// 风压
            /// </summary>
            AirPressure
        }

        /// <summary>
        /// 气密性能检测
        /// </summary>
        public enum AirtightPropertyTest
        {
            ZReady,//正压预备
            ZStart,//正压开始
            FReady,//负压预备
            FStart,//负压开始
            Stop//停止
        }


        /// <summary>
        /// 水密性能检测
        /// </summary>
        public enum WaterTightPropertyTest
        {
            Ready,//预备
            Start,//开始
            Next,//下一级
            CycleLoading,//依次加压
            Stop //停止
        }


        /// <summary>
        /// 风压性能检测
        /// </summary>
        public enum WindPressureTest
        {
            ZReady,//正压预备
            ZStart,//正压开始
            FReady,//负压预备
            FStart,//负压开始
        }

        /// <summary>
        /// 标定
        /// </summary>
        public enum DemarcateType
        {
            风速传感器,
            差压传感器,
            温度传感器,
            大气压力传感器,
            位移传感器1,
            位移传感器2,
            位移传感器3
        }

        /// <summary>
        /// 检测项
        /// </summary>
        public enum DetectionItem
        {
            //enum_气密性能检测,
            //enum_水密性能检测,
            //enum_气密性能及水密性能检测
            气密水密抗风压性能检测,
            气密性能检测,
            水密性能检测,
            抗风压性能检测,
            气密性能及水密性能检测,
            气密性能及抗风压性能检测,
            水密性能及抗风压性能检测
        }

    }
}