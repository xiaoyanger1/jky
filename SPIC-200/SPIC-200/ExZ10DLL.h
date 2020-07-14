#ifndef ___EXZ10DLL_H___
#define ___EXZ10DLL_H___

//
//
// Z-10 DLL V1.00  Copyright 2012 EVERFINE
//
//
//

//
// 设置通讯串行口波特率
//
extern BOOL __stdcall Z10DLL_SetCom(int iCom, int iBaudrate);

//
// 获取探头数量
// 
extern BOOL __stdcall Z10DLL_GetHeadNum(int& iNum, int& iCurNo, int iAllNo[]);

//
// 选择当前工作探头
//
extern BOOL __stdcall Z10DLL_SwitchHead(int iHeadSele);

//
// 通讯当前工作探头的照度、时间及积分照度值
//
extern BOOL __stdcall Z10DLL_CommE(float &fE, long &time, double &fIntE);

//
// 复位积分
//
extern BOOL __stdcall Z10DLL_ResetIntegral();

//
// 开始积分
//
extern BOOL __stdcall Z10DLL_StartIntegral();

//
// 停止积分
//
extern BOOL __stdcall Z10DLL_StopIntegral();


#endif
