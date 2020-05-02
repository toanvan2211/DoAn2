namespace DanhGiaDoanVien.Forms
{
    partial class FormSemester
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSemester));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.buttonExitEdit = new System.Windows.Forms.Button();
            this.tabapanel = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxIdSemester = new System.Windows.Forms.TextBox();
            this.textBoxNameEdit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonResetText = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.panelDefault = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.panelData = new System.Windows.Forms.Panel();
            this.dataGridViewSemester = new System.Windows.Forms.DataGridView();
            this.Id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelGroupInSemester = new System.Windows.Forms.Panel();
            this.dataGridViewGroup = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom.SuspendLayout();
            this.panelEdit.SuspendLayout();
            this.tabapanel.SuspendLayout();
            this.panelDefault.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSemester)).BeginInit();
            this.panelGroupInSemester.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).BeginInit();
            this.SuspendLayout();
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
            this.panelBottom.TabIndex = 1;
            // 
            // panelEdit
            // 
            this.panelEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEdit.Controls.Add(this.buttonExitEdit);
            this.panelEdit.Controls.Add(this.tabapanel);
            this.panelEdit.Controls.Add(this.buttonResetText);
            this.panelEdit.Controls.Add(this.buttonEdit);
            this.panelEdit.Location = new System.Drawing.Point(256, 182);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(488, 145);
            this.panelEdit.TabIndex = 3;
            this.panelEdit.Visible = false;
            // 
            // buttonExitEdit
            // 
            this.buttonExitEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExitEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitEdit.ForeColor = System.Drawing.Color.White;
            this.buttonExitEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExitEdit.Image")));
            this.buttonExitEdit.Location = new System.Drawing.Point(461, 3);
            this.buttonExitEdit.Name = "buttonExitEdit";
            this.buttonExitEdit.Size = new System.Drawing.Size(20, 20);
            this.buttonExitEdit.TabIndex = 5;
            this.buttonExitEdit.Tag = "exitEdit";
            this.buttonExitEdit.UseVisualStyleBackColor = true;
            this.buttonExitEdit.Click += new System.EventHandler(this.buttonExitEdit_Click);
            // 
            // tabapanel
            // 
            this.tabapanel.ColumnCount = 2;
            this.tabapanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.58064F));
            this.tabapanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.45161F));
            this.tabapanel.Controls.Add(this.label11, 0, 0);
            this.tabapanel.Controls.Add(this.textBoxIdSemester, 1, 0);
            this.tabapanel.Controls.Add(this.textBoxNameEdit, 1, 1);
            this.tabapanel.Controls.Add(this.label4, 0, 1);
            this.tabapanel.Location = new System.Drawing.Point(14, 18);
            this.tabapanel.Name = "tabapanel";
            this.tabapanel.RowCount = 2;
            this.tabapanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tabapanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tabapanel.Size = new System.Drawing.Size(301, 80);
            this.tabapanel.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(13, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Mã năm học:";
            // 
            // textBoxIdSemester
            // 
            this.textBoxIdSemester.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIdSemester.Location = new System.Drawing.Point(88, 10);
            this.textBoxIdSemester.MaxLength = 10;
            this.textBoxIdSemester.Name = "textBoxIdSemester";
            this.textBoxIdSemester.Size = new System.Drawing.Size(210, 20);
            this.textBoxIdSemester.TabIndex = 1;
            this.textBoxIdSemester.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIdSemester_KeyPress);
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
            // buttonResetText
            // 
            this.buttonResetText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.ForeColor = System.Drawing.Color.White;
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.Location = new System.Drawing.Point(325, 103);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(77, 35);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Thêm";
            this.buttonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // panelDefault
            // 
            this.panelDefault.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDefault.Controls.Add(this.labelName);
            this.panelDefault.Controls.Add(this.labelID);
            this.panelDefault.Controls.Add(this.tableLayoutPanel2);
            this.panelDefault.Location = new System.Drawing.Point(256, 20);
            this.panelDefault.Name = "panelDefault";
            this.panelDefault.Size = new System.Drawing.Size(488, 156);
            this.panelDefault.TabIndex = 2;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.Gold;
            this.labelName.Location = new System.Drawing.Point(155, 91);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 16);
            this.labelName.TabIndex = 5;
            // 
            // labelID
            // 
            this.labelID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.ForeColor = System.Drawing.Color.Gold;
            this.labelID.Location = new System.Drawing.Point(155, 52);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(0, 16);
            this.labelID.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(36, 39);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(113, 78);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(75, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã năm học:";
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
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Tag = "delete";
            this.buttonDelete.Text = "Xóa";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
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
            this.buttonUpdate.Location = new System.Drawing.Point(872, 78);
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
            // panelData
            // 
            this.panelData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(77)))), ((int)(((byte)(108)))));
            this.panelData.Controls.Add(this.dataGridViewSemester);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelData.Location = new System.Drawing.Point(0, 197);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(319, 438);
            this.panelData.TabIndex = 4;
            // 
            // dataGridViewSemester
            // 
            this.dataGridViewSemester.AllowUserToAddRows = false;
            this.dataGridViewSemester.AllowUserToDeleteRows = false;
            this.dataGridViewSemester.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSemester.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(87)))), ((int)(((byte)(95)))));
            this.dataGridViewSemester.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSemester.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id1,
            this.Name1});
            this.dataGridViewSemester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSemester.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSemester.Name = "dataGridViewSemester";
            this.dataGridViewSemester.Size = new System.Drawing.Size(319, 438);
            this.dataGridViewSemester.TabIndex = 4;
            this.dataGridViewSemester.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSemester_CellClick);
            // 
            // Id1
            // 
            this.Id1.DataPropertyName = "id";
            this.Id1.HeaderText = "ID";
            this.Id1.Name = "Id1";
            this.Id1.ReadOnly = true;
            // 
            // Name1
            // 
            this.Name1.DataPropertyName = "ten";
            this.Name1.HeaderText = "Năm học";
            this.Name1.Name = "Name1";
            this.Name1.ReadOnly = true;
            // 
            // panelGroupInSemester
            // 
            this.panelGroupInSemester.Controls.Add(this.dataGridViewGroup);
            this.panelGroupInSemester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGroupInSemester.Location = new System.Drawing.Point(319, 197);
            this.panelGroupInSemester.Name = "panelGroupInSemester";
            this.panelGroupInSemester.Size = new System.Drawing.Size(681, 438);
            this.panelGroupInSemester.TabIndex = 5;
            // 
            // dataGridViewGroup
            // 
            this.dataGridViewGroup.AllowUserToAddRows = false;
            this.dataGridViewGroup.AllowUserToDeleteRows = false;
            this.dataGridViewGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGroup.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.dataGridViewGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.dataGridViewTextBoxColumn1,
            this.TotalMember});
            this.dataGridViewGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGroup.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGroup.Name = "dataGridViewGroup";
            this.dataGridViewGroup.Size = new System.Drawing.Size(681, 438);
            this.dataGridViewGroup.TabIndex = 5;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ten";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tên";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // TotalMember
            // 
            this.TotalMember.DataPropertyName = "soThanhVien";
            this.TotalMember.HeaderText = "Số thành viên";
            this.TotalMember.Name = "TotalMember";
            this.TotalMember.ReadOnly = true;
            // 
            // FormSemester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(1000, 635);
            this.Controls.Add(this.panelGroupInSemester);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelBottom);
            this.Name = "FormSemester";
            this.Text = "FormSemester";
            this.Load += new System.EventHandler(this.FormSemester_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelEdit.ResumeLayout(false);
            this.tabapanel.ResumeLayout(false);
            this.tabapanel.PerformLayout();
            this.panelDefault.ResumeLayout(false);
            this.panelDefault.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSemester)).EndInit();
            this.panelGroupInSemester.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonExitEdit;
        private System.Windows.Forms.Button buttonResetText;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.TextBox textBoxNameEdit;
        private System.Windows.Forms.TextBox textBoxIdSemester;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.DataGridView dataGridViewSemester;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.Panel panelDefault;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.TableLayoutPanel tabapanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelGroupInSemester;
        private System.Windows.Forms.DataGridView dataGridViewGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMember;
    }
}