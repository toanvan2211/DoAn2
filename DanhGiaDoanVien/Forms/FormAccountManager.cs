using DanhGiaDoanVien.DAO;
using DanhGiaDoanVien.DTO;
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
    public partial class FormAccountManager : Form
    {
        Account currentAccount = new Account();

        public FormAccountManager()
        {
            InitializeComponent();
        }

        #region method
        void LoadListAccount()
        {
            dataGridViewAccount.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void LoadComboBoxTeacher()
        {
            comboBoxIdTeacher.Items.Clear();
            DataTable data = AccountDAO.Instance.GetListTeacherNoAccount();
            comboBoxIdTeacher.Items.Add("");
            foreach (DataRow item in data.Rows)
            {
                comboBoxIdTeacher.Items.Add(item["MSGV"].ToString());
            }
        }

        bool CheckUserNameIsExist(string userNameCheck)
        {
            bool isExist = false;
            foreach (DataGridViewRow row in dataGridViewAccount.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(userNameCheck))
                {
                    row.Selected = true;
                    isExist = true;
                    break;
                }
            }
            return isExist;
        }

        void AddAccount()
        {
            if (textBoxUserName.Text != "" && textBoxPassword.Text != "")
            {
                if (CheckUserNameIsExist(textBoxUserName.Text))
                {
                    MessageBox.Show("Đã tồn tại tài khoản này. Vui lòng nhập một tên tài khoản khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (textBoxUserName.Text.Length < 5)
                    {
                        MessageBox.Show("Tài khoản phải dài hơn 5 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Account addAC = new Account(textBoxUserName.Text, textBoxPassword.Text, comboBoxIdTeacher.Text, comboBoxPermission.Text);
                        AccountDAO.Instance.CreateAccount(addAC);
                        LoadListAccount();
                        LoadComboBoxTeacher();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void EditAccount()
        {
            if (textBoxUserName.Text != "")
            {
                if (CheckUserNameIsExist(textBoxUserName.Text))
                {
                    if ((textBoxPassword.Text == "" && checkBoxEditPassword.Checked))
                    {
                        MessageBox.Show("Mật khẩu phải chứa ít nhất 1 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Account addAC = new Account(textBoxUserName.Text, textBoxPassword.Text, comboBoxIdTeacher.Text, comboBoxPermission.Text);
                        AccountDAO.Instance.EditAccount(addAC);
                        LoadListAccount();
                        LoadComboBoxTeacher();
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại tài khoản này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void DeleteAccount()
        {
            if (textBoxUserName.Text != "")
            {
                if (CheckUserNameIsExist(textBoxUserName.Text))
                {
                    DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        AccountDAO.Instance.DeleteAccount(textBoxUserName.Text);
                        LoadListAccount();
                        LoadComboBoxTeacher();
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại tài khoản này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        private void FromAccountManager_Load(object sender, EventArgs e)
        {
            LoadListAccount();
            LoadComboBoxTeacher();

            comboBoxPermission.SelectedIndex = 1;
        }

        private void buttonExitEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddAccount();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            EditAccount();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteAccount();
        }

        private void dataGridViewAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentAccount.User = dataGridViewAccount.Rows[e.RowIndex].Cells["UserName1"].Value.ToString();
            currentAccount.IdTeacher = dataGridViewAccount.Rows[e.RowIndex].Cells["IdTeacher1"].Value.ToString();
            currentAccount.TypeAccount = dataGridViewAccount.Rows[e.RowIndex].Cells["Permission1"].Value.ToString();

            textBoxUserName.Text = currentAccount.User;
            comboBoxIdTeacher.Text = currentAccount.IdTeacher;
            comboBoxPermission.Text = currentAccount.TypeAccount;
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
