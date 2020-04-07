namespace DanhGiaDoanVien
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelSubMenuEvaluate = new System.Windows.Forms.Panel();
            this.buttonEvaluateStudent = new System.Windows.Forms.Button();
            this.buttonEvaluateTeacher = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelShadow2 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelCurrentChildForm = new System.Windows.Forms.Label();
            this.panelShadow1 = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.dragControl1 = new QuanLiDienThoai.DragControl();
            this.pictureBoxIconCurrent = new System.Windows.Forms.PictureBox();
            this.buttonEvaluate = new System.Windows.Forms.Button();
            this.buttonGroup = new System.Windows.Forms.Button();
            this.buttonStudent = new System.Windows.Forms.Button();
            this.buttonTeacher = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelSubMenuEvaluate.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.panelMenu.Controls.Add(this.panelSubMenuEvaluate);
            this.panelMenu.Controls.Add(this.buttonEvaluate);
            this.panelMenu.Controls.Add(this.buttonGroup);
            this.panelMenu.Controls.Add(this.buttonStudent);
            this.panelMenu.Controls.Add(this.buttonTeacher);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(248, 801);
            this.panelMenu.TabIndex = 0;
            // 
            // panelSubMenuEvaluate
            // 
            this.panelSubMenuEvaluate.Controls.Add(this.buttonEvaluateStudent);
            this.panelSubMenuEvaluate.Controls.Add(this.buttonEvaluateTeacher);
            this.panelSubMenuEvaluate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenuEvaluate.Location = new System.Drawing.Point(0, 460);
            this.panelSubMenuEvaluate.Name = "panelSubMenuEvaluate";
            this.panelSubMenuEvaluate.Size = new System.Drawing.Size(248, 110);
            this.panelSubMenuEvaluate.TabIndex = 5;
            this.panelSubMenuEvaluate.VisibleChanged += new System.EventHandler(this.panelSubMenuEvaluate_VisibleChanged);
            // 
            // buttonEvaluateStudent
            // 
            this.buttonEvaluateStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(76)))));
            this.buttonEvaluateStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEvaluateStudent.FlatAppearance.BorderSize = 0;
            this.buttonEvaluateStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEvaluateStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEvaluateStudent.ForeColor = System.Drawing.Color.White;
            this.buttonEvaluateStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEvaluateStudent.Location = new System.Drawing.Point(0, 51);
            this.buttonEvaluateStudent.Name = "buttonEvaluateStudent";
            this.buttonEvaluateStudent.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.buttonEvaluateStudent.Size = new System.Drawing.Size(248, 51);
            this.buttonEvaluateStudent.TabIndex = 6;
            this.buttonEvaluateStudent.Tag = "not";
            this.buttonEvaluateStudent.Text = "Sinh viên";
            this.buttonEvaluateStudent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEvaluateStudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEvaluateStudent.UseVisualStyleBackColor = false;
            this.buttonEvaluateStudent.Click += new System.EventHandler(this.buttonEvaluateStudent_Click);
            // 
            // buttonEvaluateTeacher
            // 
            this.buttonEvaluateTeacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(76)))));
            this.buttonEvaluateTeacher.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEvaluateTeacher.FlatAppearance.BorderSize = 0;
            this.buttonEvaluateTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEvaluateTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEvaluateTeacher.ForeColor = System.Drawing.Color.White;
            this.buttonEvaluateTeacher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEvaluateTeacher.Location = new System.Drawing.Point(0, 0);
            this.buttonEvaluateTeacher.Name = "buttonEvaluateTeacher";
            this.buttonEvaluateTeacher.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.buttonEvaluateTeacher.Size = new System.Drawing.Size(248, 51);
            this.buttonEvaluateTeacher.TabIndex = 5;
            this.buttonEvaluateTeacher.Tag = "not";
            this.buttonEvaluateTeacher.Text = "Giảng viên";
            this.buttonEvaluateTeacher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEvaluateTeacher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEvaluateTeacher.UseVisualStyleBackColor = false;
            this.buttonEvaluateTeacher.Click += new System.EventHandler(this.buttonEvaluateTeacher_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(71)))));
            this.panelLogo.Controls.Add(this.pictureBoxLogo);
            this.panelLogo.Controls.Add(this.panelShadow2);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(248, 220);
            this.panelLogo.TabIndex = 0;
            // 
            // panelShadow2
            // 
            this.panelShadow2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.panelShadow2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelShadow2.Location = new System.Drawing.Point(0, 212);
            this.panelShadow2.Name = "panelShadow2";
            this.panelShadow2.Size = new System.Drawing.Size(248, 8);
            this.panelShadow2.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.panelTop.Controls.Add(this.labelCurrentChildForm);
            this.panelTop.Controls.Add(this.pictureBoxIconCurrent);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(248, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1016, 117);
            this.panelTop.TabIndex = 1;
            // 
            // labelCurrentChildForm
            // 
            this.labelCurrentChildForm.AutoSize = true;
            this.labelCurrentChildForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentChildForm.ForeColor = System.Drawing.Color.White;
            this.labelCurrentChildForm.Location = new System.Drawing.Point(78, 53);
            this.labelCurrentChildForm.Name = "labelCurrentChildForm";
            this.labelCurrentChildForm.Size = new System.Drawing.Size(89, 20);
            this.labelCurrentChildForm.TabIndex = 2;
            this.labelCurrentChildForm.Text = "Trang chủ";
            // 
            // panelShadow1
            // 
            this.panelShadow1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(45)))));
            this.panelShadow1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow1.Location = new System.Drawing.Point(248, 117);
            this.panelShadow1.Name = "panelShadow1";
            this.panelShadow1.Size = new System.Drawing.Size(1016, 10);
            this.panelShadow1.TabIndex = 2;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(77)))), ((int)(((byte)(108)))));
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(248, 127);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1016, 674);
            this.panelChildForm.TabIndex = 3;
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelTop;
            // 
            // pictureBoxIconCurrent
            // 
            this.pictureBoxIconCurrent.Image = global::DanhGiaDoanVien.Properties.Resources.icons8_home_35px_1;
            this.pictureBoxIconCurrent.Location = new System.Drawing.Point(27, 30);
            this.pictureBoxIconCurrent.Name = "pictureBoxIconCurrent";
            this.pictureBoxIconCurrent.Size = new System.Drawing.Size(45, 59);
            this.pictureBoxIconCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIconCurrent.TabIndex = 1;
            this.pictureBoxIconCurrent.TabStop = false;
            // 
            // buttonEvaluate
            // 
            this.buttonEvaluate.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEvaluate.FlatAppearance.BorderSize = 0;
            this.buttonEvaluate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEvaluate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEvaluate.ForeColor = System.Drawing.Color.White;
            this.buttonEvaluate.Image = global::DanhGiaDoanVien.Properties.Resources.icons8_report_card_35px;
            this.buttonEvaluate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEvaluate.Location = new System.Drawing.Point(0, 400);
            this.buttonEvaluate.Name = "buttonEvaluate";
            this.buttonEvaluate.Padding = new System.Windows.Forms.Padding(15, 0, 20, 0);
            this.buttonEvaluate.Size = new System.Drawing.Size(248, 60);
            this.buttonEvaluate.TabIndex = 4;
            this.buttonEvaluate.Tag = "icons8_report_card_35px";
            this.buttonEvaluate.Text = "Đánh giá";
            this.buttonEvaluate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEvaluate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEvaluate.UseVisualStyleBackColor = true;
            this.buttonEvaluate.Click += new System.EventHandler(this.buttonEvaluate_Click);
            // 
            // buttonGroup
            // 
            this.buttonGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGroup.FlatAppearance.BorderSize = 0;
            this.buttonGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGroup.ForeColor = System.Drawing.Color.White;
            this.buttonGroup.Image = global::DanhGiaDoanVien.Properties.Resources.icons8_teamwork_35px;
            this.buttonGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGroup.Location = new System.Drawing.Point(0, 340);
            this.buttonGroup.Name = "buttonGroup";
            this.buttonGroup.Padding = new System.Windows.Forms.Padding(15, 0, 20, 0);
            this.buttonGroup.Size = new System.Drawing.Size(248, 60);
            this.buttonGroup.TabIndex = 3;
            this.buttonGroup.Tag = "icons8_teamwork_35px";
            this.buttonGroup.Text = "Chi đoàn";
            this.buttonGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonGroup.UseVisualStyleBackColor = true;
            this.buttonGroup.Click += new System.EventHandler(this.buttonGroup_Click);
            // 
            // buttonStudent
            // 
            this.buttonStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStudent.FlatAppearance.BorderSize = 0;
            this.buttonStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStudent.ForeColor = System.Drawing.Color.White;
            this.buttonStudent.Image = global::DanhGiaDoanVien.Properties.Resources.icons8_read_online_35px_1;
            this.buttonStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStudent.Location = new System.Drawing.Point(0, 280);
            this.buttonStudent.Name = "buttonStudent";
            this.buttonStudent.Padding = new System.Windows.Forms.Padding(15, 0, 20, 0);
            this.buttonStudent.Size = new System.Drawing.Size(248, 60);
            this.buttonStudent.TabIndex = 2;
            this.buttonStudent.Tag = "icons8_read_online_35px_1";
            this.buttonStudent.Text = "Sinh viên";
            this.buttonStudent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonStudent.UseVisualStyleBackColor = true;
            this.buttonStudent.Click += new System.EventHandler(this.buttonStudent_Click);
            // 
            // buttonTeacher
            // 
            this.buttonTeacher.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTeacher.FlatAppearance.BorderSize = 0;
            this.buttonTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTeacher.ForeColor = System.Drawing.Color.White;
            this.buttonTeacher.Image = global::DanhGiaDoanVien.Properties.Resources.icons8_school_director_35px_1;
            this.buttonTeacher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTeacher.Location = new System.Drawing.Point(0, 220);
            this.buttonTeacher.Name = "buttonTeacher";
            this.buttonTeacher.Padding = new System.Windows.Forms.Padding(15, 0, 20, 0);
            this.buttonTeacher.Size = new System.Drawing.Size(248, 60);
            this.buttonTeacher.TabIndex = 1;
            this.buttonTeacher.Tag = "icons8_school_director_35px_1";
            this.buttonTeacher.Text = "Giảng viên";
            this.buttonTeacher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTeacher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonTeacher.UseVisualStyleBackColor = true;
            this.buttonTeacher.Click += new System.EventHandler(this.buttonTeacher_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(3, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(242, 179);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 801);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelShadow1);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(1280, 750);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelMenu.ResumeLayout(false);
            this.panelSubMenuEvaluate.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelShadow1;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel panelShadow2;
        private System.Windows.Forms.Button buttonTeacher;
        private System.Windows.Forms.Button buttonEvaluate;
        private System.Windows.Forms.Button buttonGroup;
        private System.Windows.Forms.Button buttonStudent;
        private System.Windows.Forms.Label labelCurrentChildForm;
        private System.Windows.Forms.PictureBox pictureBoxIconCurrent;
        private System.Windows.Forms.Panel panelSubMenuEvaluate;
        private System.Windows.Forms.Button buttonEvaluateStudent;
        private System.Windows.Forms.Button buttonEvaluateTeacher;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private QuanLiDienThoai.DragControl dragControl1;
    }
}

