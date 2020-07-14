using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SPIC_200.API
{
  public  class SPIC200BAPI
    {
        public struct MeasureConditionData
        {
            public byte spectrumPrecision1;                                            // 第1台光谱仪灵敏度   0x00 --- 表示高； 0x01 --- 表示低
            public byte spectrumPrecision2;                                            // 第2台光谱仪灵敏度   0x00 --- 表示高； 0x01 --- 表示低
            public float spectrumIntegralTime1;                                     // 第1台光谱仪积分时间 (ms)
            public float spectrumIntegralTime2;                                     // 第2台光谱仪积分时间 (ms)
            public float autoIntegralTimeUpLimit1;                                // 第1台光谱仪自动积分时间上限 (ms)
            public float autoIntegralTimeUpLimit2;                                // 第2台光谱仪自动积分时间上限 (ms)
            public byte spectrumModel1;                                                 // 第1台模式    0x00 --- 表示固定积分； 0x01 --- 表示自动积分
            public byte spectrumModel2;                                                 // 第2台模式    0x00 --- 表示固定积分； 0x01 --- 表示自动积分
            public byte averageNum1;                                                     //  第1台平均次数 
            public byte averageNum2;                                                     //  第2台平均次数
        };

        public struct ReadMeasureResultData
        {
            public byte precision1;                                                            // 第1台光谱仪灵敏度 
            public byte precision2;                                                            // 第2台光谱仪灵敏度   
            public float IntegralTime1;                                                     // 第1台光谱仪积分时间 (ms)
            public float IntegralTime2;                                                     // 第2台光谱仪积分时间 (ms)
            public byte averNum1;                                                           //  第1台平均次数 
            public byte averNum2;                                                           //  第2台平均次数
            public float Ip1;                                                                      //  第1台 Ip
            public float Ip2;                                                                      //  第2台 Ip
            public float waveLenghRange1;                                             //  第1台 波长范围 WL
            public float waveLenghRange2;                                             //  第2台 波长范围 WL
            public byte useColorParam;                                                   //  是否颜色参数 0x01 --- 有  0x00 --- 无 
            public float illumination;                                                       //  光照度 E(lx)
            public float radiation;                                                            //  辐射照度 Ee （W/m2)
            public float CIE_x;                                                                  //  CIE  x
            public float CIE_y;                                                                  //  CIE  y
            public float CIE_u;                                                                  //  CIE  u
            public float CIE_v;                                                                  //  CIE  v
            public float CCT;                                                                    //  CCT (k) 相关色温
            public float duv;                                                                    //  色差 ， 统一用duv 既dc
            public float Lp;                                                                      //  峰值波长 nm
            public float HW;                                                                    // 半波长宽  nm
            public float Ld;                                                                      // 主波长长  nm
            public float Pur;                                                                    //  色纯度  %
            public float ratio_R;                                                              //  红色比
            public float ratio_G;                                                              // 绿色比
            public float ratio_B;                                                              // 蓝色比
            public float Ra;                                                                     // Ra
            //float    R[15];                                                                 //  R1 ~ R15
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
            public float[] R;
        };

        // 1. 初始化
        [DllImport("SPIC200BDLL.dll")]
        public static extern int SPIC_Initialization();
        // 2. 设置ip和port
        [DllImport("SPIC200BDLL.dll")]
        public static extern int SPIC_SetServerIPAndPort(int iIP1, int iIP2, int iIP3, int iIP4, int iPort);

        [DllImport("SPIC200BDLL.dll")]
        public static extern int SPIC_SetServerIPAndPort_EX(char[] iIP, int iPort);

        // 3. 设置设备类型
        [DllImport("SPIC200BDLL.dll")]
        public static extern int SPIC_SetCommType(int iType);


        //4. 设置测试条件
        [DllImport("SPIC200BDLL.dll")]
        public static extern int SPIC_SetMeasureCondition(ref MeasureConditionData data);

        //5. 获取测试条件
        [DllImport("SPIC200BDLL.dll")]
        public static extern int SPIC_GetMeasureReslut(ref ReadMeasureResultData data);

        //6. 测试条件
        [DllImport("SPIC200BDLL.dll")]
        public static extern int SPIC_SetTestDlgShow(int bShow); 
    }
}
