using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JKY.Calculate
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_4411_Click(object sender, EventArgs e)
        {
            var _pw = pw.Text;
            var _cpw = cpw.Text;
            var _vs = vs.Text;
            var _te = te.Text;
            var _tb = tb.Text;
            var _ac = ac.Text;
            var divisor = Math.Pow(10, 6) * double.Parse(_ac);

            if (divisor == 0)
            {
                MessageBox.Show("请将ac设置大于0"); return;
            }
            else
            {
                var _q = (double.Parse(_pw) * double.Parse(_cpw) * double.Parse(_vs) * (double.Parse(_te) - double.Parse(_tb))) / divisor;
                lbl_q.Text = Math.Round(_q, 2).ToString();
            }
        }

        private void btn_4412_Click(object sender, EventArgs e)
        {
            if (H.Text == "" || double.Parse(H.Text) == 0)
            {
                MessageBox.Show("请将H设置大于0"); return;
            }
            var _q17 = 17 * (double.Parse(lbl_q.Text) / double.Parse(H.Text));
            lbl_q17.Text = Math.Round(_q17, 2).ToString();
        }

        private void btn_442_Click(object sender, EventArgs e)
        {
            var _pw = pw.Text;
            var _cpw = cpw.Text;
            var _msfh = msfh.Text;
            var _ti = ti.Text;
            var _tf = tf.Text;
            var _tas = tas.Text;

            if (msfh.Text == "" || double.Parse(msfh.Text) == 0)
            {
                MessageBox.Show("请将△ζ设置大于0"); return;
            }

            var before = double.Parse(_pw) * double.Parse(_cpw) / double.Parse(_msfh);
            var laterUp = double.Parse(_ti) - double.Parse(_tas);
            var laterDown = double.Parse(_tf) - double.Parse(_tas);

            if (laterDown <= 0)
            {
                MessageBox.Show("请将tf-tas(av)设置大于0"); return;
            }
            var later = laterUp / laterDown;
            var _usl = Math.Round(before * Math.Log(later), 2);
            lblusl.Text = _usl.ToString();
        }

        private void btn_4432_Click(object sender, EventArgs e)
        {
            var _tr = tr.Text;
            var _tp = tp.Text;
            var _ts = ts.Text;
            var _tas = tas.Text;

            var divisor = (double.Parse(_tr) - double.Parse(_tp)) * double.Parse(_ts);

            var divisor1 = (double.Parse(_tr) + double.Parse(_tp)) / 2 - double.Parse(_tas);

            if (divisor1 <= 0)
            {
                MessageBox.Show("请将(tr+tp)/2 - tas(av)设置大于0"); return;
            }
            var _tsd = Math.Round(divisor / divisor1, 2);
            lbl_tsd.Text = _tsd.ToString();
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



        public string InputCheck(string val)
        {
            if (val.Trim() != "")
            {
                // if (!Validate(val.Trim(), @"^(-?\d+)(\.\d+)?$"))
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

        private void pw_TextChanged(object sender, EventArgs e)
        {
            pw.Text = InputCheck(pw.Text.TrimEnd());
        }

        private void ac_TextChanged(object sender, EventArgs e)
        {
            ac.Text = InputCheck(ac.Text.TrimEnd());
        }

        private void te_TextChanged(object sender, EventArgs e)
        {
            te.Text = InputCheck(te.Text.TrimEnd());
        }

        private void cpw_TextChanged(object sender, EventArgs e)
        {
            cpw.Text = InputCheck(cpw.Text.TrimEnd());
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            tb.Text = InputCheck(tb.Text.TrimEnd());
        }

        private void vs_TextChanged(object sender, EventArgs e)
        {
            vs.Text = InputCheck(vs.Text.TrimEnd());
        }

        private void tr_TextChanged(object sender, EventArgs e)
        {
            tr.Text = InputCheck(tr.Text.TrimEnd());
        }

        private void tp_TextChanged(object sender, EventArgs e)
        {
            tp.Text = InputCheck(tp.Text.TrimEnd());
        }

        private void ts_TextChanged(object sender, EventArgs e)
        {
            ts.Text = InputCheck(ts.Text.TrimEnd());
        }

        private void H_TextChanged(object sender, EventArgs e)
        {
            H.Text = InputCheck(H.Text.TrimEnd());
        }

        private void tas_TextChanged(object sender, EventArgs e)
        {
            tas.Text = InputCheck(tas.Text.TrimEnd());
        }

        private void msfh_TextChanged(object sender, EventArgs e)
        {
            msfh.Text = InputCheck(msfh.Text.TrimEnd());
        }

        private void ti_TextChanged(object sender, EventArgs e)
        {
            ti.Text = InputCheck(ti.Text.TrimEnd());
        }

        private void tf_TextChanged(object sender, EventArgs e)
        {
            tr.Text = InputCheck(tr.Text.TrimEnd());
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();

            if (path.SelectedPath == "" && path.SelectedPath == null)
                return;

            string _name = "计算_" + DateTime.Now.ToString("yyyy-MM-dd") + ".png";
            var saveExcelUrl = path.SelectedPath + "\\" + _name;
            Bitmap bit = new Bitmap(this.Width, this.Height);//实例化一个和窗体一样大的bitmap
            Graphics g = Graphics.FromImage(bit);
            g.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高
            g.CopyFromScreen(this.Left, this.Top, 0, 0, new Size(this.Width, this.Height));//保存整个窗体为图片

            bit.Save(saveExcelUrl);//默认保存格式为PNG，保存成jpg格式质量不是很好
            MessageBox.Show("导出成功-路径" + saveExcelUrl);

            //var fileName = "计算模板.docx";
            //string strResult = string.Empty;
            //string strPath = System.Windows.Forms.Application.StartupPath + "\\template";
            //string strFile = string.Format(@"{0}\{1}", strPath, fileName);

            //FolderBrowserDialog path = new FolderBrowserDialog();
            //path.ShowDialog();

            //if (path.SelectedPath == "" && path.SelectedPath == null)
            //    return;

            //string _name = "计算_" + DateTime.Now.ToString("yyyy-MM-dd") + ".docx";

            //var saveExcelUrl = path.SelectedPath + "\\" + _name;

            //var dc = new Dictionary<string, string>();
            //dc.Add("ac", ac.Text);
            //dc.Add("cpw", cpw.Text);
            //dc.Add("h", H.Text);
            //dc.Add("pw", pw.Text);
            //dc.Add("q", lbl_q.Text);
            //dc.Add("q17", lbl_q17.Text);
            //dc.Add("tasav", tas.Text);
            //dc.Add("tb", tb.Text);
            //dc.Add("te", te.Text);
            //dc.Add("tf", tf.Text);
            //dc.Add("ti", ti.Text);
            //dc.Add("tp", tp.Text);
            //dc.Add("tr", tr.Text);
            //dc.Add("usl", lblusl.Text);
            //dc.Add("vs", vs.Text);
            //dc.Add("△ts", ts.Text);
            //dc.Add("△tsd", lbl_tsd.Text);
            //dc.Add("△ζ", msfh.Text);
            //dc.Add("日期", DateTime.Now.ToString("yyyy-MM-dd"));
            //WordUtility wu = new WordUtility(strFile, saveExcelUrl);
            //if (wu.GenerateWordByBookmarks(dc))
            //{
            //    MessageBox.Show("导出成功");
            //}
        }
    }
}
