#ifndef ___EXZ10DLL_H___
#define ___EXZ10DLL_H___

//
//
// Z-10 DLL V1.00  Copyright 2012 EVERFINE
//
//
//

//
// ����ͨѶ���пڲ�����
//
extern BOOL __stdcall Z10DLL_SetCom(int iCom, int iBaudrate);

//
// ��ȡ̽ͷ����
// 
extern BOOL __stdcall Z10DLL_GetHeadNum(int& iNum, int& iCurNo, int iAllNo[]);

//
// ѡ��ǰ����̽ͷ
//
extern BOOL __stdcall Z10DLL_SwitchHead(int iHeadSele);

//
// ͨѶ��ǰ����̽ͷ���նȡ�ʱ�估�����ն�ֵ
//
extern BOOL __stdcall Z10DLL_CommE(float &fE, long &time, double &fIntE);

//
// ��λ����
//
extern BOOL __stdcall Z10DLL_ResetIntegral();

//
// ��ʼ����
//
extern BOOL __stdcall Z10DLL_StartIntegral();

//
// ֹͣ����
//
extern BOOL __stdcall Z10DLL_StopIntegral();


#endif
