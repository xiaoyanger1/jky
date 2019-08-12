using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;
namespace VentilationCalculate
{
    public partial class Calculate : Form
    {


        public Calculate()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            cbb_bjfs.SelectedIndex = 0;
            dud_jcds.SelectedIndex = 0;
            dud_jcjg.SelectedIndex = 0;
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            try
            {
                Program.excelData = new ExcelData();
                lbl_load.Visible = true;

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
            finally
            {
                lbl_load.Visible = false;
            }
        }

        public void GetTimeRange()
        {
            List<DateTime> alltime = new List<DateTime>();
            Program.excelData.TestPoint1?.ForEach(t => alltime.Add(t.GatherTime.Value));
            Program.excelData.TestPoint2?.ForEach(t => alltime.Add(t.GatherTime.Value));
            Program.excelData.TestPoint3?.ForEach(t => alltime.Add(t.GatherTime.Value));
            Program.excelData.TestPoint4?.ForEach(t => alltime.Add(t.GatherTime.Value));
            Program.excelData.TestPoint5?.ForEach(t => alltime.Add(t.GatherTime.Value));

            dtp_start.Value = DateTime.Parse(alltime.Min(t => t).ToString("yyyy-MM-dd HH:mm"));
            dtp_end.Value = DateTime.Parse(alltime.Max(t => t).ToString("yyyy-MM-dd HH:mm"));
            dtpc0.Value = DateTime.Parse(alltime.Min(t => t).ToString("yyyy-MM-dd HH:mm"));
        }

        public DataTable GetDataFromExcelByCom(string strFileName)
        {

            Excel.Application app = new Excel.Application();
            Excel.Sheets sheets;
            object oMissiong = System.Reflection.Missing.Value;
            Excel.Workbook workbook = null;
            DataTable dt = new DataTable();

            bool hasTitle = false;
            try
            {
                if (app == null) return null;
                workbook = app.Workbooks.Open(strFileName, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                sheets = workbook.Worksheets;

                //将数据读入到DataTable中
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(3);//读取第一张表  
                if (worksheet == null) return null;

                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;
                //生成列头
                for (int i = 0; i < iColCount; i++)
                {
                    var name = "column" + i;
                    if (hasTitle)
                    {
                        var txt = ((Excel.Range)worksheet.Cells[1, i + 1]).Text.ToString();
                        if (!string.IsNullOrWhiteSpace(txt)) name = txt;
                    }
                    while (dt.Columns.Contains(name)) name = name + "_1";//重复行名称会报错。
                    dt.Columns.Add(new DataColumn(name, typeof(string)));
                }
                //生成行数据
                Excel.Range range;
                //int rowIdx = hasTitle ? 2 : 1;
                for (int iRow = 1; iRow <= iRowCount; iRow++)
                {
                    DataRow dr = dt.NewRow();
                    for (int iCol = 1; iCol <= iColCount; iCol++)
                    {
                        range = (Excel.Range)worksheet.Cells[iRow, iCol];
                        dr[iCol - 1] = (range.Value2 == null) ? "" : range.Text.ToString();
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch { return null; }
            finally
            {
                workbook.Close(false, oMissiong, oMissiong);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;
            }
        }



        public List<DataItem> GetExcelGatherData(string filePath)
        {
            List<DataItem> res = new List<DataItem>();

            DataTable dt = GetDataFromExcelByCom(filePath);
            //DataSet ds = ExcelToDS(filePath);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 1; j < dt.Rows.Count; j++)
                {
                    DataRow dr = dt.Rows[j];
                    if (dr["column0"] == null || string.IsNullOrWhiteSpace(dr["column0"].ToString()))
                        continue;
                    if (dr["column1"] == null || string.IsNullOrWhiteSpace(dr["column1"].ToString()))
                        continue;

                    res.Add(new DataItem()
                    {
                        GatherTime = DateTime.Parse(dr["column0"].ToString()),
                        Value = double.Parse(dr["column1"].ToString())
                    });
                }
            }
            return res;
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            try
            {
                var count = 0;
                var measurepoint1 = Calculate_A(Program.excelData.TestPoint1, 1);
                if (measurepoint1 > 0)
                    count = count + 1;
                var measurepoint2 = Calculate_A(Program.excelData.TestPoint2, 2);
                if (measurepoint2 > 0)
                    count = count + 1;
                var measurepoint3 = Calculate_A(Program.excelData.TestPoint3, 3);
                if (measurepoint3 > 0)
                    count = count + 1;
                var measurepoint4 = Calculate_A(Program.excelData.TestPoint4, 4);
                if (measurepoint4 > 0)
                    count = count + 1;
                var measurepoint5 = Calculate_A(Program.excelData.TestPoint5, 5);
                if (measurepoint5 > 0)
                    count = count + 1;

                lbl_measurepoint1.Text = measurepoint1.ToString();
                lbl_measurepoint2.Text = measurepoint2.ToString();
                lbl_measurepoint3.Text = measurepoint3.ToString();
                lbl_measurepoint4.Text = measurepoint4.ToString();
                lbl_measurepoint5.Text = measurepoint5.ToString();

                lbl_measurepoint6.Text = Math.Round((measurepoint1 + measurepoint2 + measurepoint3 + measurepoint4 + measurepoint5) / count, 2).ToString();
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
        private double Calculate_A(List<DataItem> dataItems, int index)
        {
            if (dataItems == null || dataItems.Count == 0)
                return 0;

            var startTime = dtp_start.Value;
            var endTime = dtp_end.Value;
            var t = Math.Round((double)ExecDateDiff(startTime, endTime) / 60, 2);

            var c1 = dataItems.Max(c => c._Value); //浓度最大 第一条数据;

            var maxIndex = dataItems.FindIndex(c => c._Value.Equals(c1));
            var c0 = dataItems.Find(c => c.GatherTime.Value.ToString("yyyy-MM-dd HH:mm") == dtpc0.Value.ToString("yyyy-MM-dd HH:mm"))?._Value;
            var ct = dataItems.Find(c => c.GatherTime.Value.ToString("yyyy-MM-dd HH:mm") == endTime.ToString("yyyy-MM-dd HH:mm"))?._Value;
            if (c0 == null || ct == null)
            {
                MessageBox.Show($"计算错误,【{index}】检测点请检查数据是否存在");
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


        private void btn_export_Click(object sender, EventArgs e)
        {
            List<ExcelDataTemp> list = new List<ExcelDataTemp>();
            list.Add(GetExcelDataTemp());
            DataTable dt = ToDataTable<ExcelDataTemp>(list);
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;

                ExportExcel(dt, foldPath + "\\" + "换气次数计算" + DateTime.Now.ToString("yyyyMMddHHmmss")+".xlsx");
            }

        }

        public ExcelDataTemp GetExcelDataTemp()
        {
            ExcelDataTemp excelDataTemp = new ExcelDataTemp();
            excelDataTemp.布局方式 = cbb_bjfs.Text;

            int num1 = 0;
            if (Int32.TryParse(dud_jcds.Text, out num1) == true)
                excelDataTemp.检测点数 = num1;


            int num3 = 0;
            if (Int32.TryParse(dud_jcjg.Text, out num3) == true)
                excelDataTemp.检测间隔 = num3;

            excelDataTemp.开始时间 = DateTime.Parse(dtp_start.Text);

            excelDataTemp.结束时间= DateTime.Parse(dtp_end.Text);

            double num4 = 0;
            if (double.TryParse(lbl_measurepoint1.Text, out num4) == true)
                excelDataTemp.测点1  = num4;


            double num5 = 0;
            if (double.TryParse(lbl_measurepoint2.Text, out num5) == true)
                excelDataTemp.测点2= num5;


            double num6 = 0;
            if (double.TryParse(lbl_measurepoint3.Text, out num6) == true)
                excelDataTemp.测点3= num6;

            double num7 = 0;
            if (double.TryParse(lbl_measurepoint4.Text, out num7) == true)
                excelDataTemp.测点4 = num7;


            double num8 = 0;
            if (double.TryParse(lbl_measurepoint5.Text, out num8) == true)
                excelDataTemp.测点5 = num8;

            double num9 = 0;
            if (double.TryParse(lbl_measurepoint6.Text, out num9) == true)
                excelDataTemp.空气交换率 = num9;

            double num10 = 0;
            if (double.TryParse(txt_v.Text, out num10) == true)
                excelDataTemp.室内空气容积 = num10;

            double num11 = 0;
            if (double.TryParse(txt_res.Text, out num11) == true)
                excelDataTemp.新风量 = num11;

            return excelDataTemp;

        }

        protected void ExportExcel(System.Data.DataTable dt, string fileName)
        {
            try
            {
                if (dt == null || dt.Rows.Count == 0) return;
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    return;
                }
                System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
                Microsoft.Office.Interop.Excel.Range range;
                long totalCount = dt.Rows.Count;
                long rowRead = 0;
                float percent = 0;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
                    range.Interior.ColorIndex = 15; range.Font.Bold = true;
                }
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
                    }
                    rowRead++; percent = ((float)(100 * rowRead)) / totalCount;
                }

                workbook.SaveAs(fileName);
                xlApp.Visible = false;

                xlApp.Workbooks.Close();
                xlApp.Quit();
                GC.Collect();
                MessageBox.Show("导出成功");
            }
            catch (Exception ex) {
                MessageBox.Show("导出异常");
            }
        }
        private DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }
        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
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
public class ExcelDataTemp
{
    public string 布局方式 { get; set; }

    public int 检测点数 { get; set; }

    public int 检测间隔 { get; set; }

    public DateTime 开始时间 { get; set; }

    public DateTime 结束时间 { get; set; }

    public double 测点1 { get; set; }

    public double 测点2 { get; set; }

    public double 测点3{ get; set; }

    public double 测点4{ get; set; }

    public double 测点5{ get; set; }

    public double 空气交换率 { get; set; }

    public double 室内空气容积 { get; set; }
    public double 新风量 { get; set; }
}
