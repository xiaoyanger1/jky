using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentilationCalculate
{
    public partial class Calculate : Form
    {

        public Calculate()
        {
            InitializeComponent();
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            try
            {
                Program.excelData = new ExcelData();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] strNames = openFileDialog.FileNames;
                    for (int i = 0; i < strNames.Length; i++)
                    {
                        if (i == 0)
                            Program.excelData.TestPoint1 = GetExcelGatherData(strNames[i]);
                        if (i == 1)
                            Program.excelData.TestPoint2 = GetExcelGatherData(strNames[i]);
                        if (i == 2)
                            Program.excelData.TestPoint3 = GetExcelGatherData(strNames[i]);
                        if (i == 3)
                            Program.excelData.TestPoint4 = GetExcelGatherData(strNames[i]);
                        if (i == 4)
                            Program.excelData.TestPoint5 = GetExcelGatherData(strNames[i]);
                    }
                    GetTimeRange();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常" + ex);
            }
        }

        public void GetTimeRange()
        {
            List<DateTime> alltime = new List<DateTime>();
            Program.excelData.TestPoint1.ForEach(t => alltime.Add(t.GatherTime.Value));
            Program.excelData.TestPoint2.ForEach(t => alltime.Add(t.GatherTime.Value));
            Program.excelData.TestPoint3.ForEach(t => alltime.Add(t.GatherTime.Value));
            Program.excelData.TestPoint4.ForEach(t => alltime.Add(t.GatherTime.Value));
            Program.excelData.TestPoint5.ForEach(t => alltime.Add(t.GatherTime.Value));

            dtp_start.Value = alltime.Min(t => t);
            dtp_end.Value = alltime.Max(t => t);
        }

        public DataSet ExcelToDS(string path)
        {
            try
            {
                string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + path + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                DataSet ds = null;
                strExcel = "select * from [CO2浓度_3$]";
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ds = new DataSet();
                myCommand.Fill(ds, "table1");
                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取excel异常，请检查数据格式");
            }
            return new DataSet();
        }

        public List<DataItem> GetExcelGatherData(string filePath)
        {
            List<DataItem> res = new List<DataItem>();
            DataSet ds = ExcelToDS(filePath);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                for (int j = 1; j < dt.Rows.Count; j++)
                {
                    DataRow dr = dt.Rows[j];
                    res.Add(new DataItem()
                    {
                        GatherTime = DateTime.Parse(dr["F1"].ToString()),
                        Value = double.Parse(dr["F2"].ToString())
                    });
                }
            }
            return res;
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            try
            {
                var measurepoint1 = Calculate_A(Program.excelData.TestPoint1);
                var measurepoint2 = Calculate_A(Program.excelData.TestPoint2);
                var measurepoint3 = Calculate_A(Program.excelData.TestPoint3);
                var measurepoint4 = Calculate_A(Program.excelData.TestPoint4);
                var measurepoint5 = Calculate_A(Program.excelData.TestPoint5);

                lbl_measurepoint1.Text = measurepoint1.ToString();
                lbl_measurepoint2.Text = measurepoint2.ToString();
                lbl_measurepoint3.Text = measurepoint3.ToString();
                lbl_measurepoint4.Text = measurepoint4.ToString();
                lbl_measurepoint5.Text = measurepoint5.ToString();

                lbl_measurepoint6.Text = Math.Round((measurepoint1 + measurepoint2 + measurepoint3 + measurepoint4 + measurepoint5) / 5, 2).ToString();
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="dataItems"></param>
        /// <returns></returns>
        private double Calculate_A(List<DataItem> dataItems)
        {
            var startTime = dtp_start.Value;
            var endTime = dtp_end.Value;
            var t = Math.Round((double)ExecDateDiff(startTime, endTime) / 60, 2);

            var c1 = dataItems.Max(c => c._Value); //浓度最大 第一条数据;

            var maxIndex = dataItems.FindIndex(c => c._Value.Equals(c1));
            var c0 = dataItems.Find(c => c.GatherTime.Value.ToString("yyyy-MM-dd HH:mm") == startTime.ToString("yyyy-MM-dd HH:mm"))?._Value;//除最大浓度随机选一个时间点数据;
            var ct = dataItems.Find(c => c.GatherTime.Value.ToString("yyyy-MM-dd HH:mm") == endTime.ToString("yyyy-MM-dd HH:mm"))?._Value;
            if (c0 == null || ct == null)
            {
                MessageBox.Show("计算错误,请检查数据是否存在");
                return 0;
            }
            var a = Math.Round((Math.Log(c1 - c0.Value) - Math.Log(ct.Value - c0.Value)) / t, 2);

            return a;

        }

        public static int ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            return (int)ts3.TotalMinutes;
        }
        public string InputCheck(string val)
        {
            if (val.Trim() != "")
            {
                if (!Validate(val.Trim(), @"^\d*\.{0,1}\d{0,4}$"))
                {
                    MessageBox.Show("请输入数字"); return "0";
                }
                return val;
            }
            else
            {
                return "0";
            }
        }

        /**////是否符合指定的正则表达式
        static public bool Validate(string str, string regexStr)
        {
            Regex regex = new Regex(regexStr);
            Match match = regex.Match(str);
            if (match.Success)
                return true;
            else
                return false;
        }

        private void txt_v_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_v.Text = InputCheck(txt_v.Text.TrimEnd());

                txt_res.Text = Math.Round((double.Parse(lbl_measurepoint6.Text) * double.Parse(txt_v.Text)), 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("计算错误");
            }
        }
    }
}


public class ExcelData
{
    public List<DataItem> TestPoint1 { get; set; }
    public List<DataItem> TestPoint2 { get; set; }
    public List<DataItem> TestPoint3 { get; set; }
    public List<DataItem> TestPoint4 { get; set; }
    public List<DataItem> TestPoint5 { get; set; }
}

public class DataItem
{
    public DateTime? GatherTime { get; set; }
    public double Value { get; set; }
    // 1ppm = 1.96 mg/m³
    public double _Value
    {
        get
        {
            return this.Value * 1.96;
        }
    }
}
