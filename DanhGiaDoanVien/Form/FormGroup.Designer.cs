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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.panelData = new System.Windows.Forms.Panel();
            this.dataGridViewGroup = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalFemaleStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTeacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalFemaleTeacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.buttonExitEdit = new System.Windows.Forms.Button();
            this.buttonResetText = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.panelBottom.SuspendLayout();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.panelBottom.Controls.Add(this.panelEdit);
            this.panelBottom.Controls.Add(this.panel1);
            this.panelBottom.Controls.Add(this.buttonDelete);
            this.panelBottom.Controls.Add(this.buttonAdd);
            this.panelBottom.Controls.Add(this.buttonUpdate);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBottom.Location = new System.Drawing.Point(0, 0);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1000, 197);
            this.panelBottom.TabIndex = 2;
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
            this.buttonDelete.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonDelete.Size = new System.Drawing.Size(91, 39);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Xóa";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDelete.UseVisualStyleBackColor = true;
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
            this.buttonAdd.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonAdd.Size = new System.Drawing.Size(91, 39);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Thêm";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.UseVisualStyleBackColor = true;
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
            this.buttonUpdate.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonUpdate.Size = new System.Drawing.Size(91, 39);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Sửa";
            this.buttonUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên:";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxName.Location = new System.Drawing.Point(80, 40);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(198, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.dataGridViewGroup);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 197);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(1000, 438);
            this.panelData.TabIndex = 3;
            // 
            // dataGridViewGroup
            // 
            this.dataGridViewGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGroup.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(77)))), ((int)(((byte)(108)))));
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
            this.dataGridViewGroup.Size = new System.Drawing.Size(1000, 438);
            this.dataGridViewGroup.TabIndex = 0;
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
            this.TotalMember.DataPropertyName = "soDoanVien";
            this.TotalMember.HeaderText = "Số đoàn viên";
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
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.Controls.Add(this.textBoxID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(24, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 71);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(32, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "ID:";
            // 
            // textBoxID
            // 
            this.textBoxID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxID.Location = new System.Drawing.Point(80, 14);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(198, 20);
            this.textBoxID.TabIndex = 1;
            // 
            // panelEdit
            // 
            this.panelEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEdit.Controls.Add(this.buttonExitEdit);
            this.panelEdit.Controls.Add(this.buttonResetText);
            this.panelEdit.Controls.Add(this.buttonEdit);
            this.panelEdit.Location = new System.Drawing.Point(336, 17);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(204, 91);
            this.panelEdit.TabIndex = 8;
            this.panelEdit.Visible = false;
            // 
            // buttonExitEdit
            // 
            this.buttonExitEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExitEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitEdit.ForeColor = System.Drawing.Color.White;
            this.buttonExitEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExitEdit.Image")));
            this.buttonExitEdit.Location = new System.Drawing.Point(177, 3);
            this.buttonExitEdit.Name = "buttonExitEdit";
            this.buttonExitEdit.Size = new System.Drawing.Size(20, 20);
            this.buttonExitEdit.TabIndex = 7;
            this.buttonExitEdit.Tag = "exitEdit";
            this.buttonExitEdit.UseVisualStyleBackColor = true;
            // 
            // buttonResetText
            // 
            this.buttonResetText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetText.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonResetText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetText.ForeColor = System.Drawing.Color.White;
            this.buttonResetText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonResetText.Location = new System.Drawing.Point(108, 39);
            this.buttonResetText.Name = "buttonResetText";
            this.buttonResetText.Size = new System.Drawing.Size(77, 35);
            this.buttonResetText.TabIndex = 4;
            this.buttonResetText.Text = "Xóa";
            this.buttonResetText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonResetText.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.ForeColor = System.Drawing.Color.White;
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.Location = new System.Drawing.Point(25, 39);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(77, 35);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Thêm";
            this.buttonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEdit.UseVisualStyleBackColor = true;
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
            this.panelBottom.ResumeLayout(false);
            this.panelData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.DataGridView dataGridViewGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalFemaleStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTeacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalFemaleTeacher;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Button buttonExitEdit;
        private System.Windows.Forms.Button buttonResetText;
        private System.Windows.Forms.Button buttonEdit;
    }
}