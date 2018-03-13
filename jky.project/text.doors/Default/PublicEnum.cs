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
            Watertight,//水密
            Airtight,//气密
            AirPressure //风压
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
        /// 标定
        /// </summary>
        public enum DemarcateType
        {
            enum_风速传感器,
            enum_差压传感器,
            enum_温度传感器,
            enum_大气压力传感器
        }

        /// <summary>
        /// 检测项
        /// </summary>
        public enum DetectionItem
        {
            enum_气密性能检测,
            enum_水密性能检测,
            enum_气密性能及水密性能检测
        }

    }
}