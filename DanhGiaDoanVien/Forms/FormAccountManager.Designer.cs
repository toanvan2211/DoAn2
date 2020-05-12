namespace DanhGiaDoanVien.Forms
{
    partial class FormAccountManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccountManager));
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExitEdit = new System.Windows.Forms.Button();
            this.dragControl1 = new QuanLiDienThoai.DragControl();
            this.dragControl2 = new QuanLiDienThoai.DragControl();
            this.panelTool = new System.Windows.Forms.Panel();
            this.checkBoxEditPassword = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.comboBoxIdTeacher = new System.Windows.Forms.ComboBox();
            this.comboBoxPermission = new System.Windows.Forms.ComboBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panelAccountData = new System.Windows.Forms.Panel();
            this.dataGridViewAccount = new System.Windows.Forms.DataGridView();
            this.UserName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTeacher1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Permission1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelTool.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelAdmin.SuspendLayout();
            this.panelAccountData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(99)))), ((int)(((byte)(84)))));
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.buttonExitEdit);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(825, 33);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Quản lí tài khoản";
            // 
            // buttonExitEdit
            // 
            this.buttonExitEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonExitEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitEdit.ForeColor = System.Drawing.Color.White;
            this.buttonExitEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExitEdit.Image")));
            this.buttonExitEdit.Location = new System.Drawing.Point(791, 0);
            this.buttonExitEdit.Name = "buttonExitEdit";
            this.buttonExitEdit.Size = new System.Drawing.Size(34, 33);
            this.buttonExitEdit.TabIndex = 10;
            this.buttonExitEdit.Tag = "exitEdit";
            this.buttonExitEdit.UseVisualStyleBackColor = true;
            this.buttonExitEdit.Click += new System.EventHandler(this.buttonExitEdit_Click);
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelTop;
            // 
            // dragControl2
            // 
            this.dragControl2.SelectControl = this.label1;
            // 
            // panelTool
            // 
            this.panelTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(73)))), ((int)(((byte)(62)))));
            this.panelTool.Controls.Add(this.checkBoxEditPassword);
            this.panelTool.Controls.Add(this.tableLayoutPanel1);
            this.panelTool.Controls.Add(this.panelAdmin);
            this.panelTool.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTool.Location = new System.Drawing.Point(0, 315);
            this.panelTool.Name = "panelTool";
            this.panelTool.Size = new System.Drawing.Size(825, 233);
            this.panelTool.TabIndex = 1;
            // 
            // checkBoxEditPassword
            // 
            this.checkBoxEditPassword.AutoSize = true;
            this.checkBoxEditPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEditPassword.ForeColor = System.Drawing.Color.White;
            this.checkBoxEditPassword.Location = new System.Drawing.Point(278, 187);
            this.checkBoxEditPassword.Name = "checkBoxEditPassword";
            this.checkBoxEditPassword.Size = new System.Drawing.Size(108, 20);
            this.checkBoxEditPassword.TabIndex = 1;
            this.checkBoxEditPassword.Text = "Sửa mật khẩu";
            this.checkBoxEditPassword.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.13772F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.86227F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxUserName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxIdTeacher, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPermission, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPassword, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(160, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(371, 162);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(41, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tài khoản:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã giảng viên:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(62, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Quyền:";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUserName.Location = new System.Drawing.Point(118, 10);
            this.textBoxUserName.MaxLength = 100;
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(250, 20);
            this.textBoxUserName.TabIndex = 1;
            this.textBoxUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUserName_KeyPress);
            // 
            // comboBoxIdTeacher
            // 
            this.comboBoxIdTeacher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxIdTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIdTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxIdTeacher.FormattingEnabled = true;
            this.comboBoxIdTeacher.Items.AddRange(new object[] {
            ""});
            this.comboBoxIdTeacher.Location = new System.Drawing.Point(118, 89);
            this.comboBoxIdTeacher.Name = "comboBoxIdTeacher";
            this.comboBoxIdTeacher.Size = new System.Drawing.Size(250, 21);
            this.comboBoxIdTeacher.TabIndex = 2;
            // 
            // comboBoxPermission
            // 
            this.comboBoxPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPermission.FormattingEnabled = true;
            this.comboBoxPermission.Items.AddRange(new object[] {
            "admin",
            "giảng viên"});
            this.comboBoxPermission.Location = new System.Drawing.Point(118, 130);
            this.comboBoxPermission.Name = "comboBoxPermission";
            this.comboBoxPermission.Size = new System.Drawing.Size(250, 21);
            this.comboBoxPermission.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(118, 50);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(250, 20);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(47, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu:";
            // 
            // panelAdmin
            // 
            this.panelAdmin.Controls.Add(this.buttonAdd);
            this.panelAdmin.Controls.Add(this.buttonUpdate);
            this.panelAdmin.Controls.Add(this.buttonDelete);
            this.panelAdmin.Location = new System.Drawing.Point(537, 11);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(116, 178);
            this.panelAdmin.TabIndex = 12;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Image")));
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(12, 18);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonAdd.Size = new System.Drawing.Size(91, 39);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Tag = "add";
            this.buttonAdd.Text = "Thêm";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Image = ((System.Drawing.Image)(resources.GetObject("buttonUpdate.Image")));
            this.buttonUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdate.Location = new System.Drawing.Point(12, 70);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonUpdate.Size = new System.Drawing.Size(91, 39);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Tag = "update";
            this.buttonUpdate.Text = "Sửa";
            this.buttonUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.Location = new System.Drawing.Point(12, 122);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.buttonDelete.Size = new System.Drawing.Size(91, 39);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Tag = "delete";
            this.buttonDelete.Text = "Xóa";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // panelAccountData
            // 
            this.panelAccountData.Controls.Add(this.dataGridViewAccount);
            this.panelAccountData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAccountData.Location = new System.Drawing.Point(0, 57);
            this.panelAccountData.Name = "panelAccountData";
            this.panelAccountData.Size = new System.Drawing.Size(825, 258);
            this.panelAccountData.TabIndex = 2;
            // 
            // dataGridViewAccount
            // 
            this.dataGridViewAccount.AllowUserToAddRows = false;
            this.dataGridViewAccount.AllowUserToDeleteRows = false;
            this.dataGridViewAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAccount.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(39)))), ((int)(((byte)(33)))));
            this.dataGridViewAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName1,
            this.IdTeacher1,
            this.Permission1});
            this.dataGridViewAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAccount.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAccount.Name = "dataGridViewAccount";
            this.dataGridViewAccount.ReadOnly = true;
            this.dataGridViewAccount.Size = new System.Drawing.Size(825, 258);
            this.dataGridViewAccount.TabIndex = 0;
            this.dataGridViewAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAccount_CellClick);
            // 
            // UserName1
            // 
            this.UserName1.DataPropertyName = "taiKhoan";
            this.UserName1.HeaderText = "Tài khoản";
            this.UserName1.Name = "UserName1";
            this.UserName1.ReadOnly = true;
            // 
            // IdTeacher1
            // 
            this.IdTeacher1.DataPropertyName = "MSGV";
            this.IdTeacher1.HeaderText = "MSGV";
            this.IdTeacher1.Name = "IdTeacher1";
            this.IdTeacher1.ReadOnly = true;
            // 
            // Permission1
            // 
            this.Permission1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Permission1.DataPropertyName = "loaiTaiKhoan";
            this.Permission1.HeaderText = "Quyền";
            this.Permission1.Name = "Permission1";
            this.Permission1.ReadOnly = true;
            this.Permission1.Width = 63;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(84)))), ((int)(((byte)(71)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 24);
            this.panel1.TabIndex = 3;
            // 
            // FormAccountManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(39)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(825, 548);
            this.Controls.Add(this.panelAccountData);
            this.Controls.Add(this.panelTool);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAccountManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FromAccountManager";
            this.Load += new System.EventHandler(this.FromAccountManager_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelTool.ResumeLayout(false);
            this.panelTool.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelAdmin.ResumeLayout(false);
            this.panelAccountData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonExitEdit;
        private QuanLiDienThoai.DragControl dragControl1;
        private System.Windows.Forms.Label label1;
        private QuanLiDienThoai.DragControl dragControl2;
        private System.Windows.Forms.Panel panelTool;
        private System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panelAccountData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.ComboBox comboBoxIdTeacher;
        private System.Windows.Forms.ComboBox comboBoxPermission;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.DataGridView dataGridViewAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTeacher1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Permission1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxEditPassword;
    }
}