using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanhGiaDoanVien.Forms
{
    public partial class FormNotified : Form
    {
        public FormNotified()
        {
            InitializeComponent();
        }

        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Insert,
            Edit,
            Delete
        }

        private int x, y;
        private FormNotified.enmAction action;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;
                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.y < this.Location.Y)
                    {
                        this.Top++;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Top += 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }

        public void ShowAlert(string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 100; i++)
            {
                fname = "alert" + i.ToString();
                FormNotified frm = (FormNotified)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    switch (type)
                    {
                        case enmType.Insert:
                            labelState.Text = "thêm thành công " + msg;
                            break;
                        case enmType.Edit:
                            labelState.Text = "sửa thành công " + msg;
                            break;
                        case enmType.Delete:
                            labelState.Text = "xóa thành công " + msg;
                            break;
                    }
                    this.x = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;

                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            timer1.Start();
        }
    }
}
