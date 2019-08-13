namespace VentilationCalculate
{
    partial class Calculate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculate));
            this.fbd_browse = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_browse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_calculate = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_measurepoint1 = new System.Windows.Forms.Label();
            this.lbl_measurepoint4 = new System.Windows.Forms.Label();
            this.lbl_measurepoint3 = new System.Windows.Forms.Label();
            this.lbl_measurepoint2 = new System.Windows.Forms.Label();
            this.lbl_measurepoint5 = new System.Windows.Forms.Label();
            this.lbl_measurepoint6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_v = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_res = new System.Windows.Forms.TextBox();
            this.lbl_load = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpc0 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dud_jcds = new System.Windows.Forms.DomainUpDown();
            this.dud_jcjg = new System.Windows.Forms.DomainUpDown();
            this.cbb_bjfs = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_export = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // fbd_browse
            // 
            this.fbd_browse.SelectedPath = "C:\\Users\\Yang.Zhang\\Desktop";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(100, 20);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 0;
            this.btn_browse.Text = "浏览";
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据来源：";
            // 
            // dtp_start
            // 
            this.dtp_start.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtp_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_start.Location = new System.Drawing.Point(100, 94);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(134, 21);
            this.dtp_start.TabIndex = 2;
            // 
            // dtp_end
            // 
            this.dtp_end.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_end.Location = new System.Drawing.Point(278, 94);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(143, 21);
            this.dtp_end.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "时间选取：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "至";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "测点1（A）：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "测点2（A）：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(455, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "测点3（A）：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "测点4（A）：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(241, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "测点5（A）：";
            // 
            // btn_calculate
            // 
            this.btn_calculate.Location = new System.Drawing.Point(439, 92);
            this.btn_calculate.Name = "btn_calculate";
            this.btn_calculate.Size = new System.Drawing.Size(75, 23);
            this.btn_calculate.TabIndex = 11;
            this.btn_calculate.Text = "计算";
            this.btn_calculate.UseVisualStyleBackColor = true;
            this.btn_calculate.Click += new System.EventHandler(this.btn_calculate_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(431, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "空气交换率 (A)：";
            // 
            // lbl_measurepoint1
            // 
            this.lbl_measurepoint1.AutoSize = true;
            this.lbl_measurepoint1.Location = new System.Drawing.Point(98, 30);
            this.lbl_measurepoint1.Name = "lbl_measurepoint1";
            this.lbl_measurepoint1.Size = new System.Drawing.Size(11, 12);
            this.lbl_measurepoint1.TabIndex = 13;
            this.lbl_measurepoint1.Text = "0";
            // 
            // lbl_measurepoint4
            // 
            this.lbl_measurepoint4.AutoSize = true;
            this.lbl_measurepoint4.Location = new System.Drawing.Point(98, 61);
            this.lbl_measurepoint4.Name = "lbl_measurepoint4";
            this.lbl_measurepoint4.Size = new System.Drawing.Size(11, 12);
            this.lbl_measurepoint4.TabIndex = 14;
            this.lbl_measurepoint4.Text = "0";
            // 
            // lbl_measurepoint3
            // 
            this.lbl_measurepoint3.AutoSize = true;
            this.lbl_measurepoint3.Location = new System.Drawing.Point(535, 30);
            this.lbl_measurepoint3.Name = "lbl_measurepoint3";
            this.lbl_measurepoint3.Size = new System.Drawing.Size(11, 12);
            this.lbl_measurepoint3.TabIndex = 15;
            this.lbl_measurepoint3.Text = "0";
            // 
            // lbl_measurepoint2
            // 
            this.lbl_measurepoint2.AutoSize = true;
            this.lbl_measurepoint2.Location = new System.Drawing.Point(320, 30);
            this.lbl_measurepoint2.Name = "lbl_measurepoint2";
            this.lbl_measurepoint2.Size = new System.Drawing.Size(11, 12);
            this.lbl_measurepoint2.TabIndex = 16;
            this.lbl_measurepoint2.Text = "0";
            // 
            // lbl_measurepoint5
            // 
            this.lbl_measurepoint5.AutoSize = true;
            this.lbl_measurepoint5.Location = new System.Drawing.Point(320, 61);
            this.lbl_measurepoint5.Name = "lbl_measurepoint5";
            this.lbl_measurepoint5.Size = new System.Drawing.Size(11, 12);
            this.lbl_measurepoint5.TabIndex = 17;
            this.lbl_measurepoint5.Text = "0";
            // 
            // lbl_measurepoint6
            // 
            this.lbl_measurepoint6.AutoSize = true;
            this.lbl_measurepoint6.Location = new System.Drawing.Point(535, 61);
            this.lbl_measurepoint6.Name = "lbl_measurepoint6";
            this.lbl_measurepoint6.Size = new System.Drawing.Size(11, 12);
            this.lbl_measurepoint6.TabIndex = 18;
            this.lbl_measurepoint6.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "室内空气容积 V：";
            // 
            // txt_v
            // 
            this.txt_v.Location = new System.Drawing.Point(126, 99);
            this.txt_v.Name = "txt_v";
            this.txt_v.Size = new System.Drawing.Size(70, 21);
            this.txt_v.TabIndex = 20;
            this.txt_v.TextChanged += new System.EventHandler(this.txt_v_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "新风量 Q=";
            // 
            // txt_res
            // 
            this.txt_res.Location = new System.Drawing.Point(314, 99);
            this.txt_res.Name = "txt_res";
            this.txt_res.Size = new System.Drawing.Size(62, 21);
            this.txt_res.TabIndex = 22;
            // 
            // lbl_load
            // 
            this.lbl_load.AutoSize = true;
            this.lbl_load.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_load.ForeColor = System.Drawing.Color.Red;
            this.lbl_load.Location = new System.Drawing.Point(266, 19);
            this.lbl_load.Name = "lbl_load";
            this.lbl_load.Size = new System.Drawing.Size(95, 18);
            this.lbl_load.TabIndex = 23;
            this.lbl_load.Text = "读取中...";
            this.lbl_load.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "本底浓度：";
            // 
            // dtpc0
            // 
            this.dtpc0.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpc0.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpc0.Location = new System.Drawing.Point(100, 61);
            this.dtpc0.Name = "dtpc0";
            this.dtpc0.Size = new System.Drawing.Size(134, 21);
            this.dtpc0.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_res);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lbl_measurepoint1);
            this.groupBox1.Controls.Add(this.txt_v);
            this.groupBox1.Controls.Add(this.lbl_measurepoint4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbl_measurepoint6);
            this.groupBox1.Controls.Add(this.lbl_measurepoint3);
            this.groupBox1.Controls.Add(this.lbl_measurepoint5);
            this.groupBox1.Controls.Add(this.lbl_measurepoint2);
            this.groupBox1.Location = new System.Drawing.Point(29, 221);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(675, 134);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测点计算";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(578, 30);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(35, 12);
            this.label25.TabIndex = 36;
            this.label25.Text = "(h-1)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(361, 61);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 12);
            this.label24.TabIndex = 35;
            this.label24.Text = "(h-1)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(361, 30);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 12);
            this.label23.TabIndex = 34;
            this.label23.Text = "(h-1)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(140, 61);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 12);
            this.label20.TabIndex = 33;
            this.label20.Text = "(h-1)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(140, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 12);
            this.label19.TabIndex = 32;
            this.label19.Text = "(h-1)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(578, 61);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 12);
            this.label18.TabIndex = 31;
            this.label18.Text = "(h-1)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(396, 102);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 29;
            this.label14.Text = "m3/h";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(202, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 28;
            this.label13.Text = "m3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Location = new System.Drawing.Point(29, 361);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 141);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "计算公式";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(20, 64);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(191, 12);
            this.label31.TabIndex = 26;
            this.label31.Text = "A=[ln（C1- C0）-ln（Ct- C0）]/t";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.dud_jcds);
            this.groupBox3.Controls.Add(this.dud_jcjg);
            this.groupBox3.Controls.Add(this.cbb_bjfs);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(29, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(675, 60);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "检测设定";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(601, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 54;
            this.label15.Text = "分钟";
            // 
            // dud_jcds
            // 
            this.dud_jcds.Items.Add("1");
            this.dud_jcds.Items.Add("2");
            this.dud_jcds.Items.Add("3");
            this.dud_jcds.Items.Add("4");
            this.dud_jcds.Items.Add("5");
            this.dud_jcds.Location = new System.Drawing.Point(326, 20);
            this.dud_jcds.Name = "dud_jcds";
            this.dud_jcds.Size = new System.Drawing.Size(83, 21);
            this.dud_jcds.TabIndex = 53;
            this.dud_jcds.Text = "1";
            // 
            // dud_jcjg
            // 
            this.dud_jcjg.Items.Add("1");
            this.dud_jcjg.Items.Add("2");
            this.dud_jcjg.Items.Add("3");
            this.dud_jcjg.Items.Add("4");
            this.dud_jcjg.Items.Add("5");
            this.dud_jcjg.Items.Add("6");
            this.dud_jcjg.Items.Add("7");
            this.dud_jcjg.Items.Add("8");
            this.dud_jcjg.Items.Add("9");
            this.dud_jcjg.Items.Add("10");
            this.dud_jcjg.Location = new System.Drawing.Point(512, 18);
            this.dud_jcjg.Name = "dud_jcjg";
            this.dud_jcjg.Size = new System.Drawing.Size(81, 21);
            this.dud_jcjg.TabIndex = 52;
            this.dud_jcjg.Text = "1";
            // 
            // cbb_bjfs
            // 
            this.cbb_bjfs.FormattingEnabled = true;
            this.cbb_bjfs.Items.AddRange(new object[] {
            "对角线",
            "梅花状"});
            this.cbb_bjfs.Location = new System.Drawing.Point(95, 19);
            this.cbb_bjfs.Name = "cbb_bjfs";
            this.cbb_bjfs.Size = new System.Drawing.Size(124, 20);
            this.cbb_bjfs.TabIndex = 49;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(257, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 41;
            this.label21.Text = "检测点数：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 35;
            this.label17.Text = "布局方式：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(441, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 33;
            this.label16.Text = "检测间隔：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_export);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btn_browse);
            this.groupBox4.Controls.Add(this.dtp_start);
            this.groupBox4.Controls.Add(this.dtp_end);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.dtpc0);
            this.groupBox4.Controls.Add(this.btn_calculate);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.lbl_load);
            this.groupBox4.Location = new System.Drawing.Point(29, 79);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(675, 136);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "采集";
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(530, 92);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 23);
            this.btn_export.TabIndex = 37;
            this.btn_export.Text = "导出";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(23, 27);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(239, 12);
            this.label26.TabIndex = 22;
            this.label26.Text = " A――换气次数，即平均空气交换率（h-1）";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(23, 48);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(227, 12);
            this.label27.TabIndex = 23;
            this.label27.Text = "C0――示踪气体的环境本底浓度（mg/m3）";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(23, 71);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(227, 12);
            this.label28.TabIndex = 24;
            this.label28.Text = "C1――测量开始时示踪气体浓度（mg/m3）";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(23, 94);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(221, 12);
            this.label29.TabIndex = 25;
            this.label29.Text = "Ct――时间为t时示踪气体浓度（mg/m3）";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Location = new System.Drawing.Point(282, 361);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(422, 141);
            this.groupBox5.TabIndex = 32;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "式中";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(23, 116);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(119, 12);
            this.label30.TabIndex = 26;
            this.label30.Text = " t――测定时间（h）";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(448, 513);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(148, 12);
            this.label32.TabIndex = 33;
            this.label32.Text = "北京建科源科技有限公司";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(10, 513);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(353, 12);
            this.label33.TabIndex = 34;
            this.label33.Text = "检测依据: GB/T 18204.18-2000《公共场所室内新风量测定方法》";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(10, 536);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(365, 12);
            this.label35.TabIndex = 36;
            this.label35.Text = "计算方法：平均法计算平均空气交换率     示踪气体：二氧化碳   ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(448, 536);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(251, 12);
            this.label22.TabIndex = 37;
            this.label22.Text = "JKY Smart Meter | Copyright © 2019 ";
            // 
            // Calculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 564);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Calculate";
            this.Text = "换气次数测试系统  JKY-EMCSO-P021";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbd_browse;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_calculate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_measurepoint1;
        private System.Windows.Forms.Label lbl_measurepoint4;
        private System.Windows.Forms.Label lbl_measurepoint3;
        private System.Windows.Forms.Label lbl_measurepoint2;
        private System.Windows.Forms.Label lbl_measurepoint5;
        private System.Windows.Forms.Label lbl_measurepoint6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_v;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_res;
        private System.Windows.Forms.Label lbl_load;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpc0;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbb_bjfs;
        private System.Windows.Forms.DomainUpDown dud_jcjg;
        private System.Windows.Forms.DomainUpDown dud_jcds;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label22;
    }
}