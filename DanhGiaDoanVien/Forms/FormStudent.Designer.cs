namespace DanhGiaDoanVien
{
    partial class FormStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStudent));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.buttonExitEdit = new System.Windows.Forms.Button();
            this.panelRadioEdit = new System.Windows.Forms.Panel();
            this.radioButtonNoEdit = new System.Windows.Forms.RadioButton();
            this.radioButtonHaveEdit = new System.Windows.Forms.RadioButton();
            this.comboBoxSexEdit = new System.Windows.Forms.ComboBox();
            this.buttonResetText = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.comboBoxGroupEdit = new System.Windows.Forms.ComboBox();
            this.textBoxNameEdit = new System.Windows.Forms.TextBox();
            this.textBoxMSSVEdit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panelDefault = new System.Windows.Forms.Panel();
            this.panelRadio = new System.Windows.Forms.Panel();
            this.radioButtonNot = new System.Windows.Forms.RadioButton();
            this.radioButtonHave = new System.Windows.Forms.RadioButton();
            this.radioButtonAllMember = new System.Windows.Forms.RadioButton();
            this.comboBoxSex = new System.Windows.Forms.ComboBox();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMSSV = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.panelData = new System.Windows.Forms.Panel();
            this.dataGridViewStudent = new System.Windows.Forms.DataGridView();
            this.MSSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsMember1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom.SuspendLayout();
            this.panelEdit.SuspendLayout();
            this.panelRadioEdit.SuspendLayout();
            this.panelDefault.SuspendLayout();
            this.panelRadio.SuspendLayout();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
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
            this.panelEdit.Controls.Add(this.panelRadioEdit);
            this.panelEdit.Controls.Add(this.comboBoxSexEdit);
            this.panelEdit.Controls.Add(this.buttonResetText);
            this.panelEdit.Controls.Add(this.buttonEdit);
            this.panelEdit.Controls.Add(this.comboBoxGroupEdit);
            this.panelEdit.Controls.Add(this.textBoxNameEdit);
            this.panelEdit.Controls.Add(this.textBoxMSSVEdit);
            this.panelEdit.Controls.Add(this.label6);
            this.panelEdit.Controls.Add(this.label7);
            this.panelEdit.Controls.Add(this.label8);
            this.panelEdit.Controls.Add(this.label9);
            this.panelEdit.Controls.Add(this.label10);
            this.panelEdit.Controls.Add(this.label11);
            this.panelEdit.Controls.Add(this.label12);
            this.panelEdit.Location = new System.Drawing.Point(56, 26);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(594, 163);
            this.panelEdit.TabIndex = 6;
            this.panelEdit.Visible = false;
            // 
            // buttonExitEdit
            // 
            this.buttonExitEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitEdit.ForeColor = System.Drawing.Color.White;
            this.buttonExitEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExitEdit.Image")));
            this.buttonExitEdit.Location = new System.Drawing.Point(567, 3);
            this.buttonExitEdit.Name = "buttonExitEdit";
            this.buttonExitEdit.Size = new System.Drawing.Size(20, 20);
            this.buttonExitEdit.TabIndex = 7;
            this.buttonExitEdit.Tag = "exitEdit";
            this.buttonExitEdit.UseVisualStyleBackColor = true;
            this.buttonExitEdit.Click += new System.EventHandler(this.buttonExitEdit_Click);
            // 
            // panelRadioEdit
            // 
            this.panelRadioEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRadioEdit.Controls.Add(this.radioButtonNoEdit);
            this.panelRadioEdit.Controls.Add(this.radioButtonHaveEdit);
            this.panelRadioEdit.Location = new System.Drawing.Point(498, 24);
            this.panelRadioEdit.Name = "panelRadioEdit";
            this.panelRadioEdit.Size = new System.Drawing.Size(64, 74);
            this.panelRadioEdit.TabIndex = 5;
            // 
            // radioButtonNoEdit
            // 
            this.radioButtonNoEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonNoEdit.AutoSize = true;
            this.radioButtonNoEdit.ForeColor = System.Drawing.Color.White;
            this.radioButtonNoEdit.Location = new System.Drawing.Point(3, 38);
            this.radioButtonNoEdit.Name = "radioButtonNoEdit";
            this.radioButtonNoEdit.Size = new System.Drawing.Size(56, 17);
            this.radioButtonNoEdit.TabIndex = 2;
            this.radioButtonNoEdit.Tag = "False";
            this.radioButtonNoEdit.Text = "Không";
            this.radioButtonNoEdit.UseVisualStyleBackColor = true;
            // 
            // radioButtonHaveEdit
            // 
            this.radioButtonHaveEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonHaveEdit.AutoSize = true;
            this.radioButtonHaveEdit.Checked = true;
            this.radioButtonHaveEdit.ForeColor = System.Drawing.Color.White;
            this.radioButtonHaveEdit.Location = new System.Drawing.Point(3, 15);
            this.radioButtonHaveEdit.Name = "radioButtonHaveEdit";
            this.radioButtonHaveEdit.Size = new System.Drawing.Size(38, 17);
            this.radioButtonHaveEdit.TabIndex = 1;
            this.radioButtonHaveEdit.TabStop = true;
            this.radioButtonHaveEdit.Tag = "True";
            this.radioButtonHaveEdit.Text = "Có";
            this.radioButtonHaveEdit.UseVisualStyleBackColor = true;
            this.radioButtonHaveEdit.CheckedChanged += new System.EventHandler(this.radioButtonHaveEdit_CheckedChanged);
            // 
            // comboBoxSexEdit
            // 
            this.comboBoxSexEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSexEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSexEdit.FormattingEnabled = true;
            this.comboBoxSexEdit.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.comboBoxSexEdit.Location = new System.Drawing.Point(282, 37);
            this.comboBoxSexEdit.Name = "comboBoxSexEdit";
            this.comboBoxSexEdit.Size = new System.Drawing.Size(96, 21);
            this.comboBoxSexEdit.TabIndex = 0;
            // 
            // buttonResetText
            // 
            this.buttonResetText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetText.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonResetText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetText.ForeColor = System.Drawing.Color.White;
            this.buttonResetText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonResetText.Location = new System.Drawing.Point(498, 111);
            this.buttonResetText.Name = "buttonResetText";
            this.buttonResetText.Size = new System.Drawing.Size(77, 35);
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
            this.buttonEdit.Location = new System.Drawing.Point(415, 111);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(77, 35);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Thêm";
            this.buttonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // comboBoxGroupEdit
            // 
            this.comboBoxGroupEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGroupEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroupEdit.FormattingEnabled = true;
            this.comboBoxGroupEdit.Location = new System.Drawing.Point(78, 38);
            this.comboBoxGroupEdit.Name = "comboBoxGroupEdit";
            this.comboBoxGroupEdit.Size = new System.Drawing.Size(117, 21);
            this.comboBoxGroupEdit.TabIndex = 0;
            // 
            // textBoxNameEdit
            // 
            this.textBoxNameEdit.Location = new System.Drawing.Point(78, 108);
            this.textBoxNameEdit.Name = "textBoxNameEdit";
            this.textBoxNameEdit.Size = new System.Drawing.Size(258, 20);
            this.textBoxNameEdit.TabIndex = 2;
            // 
            // textBoxMSSVEdit
            // 
            this.textBoxMSSVEdit.Location = new System.Drawing.Point(78, 82);
            this.textBoxMSSVEdit.Name = "textBoxMSSVEdit";
            this.textBoxMSSVEdit.Size = new System.Drawing.Size(114, 20);
            this.textBoxMSSVEdit.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(433, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Đoàn viên:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gold;
            this.label7.Location = new System.Drawing.Point(81, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(36, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Tên:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(226, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Giới tính:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Gold;
            this.label10.Location = new System.Drawing.Point(81, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(24, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "MSSV:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(19, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Chi đoàn:";
            // 
            // panelDefault
            // 
            this.panelDefault.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDefault.Controls.Add(this.panelRadio);
            this.panelDefault.Controls.Add(this.comboBoxSex);
            this.panelDefault.Controls.Add(this.comboBoxGroup);
            this.panelDefault.Controls.Add(this.label3);
            this.panelDefault.Controls.Add(this.labelName);
            this.panelDefault.Controls.Add(this.label1);
            this.panelDefault.Controls.Add(this.label4);
            this.panelDefault.Controls.Add(this.labelMSSV);
            this.panelDefault.Controls.Add(this.label5);
            this.panelDefault.Controls.Add(this.label2);
            this.panelDefault.Location = new System.Drawing.Point(59, 15);
            this.panelDefault.Name = "panelDefault";
            this.panelDefault.Size = new System.Drawing.Size(594, 163);
            this.panelDefault.TabIndex = 1;
            // 
            // panelRadio
            // 
            this.panelRadio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRadio.Controls.Add(this.radioButtonNot);
            this.panelRadio.Controls.Add(this.radioButtonHave);
            this.panelRadio.Controls.Add(this.radioButtonAllMember);
            this.panelRadio.Location = new System.Drawing.Point(498, 25);
            this.panelRadio.Name = "panelRadio";
            this.panelRadio.Size = new System.Drawing.Size(83, 100);
            this.panelRadio.TabIndex = 5;
            // 
            // radioButtonNot
            // 
            this.radioButtonNot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonNot.AutoSize = true;
            this.radioButtonNot.ForeColor = System.Drawing.Color.White;
            this.radioButtonNot.Location = new System.Drawing.Point(13, 37);
            this.radioButtonNot.Name = "radioButtonNot";
            this.radioButtonNot.Size = new System.Drawing.Size(56, 17);
            this.radioButtonNot.TabIndex = 2;
            this.radioButtonNot.Text = "Không";
            this.radioButtonNot.UseVisualStyleBackColor = true;
            // 
            // radioButtonHave
            // 
            this.radioButtonHave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonHave.AutoSize = true;
            this.radioButtonHave.ForeColor = System.Drawing.Color.White;
            this.radioButtonHave.Location = new System.Drawing.Point(13, 14);
            this.radioButtonHave.Name = "radioButtonHave";
            this.radioButtonHave.Size = new System.Drawing.Size(38, 17);
            this.radioButtonHave.TabIndex = 2;
            this.radioButtonHave.Text = "Có";
            this.radioButtonHave.UseVisualStyleBackColor = true;
            this.radioButtonHave.CheckedChanged += new System.EventHandler(this.radioButtonHave_CheckedChanged);
            // 
            // radioButtonAllMember
            // 
            this.radioButtonAllMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonAllMember.AutoSize = true;
            this.radioButtonAllMember.Checked = true;
            this.radioButtonAllMember.ForeColor = System.Drawing.Color.White;
            this.radioButtonAllMember.Location = new System.Drawing.Point(13, 60);
            this.radioButtonAllMember.Name = "radioButtonAllMember";
            this.radioButtonAllMember.Size = new System.Drawing.Size(56, 17);
            this.radioButtonAllMember.TabIndex = 2;
            this.radioButtonAllMember.TabStop = true;
            this.radioButtonAllMember.Text = "Tất cả";
            this.radioButtonAllMember.UseVisualStyleBackColor = true;
            this.radioButtonAllMember.CheckedChanged += new System.EventHandler(this.radioButtonAllMember_CheckedChanged);
            // 
            // comboBoxSex
            // 
            this.comboBoxSex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSex.FormattingEnabled = true;
            this.comboBoxSex.Items.AddRange(new object[] {
            "Tất cả",
            "Nam",
            "Nữ"});
            this.comboBoxSex.Location = new System.Drawing.Point(299, 36);
            this.comboBoxSex.Name = "comboBoxSex";
            this.comboBoxSex.Size = new System.Drawing.Size(100, 21);
            this.comboBoxSex.TabIndex = 0;
            this.comboBoxSex.SelectedIndexChanged += new System.EventHandler(this.comboBoxSex_SelectedIndexChanged);
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(84, 36);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGroup.TabIndex = 0;
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroup_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(433, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đoàn viên:";
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoSize = true;
            this.labelName.ForeColor = System.Drawing.Color.Gold;
            this.labelName.Location = new System.Drawing.Point(81, 111);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 13);
            this.labelName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(226, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giới tính:";
            // 
            // labelMSSV
            // 
            this.labelMSSV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMSSV.AutoSize = true;
            this.labelMSSV.ForeColor = System.Drawing.Color.Gold;
            this.labelMSSV.Location = new System.Drawing.Point(81, 85);
            this.labelMSSV.Name = "labelMSSV";
            this.labelMSSV.Size = new System.Drawing.Size(0, 13);
            this.labelMSSV.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(24, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "MSSV:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chi đoàn:";
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
            this.buttonAdd.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonAdd.Size = new System.Drawing.Size(91, 39);
            this.buttonAdd.TabIndex = 2;
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
            this.buttonUpdate.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonUpdate.Size = new System.Drawing.Size(91, 39);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Tag = "update";
            this.buttonUpdate.Text = "Sửa";
            this.buttonUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.dataGridViewStudent);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 197);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(1000, 438);
            this.panelData.TabIndex = 2;
            // 
            // dataGridViewStudent
            // 
            this.dataGridViewStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStudent.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(77)))), ((int)(((byte)(108)))));
            this.dataGridViewStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MSSV,
            this.Name1,
            this.Sex1,
            this.Group1,
            this.IsMember1});
            this.dataGridViewStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStudent.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStudent.Name = "dataGridViewStudent";
            this.dataGridViewStudent.Size = new System.Drawing.Size(1000, 438);
            this.dataGridViewStudent.TabIndex = 0;
            this.dataGridViewStudent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudent_CellClick);
            // 
            // MSSV
            // 
            this.MSSV.DataPropertyName = "MSSV";
            this.MSSV.HeaderText = "MSSV";
            this.MSSV.Name = "MSSV";
            this.MSSV.ReadOnly = true;
            // 
            // Name1
            // 
            this.Name1.DataPropertyName = "ten";
            this.Name1.HeaderText = "Tên";
            this.Name1.Name = "Name1";
            this.Name1.ReadOnly = true;
            // 
            // Sex1
            // 
            this.Sex1.DataPropertyName = "gioiTinh";
            this.Sex1.HeaderText = "Giới tính";
            this.Sex1.Name = "Sex1";
            this.Sex1.ReadOnly = true;
            this.Sex1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Group1
            // 
            this.Group1.DataPropertyName = "chiDoan";
            this.Group1.HeaderText = "Chi đoàn";
            this.Group1.Name = "Group1";
            this.Group1.ReadOnly = true;
            // 
            // IsMember1
            // 
            this.IsMember1.DataPropertyName = "doanVien";
            this.IsMember1.HeaderText = "Đoàn viên";
            this.IsMember1.Name = "IsMember1";
            this.IsMember1.ReadOnly = true;
            // 
            // FormStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(77)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(1000, 635);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelBottom);
            this.Name = "FormStudent";
            this.Text = "FormStudent";
            this.Load += new System.EventHandler(this.FormStudent_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            this.panelRadioEdit.ResumeLayout(false);
            this.panelRadioEdit.PerformLayout();
            this.panelDefault.ResumeLayout(false);
            this.panelDefault.PerformLayout();
            this.panelRadio.ResumeLayout(false);
            this.panelRadio.PerformLayout();
            this.panelData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.DataGridView dataGridViewStudent;
        private System.Windows.Forms.Panel panelDefault;
        private System.Windows.Forms.Panel panelRadio;
        private System.Windows.Forms.RadioButton radioButtonNot;
        private System.Windows.Forms.RadioButton radioButtonHave;
        private System.Windows.Forms.RadioButton radioButtonAllMember;
        private System.Windows.Forms.ComboBox comboBoxSex;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsMember1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelMSSV;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Button buttonExitEdit;
        private System.Windows.Forms.Panel panelRadioEdit;
        private System.Windows.Forms.RadioButton radioButtonNoEdit;
        private System.Windows.Forms.RadioButton radioButtonHaveEdit;
        private System.Windows.Forms.ComboBox comboBoxSexEdit;
        private System.Windows.Forms.Button buttonResetText;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ComboBox comboBoxGroupEdit;
        private System.Windows.Forms.TextBox textBoxNameEdit;
        private System.Windows.Forms.TextBox textBoxMSSVEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}