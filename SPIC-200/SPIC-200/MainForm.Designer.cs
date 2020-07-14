namespace SPIC_200
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ts_pic = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_RealTimeSurveillance = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_生成报告 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_DetectionSet = new System.Windows.Forms.ToolStripDropDownButton();
            this.传感器标定ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.系统校验ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.通讯设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.密码修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtn_about = new System.Windows.Forms.ToolStripButton();
            this.ssp_mnue = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_code = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_Init = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ts_pic.SuspendLayout();
            this.ssp_mnue.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts_pic
            // 
            this.ts_pic.AutoSize = false;
            this.ts_pic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.tsb_RealTimeSurveillance,
            this.toolStripSeparator2,
            this.tsb_生成报告,
            this.toolStripSeparator3,
            this.tsb_DetectionSet,
            this.tsbtn_about});
            this.ts_pic.Location = new System.Drawing.Point(0, 0);
            this.ts_pic.Name = "ts_pic";
            this.ts_pic.Size = new System.Drawing.Size(884, 36);
            this.ts_pic.TabIndex = 5;
            this.ts_pic.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(76, 33);
            this.toolStripButton1.Text = "检测设定";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // tsb_RealTimeSurveillance
            // 
            this.tsb_RealTimeSurveillance.Image = ((System.Drawing.Image)(resources.GetObject("tsb_RealTimeSurveillance.Image")));
            this.tsb_RealTimeSurveillance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_RealTimeSurveillance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_RealTimeSurveillance.Name = "tsb_RealTimeSurveillance";
            this.tsb_RealTimeSurveillance.Size = new System.Drawing.Size(100, 33);
            this.tsb_RealTimeSurveillance.Text = "Tr/Ra检测";
            this.tsb_RealTimeSurveillance.Click += new System.EventHandler(this.tsb_RealTimeSurveillance_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 36);
            // 
            // tsb_生成报告
            // 
            this.tsb_生成报告.Image = ((System.Drawing.Image)(resources.GetObject("tsb_生成报告.Image")));
            this.tsb_生成报告.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_生成报告.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_生成报告.Name = "tsb_生成报告";
            this.tsb_生成报告.Size = new System.Drawing.Size(92, 33);
            this.tsb_生成报告.Text = "生成报告";
            this.tsb_生成报告.Click += new System.EventHandler(this.tsb_生成报告_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 36);
            // 
            // tsb_DetectionSet
            // 
            this.tsb_DetectionSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.传感器标定ToolStripMenuItem1,
            this.系统校验ToolStripMenuItem1,
            this.toolStripSeparator4,
            this.通讯设置ToolStripMenuItem1,
            this.密码修改ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.tsb_DetectionSet.Image = ((System.Drawing.Image)(resources.GetObject("tsb_DetectionSet.Image")));
            this.tsb_DetectionSet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_DetectionSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_DetectionSet.Name = "tsb_DetectionSet";
            this.tsb_DetectionSet.Size = new System.Drawing.Size(101, 33);
            this.tsb_DetectionSet.Text = "系统设置";
            // 
            // 传感器标定ToolStripMenuItem1
            // 
            this.传感器标定ToolStripMenuItem1.Name = "传感器标定ToolStripMenuItem1";
            this.传感器标定ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.传感器标定ToolStripMenuItem1.Text = "传感器标定";
            // 
            // 系统校验ToolStripMenuItem1
            // 
            this.系统校验ToolStripMenuItem1.Name = "系统校验ToolStripMenuItem1";
            this.系统校验ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.系统校验ToolStripMenuItem1.Text = "系统校验";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(133, 6);
            // 
            // 通讯设置ToolStripMenuItem1
            // 
            this.通讯设置ToolStripMenuItem1.Name = "通讯设置ToolStripMenuItem1";
            this.通讯设置ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.通讯设置ToolStripMenuItem1.Text = "通讯设置";
            this.通讯设置ToolStripMenuItem1.Click += new System.EventHandler(this.通讯设置ToolStripMenuItem1_Click);
            // 
            // 密码修改ToolStripMenuItem
            // 
            this.密码修改ToolStripMenuItem.Name = "密码修改ToolStripMenuItem";
            this.密码修改ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.密码修改ToolStripMenuItem.Text = "密码修改";
            this.密码修改ToolStripMenuItem.Click += new System.EventHandler(this.密码修改ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // tsbtn_about
            // 
            this.tsbtn_about.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_about.Image")));
            this.tsbtn_about.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_about.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_about.Name = "tsbtn_about";
            this.tsbtn_about.Size = new System.Drawing.Size(92, 33);
            this.tsbtn_about.Text = "关于系统";
            this.tsbtn_about.Click += new System.EventHandler(this.tsbtn_about_Click);
            // 
            // ssp_mnue
            // 
            this.ssp_mnue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tssl_code,
            this.toolStripStatusLabel3,
            this.tss_Init});
            this.ssp_mnue.Location = new System.Drawing.Point(0, 539);
            this.ssp_mnue.Name = "ssp_mnue";
            this.ssp_mnue.Size = new System.Drawing.Size(884, 22);
            this.ssp_mnue.TabIndex = 6;
            this.ssp_mnue.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "检测编号：";
            // 
            // tssl_code
            // 
            this.tssl_code.Name = "tssl_code";
            this.tssl_code.Size = new System.Drawing.Size(44, 17);
            this.tssl_code.Text = "未设置";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(571, 17);
            this.toolStripStatusLabel3.Spring = true;
            // 
            // tss_Init
            // 
            this.tss_Init.ActiveLinkColor = System.Drawing.Color.Red;
            this.tss_Init.Name = "tss_Init";
            this.tss_Init.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.tss_Init.Size = new System.Drawing.Size(136, 17);
            this.tss_Init.Text = "设备初始化中..";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 10);
            this.panel1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ssp_mnue);
            this.Controls.Add(this.ts_pic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "建筑外窗采光性能分级检测系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ts_pic.ResumeLayout(false);
            this.ts_pic.PerformLayout();
            this.ssp_mnue.ResumeLayout(false);
            this.ssp_mnue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts_pic;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_RealTimeSurveillance;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsb_生成报告;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtn_about;
        private System.Windows.Forms.StatusStrip ssp_mnue;
        private System.Windows.Forms.ToolStripDropDownButton tsb_DetectionSet;
        private System.Windows.Forms.ToolStripMenuItem 传感器标定ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 系统校验ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 通讯设置ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 密码修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_code;
        private System.Windows.Forms.ToolStripStatusLabel tss_Init;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}