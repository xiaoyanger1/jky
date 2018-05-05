using text.doors.Common;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Young.Core.SQLite;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace text.doors
{
    public partial class Login : Form
    {
        public static Young.Core.Logger.ILog Logger = Young.Core.Logger.LoggerManager.Current();
        public Login()
        {
            InitializeComponent();

            //Document doc = new Document("C: \\Users\\z_young\\Desktop\\试验室记录_20180503.doc");
            //Section sec = doc.AddSection();
            //Paragraph para1 = sec.AddParagraph();
            //ShapeObject shape1 = para1.AppendShape(230, 200, ShapeType.Line);
            //shape1.FillColor = Color.Black;
            //shape1.StrokeColor = Color.Black;
            //shape1.HorizontalPosition = 250;
            //shape1.VerticalPosition = 370;

            //ShapeObject shape2 = para1.AppendShape(100, 100, ShapeType.Arrow);
            //shape2.FillColor = Color.Purple;
            //shape2.StrokeColor = Color.Black;
            //shape2.LineStyle = ShapeLineStyle.Double;
            //shape2.StrokeWeight = 3;
            //shape2.HorizontalPosition = 200;
            //shape2.VerticalPosition = 200;


            //Paragraph para2 = sec.AddParagraph();
            //ShapeGroup shapegr = para2.AppendShapeGroup(200, 400);
            //shapegr.ChildObjects.Add(new ShapeObject(doc, ShapeType.Rectangle)
            //{
            //    Width = 500,
            //    Height = 300,
            //    LineStyle = ShapeLineStyle.ThickThin,
            //    StrokeColor = System.Drawing.Color.Blue,
            //    StrokeWeight = 1.5,
            //});
            //shapegr.ChildObjects.Add(new ShapeObject(doc, ShapeType.RightTriangle)
            //{
            //    Width = 500,
            //    Height = 300,
            //    VerticalPosition = 301,
            //    LineStyle = ShapeLineStyle.ThickThin,
            //    StrokeColor = System.Drawing.Color.Green,
            //    StrokeWeight = 1.5,
            //});
            //shapegr.ChildObjects.Add(new ShapeObject(doc, ShapeType.QuadArrow)
            //{
            //    Width = 500,
            //    Height = 300,
            //    VerticalPosition = 601,
            //    LineStyle = ShapeLineStyle.ThickThin,
            //    StrokeColor = System.Drawing.Color.Blue,
            //    StrokeWeight = 1.5,
            //});
            // doc.SaveToFile("C: \\Users\\z_young\\Desktop\\试验室记录_20180503.doc", FileFormat.Docx2010);
            Init();
        }

        private string administrator = "administrator";
        private void Init()
        {
            //WindowsIdentity identity = WindowsIdentity.GetCurrent();
            //WindowsPrincipal principal = new WindowsPrincipal(identity);
            //if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            //{
            txt_userID.Text = administrator;
            this.txt_passWord.Focus();
            //}
            //else
            //{
            //    lbl_LoginType.Text = "请使用管理员身份登录！";
            //    btn_login.Enabled = false;
            //}
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_passWord.Text == "")
            {
                lbl_LoginType.Text = "密码不能为空";
                return;
            }

            string sql = "select * from  User where User_Name='" + administrator + "'";
            DataTable dt = SQLiteHelper.ExecuteDataRow(sql).Table;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("账户出现问题，请联系管理员", "账户", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                Logger.Error("登录:未发现" + administrator + "账户");
                return;
            }


            if (!string.IsNullOrWhiteSpace(dt.Rows[0]["User_PassWord"].ToString()))
            {
                if (txt_passWord.Text == dt.Rows[0]["User_PassWord"].ToString())
                {
                    this.DialogResult = DialogResult.OK;//关键:设置登陆成功状态  
                    this.Close();
                }
                else
                {
                    lbl_LoginType.Text = "密码输入错误！";
                    return;
                }
            }
        }
    }
}
