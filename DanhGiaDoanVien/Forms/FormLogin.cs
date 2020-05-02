using DanhGiaDoanVien.DAO;
using DanhGiaDoanVien.DTO;
using DanhGiaDoanVien.Other_Class;
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
    public partial class FormLogin : Form
    {
        private int wrongPassword = 0;
        
        public FormLogin()
        {
            InitializeComponent();
        }

        bool CheckPassword(string userName, string password)
        {
            return LoginDAO.Instance.CheckPassword(userName, password);
        }

        void OpenFormMain(InfoAccount info)
        {
            using (FormMain fm = new FormMain(info))
            {
                fm.userName = textBoxUserName.Text;
                fm.password = textBoxPassword.Text;

                this.Hide();
                fm.ShowDialog();
            }
            if (Properties.Settings.Default.IsLogOut == false)
            {
                this.Close();
            }
            else
            {
                if (Properties.Settings.Default.RememberPW == false)
                    textBoxPassword.ResetText();
                this.Show();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (wrongPassword == 5)
            {
                Properties.Settings.Default.TimeBlock = DateTime.Now.AddMinutes(30);
                Properties.Settings.Default.IsBlockLogin = true;
                Properties.Settings.Default.Save();

                MessageBox.Show("Bạn đăng nhập sai quá 5 lần! Chức năng đăng nhập sẽ bị khóa đến " + Properties.Settings.Default.TimeBlock, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                panelControlLogin.Visible = false; 
                labelBlockLogin.Text = "Bạn đăng nhập sai quá 5 lần! Chức năng đăng nhập sẽ bị khóa đến " + Properties.Settings.Default.TimeBlock;

                timer1.Start();
            }
            else if (CheckPassword(textBoxUserName.Text, textBoxPassword.Text))
            {
                if (checkBoxRemember.Checked)
                {
                    Properties.Settings.Default.RememberPW = true;
                    Properties.Settings.Default.UserName = textBoxUserName.Text;
                    Properties.Settings.Default.Password = textBoxPassword.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.RememberPW = false;
                    Properties.Settings.Default.Save();
                }

                InfoAccount info = LoginDAO.Instance.GetInfo(textBoxUserName.Text);

                OpenFormMain(info);

                labelNotified.Text = "";
            }
            else
            {
                labelNotified.Text = "Sai tài khoản hoặc mật khẩu, vui lòng kiểm tra lại!";
                wrongPassword++;
            }            
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //Properties.Settings.Default.IsBlockLogin = false;
            //Properties.Settings.Default.Save();

            if (Properties.Settings.Default.UserName != string.Empty)
            {
                textBoxUserName.Text = Properties.Settings.Default.UserName;
                textBoxPassword.Text = Properties.Settings.Default.Password;

                if (Properties.Settings.Default.RememberPW)
                    checkBoxRemember.Checked = true;
            }

            if (Properties.Settings.Default.IsLogOut == false)
            {
                InfoAccount info = LoginDAO.Instance.GetInfo(Properties.Settings.Default.UserName);
                if (info == null)
                {
                    MessageBox.Show("Tài khoản của bạn không tồn tại, hoặc đã bị xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    OpenFormMain(info);
                }
            }

            if (Properties.Settings.Default.IsBlockLogin)
            {
                panelControlLogin.Visible = false;
                labelBlockLogin.Text = "Bạn đăng nhập sai quá 5 lần! Chức năng đăng nhập sẽ bị khóa đến " + Properties.Settings.Default.TimeBlock;
            }
            labelNotified.Text = "";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= Properties.Settings.Default.TimeBlock)
            {
                panelControlLogin.Visible = true;
                Properties.Settings.Default.IsBlockLogin = false;
                Properties.Settings.Default.Save();

                labelBlockLogin.Text = "";
            }
        }

        private void textBoxUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
    }
}
