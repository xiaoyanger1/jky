using Jky.Public.Common;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Young.Core.Common;

namespace text.doors.Common
{
    public class TcpConnection1
    {

        [DllImport("WININET", CharSet = CharSet.Auto)]
        private static extern bool InternetGetConnectedState(ref InternetConnectionState lpdwFlags, int dwReserved);

        public TcpClient tcpClient;
        public ModbusIpMaster _MASTER;
        /// <summary>
        /// 是否打开
        /// </summary>
        public bool IsOpen = false;

        private ushort _StartAddress = 0;
        private ushort _NumOfPoints = 1;
        private byte _SlaveID = 1;

        //public TcpConnection()
        //{
        //    Connect();
        //}

        public void OpenTcpConnection()
        {
            Connect();
        }

        /// <summary>
        /// 检测网络状态
        /// </summary>
        /// <returns></returns>
        private bool CheckInternet()
        {
            InternetConnectionState flag = InternetConnectionState.INTERNET_CONNECTION_LAN;
            return InternetGetConnectedState(ref flag, 0);
        }
        enum InternetConnectionState : int
        {
            INTERNET_CONNECTION_MODEM = 0x1,  //调制解调器
            INTERNET_CONNECTION_LAN = 0x2, //局域网
            INTERNET_CONNECTION_PROXY = 0x4, //代理
            INTERNET_RAS_INSTALLED = 0x10, //？
            INTERNET_CONNECTION_OFFLINE = 0x20, // 通道？
            INTERNET_CONNECTION_CONFIGURED = 0x40//？
        }

        /// <summary>
        /// 打开TCP服务
        /// </summary>
        /// <returns></returns>
        public void Connect()
        {
            if (_MASTER != null)
                _MASTER.Dispose();
            if (tcpClient != null)
                tcpClient.Close();

            if (CheckInternet())
            {
                try
                {
                    tcpClient = new TcpClient(_GetConfig._IPAddress, _GetConfig._TCPPort);
                    tcpClient.ReceiveTimeout = 1500;

                    //开始一个对远程主机连接的异步请求
                    //IAsyncResult asyncResult = tcpClient..BeginConnect ( _GetConfig._IPAddress, _GetConfig._TCPPort, null, null );
                    //asyncResult.AsyncWaitHandle.WaitOne ( 500, true );
                    //if ( !asyncResult.IsCompleted )
                    //{
                    //    tcpClient.Close ();
                    //    Log.Error ( "ExportReport.Eexport", "message:无法连接从端" );
                    //    IsOpen = false;
                    //}

                    //由TCP客户端创建Modbus TCP的主
                    _MASTER = ModbusIpMaster.CreateIp(tcpClient);
                    _MASTER.Transport.Retries = 0;   //不必调试
                    _MASTER.Transport.ReadTimeout = 1500;//读取超时
                    IsOpen = true;
                }
                catch (Exception ex)
                {
                    Log.Error("ExportReport.Eexport", "message:tcp打开失败" + ex.Message + "\r\nsource:" + ex.Source + "\r\nStackTrace:" + ex.StackTrace);
                    tcpClient.Close();
                    IsOpen = false;
                }
            }
        }

        /// <summary>
        /// 设置高压标0
        /// </summary>
        public void SendGYBD(ref bool IsSuccess, bool logon = false)
        {
            try
            {
                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.高压标0_交替型按钮);
                bool[] readCoils = _MASTER.ReadCoils(_SlaveID, _StartAddress, _NumOfPoints);
                if (readCoils[0])
                    _MASTER.WriteSingleCoil(_StartAddress, false);
                else
                {
                    if (logon == false)
                    {
                        _MASTER.WriteSingleCoil(_StartAddress, true);
                    }
                }
            }
            catch (Exception ex)
            {
                IsOpen = false;
                IsSuccess = false;
                // Log.Error("ExportReport.Eexport", "message:高压标0" + ex.Message);
            }
            IsSuccess = true;
        }
        /// <summary>
        /// 获取温度显示
        /// </summary>
        public double GetWDXS(ref bool IsSuccess)
        {
            double res = 0;
            lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.温度显示);

                    ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    res = double.Parse((double.Parse(holding_register[0].ToString()) / 10).ToString());
                    res = _SlopeCompute.GetValues(text.doors.Common._Public_Enum.ENUM_Demarcate.enum_温度传感器, float.Parse(res.ToString()));
                }
                catch (Exception ex)
                {
                    IsSuccess = false;
                    IsOpen = false;
                    // Log.Error("ExportReport.Eexport", "message:获取温度显示" + ex.Message);
                }

                IsSuccess = true;
            }
            return res;
        }

        /// <summary>
        /// 获取大气压力显示
        /// </summary>
        public double GetDQYLXS(ref bool IsSuccess)
        {
            double res = 0; lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.大气压力显示);

                    ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    res = double.Parse((double.Parse(holding_register[0].ToString()) / 10).ToString());

                    res = _SlopeCompute.GetValues(text.doors.Common._Public_Enum.ENUM_Demarcate.enum_大气压力传感器, float.Parse(res.ToString()));
                }
                catch (Exception ex)
                {
                    IsSuccess = false;
                    IsOpen = false;
                    //  Log.Error("ExportReport.Eexport", "message:获取大气压力" + ex.Message);
                }

                IsSuccess = true;
            }
            return res;
        }

        /// <summary>
        /// 获取风速显示
        /// </summary>
        public double GetFSXS(ref bool IsSuccess)
        {

            double res = 0;
            lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.风速显示);

                    ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    res = double.Parse((double.Parse(holding_register[0].ToString()) / 100).ToString());
                }
                catch (Exception ex)
                {
                    IsSuccess = false;
                    IsOpen = false;
                    Log.Error("ExportReport.Eexport", "message:获取风速显示" + ex.Message);
                }

                IsSuccess = true;
            }
            return res;
        }

        /// <summary>
        /// 读取差压显示
        /// </summary>
        /// <param name="IsSuccess"></param>
        /// <returns></returns>
        public double GetCYXS(ref bool IsSuccess)
        {
            double res = 0;
            lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.差压显示);

                    ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    res = double.Parse((double.Parse(holding_register[0].ToString()) / 100).ToString());

                    if (int.Parse(holding_register[0].ToString()) > 1100)
                    {
                        res = -(65535 - int.Parse(holding_register[0].ToString()));
                    }
                    else
                    {
                        res = int.Parse(holding_register[0].ToString());
                    }
                    res = _SlopeCompute.GetValues(text.doors.Common._Public_Enum.ENUM_Demarcate.enum_差压传感器, float.Parse(res.ToString()));
                }
                catch (Exception ex)
                {
                    IsOpen = false;
                    IsSuccess = false;
                    Log.Error("ExportReport.Eexport", "message:读取差压显示" + ex.Message);
                }

                IsSuccess = true;
            }
            return res;
        }

        /// <summary>
        /// 设置风机控制
        /// </summary>
        public void SendFJKZ(double value, ref bool IsSuccess)
        {
            try
            {
                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.风机控制);
                _MASTER.WriteSingleRegister(_SlaveID, _StartAddress, (ushort)(value));
            }
            catch (Exception ex)
            {
                IsSuccess = false; IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:设置风机控制" + ex.Message);
            }
            IsSuccess = true;
        }


        /// <summary>
        /// 设置正压阀
        /// </summary>
        /// <param name="IsSuccess"></param>
        public void SendZYF(ref bool IsSuccess)
        {
            lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.负压阀);
                    _MASTER.WriteSingleCoil(_StartAddress, false);
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.正压阀);
                    _MASTER.WriteSingleCoil(_StartAddress, true);
                }
                catch (Exception ex)
                {
                    IsSuccess = false;
                    IsOpen = false;
                    Log.Error("ExportReport.Eexport", "message:设置正压阀" + ex.Message);
                }
            }
            IsSuccess = true;
        }

        /// <summary>
        /// 设置负压阀
        /// </summary>
        /// <param name="IsSuccess"></param>
        public void SendFYF(ref bool IsSuccess)
        {
            lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.正压阀);
                    _MASTER.WriteSingleCoil(_StartAddress, false);
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.负压阀);
                    _MASTER.WriteSingleCoil(_StartAddress, true);
                }
                catch (Exception ex)
                {
                    IsSuccess = false;
                    IsOpen = false;
                    Log.Error("ExportReport.Eexport", "message:设置负压阀" + ex.Message);
                }
            }
            IsSuccess = true;
        }


        /// <summary>
        /// 读取正负压阀
        /// </summary>
        public void GetZFYF(ref bool IsSuccess, ref bool z, ref bool f)
        {
            lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.正压阀);
                    bool[] readCoils_z = _MASTER.ReadCoils(_StartAddress, _NumOfPoints);
                    z = bool.Parse(readCoils_z[0].ToString());

                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.负压阀);
                    bool[] readCoils_f = _MASTER.ReadCoils(_StartAddress, _NumOfPoints);
                    f = bool.Parse(readCoils_f[0].ToString());
                }
                catch (Exception ex)
                {
                    IsSuccess = false;
                    IsOpen = false;
                    Log.Error("ExportReport.Eexport", "message:读取正负压阀" + ex.Message);
                }
            }
            IsSuccess = true;
        }



        /*图标页面*/

        /// <summary>
        /// 设置正压预备
        /// </summary>
        /// <param name="IsSuccess"></param>
        public void SetZYYB(ref bool IsSuccess)
        {
            try
            {
                SendZYF(ref IsSuccess);
                if (!IsSuccess)
                {
                    return;
                }

                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.正压预备);
                _MASTER.WriteSingleCoil(_StartAddress, false);
                _MASTER.WriteSingleCoil(_StartAddress, true);

            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:设置正压预备" + ex.Message);
            }
            IsSuccess = true;
        }

        /// <summary>
        /// 读取正压预备结束
        /// </summary>
        /// <param name="IsSuccess"></param>
        public int GetZYYBJS(ref bool IsSuccess)
        {
            int res = 0;
            try
            {
                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.正压预备结束);
                ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                res = int.Parse(holding_register[0].ToString());
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:读取正压预备结束" + ex.Message);
            }
            IsSuccess = true;
            return res;
        }

        /// <summary>
        /// 发送正压开始
        /// </summary>
        public void SendZYKS(ref bool IsSuccess)
        {
            try
            {
                SendZYF(ref IsSuccess);
                if (!IsSuccess)
                {
                    return;
                }
                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.正压开始);
                _MASTER.WriteSingleCoil(_SlaveID, _StartAddress, false);
                _MASTER.WriteSingleCoil(_SlaveID, _StartAddress, true);
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:发送正压开始" + ex.Message);
            }
            IsSuccess = true;
        }


        /// <summary>
        /// 读取正压开始结束
        /// </summary>
        /// <param name="IsSuccess"></param>
        public double GetZYKSJS(ref bool IsSuccess)
        {
            double res = 0;
            try
            {
                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.正压开始结束);
                ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                res = double.Parse(holding_register[0].ToString());
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:读取正压开始结束" + ex.Message);
            }
            IsSuccess = true;
            return res;
        }

        /// <summary>
        /// 发送负压预备
        /// </summary>
        /// <param name="IsSuccess"></param>
        public void SendFYYB(ref bool IsSuccess)
        {
            try
            {
                SendFYF(ref IsSuccess);
                if (!IsSuccess)
                {
                    return;
                }

                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.负压预备);
                _MASTER.WriteSingleCoil(_StartAddress, false);
                _MASTER.WriteSingleCoil(_StartAddress, true);

            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:发送负压预备" + ex.Message);
            }
            IsSuccess = true;
        }
        /// <summary>
        /// 发送负压开始
        /// </summary>
        public void SendFYKS(ref bool IsSuccess)
        {
            try
            {
                SendFYF(ref IsSuccess);
                if (!IsSuccess)
                {
                    return;
                }
                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.负压开始);
                _MASTER.WriteSingleCoil(_SlaveID, _StartAddress, false);
                _MASTER.WriteSingleCoil(_SlaveID, _StartAddress, true);
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:发送负压开始" + ex.Message);
            }
            IsSuccess = true;
        }


        /// <summary>
        /// 读取正压预备结束
        /// </summary>
        /// <param name="IsSuccess"></param>
        public int GetFYYBJS(ref bool IsSuccess)
        {
            int res = 0;
            lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.负压预备结束);
                    ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    res = int.Parse(holding_register[0].ToString());
                }
                catch (Exception ex)
                {
                    IsSuccess = false;
                    IsOpen = false;
                    Log.Error("ExportReport.Eexport", "message:读取正压预备结束" + ex.Message);
                }
                IsSuccess = true;
            }
            return res;
        }

        /// <summary>
        /// 读取正压开始结束
        /// </summary>
        /// <param name="IsSuccess"></param>
        public double GetFYKSJS(ref bool IsSuccess)
        {
            double res = 0;
            try
            {
                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.负压开始结束);
                ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                res = double.Parse(holding_register[0].ToString());
                Log.Info("", res.ToString());
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:读取正压开始结束" + ex.Message);
            }
            IsSuccess = true;
            return res;
        }



        /// <summary>
        /// 获取正压预备时，设定压力值
        /// </summary>
        public double GetZYYBYLZ(ref bool IsSuccess, string type)
        {
            double res = 0;
            lock (_MASTER)
            {
                try
                {
                    if (type == "ZYYB")
                    {
                        _StartAddress = _Public_Command.GetCommandDict(_Public_Command.正压预备_设定值);
                    }
                    else if (type == "ZYKS")
                    {
                        _StartAddress = _Public_Command.GetCommandDict(_Public_Command.正压开始_设定值);
                    }
                    else if (type == "FYYB")
                    {
                        _StartAddress = _Public_Command.GetCommandDict(_Public_Command.负压预备_设定值);
                    }
                    else if (type == "FYKS")
                    {
                        _StartAddress = _Public_Command.GetCommandDict(_Public_Command.负压开始_设定值);
                    }

                    ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                    res = double.Parse((double.Parse(holding_register[0].ToString())).ToString());

                }
                catch (Exception ex)
                {
                    IsSuccess = false;
                    IsOpen = false;
                    Log.Error("ExportReport.Eexport", "message:获取正压预备时，设定压力值" + ex.Message);
                }

                IsSuccess = true;
            }
            return res;
        }



        /// <summary>
        /// 获取正压100Pa是否开始计时
        /// </summary>
        public bool Get_Z_S100TimeStart(ref bool IsSuccess)
        {
            bool res = false;
            lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.正压100TimeStart);
                    bool[] readCoils_z = _MASTER.ReadCoils(_StartAddress, _NumOfPoints);
                    res = bool.Parse(readCoils_z[0].ToString());
                }
                catch (Exception ex)
                {
                    IsSuccess = false;
                    IsOpen = false;
                    Log.Error("ExportReport.Eexport", "message:获取正压100Pa是否开始计时" + ex.Message);
                }
            }
            return res;
        }

        /// <summary>
        /// 获取正压150Pa是否开始计时
        /// </summary>
        public bool Get_Z_S150PaTimeStart(ref bool IsSuccess)
        {
            bool res = false;
            lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.正压150TimeStart);
                    bool[] readCoils_z = _MASTER.ReadCoils(_StartAddress, _NumOfPoints);
                    res = bool.Parse(readCoils_z[0].ToString());
                }
                catch (Exception ex)
                {
                    IsSuccess = false;
                    IsOpen = false;
                    Log.Error("ExportReport.Eexport", "message:获取正压150Pa是否开始计时" + ex.Message);
                }
            }
            return res;
        }

        /// <summary>
        /// 获取降压100Pa是否开始计时
        /// </summary>
        public bool Get_Z_J100PaTimeStart(ref bool IsSuccess)
        {
            bool res = false;
            lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.正压_100TimeStart);
                    bool[] readCoils_z = _MASTER.ReadCoils(_StartAddress, _NumOfPoints);
                    res = bool.Parse(readCoils_z[0].ToString());
                }
                catch (Exception ex)
                {
                    IsSuccess = false;
                    IsOpen = false;
                    Log.Error("ExportReport.Eexport", "message:获取降压100Pa是否开始计时" + ex.Message);
                }
            }
            return res;
        }

        /// <summary>
        /// 获取负压100Pa是否开始计时
        /// </summary>
        public bool Get_F_S100PaTimeStart(ref bool IsSuccess)
        {
            bool res = false;
            lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.负压100TimeStart);
                    bool[] readCoils_z = _MASTER.ReadCoils(_StartAddress, _NumOfPoints);
                    res = bool.Parse(readCoils_z[0].ToString());
                }
                catch (Exception ex)
                {
                    IsSuccess = false;
                    IsOpen = false;
                    Log.Error("ExportReport.Eexport", "message:获取负压100Pa是否开始计时" + ex.Message);
                }
            }
            return res;
        }

        /// <summary>
        /// 获取负压150Pa是否开始计时
        /// </summary>
        public bool Get_F_S150PaTimeStart(ref bool IsSuccess)
        {
            bool res = false;
            lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.负压150TimeStart);
                    bool[] readCoils_z = _MASTER.ReadCoils(_StartAddress, _NumOfPoints);
                    res = bool.Parse(readCoils_z[0].ToString());
                }
                catch (Exception ex)
                {
                    IsOpen = false;
                    IsSuccess = false;
                    Log.Error("ExportReport.Eexport", "message:获取负压150Pa是否开始计时" + ex.Message);

                }
            }
            return res;
        }

        /// <summary>
        /// 获取负压降100Pa是否开始计时
        /// </summary>
        public bool Get_F_J100PaTimeStart(ref bool IsSuccess)
        {
            bool res = false;
            lock (_MASTER)
            {
                try
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.负压_100TimeStart);
                    bool[] readCoils_z = _MASTER.ReadCoils(_StartAddress, _NumOfPoints);
                    res = bool.Parse(readCoils_z[0].ToString());
                }
                catch (Exception ex)
                {
                    IsSuccess = false;
                    IsOpen = false;
                    Log.Error("ExportReport.Eexport", "message:获取负压降100Pa是否开始计时" + ex.Message);
                }
            }
            return res;
        }
        /*水密*/

        /// <summary>
        /// 设置水密预备
        /// </summary>
        /// <param name="IsSuccess"></param>
        public void SetSMYB(ref bool IsSuccess)
        {
            try
            {
                SendZYF(ref IsSuccess);
                if (!IsSuccess)
                {
                    return;
                }

                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.水密性预备加压);
                _MASTER.WriteSingleCoil(_StartAddress, false);
                _MASTER.WriteSingleCoil(_StartAddress, true);

            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:水密性预备加压" + ex.Message);

            }
            IsSuccess = true;
        }


        /// <summary>
        /// 读取水密预备结束
        /// </summary>
        /// <param name="IsSuccess"></param>
        public int GetSMYBJS(ref bool IsSuccess)
        {
            int res = 0;
            try
            {
                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.水密预备结束);
                ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                res = int.Parse(holding_register[0].ToString());
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:水密预备结束" + ex.Message);
            }
            IsSuccess = true;
            return res;
        }


        /// <summary>
        /// 读取水密预备设定压力
        /// </summary>
        /// <param name="IsSuccess"></param>
        public int GetSMYBSDYL(ref bool IsSuccess, string type)
        {
            int res = 0;
            try
            {
                if (type == "SMYB")
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.水密预备_设定值);
                }
                else if (type == "SMKS")
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.水密开始_设定值);
                }
                else if (type == "YCJY")
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.水密依次加压_设定值);
                }
                else if (type == "XYJ")
                {
                    _StartAddress = _Public_Command.GetCommandDict(_Public_Command.水密开始_设定值);
                }

                ushort[] holding_register = _MASTER.ReadHoldingRegisters(_SlaveID, _StartAddress, _NumOfPoints);
                res = int.Parse(holding_register[0].ToString());
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:读取水密预备设定压力" + ex.Message);
            }
            IsSuccess = true;
            return res;
        }

        /// <summary>
        /// 发送水密开始
        /// </summary>
        public void SendSMXKS(ref bool IsSuccess)
        {
            try
            {
                SendZYF(ref IsSuccess);
                if (!IsSuccess)
                {
                    return;
                }

                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.水密性开始);
                _MASTER.WriteSingleCoil(_SlaveID, _StartAddress, false);
                _MASTER.WriteSingleCoil(_SlaveID, _StartAddress, true);
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:水密性开始" + ex.Message);
            }
            IsSuccess = true;
        }

        /// <summary>
        /// 发送水密性下一级
        /// </summary>
        public void SendSMXXYJ(ref bool IsSuccess)
        {
            try
            {
                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.下一级);
                _MASTER.WriteSingleCoil(_SlaveID, _StartAddress, false);
                _MASTER.WriteSingleCoil(_SlaveID, _StartAddress, true);
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:下一级" + ex.Message);
            }
            IsSuccess = true;
        }



        /// <summary>
        /// 设置水密依次加压
        /// </summary>
        public void SendSMYCJY(double value, ref bool IsSuccess)
        {
            try
            {
                SendZYF(ref IsSuccess);

                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.以此加压数值);
                _MASTER.WriteSingleRegister(_SlaveID, _StartAddress, (ushort)(value));

                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.以此加压);
                _MASTER.WriteSingleCoil(_StartAddress, false);
                _MASTER.WriteSingleCoil(_StartAddress, true);

            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:设置水密依次加压" + ex.Message);
            }
            IsSuccess = true;
        }


        /// <summary>
        /// 急停
        /// </summary>
        public void Stop(ref bool IsSuccess)
        {
            try
            {
                _StartAddress = _Public_Command.GetCommandDict(_Public_Command.急停);
                _MASTER.WriteSingleCoil(_StartAddress, false);
                _MASTER.WriteSingleCoil(_StartAddress, true);
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                IsOpen = false;
                Log.Error("ExportReport.Eexport", "message:急停" + ex.Message);
            }
            IsSuccess = true;
        }
    }
}
