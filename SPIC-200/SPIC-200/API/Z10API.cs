using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SPIC_200.API
{
    public class Z10API
    {

        public struct ReadCount
        {
            [MarshalAs(UnmanagedType.SysInt, SizeConst = 15)]
            public int[] iAllNo;

            public int iNum;
            public int iCurNo;
        }

        // 设置通讯口
        [DllImport("Z10CommDLL.dll")]
        public static extern int Z10DLL_SetCom(int iCom, int iBaudrate);

        // 获取探头数
        [DllImport("Z10CommDLL.dll")]
        public static extern int Z10DLL_GetHeadNum(ref int iNum, ref int iCurNo, int[] iAllNo);

        // 切换探头
        [DllImport("Z10CommDLL.dll")]
        public static extern int Z10DLL_SwitchHead(int iHeadSele);
        // 通讯照度
        [DllImport("Z10CommDLL.dll")]
        public static extern int Z10DLL_CommE(ref float fE, ref Int32 time, ref  double fIntE);

    }
}
