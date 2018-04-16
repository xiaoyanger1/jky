using Modbus.Device;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using text.doors.Default;
using Young.Core.Common;

namespace text.doors.Common
{
    public class TCPClient
    {

        public static Young.Core.Logger.ILog Logger = Young.Core.Logger.LoggerManager.Current();

        public TcpClient tcpClient;
        public ModbusIpMaster _MASTER;
        /// <summary>
        /// 是否打开
        /// </summary>
        public bool IsTCPLink = false;
        private static Object syncLock = new Object();

        public void TcpOpen()
        {
            IsTCPLink = false;
            if (_MASTER != null)
                _MASTER.Dispose();
            if (tcpClient != null)
                tcpClient.Close();
            if (LAN.IsLanLink)
            {
                try
                {
                    tcpClient = new TcpClient();
                    //开始一个对远程主机连接的异步请求
                    IAsyncResult asyncResult = tcpClient.BeginConnect(DefaultBase.IPAddress, DefaultBase.TCPPort, null, null);
                    asyncResult.AsyncWaitHandle.WaitOne(500, true);
                    if (!asyncResult.IsCompleted)
                    {
                        tcpClient.Close();
                        IsTCPLink = false;
                        Logger.Info("连接服务器失败!:IP" + DefaultBase.IPAddress + ",port:" + DefaultBase.TCPPort);
                        return;
                    }
                    //由TCP客户端创建Modbus TCP的主
                    _MASTER = ModbusIpMaster.CreateIp(tcpClient);
                    _MASTER.Transport.Retries = 0;   //不必调试
                    _MASTER.Transport.ReadTimeout = 1500;//读取超时
                    IsTCPLink = true;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    IsTCPLink = false;
                    tcpClient.Close();
                }
            }
        }


        private ushort _StartAddress = 0;
        private ushort _NumOfPoints = 1;
        private byte _SlaveID = 1;


        #region 首页

        /// <summary>
        /// 设置标零
        /// </summary>
        /// <param name="logon"></param>
        /// <returns></returns>
        public bool SendSignZero(string commandStr, bool logon = false)
        {
            if (!IsTCPLink)
                return false;
            try
            {
                _StartAddress = BFMCommand.GetCommandDict(commandStr);
                bool[] readCoils = _MASTER.ReadCoils(_SlaveID, _StartAddress, _NumOfPoints);
                if (readCoils[0])
                    _MASTER.WriteSingleCoil(_StartAddress, false);
                else
                {
                    if (logon == false)
                        _MASTER.WriteSingleCoil(_StartAddress, true);
                }
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取温度显示
        /// </summary>
        public double GetWDXS(ref bool IsSuccess)
        {
            double res = 0;
            if (!IsTCPLink)
            {
                IsSuccess = false;
                return res;
            }
            try
            {
                lock (syncLock)
                {
                    _StartAddress = BFMCommand.GetCommandDict(BFMCommand.温度显示);

                    ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    res = double.Parse((double.Parse(holding_register[0].ToString()) / 10).ToString());
                    res = Formula.GetValues(PublicEnum.DemarcateType.温度传感器, float.Parse(res.ToString()));
                    IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                IsSuccess = false;
            }
            return res;
        }

        /// <summary>
        /// 获取大气压力显示
        /// </summary>
        public double GetDQYLXS(ref bool IsSuccess)
        {
            double res = 0;
            if (!IsTCPLink)
            {
                IsSuccess = false;
                return res;
            }
            try
            {
                lock (syncLock)
                {
                    _StartAddress = BFMCommand.GetCommandDict(BFMCommand.大气压力显示);
                    ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    res = double.Parse((double.Parse(holding_register[0].ToString()) / 10).ToString());
                    res = Formula.GetValues(PublicEnum.DemarcateType.大气压力传感器, float.Parse(res.ToString()));
                }
                IsSuccess = true;
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                IsSuccess = false;
            }

            return res;
        }

        /// <summary>
        /// 获取风速显示
        /// </summary>
        public double GetFSXS(ref bool IsSuccess)
        {
            double res = 0;

            if (!IsTCPLink)
            {
                IsSuccess = false;
                return res;
            }
            try
            {
                lock (syncLock)
                {
                    _StartAddress = BFMCommand.GetCommandDict(BFMCommand.风速显示);
                    ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    var f = double.Parse((double.Parse(holding_register[0].ToString()) / 100).ToString());
                    res = Formula.GetValues(PublicEnum.DemarcateType.风速传感器, float.Parse(f.ToString()));
                    IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                IsSuccess = false;
                Logger.Error(ex);
            }
            return res;
        }

        /// <summary>
        /// 读取差压显示
        /// </summary>
        /// <param name="IsSuccess"></param>
        /// <returns></returns>
        public int GetCYXS(ref bool IsSuccess)
        {
            double res = 0;
            if (!IsTCPLink)
            {
                IsSuccess = false;
                return 0;
            }
            try
            {
                lock (syncLock)
                {
                    _StartAddress = BFMCommand.GetCommandDict(BFMCommand.差压显示);

                    ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    var f = double.Parse(holding_register[0].ToString()) / 100;

                    if (int.Parse(holding_register[0].ToString()) > 1100)
                        f = -(65535 - int.Parse(holding_register[0].ToString()));
                    else
                        f = int.Parse(holding_register[0].ToString());

                    res = Formula.GetValues(PublicEnum.DemarcateType.差压传感器, float.Parse(f.ToString()));
                    IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                IsSuccess = false;
                Logger.Error(ex);
            }
            return int.Parse(Math.Round(res, 0).ToString());
        }

        /// <summary>
        /// 设置风机控制
        /// </summary>
        public bool SendFJKZ(double value)
        {
            if (!IsTCPLink)
                return false;
            try
            {
                lock (syncLock)
                {
                    _StartAddress = BFMCommand.GetCommandDict(BFMCommand.风机控制);
                    _MASTER.WriteSingleRegister(_SlaveID, _StartAddress, (ushort)(value));
                }
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
            }
            return true;
        }


        /// <summary>
        /// 设置正压阀
        /// </summary>
        public bool SendZYF()
        {
            if (!IsTCPLink)
                return false;
            try
            {
                lock (syncLock)
                {
                    _StartAddress = BFMCommand.GetCommandDict(BFMCommand.负压阀);
                    _MASTER.WriteSingleCoil(_StartAddress, false);
                    _StartAddress = BFMCommand.GetCommandDict(BFMCommand.正压阀);
                    _MASTER.WriteSingleCoil(_StartAddress, true);
                }
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 设置负压阀
        /// </summary>
        public bool SendFYF()
        {
            if (!IsTCPLink)
                return false;
            try
            {
                lock (syncLock)
                {
                    _StartAddress = BFMCommand.GetCommandDict(BFMCommand.正压阀);
                    _MASTER.WriteSingleCoil(_StartAddress, false);
                    _StartAddress = BFMCommand.GetCommandDict(BFMCommand.负压阀);
                    _MASTER.WriteSingleCoil(_StartAddress, true);
                }
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 读取正负压阀
        /// </summary>
        public bool GetZFYF(ref bool z, ref bool f)
        {
            if (!IsTCPLink)
                return false;
            try
            {
                lock (syncLock)
                {
                    _StartAddress = BFMCommand.GetCommandDict(BFMCommand.正压阀);
                    bool[] readCoils_z = _MASTER.ReadCoils(_StartAddress, _NumOfPoints);
                    z = bool.Parse(readCoils_z[0].ToString());

                    _StartAddress = BFMCommand.GetCommandDict(BFMCommand.负压阀);
                    bool[] readCoils_f = _MASTER.ReadCoils(_StartAddress, _NumOfPoints);
                    f = bool.Parse(readCoils_f[0].ToString());
                }
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
            }
            return true;
        }


        #endregion

        #region 气密

        public int Read_SM_BtnType(string commandStr, ref bool IsSuccess)
        {
            int res = 0;
            if (!IsTCPLink)
            {
                IsSuccess = false;
                return res;
            }
            try
            {
                lock (syncLock)
                {
                    _StartAddress = BFMCommand.GetCommandDict(commandStr);
                    ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    res = int.Parse(holding_register[0].ToString());
                    IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                IsSuccess = false;
                Logger.Error(ex);
            }
            return res;
        }
        /// <summary>
        /// 气密发送按钮命令
        /// </summary>
        /// <returns></returns>
        public bool Send_QM_Btn(string commandStr)
        {
            if (!IsTCPLink)
                return false;
            try
            {
                lock (syncLock)
                {
                    var res = SendFYF();
                    if (!res)
                    {
                        return false;
                    }
                    _StartAddress = BFMCommand.GetCommandDict(commandStr);
                    _MASTER.WriteSingleCoil(_SlaveID, _StartAddress, false);
                    _MASTER.WriteSingleCoil(_SlaveID, _StartAddress, true);
                }
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
            }
            return true;
        }


        /// <summary>
        /// 读取气密按钮设定值
        /// /// </summary>
        public double ReadSetkPa(string commandStr, ref bool IsSuccess)
        {
            double res = 0;
            if (!IsTCPLink)
            {
                IsSuccess = false;
                return res;
            }

            try
            {
                lock (syncLock)
                {
                    _StartAddress = BFMCommand.GetCommandDict(commandStr);
                    ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    res = double.Parse((double.Parse(holding_register[0].ToString())).ToString());
                    IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                IsSuccess = false;
                Logger.Error(ex);
            }
            return res;
        }

        /// <summary>
        /// 获取气密个等级Pa是否开始计时
        /// </summary>
        public bool Read_QM_kPaTimeStart(string commandStr)
        {
            if (!IsTCPLink)
                return false;
            try
            {
                lock (syncLock)
                {
                    _StartAddress = BFMCommand.GetCommandDict(commandStr);
                    ushort[] t = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    if (Convert.ToInt32(t[0]) > 20)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
            }

        }

        #endregion

        #region 水密

        /// <summary>
        /// 水密按钮设置
        /// </summary>
        public bool Send_SM_Btn(string commandStr)
        {
            if (!IsTCPLink)
                return false;
            try
            {
                var res = SendZYF();
                if (!res)
                    return false;

                _StartAddress = BFMCommand.GetCommandDict(commandStr);
                _MASTER.WriteSingleCoil(_StartAddress, false);
                _MASTER.WriteSingleCoil(_StartAddress, true);
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 读取水密按钮状态
        /// </summary>
        /// <param name="IsSuccess"></param>
        public int Get_SM_BtnType(string commandStr, ref bool IsSuccess)
        {
            int res = 0;
            if (!IsTCPLink)
            {
                IsSuccess = false;
                return res;
            }
            try
            {
                _StartAddress = BFMCommand.GetCommandDict(commandStr);
                ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                res = int.Parse(holding_register[0].ToString());
                IsSuccess = true;
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                IsSuccess = false;
                Logger.Error(ex);
            }
            return res;
        }


        /// <summary>
        /// 读取水密设定压力
        /// </summary>
        /// <param name="IsSuccess"></param>
        public int Get_SM_SetkPa(string commandStr, ref bool IsSuccess)
        {
            int res = 0;
            if (!IsTCPLink)
            {
                IsSuccess = false;
                return res;
            }

            try
            {
                _StartAddress = BFMCommand.GetCommandDict(commandStr);

                ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                res = int.Parse(holding_register[0].ToString());
                IsSuccess = true;
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                IsSuccess = false;
                Logger.Error(ex);
            }
            return res;
        }


        /// <summary>
        /// 设置水密依次加压
        /// </summary>
        public bool SendSMYCJY(double value)
        {
            if (!IsTCPLink)
                return false;
            try
            {
                var res = SendZYF();
                if (!res)
                    return false;

                _StartAddress = BFMCommand.GetCommandDict(BFMCommand.依次加压数值);
                _MASTER.WriteSingleRegister(_SlaveID, _StartAddress, (ushort)(value));

                _StartAddress = BFMCommand.GetCommandDict(BFMCommand.依次加压);
                _MASTER.WriteSingleCoil(_StartAddress, false);
                _MASTER.WriteSingleCoil(_StartAddress, true);
                return true;

            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
            }

        }


        /// <summary>
        /// 急停
        /// </summary>
        public bool Stop()
        {
            if (!IsTCPLink)
                return false;

            try
            {
                _StartAddress = BFMCommand.GetCommandDict(BFMCommand.急停);
                _MASTER.WriteSingleCoil(_StartAddress, false);
                _MASTER.WriteSingleCoil(_StartAddress, true);
                return true;
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
                // System.Environment.Exit(0);
            }
        }

        #endregion

        #region 风压
        /// <summary>
        /// 获取位移传感器
        /// </summary>
        public double Get_FY_Displace(string commandStr, ref bool IsSuccess)
        {
            double res = 0;
            try
            {
                if (!IsTCPLink)
                {
                    IsSuccess = false;
                    return res;
                }
                lock (syncLock)
                {
                    _StartAddress = BFMCommand.GetCommandDict(commandStr);
                    ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    res = double.Parse((double.Parse(holding_register[0].ToString()) / 10).ToString());
                    //res = Formula.GetValues(PublicEnum.DemarcateType.enum_大气压力传感器, float.Parse(res.ToString()));
                    //todo:位移标定
                }
                IsSuccess = true;
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                IsSuccess = false;
            }

            return res;
        }

        /// <summary>
        /// 风压按钮
        /// </summary>
        /// <param name="commandStr"></param>
        /// <returns></returns>
        public bool Send_FY_Btn(string commandStr)
        {
            if (!IsTCPLink)
                return false;
            try
            {
                var res = SendZYF();
                if (!res)
                {
                    return false;
                }
                _StartAddress = BFMCommand.GetCommandDict(commandStr);
                _MASTER.WriteSingleCoil(_SlaveID, _StartAddress, false);
                _MASTER.WriteSingleCoil(_SlaveID, _StartAddress, true);
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 这是正反复安全
        /// </summary>
        /// <param name="commandStr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set_FY_Value(string valueStr, string commandStr, double value)
        {
            if (!IsTCPLink)
                return false;
            try
            {
                var res = SendZYF();
                if (!res)
                    return false;

                _StartAddress = BFMCommand.GetCommandDict(valueStr);
                _MASTER.WriteSingleRegister(_SlaveID, _StartAddress, (ushort)(value));

                _StartAddress = BFMCommand.GetCommandDict(commandStr);
                _MASTER.WriteSingleCoil(_StartAddress, false);
                _MASTER.WriteSingleCoil(_StartAddress, true);
                return true;

            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
            }
        }


        /// <summary>
        /// 读取风压按钮状态
        /// </summary>
        /// <param name="IsSuccess"></param>
        public int Read_FY_BtnType(string commandStr, ref bool IsSuccess)
        {
            int res = 0;
            if (!IsTCPLink)
            {
                IsSuccess = false;
                return res;
            }
            try
            {
                _StartAddress = BFMCommand.GetCommandDict(commandStr);
                ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                res = int.Parse(holding_register[0].ToString());
                IsSuccess = true;
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                IsSuccess = false;
                Logger.Error(ex);
            }
            return res;
        }


        /// <summary>
        /// 设置位移标零
        /// </summary>
        /// <param name="logon"></param>
        /// <returns></returns>
        public bool SendDisplacementSignZero(string commandStr)
        {
            if (!IsTCPLink)
                return false;
            try
            {
                _StartAddress = BFMCommand.GetCommandDict(commandStr);
                bool[] readCoils = _MASTER.ReadCoils(_SlaveID, _StartAddress, _NumOfPoints);
                if (readCoils[0])
                    _MASTER.WriteSingleCoil(_StartAddress, false);
                else
                    _MASTER.WriteSingleCoil(_StartAddress, true);
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
            }
            return true;
        }


        #endregion

        #region  PID

        /// <summary>
        /// 写入PID
        /// </summary>
        /// <param name="IsSuccess"></param>
        public bool SendPid(string commandStr, double value)
        {
            if (!IsTCPLink)
                return false;
            try
            {
                _StartAddress = BFMCommand.GetCommandDict(commandStr);
                _MASTER.WriteSingleRegister(_SlaveID, _StartAddress, (ushort)value);
                return true;
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                Logger.Error(ex);
                return false;
            }
        }

        /// <summary>
        /// 读取PID
        /// </summary>
        /// <param name="IsSuccess"></param>
        public int GetPID(string commandStr, ref bool IsSuccess)
        {
            int res = 0;
            if (!IsTCPLink)
            {
                IsSuccess = false;
                return res;
            }
            try
            {
                _StartAddress = BFMCommand.GetCommandDict(commandStr);

                ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                res = int.Parse(holding_register[0].ToString());
                IsSuccess = true;
            }
            catch (Exception ex)
            {
                IsTCPLink = false;
                IsSuccess = false;
                Logger.Error(ex);
            }
            return res;
        }

        #endregion
    }
}
