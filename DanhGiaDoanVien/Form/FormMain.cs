using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanhGiaDoanVien
{
    public partial class FormMain : Form
    {
        //Fields
        private Button currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public FormMain()
        {
            InitializeComponent();
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
            //Visible
            panelSubMenuEvaluate.Visible = false;
        }

        private struct RGBColors
        {
            public static Color colorEvaluate = Color.FromArgb(249, 118, 176);
            public static Color colorTeacher = Color.FromArgb(253, 138, 114);
            public static Color colorStudent = Color.FromArgb(147, 255, 119);
            public static Color colorEvaluate1 = Color.FromArgb(249, 88, 155);
            public static Color colorGroup = Color.FromArgb(24, 161, 251);
        }

        //Methods        
        private void ActivateButton(object senderBtn, Color color, Image img)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (Button)senderBtn;
                currentBtn.BackColor = Color.FromArgb(58, 59, 85);
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
            }
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                currentBtn.ForeColor = Color.White;
                currentBtn = (Button)senderBtn;
                currentBtn.BackColor = Color.FromArgb(58, 59, 85);
                currentBtn.ForeColor = color;
                //Label Title current child form
                labelCurrentChildForm.Text = currentBtn.Text;
                labelCurrentChildForm.ForeColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(43, 44, 63);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                if (currentBtn.Tag.ToString() != "not") 
                    currentBtn.Image = (Image)currentBtn.Tag;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                //Borderleft
                leftBorderBtn.Visible = false;
            }
        }
        private void OpenChildForm(Form childForm)
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
                DisableButton();
                currentBtn = (Button)sender;
                DisableButton();
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
            ActivateButton(sender, Color.FromArgb(255, 167, 51));
            OpenChildForm(new FormEvaluateTeacher());
        }

        private void buttonEvaluateStudent_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 167, 51));
            OpenChildForm(new FormEvaluateStudent());
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            DisableButton();
            panelSubMenuEvaluate.Visible = false;
            if (currentChildForm != null)
                currentChildForm.Close();
            pictureBoxIconCurrent.Image = Properties.Resources.icons8_home_35px_1;
            labelCurrentChildForm.ForeColor = Color.White;
            labelCurrentChildForm.Text = "Trang chủ";
        }
        private void panelSubMenuEvaluate_VisibleChanged(object sender, EventArgs e)
        {
            if (panelSubMenuEvaluate.Visible == false)
            {
                buttonEvaluate.BackColor = Color.FromArgb(43, 44, 63);
                buttonEvaluate.ForeColor = Color.White;
                buttonEvaluate.TextAlign = ContentAlignment.MiddleLeft;
                buttonEvaluate.Image = (Image)buttonEvaluate.Tag;
                buttonEvaluate.TextImageRelation = TextImageRelation.ImageBeforeText;
                buttonEvaluate.ImageAlign = ContentAlignment.MiddleLeft;
                //Borderleft
                leftBorderBtn.Visible = false;
            }
        }
    }
}
