namespace DanhGiaDoanVien
{
    partial class FormGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGroup));
            this.tabapanel = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxNameEdit = new System.Windows.Forms.TextBox();
            this.textBoxMCDEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonExitEdit = new System.Windows.Forms.Button();
            this.buttonResetText = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.panelGroup = new System.Windows.Forms.Panel();
            this.dataGridViewGroup = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalFemaleStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTeacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalFemaleTeacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelData = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewMember = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelDefault = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabapanel.SuspendLayout();
            this.panelGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).BeginInit();
            this.panelData.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMember)).BeginInit();
            this.panelEdit.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelDefault.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabapanel
            // 
            this.tabapanel.ColumnCount = 2;
            this.tabapanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.58064F));
            this.tabapanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.45161F));
            this.tabapanel.Controls.Add(this.textBoxNameEdit, 1, 1);
            this.tabapanel.Controls.Add(this.textBoxMCDEdit, 1, 0);
            this.tabapanel.Controls.Add(this.label2, 0, 0);
            this.tabapanel.Controls.Add(this.label4, 0, 1);
            this.tabapanel.Location = new System.Drawing.Point(14, 18);
            this.tabapanel.Name = "tabapanel";
            this.tabapanel.RowCount = 2;
            this.tabapanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tabapanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tabapanel.Size = new System.Drawing.Size(301, 80);
            this.tabapanel.TabIndex = 9;
            // 
            // textBoxNameEdit
            // 
            this.textBoxNameEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNameEdit.Location = new System.Drawing.Point(88, 50);
            this.textBoxNameEdit.MaxLength = 100;
            this.textBoxNameEdit.Name = "textBoxNameEdit";
            this.textBoxNameEdit.Size = new System.Drawing.Size(210, 20);
            this.textBoxNameEdit.TabIndex = 2;
            // 
            // textBoxMCDEdit
            // 
            this.textBoxMCDEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMCDEdit.Location = new System.Drawing.Point(88, 10);
            this.textBoxMCDEdit.MaxLength = 10;
            this.textBoxMCDEdit.Name = "textBoxMCDEdit";
            this.textBoxMCDEdit.Size = new System.Drawing.Size(210, 20);
            this.textBoxMCDEdit.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã chi đoàn:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(53, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên:";
            // 
            // buttonExitEdit
            // 
            this.buttonExitEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExitEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitEdit.ForeColor = System.Drawing.Color.White;
            this.buttonExitEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExitEdit.Image")));
            this.buttonExitEdit.Location = new System.Drawing.Point(461, 0);
            this.buttonExitEdit.Name = "buttonExitEdit";
            this.buttonExitEdit.Size = new System.Drawing.Size(20, 20);
            this.buttonExitEdit.TabIndex = 7;
            this.buttonExitEdit.Tag = "exitEdit";
            this.buttonExitEdit.UseVisualStyleBackColor = true;
            this.buttonExitEdit.Click += new System.EventHandler(this.buttonExitEdit_Click);
            // 
            // buttonResetText
            // 
            this.buttonResetText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonResetText.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonResetText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.buttonResetText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonResetText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetText.ForeColor = System.Drawing.Color.White;
            this.buttonResetText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonResetText.Location = new System.Drawing.Point(408, 103);
            this.buttonResetText.Name = "buttonResetText";
            this.buttonResetText.Size = new System.Drawing.Size(73, 35);
            this.buttonResetText.TabIndex = 4;
            this.buttonResetText.Text = "Xóa";
            this.buttonResetText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonResetText.UseVisualStyleBackColor = true;
            this.buttonResetText.Click += new System.EventHandler(this.buttonResetText_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.ForeColor = System.Drawing.Color.White;
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.Location = new System.Drawing.Point(321, 103);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(77, 35);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Thêm";
            this.buttonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // panelGroup
            // 
            this.panelGroup.AutoScroll = true;
            this.panelGroup.Controls.Add(this.dataGridViewGroup);
            this.panelGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelGroup.Location = new System.Drawing.Point(0, 0);
            this.panelGroup.Name = "panelGroup";
            this.panelGroup.Size = new System.Drawing.Size(491, 438);
            this.panelGroup.TabIndex = 0;
            // 
            // dataGridViewGroup
            // 
            this.dataGridViewGroup.AllowUserToAddRows = false;
            this.dataGridViewGroup.AllowUserToDeleteRows = false;
            this.dataGridViewGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGroup.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(87)))), ((int)(((byte)(95)))));
            this.dataGridViewGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Name1,
            this.TotalMember,
            this.TotalStudent,
            this.TotalFemaleStudent,
            this.TotalTeacher,
            this.TotalFemaleTeacher});
            this.dataGridViewGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGroup.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGroup.Name = "dataGridViewGroup";
            this.dataGridViewGroup.Size = new System.Drawing.Size(491, 438);
            this.dataGridViewGroup.TabIndex = 1;
            this.dataGridViewGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGroup_CellClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // Name1
            // 
            this.Name1.DataPropertyName = "ten";
            this.Name1.HeaderText = "Tên";
            this.Name1.Name = "Name1";
            this.Name1.ReadOnly = true;
            // 
            // TotalMember
            // 
            this.TotalMember.DataPropertyName = "soThanhVien";
            this.TotalMember.HeaderText = "Số thành viên";
            this.TotalMember.Name = "TotalMember";
            this.TotalMember.ReadOnly = true;
            // 
            // TotalStudent
            // 
            this.TotalStudent.DataPropertyName = "tongSV";
            this.TotalStudent.HeaderText = "Tổng sinh viên";
            this.TotalStudent.Name = "TotalStudent";
            this.TotalStudent.ReadOnly = true;
            // 
            // TotalFemaleStudent
            // 
            this.TotalFemaleStudent.DataPropertyName = "tongNuSV";
            this.TotalFemaleStudent.HeaderText = "Sinh viên nữ";
            this.TotalFemaleStudent.Name = "TotalFemaleStudent";
            this.TotalFemaleStudent.ReadOnly = true;
            // 
            // TotalTeacher
            // 
            this.TotalTeacher.DataPropertyName = "tongGV";
            this.TotalTeacher.HeaderText = "Tổng giảng viên";
            this.TotalTeacher.Name = "TotalTeacher";
            this.TotalTeacher.ReadOnly = true;
            // 
            // TotalFemaleTeacher
            // 
            this.TotalFemaleTeacher.DataPropertyName = "tongNuGV";
            this.TotalFemaleTeacher.HeaderText = "Giảng viên nữ";
            this.TotalFemaleTeacher.Name = "TotalFemaleTeacher";
            this.TotalFemaleTeacher.ReadOnly = true;
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.panel1);
            this.panelData.Controls.Add(this.panelGroup);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 197);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(1000, 438);
            this.panelData.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewMember);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(491, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 438);
            this.panel1.TabIndex = 1;
            // 
            // dataGridViewMember
            // 
            this.dataGridViewMember.AllowUserToAddRows = false;
            this.dataGridViewMember.AllowUserToDeleteRows = false;
            this.dataGridViewMember.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMember.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.dataGridViewMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Sex,
            this.Group,
            this.isMember});
            this.dataGridViewMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMember.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMember.Name = "dataGridViewMember";
            this.dataGridViewMember.Size = new System.Drawing.Size(509, 438);
            this.dataGridViewMember.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ten";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Sex
            // 
            this.Sex.DataPropertyName = "gioiTinh";
            this.Sex.HeaderText = "Giới tính";
            this.Sex.Name = "Sex";
            // 
            // Group
            // 
            this.Group.DataPropertyName = "chiDoan";
            this.Group.HeaderText = "Chi đoàn";
            this.Group.Name = "Group";
            // 
            // isMember
            // 
            this.isMember.DataPropertyName = "doanVien";
            this.isMember.HeaderText = "Đoàn viên";
            this.isMember.Name = "isMember";
            // 
            // panelEdit
            // 
            this.panelEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEdit.Controls.Add(this.tabapanel);
            this.panelEdit.Controls.Add(this.buttonExitEdit);
            this.panelEdit.Controls.Add(this.buttonEdit);
            this.panelEdit.Controls.Add(this.buttonResetText);
            this.panelEdit.Location = new System.Drawing.Point(213, 177);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(488, 145);
            this.panelEdit.TabIndex = 11;
            this.panelEdit.Visible = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Image = ((System.Drawing.Image)(resources.GetObject("buttonUpdate.Image")));
            this.buttonUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdate.Location = new System.Drawing.Point(872, 78);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonUpdate.Size = new System.Drawing.Size(91, 39);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Tag = "update";
            this.buttonUpdate.Text = "Sửa";
            this.buttonUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Image")));
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(872, 26);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonAdd.Size = new System.Drawing.Size(91, 39);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Tag = "add";
            this.buttonAdd.Text = "Thêm";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.Location = new System.Drawing.Point(872, 130);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.buttonDelete.Size = new System.Drawing.Size(91, 39);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Tag = "delete";
            this.buttonDelete.Text = "Xóa";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(41)))), ((int)(((byte)(45)))));
            this.panelBottom.Controls.Add(this.panelEdit);
            this.panelBottom.Controls.Add(this.panelDefault);
            this.panelBottom.Controls.Add(this.buttonDelete);
            this.panelBottom.Controls.Add(this.buttonAdd);
            this.panelBottom.Controls.Add(this.buttonUpdate);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBottom.Location = new System.Drawing.Point(0, 0);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1000, 197);
            this.panelBottom.TabIndex = 2;
            // 
            // panelDefault
            // 
            this.panelDefault.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDefault.Controls.Add(this.labelName);
            this.panelDefault.Controls.Add(this.labelID);
            this.panelDefault.Controls.Add(this.tableLayoutPanel1);
            this.panelDefault.Location = new System.Drawing.Point(213, 15);
            this.panelDefault.Name = "panelDefault";
            this.panelDefault.Size = new System.Drawing.Size(488, 156);
            this.panelDefault.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoSize = true;
            this.labelName.ForeColor = System.Drawing.Color.Gold;
            this.labelName.Location = new System.Drawing.Point(125, 91);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 13);
            this.labelName.TabIndex = 5;
            // 
            // labelID
            // 
            this.labelID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelID.AutoSize = true;
            this.labelID.ForeColor = System.Drawing.Color.Gold;
            this.labelID.Location = new System.Drawing.Point(125, 52);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(0, 13);
            this.labelID.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(36, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(83, 78);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã chi đoàn:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(51, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên:";
            // 
            // FormGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(77)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(1000, 635);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelBottom);
            this.Name = "FormGroup";
            this.Text = "FormGroup";
            this.tabapanel.ResumeLayout(false);
            this.tabapanel.PerformLayout();
            this.panelGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).EndInit();
            this.panelData.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMember)).EndInit();
            this.panelEdit.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelDefault.ResumeLayout(false);
            this.panelDefault.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonResetText;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.TextBox textBoxNameEdit;
        private System.Windows.Forms.TextBox textBoxMCDEdit;
        private System.Windows.Forms.TableLayoutPanel tabapanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonExitEdit;
        private System.Windows.Forms.Panel panelGroup;
        private System.Windows.Forms.DataGridView dataGridViewGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalFemaleStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTeacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalFemaleTeacher;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn isMember;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelDefault;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelID;
    }
}