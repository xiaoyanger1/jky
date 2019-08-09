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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fbd_browse
            // 
            this.fbd_browse.SelectedPath = "C:\\Users\\Yang.Zhang\\Desktop";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(97, 24);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 0;
            this.btn_browse.Text = "浏览";
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据来源：";
            // 
            // dtp_start
            // 
            this.dtp_start.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtp_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_start.Location = new System.Drawing.Point(97, 61);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(134, 21);
            this.dtp_start.TabIndex = 2;
            // 
            // dtp_end
            // 
            this.dtp_end.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_end.Location = new System.Drawing.Point(275, 61);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(143, 21);
            this.dtp_end.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "时间选取：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 67);
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
            this.label5.Location = new System.Drawing.Point(147, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "测点2（A）：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 30);
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
            this.label8.Location = new System.Drawing.Point(147, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "测点5（A）：";
            // 
            // btn_calculate
            // 
            this.btn_calculate.Location = new System.Drawing.Point(436, 59);
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
            this.label9.Location = new System.Drawing.Point(270, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "平 均 值A：";
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
            this.lbl_measurepoint3.Location = new System.Drawing.Point(344, 30);
            this.lbl_measurepoint3.Name = "lbl_measurepoint3";
            this.lbl_measurepoint3.Size = new System.Drawing.Size(11, 12);
            this.lbl_measurepoint3.TabIndex = 15;
            this.lbl_measurepoint3.Text = "0";
            // 
            // lbl_measurepoint2
            // 
            this.lbl_measurepoint2.AutoSize = true;
            this.lbl_measurepoint2.Location = new System.Drawing.Point(226, 30);
            this.lbl_measurepoint2.Name = "lbl_measurepoint2";
            this.lbl_measurepoint2.Size = new System.Drawing.Size(11, 12);
            this.lbl_measurepoint2.TabIndex = 16;
            this.lbl_measurepoint2.Text = "0";
            // 
            // lbl_measurepoint5
            // 
            this.lbl_measurepoint5.AutoSize = true;
            this.lbl_measurepoint5.Location = new System.Drawing.Point(226, 61);
            this.lbl_measurepoint5.Name = "lbl_measurepoint5";
            this.lbl_measurepoint5.Size = new System.Drawing.Size(11, 12);
            this.lbl_measurepoint5.TabIndex = 17;
            this.lbl_measurepoint5.Text = "0";
            // 
            // lbl_measurepoint6
            // 
            this.lbl_measurepoint6.AutoSize = true;
            this.lbl_measurepoint6.Location = new System.Drawing.Point(343, 61);
            this.lbl_measurepoint6.Name = "lbl_measurepoint6";
            this.lbl_measurepoint6.Size = new System.Drawing.Size(11, 12);
            this.lbl_measurepoint6.TabIndex = 18;
            this.lbl_measurepoint6.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "室内空气容积（m3）：";
            // 
            // txt_v
            // 
            this.txt_v.Location = new System.Drawing.Point(143, 271);
            this.txt_v.Name = "txt_v";
            this.txt_v.Size = new System.Drawing.Size(70, 21);
            this.txt_v.TabIndex = 20;
            this.txt_v.TextChanged += new System.EventHandler(this.txt_v_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(219, 274);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "Q=";
            // 
            // txt_res
            // 
            this.txt_res.Location = new System.Drawing.Point(242, 271);
            this.txt_res.Name = "txt_res";
            this.txt_res.Size = new System.Drawing.Size(104, 21);
            this.txt_res.TabIndex = 22;
            // 
            // lbl_load
            // 
            this.lbl_load.AutoSize = true;
            this.lbl_load.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_load.ForeColor = System.Drawing.Color.Red;
            this.lbl_load.Location = new System.Drawing.Point(263, 23);
            this.lbl_load.Name = "lbl_load";
            this.lbl_load.Size = new System.Drawing.Size(95, 18);
            this.lbl_load.TabIndex = 23;
            this.lbl_load.Text = "读取中...";
            this.lbl_load.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(61, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "C0：";
            // 
            // dtpc0
            // 
            this.dtpc0.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpc0.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpc0.Location = new System.Drawing.Point(97, 99);
            this.dtpc0.Name = "dtpc0";
            this.dtpc0.Size = new System.Drawing.Size(134, 21);
            this.dtpc0.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbl_measurepoint1);
            this.groupBox1.Controls.Add(this.lbl_measurepoint4);
            this.groupBox1.Controls.Add(this.lbl_measurepoint6);
            this.groupBox1.Controls.Add(this.lbl_measurepoint3);
            this.groupBox1.Controls.Add(this.lbl_measurepoint5);
            this.groupBox1.Controls.Add(this.lbl_measurepoint2);
            this.groupBox1.Location = new System.Drawing.Point(28, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 93);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测点";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(436, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 100);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "公式";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VentilationCalculate.Properties.Resources.QQ图片20190809171736;
            this.pictureBox1.Location = new System.Drawing.Point(16, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 53);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Calculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 345);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpc0);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbl_load);
            this.Controls.Add(this.txt_res);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_v);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_calculate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_end);
            this.Controls.Add(this.dtp_start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_browse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Calculate";
            this.Text = "换气次数计算";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}