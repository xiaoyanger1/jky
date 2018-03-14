using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text.doors.Default;
using text.doors.Model;
using Young.Core.SQLite;

namespace text.doors.Service
{

    public class DAL_Demarcate_Dict
    {
        public static Young.Core.Logger.ILog Logger = Young.Core.Logger.LoggerManager.Current();

        private static List<Calibrating_Dict> DemarcateList = GetCalibrating_Dict();
        //<summary>
        //温度传感器
        //</summary>
        public static List<Calibrating_Dict> _temperatureDict = null;
        public static List<Calibrating_Dict> temperatureDict
        {
            get
            {
                if (_temperatureDict == null)
                    temperatureDict = DemarcateList.FindAll(t => t.Enum == PublicEnum.DemarcateType.enum_温度传感器.ToString()).OrderBy(t => t.x).ToList();
                return _temperatureDict;
            }
            set
            {
                _temperatureDict = value;
            }
        }

        //<summary>
        //差压传感器
        //</summary>
        public static List<Calibrating_Dict> _differentialPressureDict = null;
        public static List<Calibrating_Dict> differentialPressureDict
        {
            get
            {
                if (_differentialPressureDict == null)
                    differentialPressureDict = DemarcateList.FindAll(t => t.Enum == PublicEnum.DemarcateType.enum_差压传感器.ToString()).OrderBy(t => t.x).ToList();
                return _differentialPressureDict;
            }
            set
            {
                _differentialPressureDict = value;
            }
        }

        //<summary>
        //风速传感器
        //</summary>
        public static List<Calibrating_Dict> _windSpeedDict = null;
        public static List<Calibrating_Dict> windSpeedDict
        {
            get
            {
                if (_windSpeedDict == null)
                    windSpeedDict = DemarcateList.FindAll(t => t.Enum == PublicEnum.DemarcateType.enum_风速传感器.ToString()).OrderBy(t => t.x).ToList();
                return _windSpeedDict;
            }
            set
            {
                _windSpeedDict = value;
            }
        }

        //<summary>
        //大气压力传感器
        //</summary>
        public static List<Calibrating_Dict> _kPaDict = null;
        public static List<Calibrating_Dict> kPaDict
        {
            get
            {
                if (_kPaDict == null)
                    kPaDict = DemarcateList.FindAll(t => t.Enum == PublicEnum.DemarcateType.enum_大气压力传感器.ToString()).OrderBy(t => t.x).ToList();
                return _kPaDict;
            }
            set
            {
                _temperatureDict = value;
            }
        }


        private static List<Calibrating_Dict> GetCalibrating_Dict()
        {
            List<Calibrating_Dict> list = new List<Calibrating_Dict>();
            try
            {
                string sql = string.Format("select * from Demarcate_Dict");

                DataTable dt = SQLiteHelper.ExecuteDataset(sql).Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    Calibrating_Dict model = new Calibrating_Dict();
                    if (!string.IsNullOrWhiteSpace(dr["Enum"].ToString()))
                    {
                        model.Enum = dr["Enum"].ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(dr["D_Key"].ToString()))
                    {
                        model.x = float.Parse(dr["D_Key"].ToString());
                    }
                    if (!string.IsNullOrWhiteSpace(dr["D_Value"].ToString()))
                    {
                        model.y = float.Parse(dr["D_Value"].ToString());
                    }
                    list.Add(model);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            return list;
        }

    }
}
