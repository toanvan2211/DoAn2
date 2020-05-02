namespace DanhGiaDoanVien
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelNotified = new System.Windows.Forms.Label();
            this.checkBoxRemember = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelControlLogin = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelBlockLogin = new System.Windows.Forms.Label();
            this.lbWelcome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelControlLogin.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(84, 3);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(242, 179);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 2;
            this.pictureBoxLogo.TabStop = false;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserName.Location = new System.Drawing.Point(94, 9);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(268, 23);
            this.textBoxUserName.TabIndex = 1;
            this.textBoxUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUserName_KeyPress);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(94, 50);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(268, 23);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tài khoản:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mật khẩu:";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(25, 171);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(352, 49);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Đăng nhập";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelNotified
            // 
            this.labelNotified.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNotified.AutoSize = true;
            this.labelNotified.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotified.ForeColor = System.Drawing.Color.Yellow;
            this.labelNotified.Location = new System.Drawing.Point(29, 120);
            this.labelNotified.Name = "labelNotified";
            this.labelNotified.Size = new System.Drawing.Size(74, 16);
            this.labelNotified.TabIndex = 4;
            this.labelNotified.Text = "Thông báo";
            // 
            // checkBoxRemember
            // 
            this.checkBoxRemember.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxRemember.AutoSize = true;
            this.checkBoxRemember.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRemember.ForeColor = System.Drawing.Color.White;
            this.checkBoxRemember.Location = new System.Drawing.Point(131, 143);
            this.checkBoxRemember.Name = "checkBoxRemember";
            this.checkBoxRemember.Size = new System.Drawing.Size(128, 22);
            this.checkBoxRemember.TabIndex = 3;
            this.checkBoxRemember.Text = "Nhớ mật khẩu?";
            this.checkBoxRemember.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.93151F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0685F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxUserName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPassword, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 82);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panelControlLogin);
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.pictureBoxLogo);
            this.panel2.Controls.Add(this.lbWelcome);
            this.panel2.Location = new System.Drawing.Point(475, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 554);
            this.panel2.TabIndex = 9;
            // 
            // panelControlLogin
            // 
            this.panelControlLogin.Controls.Add(this.tableLayoutPanel1);
            this.panelControlLogin.Controls.Add(this.labelNotified);
            this.panelControlLogin.Controls.Add(this.buttonLogin);
            this.panelControlLogin.Controls.Add(this.checkBoxRemember);
            this.panelControlLogin.Location = new System.Drawing.Point(3, 247);
            this.panelControlLogin.Name = "panelControlLogin";
            this.panelControlLogin.Size = new System.Drawing.Size(394, 252);
            this.panelControlLogin.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labelBlockLogin, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(21, 276);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(359, 262);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // labelBlockLogin
            // 
            this.labelBlockLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelBlockLogin.AutoSize = true;
            this.labelBlockLogin.BackColor = System.Drawing.Color.Transparent;
            this.labelBlockLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBlockLogin.ForeColor = System.Drawing.Color.Orange;
            this.labelBlockLogin.Location = new System.Drawing.Point(85, 0);
            this.labelBlockLogin.Name = "labelBlockLogin";
            this.labelBlockLogin.Size = new System.Drawing.Size(188, 29);
            this.labelBlockLogin.TabIndex = 4;
            this.labelBlockLogin.Text = "Khóa đăng nhập";
            // 
            // lbWelcome
            // 
            this.lbWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lbWelcome.Font = new System.Drawing.Font("UTM Aircona", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.ForeColor = System.Drawing.Color.Cyan;
            this.lbWelcome.Location = new System.Drawing.Point(93, 200);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(216, 44);
            this.lbWelcome.TabIndex = 4;
            this.lbWelcome.Text = "WELCOME";
            // 
            // FormLogin
            // 
            this.AcceptButton = this.buttonLogin;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(41)))), ((int)(((byte)(45)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(875, 595);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(891, 634);
            this.MinimumSize = new System.Drawing.Size(891, 634);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelControlLogin.ResumeLayout(false);
            this.panelControlLogin.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelNotified;
        private System.Windows.Forms.CheckBox checkBoxRemember;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Panel panelControlLogin;
        private System.Windows.Forms.Label labelBlockLogin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}