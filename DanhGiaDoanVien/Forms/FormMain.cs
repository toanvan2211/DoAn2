using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DanhGiaDoanVien.DAO;
using DanhGiaDoanVien.DTO;
using DanhGiaDoanVien.Forms;
using DanhGiaDoanVien.Other_Class;

namespace DanhGiaDoanVien
{
    public partial class FormMain : Form
    {
        //Fields
        private Button currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private bool checkLogOut = false;
        private InfoAccount infoAccount;
        public string userName;
        public string password;
        public static string typeAccount;
        
        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(InfoAccount info)
        {
            InitializeComponent();
            this.infoAccount = info;
            typeAccount = info.TypeAccount;

            if (!string.IsNullOrEmpty(infoAccount.Name))
            {
                labelName.Text = infoAccount.Name;
            }
            else
            {
                labelName.Text = "Không tên";
            }
        }

        private struct RGBColors
        {
            public static Color colorEvaluate = Color.FromArgb(249, 118, 176);
            public static Color colorTeacher = Color.FromArgb(253, 138, 114);
            public static Color colorStudent = Color.FromArgb(147, 255, 119);
            public static Color colorEvaluate1 = Color.FromArgb(249, 88, 155);
            public static Color colorGroup = Color.FromArgb(24, 161, 251);
            public static Color colorSemester = Color.FromArgb(255, 219, 77);
        }

        #region method
        void ActivateButton(object senderBtn, Color color, Image img)
        {
            bool check = false;
            if (currentBtn != null)
            {
                if (currentBtn.Tag.ToString() == "not")
                {
                    DisableButton(2);
                    panelSubMenuEvaluate.Visible = false;

                    check = true;
                }
            }
            if (senderBtn != null)
            {
                if (check == false)
                    DisableButton(1);
                currentBtn = (Button)senderBtn;
                currentBtn.BackColor = Color.FromArgb(16, 18, 20);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.Image = img;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon Current Child Form
                pictureBoxIconCurrent.Image = img;
                //Label Title current child form
                labelCurrentChildForm.Text = currentBtn.Text;
                labelCurrentChildForm.ForeColor = color;

                //panel shadow
                panelShadow1.BackColor = color;
            }
        }

        void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null && currentBtn.Tag.ToString() == "not")
            {
                DisableButton(2);
                currentBtn = (Button)senderBtn;
                currentBtn.BackColor = Color.FromArgb(22, 25, 29);
                currentBtn.ForeColor = color;

                //Label Title current child form
                labelCurrentChildForm.Text = currentBtn.Text;
                labelCurrentChildForm.ForeColor = color;
            }
            else if (((Button)senderBtn).Tag.ToString() == "not")
            {
                currentBtn = (Button)senderBtn;
                //Label Title current child form
                currentBtn.BackColor = Color.FromArgb(22, 25, 29);
                currentBtn.ForeColor = color;
                labelCurrentChildForm.Text = currentBtn.Text;
                labelCurrentChildForm.ForeColor = color;
            }
            //Panel Shadow
            panelShadow1.BackColor = color;
        }

        void DisableButton(int type)
        {
            if (currentBtn != null && type == 1)
            {
                currentBtn.BackColor = Color.FromArgb(26, 30, 34);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.Image = (Image)currentBtn.Tag;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                //Borderleft
                leftBorderBtn.Visible = false;
            }
            else if (currentBtn != null && type == 2)
            {
                currentBtn.BackColor = Color.FromArgb(33, 38, 43);
                currentBtn.ForeColor = Color.White;
            }
        }
        void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        void LoadStatistical()
        {
            int[] statis = new int[6];
            statis = DataProvider.Instance.GetStatistical();

            labelTeacher.Text = statis[0].ToString();
            labelStudent.Text = statis[1].ToString();
            labelGroup.Text = statis[2].ToString();
            labelSemester.Text = statis[3].ToString();
            labelEvaluation.Text = statis[4].ToString();
            labelDoneScores.Text = statis[5].ToString();
        }

        #endregion

        private void FormMain_Load(object sender, EventArgs e)
        {
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //icon tag
            buttonTeacher.Tag = Properties.Resources.icons8_school_director_35px_1;
            buttonStudent.Tag = Properties.Resources.icons8_read_online_35px_1;
            buttonGroup.Tag = Properties.Resources.icons8_teamwork_35px;
            buttonEvaluate.Tag = Properties.Resources.icons8_report_card_35px;
            buttonSemester.Tag = Properties.Resources.icons8_year_view_35px_1;
            //Visible
            panelSubMenuEvaluate.Visible = false;

            LoadStatistical();
        }

        private void buttonTeacher_Click(object sender, EventArgs e)
        {
            panelSubMenuEvaluate.Visible = false;
            ActivateButton(sender, RGBColors.colorTeacher, Properties.Resources.icons8_school_director_35px);
            OpenChildForm(new FormTeacher());
        }

        private void buttonStudent_Click(object sender, EventArgs e)
        {
            panelSubMenuEvaluate.Visible = false;
            ActivateButton(sender, RGBColors.colorStudent, Properties.Resources.icons8_read_online_35px_3);
            OpenChildForm(new FormStudent());
        }

        private void buttonGroup_Click(object sender, EventArgs e)
        {
            panelSubMenuEvaluate.Visible = false;
            ActivateButton(sender, RGBColors.colorGroup, Properties.Resources.icons8_teamwork_35px_1);
            OpenChildForm(new FormGroup());
        }

        private void buttonEvaluate_Click(object sender, EventArgs e)
        {
            if (panelSubMenuEvaluate.Visible == true)
            {
                if (currentBtn.Tag.ToString() != "not")
                    DisableButton(1);
                else
                    DisableButton(2);
                currentBtn = (Button)sender;
                DisableButton(1);
                panelSubMenuEvaluate.Visible = false;
            }
            else
            {
                ActivateButton(sender, RGBColors.colorEvaluate, Properties.Resources.icons8_report_card_35px_1);
                panelSubMenuEvaluate.Visible = true;
            }
        }

        private void buttonEvaluateTeacher_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 213, 77));
            OpenChildForm(new FormEvaluateTeacher());
        }

        private void buttonEvaluateStudent_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 213, 77));
            OpenChildForm(new FormEvaluateStudent());
        }

        private void buttonEvaluateGroup_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 213, 77));
            OpenChildForm(new FormEvaluateGroup());
        }

        private void buttonOldScores_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 213, 77));
            OpenChildForm(new FormOldScores());
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            if (currentBtn != null)
            {
                if (currentBtn.Tag.ToString() != "not")
                    DisableButton(1);
                else
                    DisableButton(2);
                panelSubMenuEvaluate.Visible = false;
                if (currentChildForm != null)
                    currentChildForm.Close();
                pictureBoxIconCurrent.Image = Properties.Resources.icons8_home_35px_1;
                labelCurrentChildForm.ForeColor = Color.White;
                labelCurrentChildForm.Text = "Trang chủ";
            }
        }
        private void panelSubMenuEvaluate_VisibleChanged(object sender, EventArgs e)
        {
            if (panelSubMenuEvaluate.Visible == false)
            {
                buttonEvaluate.BackColor = Color.FromArgb(26, 30, 34);
                buttonEvaluate.ForeColor = Color.White;
                buttonEvaluate.TextAlign = ContentAlignment.MiddleLeft;
                buttonEvaluate.Image = (Image)buttonEvaluate.Tag;
                buttonEvaluate.TextImageRelation = TextImageRelation.ImageBeforeText;
                buttonEvaluate.ImageAlign = ContentAlignment.MiddleLeft;
                //Borderleft
                leftBorderBtn.Visible = false;
            }
        }

        private void buttonSemester_Click(object sender, EventArgs e)
        {
            panelSubMenuEvaluate.Visible = false;
            ActivateButton(sender, RGBColors.colorSemester, Properties.Resources.icons8_year_view_35px);
            OpenChildForm(new FormSemester());
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkLogOut == false)
            {
                Properties.Settings.Default.UserName = userName;
                Properties.Settings.Default.Password = password;
                Properties.Settings.Default.IsLogOut = false;
                Properties.Settings.Default.Save();
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            checkLogOut = true;

            if (Properties.Settings.Default.RememberPW == false)
            {
                Properties.Settings.Default.UserName = null;
                Properties.Settings.Default.Password = null;
            }

            Properties.Settings.Default.IsLogOut = true;
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void pictureBoxRefesh_Click(object sender, EventArgs e)
        {
            LoadStatistical();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            labelChangePWNotifed.Text = "";
            panelChangePassword.Visible = true;
            panelMain.Visible = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            panelChangePassword.Visible = false;
            panelMain.Visible = true;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (LoginDAO.Instance.CheckPassword(userName, textBoxOldPassword.Text))
            {
                if (textBoxNewPassword.Text == textBoxReEnterNewPassword.Text)
                {
                    AccountDAO.Instance.ChangePassword(userName, textBoxNewPassword.Text);
                    textBoxOldPassword.ResetText();
                    textBoxNewPassword.ResetText();
                    textBoxReEnterNewPassword.ResetText();
                    labelChangePWNotifed.ForeColor = Color.Gold;

                    labelError1.Visible = false;
                    labelError2.Visible = false;
                    labelError3.Visible = false;
                    labelChangePWNotifed.Text = "Đổi mật khẩu thành công!";

                    password = textBoxNewPassword.Text;
                }
                else
                {
                    labelChangePWNotifed.ForeColor = Color.Red;
                    labelChangePWNotifed.Text = "Mật khẩu mới không trùng khớp";
                    labelError2.Visible = true;
                    labelError3.Visible = true;
                }
            }
            else
            {
                labelChangePWNotifed.ForeColor = Color.Red;
                labelChangePWNotifed.Text = "Mật khẩu cũ không đúng";
                textBoxOldPassword.ResetText();
                labelError1.Visible = true;
            }
        }

        private void textBoxOldPassword_MouseClick(object sender, MouseEventArgs e)
        {
            labelError1.Visible = false;
        }

        private void textBoxNewPassword_MouseClick(object sender, MouseEventArgs e)
        {
            labelError2.Visible = false;
        }

        private void textBoxReEnterNewPassword_MouseClick(object sender, MouseEventArgs e)
        {
            labelError3.Visible = false;
        }

        private void pictureBoxHelp_Click(object sender, EventArgs e)
        {
            using (FormHelp fh = new FormHelp())
            {
                fh.ShowDialog();
            }
        }
    }
}
