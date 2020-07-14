#ifndef _SPIC200B_EX_DLL_H_
#define _SPIC200B_EX_DLL_H_


#define  WRITE_SCUEESS   0x55
#define  WRITE_FAILE     0xAA

#define  ERROR_MEASURE_CODE  0xFF
#define  DATA_SIZE                     1024*512 
#define  DATA_FRAME_FIXE_VALVE           10

#define  DLLExport _stdcall

typedef unsigned char      BYTE;
// ������Ϣ�ṹ��

// ���������ṹ��
struct MeasureConditionData
{
	BYTE   spectrumPrecision1;                                            // ��1̨������������   0x00 --- ��ʾ�ߣ� 0x01 --- ��ʾ��
	BYTE   spectrumPrecision2;                                            // ��2̨������������   0x00 --- ��ʾ�ߣ� 0x01 --- ��ʾ��
	float    spectrumIntegralTime1 ;                                     // ��1̨�����ǻ���ʱ�� (ms)
	float    spectrumIntegralTime2 ;                                     // ��2̨�����ǻ���ʱ�� (ms)
	float    autoIntegralTimeUpLimit1 ;                                // ��1̨�������Զ�����ʱ������ (ms)
	float    autoIntegralTimeUpLimit2 ;                                // ��2̨�������Զ�����ʱ������ (ms)
	BYTE   spectrumModel1;                                                 // ��1̨ģʽ    0x00 --- ��ʾ�̶����֣� 0x01 --- ��ʾ�Զ�����
	BYTE   spectrumModel2;                                                 // ��2̨ģʽ    0x00 --- ��ʾ�̶����֣� 0x01 --- ��ʾ�Զ�����
	BYTE   averageNum1;                                                     //  ��1̨ƽ������ 
    BYTE   averageNum2;                                                     //  ��2̨ƽ������
};

struct ReadMeasureResultData
{ 
	BYTE   precision1;                                                            // ��1̨������������ 
	BYTE   precision2;                                                            // ��2̨������������   
	float    IntegralTime1 ;                                                     // ��1̨�����ǻ���ʱ�� (ms)
	float    IntegralTime2 ;                                                     // ��2̨�����ǻ���ʱ�� (ms)
	BYTE   averNum1;                                                           //  ��1̨ƽ������ 
	BYTE   averNum2;                                                           //  ��2̨ƽ������
	float    Ip1;                                                                      //  ��1̨ Ip
	float    Ip2;                                                                      //  ��2̨ Ip
	float    waveLenghRange1;                                             //  ��1̨ ������Χ WL
	float    waveLenghRange2;                                             //  ��2̨ ������Χ WL
	BYTE   useColorParam;                                                   //  �Ƿ���ɫ���� 0x01 --- ��  0x00 --- �� 
	float    illumination;                                                       //  ���ն� E(lx)
	float    radiation;                                                            //  �����ն� Ee ��W/m2)
	float    CIE_x;                                                                  //  CIE  x
	float    CIE_y;                                                                  //  CIE  y
	float    CIE_u;                                                                  //  CIE  u
	float    CIE_v;                                                                  //  CIE  v
	float    CCT;                                                                    //  CCT (k) ���ɫ��
	float    duv;                                                                    //  ɫ�� �� ͳһ��duv ��dc
	float    Lp;                                                                      //  ��ֵ���� nm
	float    HW;                                                                    // �벨����  nm
	float    Ld;                                                                      // ��������  nm
	float    Pur;                                                                    //  ɫ����  %
	float    ratio_R;                                                              //  ��ɫ��
	float    ratio_G;                                                              // ��ɫ��
	float    ratio_B;                                                              // ��ɫ��
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


// ֡��ʽ�ṹ��

// 1. ��ʼ��
extern BOOL DLLExport SPIC_Initialization();
// 2. ����ip��port
extern BOOL DLLExport SPIC_SetServerIPAndPort(int iIP1, int iIP2, int iIP3, int iIP4, int iPort);

extern BOOL DLLExport SPIC_SetServerIPAndPort_EX(char *szIP, int iPort);

// 3. �����豸����
extern BOOL DLLExport SPIC_SetCommType(int iType);


//4. ���ò�������
extern BOOL DLLExport SPIC_SetMeasureCondition(MeasureConditionData &data);

//5. ��ȡ��������
extern int DLLExport SPIC_GetMeasureReslut(ReadMeasureResultData &data); 



//6. ��ȡ�������Թ���
extern BOOL DLLExport SPIC_GetMeasureAbsoluteSpectrum(float InttervaWL, float *data ,int & iN);

extern BOOL DLLExport SPIC_OnlyTestE(BYTE & level, float & E, float & AD);

extern BOOL DLLExport SPIC_SetParamAndTestLabView(
	                      BYTE  spectrumPrecision1,              // ������������   0x00 --- ��ʾ�ߣ� 0x01 --- ��ʾ��                                        
                          float    spectrumIntegralTime1,        // �����ǻ���ʱ�� (ms)
                          float    autoIntegralTimeUpLimit1,     // �������Զ�����ʱ������ (ms)
                          BYTE   spectrumModel1,                 //  ģʽ    0x00 --- ��ʾ�̶����֣� 0x01 --- ��ʾ�Զ�����
                          BYTE   averageNum1);                   //  ƽ������ 

//5. ��ȡ���Խ��
extern void DLLExport SPIC_GetBasicLabView(BYTE & precision1,float& IntegralTime1,BYTE & averNum1,
	float &Ip1,float &waveLenghRange1,BYTE & useColorParam,float& illumination,float &radiation);

extern void DLLExport SPIC_GetCIELabView(float &CIE_x,float &CIE_y,float& CIE_u,float &CIE_v);

extern void DLLExport SPIC_GetBasic2LabView(float& CCT,float &duv,float& Lp, float &HW,float& Ld,float &Pur);

extern void DLLExport SPIC_GetRGBLabView(float &ratioR,float& ratioG,float &ratioB,float &Ra);

extern void DLLExport SPIC_GetRLabView(float* R,int & iNums);
// 7 ���� ����
extern BOOL DLLExport SPIC_SetLanguage(Language language);

extern BOOL DLLExport SPIC_SetTestDlgShow(BOOL bShow);

#endif
