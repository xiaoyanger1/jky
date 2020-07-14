#ifndef _SPIC200B_EX_DLL_H_
#define _SPIC200B_EX_DLL_H_


#define  WRITE_SCUEESS   0x55
#define  WRITE_FAILE     0xAA

#define  ERROR_MEASURE_CODE  0xFF
#define  DATA_SIZE                     1024*512 
#define  DATA_FRAME_FIXE_VALVE           10

#define  DLLExport _stdcall

typedef unsigned char      BYTE;
// 基本信息结构体

// 测量条件结构体
struct MeasureConditionData
{
	BYTE   spectrumPrecision1;                                            // 第1台光谱仪灵敏度   0x00 --- 表示高； 0x01 --- 表示低
	BYTE   spectrumPrecision2;                                            // 第2台光谱仪灵敏度   0x00 --- 表示高； 0x01 --- 表示低
	float    spectrumIntegralTime1 ;                                     // 第1台光谱仪积分时间 (ms)
	float    spectrumIntegralTime2 ;                                     // 第2台光谱仪积分时间 (ms)
	float    autoIntegralTimeUpLimit1 ;                                // 第1台光谱仪自动积分时间上限 (ms)
	float    autoIntegralTimeUpLimit2 ;                                // 第2台光谱仪自动积分时间上限 (ms)
	BYTE   spectrumModel1;                                                 // 第1台模式    0x00 --- 表示固定积分； 0x01 --- 表示自动积分
	BYTE   spectrumModel2;                                                 // 第2台模式    0x00 --- 表示固定积分； 0x01 --- 表示自动积分
	BYTE   averageNum1;                                                     //  第1台平均次数 
    BYTE   averageNum2;                                                     //  第2台平均次数
};

struct ReadMeasureResultData
{ 
	BYTE   precision1;                                                            // 第1台光谱仪灵敏度 
	BYTE   precision2;                                                            // 第2台光谱仪灵敏度   
	float    IntegralTime1 ;                                                     // 第1台光谱仪积分时间 (ms)
	float    IntegralTime2 ;                                                     // 第2台光谱仪积分时间 (ms)
	BYTE   averNum1;                                                           //  第1台平均次数 
	BYTE   averNum2;                                                           //  第2台平均次数
	float    Ip1;                                                                      //  第1台 Ip
	float    Ip2;                                                                      //  第2台 Ip
	float    waveLenghRange1;                                             //  第1台 波长范围 WL
	float    waveLenghRange2;                                             //  第2台 波长范围 WL
	BYTE   useColorParam;                                                   //  是否颜色参数 0x01 --- 有  0x00 --- 无 
	float    illumination;                                                       //  光照度 E(lx)
	float    radiation;                                                            //  辐射照度 Ee （W/m2)
	float    CIE_x;                                                                  //  CIE  x
	float    CIE_y;                                                                  //  CIE  y
	float    CIE_u;                                                                  //  CIE  u
	float    CIE_v;                                                                  //  CIE  v
	float    CCT;                                                                    //  CCT (k) 相关色温
	float    duv;                                                                    //  色差 ， 统一用duv 既dc
	float    Lp;                                                                      //  峰值波长 nm
	float    HW;                                                                    // 半波长宽  nm
	float    Ld;                                                                      // 主波长长  nm
	float    Pur;                                                                    //  色纯度  %
	float    ratio_R;                                                              //  红色比
	float    ratio_G;                                                              // 绿色比
	float    ratio_B;                                                              // 蓝色比
	float    Ra;                                                                     // Ra
    float    R[15];                                                                 //  R1 ~ R15
};


typedef union
{
	UINT8 ui8[4];
	float f32i4;
} Data32_4;


enum Language
{
	Language_Chinese,
	Language_English
};


// 帧格式结构体

// 1. 初始化
extern BOOL DLLExport SPIC_Initialization();
// 2. 设置ip和port
extern BOOL DLLExport SPIC_SetServerIPAndPort(int iIP1, int iIP2, int iIP3, int iIP4, int iPort);

extern BOOL DLLExport SPIC_SetServerIPAndPort_EX(char *szIP, int iPort);

// 3. 设置设备类型
extern BOOL DLLExport SPIC_SetCommType(int iType);


//4. 设置测试条件
extern BOOL DLLExport SPIC_SetMeasureCondition(MeasureConditionData &data);

//5. 获取测试条件
extern int DLLExport SPIC_GetMeasureReslut(ReadMeasureResultData &data); 



//6. 读取测量绝对光谱
extern BOOL DLLExport SPIC_GetMeasureAbsoluteSpectrum(float InttervaWL, float *data ,int & iN);

extern BOOL DLLExport SPIC_OnlyTestE(BYTE & level, float & E, float & AD);

extern BOOL DLLExport SPIC_SetParamAndTestLabView(
	                      BYTE  spectrumPrecision1,              // 光谱仪灵敏度   0x00 --- 表示高； 0x01 --- 表示低                                        
                          float    spectrumIntegralTime1,        // 光谱仪积分时间 (ms)
                          float    autoIntegralTimeUpLimit1,     // 光谱仪自动积分时间上限 (ms)
                          BYTE   spectrumModel1,                 //  模式    0x00 --- 表示固定积分； 0x01 --- 表示自动积分
                          BYTE   averageNum1);                   //  平均次数 

//5. 获取测试结果
extern void DLLExport SPIC_GetBasicLabView(BYTE & precision1,float& IntegralTime1,BYTE & averNum1,
	float &Ip1,float &waveLenghRange1,BYTE & useColorParam,float& illumination,float &radiation);

extern void DLLExport SPIC_GetCIELabView(float &CIE_x,float &CIE_y,float& CIE_u,float &CIE_v);

extern void DLLExport SPIC_GetBasic2LabView(float& CCT,float &duv,float& Lp, float &HW,float& Ld,float &Pur);

extern void DLLExport SPIC_GetRGBLabView(float &ratioR,float& ratioG,float &ratioB,float &Ra);

extern void DLLExport SPIC_GetRLabView(float* R,int & iNums);
// 7 设置 语言
extern BOOL DLLExport SPIC_SetLanguage(Language language);

extern BOOL DLLExport SPIC_SetTestDlgShow(BOOL bShow);

#endif
