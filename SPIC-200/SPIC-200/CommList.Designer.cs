namespace SPIC_200
{
    partial class CommList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommList));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbb_com = new System.Windows.Forms.ComboBox();
            this.txt_btl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbb_count = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.list_IP = new System.Windows.Forms.ListView();
            this.cms_delete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_add = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cms_delete.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbb_com);
            this.groupBox1.Controls.Add(this.txt_btl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(287, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "照度计通讯设置";
            // 
            // cbb_com
            // 
            this.cbb_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_com.FormattingEnabled = true;
            this.cbb_com.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbb_com.Location = new System.Drawing.Point(58, 23);
            this.cbb_com.Name = "cbb_com";
            this.cbb_com.Size = new System.Drawing.Size(121, 20);
            this.cbb_com.TabIndex = 5;
            // 
            // txt_btl
            // 
            this.txt_btl.Enabled = false;
            this.txt_btl.Location = new System.Drawing.Point(58, 77);
            this.txt_btl.Name = "txt_btl";
            this.txt_btl.Size = new System.Drawing.Size(121, 21);
            this.txt_btl.TabIndex = 3;
            this.txt_btl.Text = "9600";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM：";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(315, 190);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(134, 38);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbb_count);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_ip);
            this.groupBox2.Controls.Add(this.list_IP);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 218);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "光谱仪通讯设置";
            // 
            // cbb_count
            // 
            this.cbb_count.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_count.FormattingEnabled = true;
            this.cbb_count.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbb_count.Location = new System.Drawing.Point(61, 23);
            this.cbb_count.Name = "cbb_count";
            this.cbb_count.Size = new System.Drawing.Size(170, 20);
            this.cbb_count.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "设备数：";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(61, 186);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(96, 21);
            this.txt_ip.TabIndex = 4;
            // 
            // list_IP
            // 
            this.list_IP.ContextMenuStrip = this.cms_delete;
            this.list_IP.Location = new System.Drawing.Point(61, 66);
            this.list_IP.Name = "list_IP";
            this.list_IP.Size = new System.Drawing.Size(170, 107);
            this.list_IP.TabIndex = 11;
            this.list_IP.UseCompatibleStateImageBehavior = false;
            this.list_IP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.list_IP_MouseDown);
            // 
            // cms_delete
            // 
            this.cms_delete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cms_delete.Name = "cms_delete";
            this.cms_delete.Size = new System.Drawing.Size(101, 26);
            this.cms_delete.Text = "删除";
            this.cms_delete.Click += new System.EventHandler(this.cms_delete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem1.Text = "删除";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(171, 186);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(60, 23);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "添加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "IP列表：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "IP：";
            // 
            // CommList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 261);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通讯设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.cms_delete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_btl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView list_IP;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbb_com;
        private System.Windows.Forms.ComboBox cbb_count;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip cms_delete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}