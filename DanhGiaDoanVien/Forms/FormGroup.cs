using DanhGiaDoanVien.DAO;
using DanhGiaDoanVien.DTO;
using DanhGiaDoanVien.Forms;
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
    public partial class FormGroup : Form
    {
        private string currentIdGroup = "";
        private string currentNameGroup = "";
        private string currentEditState = EditState.none;

        private struct EditState
        {
            public static string none = "Không";
            public static string add = "Thêm";
            public static string update = "Sửa";
            public static string delete = "Xóa";
        }

        public FormGroup()
        {
            InitializeComponent();
            LoadForm();
        }
        #region method
        void LoadInterface()
        {
            if (FormMain.typeAccount == "giảng viên")
                panelAdmin.Visible = false;
        }
        void LoadListGroup()
        {
            dataGridViewGroup.DataSource = GroupDAO.Instance.GetListGroup();
        }

        void AddAndUpdateState()
        {
            //Show the panel
            panelDefault.Visible = false;
            panelEdit.Visible = true;
            //Position
            panelEdit.Location = panelDefault.Location;
            //Button in panel
            AcceptButton = buttonEdit;
            buttonEdit.Text = currentEditState;
            buttonResetText.Visible = true;
            //Other controls
            textBoxMCDEdit.Enabled = true;
            textBoxMCDEdit.ReadOnly = false;
            textBoxNameEdit.Enabled = true;
            textBoxNameEdit.ReadOnly = false;
            tabapanel.Enabled = true;
        }

        void ChangeState(Button btn)
        {
            if (btn.Tag.ToString() == "add")
            {
                currentEditState = EditState.add;
                AddAndUpdateState();
                buttonEdit.FlatAppearance.BorderColor = Color.MediumSeaGreen;
                buttonEdit.FlatAppearance.MouseOverBackColor = default;
                buttonEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
            }
            else if (btn.Tag.ToString() == "update")
            {
                currentEditState = EditState.update;
                AddAndUpdateState();
                buttonEdit.FlatAppearance.BorderColor = Color.Aqua;
                buttonEdit.FlatAppearance.MouseOverBackColor = default;
                buttonEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
                textBoxMCDEdit.Enabled = false;
            }
            else if (btn.Tag.ToString() == "delete")
            {
                currentEditState = EditState.delete;
                //Show the panel
                panelEdit.Visible = true;
                panelDefault.Visible = false;
                //Position
                panelEdit.Location = panelDefault.Location;
                //Button in panel
                buttonEdit.FlatAppearance.BorderColor = Color.Red;
                buttonEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
                buttonEdit.FlatAppearance.MouseDownBackColor = Color.Red;
                AcceptButton = buttonEdit;
                buttonResetText.Visible = false;
                buttonEdit.Text = currentEditState;
                //Other controls
                textBoxMCDEdit.Enabled = false;
                textBoxNameEdit.Enabled = false;
            }
            else if (btn.Tag.ToString() == "exitEdit")
            {
                //AcceptButton
                AcceptButton = null;
                //Position
                panelEdit.Location = panelDefault.Location;
                //Hide the panel edit
                panelEdit.Visible = false;
                panelDefault.Visible = true;
            }
        }

        public void Alert(string msg, FormNotified.enmType type)
        {
            FormNotified frm = new FormNotified();
            frm.ShowAlert(msg, type);
        }

        void ExecuteEditCommand()
        {
            if (currentEditState == EditState.add)
            {
                if (textBoxMCDEdit.Text != "" && textBoxNameEdit.Text != "")
                {
                    int result = GroupDAO.Instance.AddGroup(textBoxMCDEdit.Text, textBoxNameEdit.Text);
                    if (result > 0)
                    {
                        string stringNotification = "chi đoàn có mã: " + textBoxMCDEdit.Text;
                        textBoxMCDEdit.ResetText();
                        textBoxNameEdit.ResetText();
                        LoadListGroup();

                        Alert(stringNotification, FormNotified.enmType.Insert);
                    }
                    else if (result == -1)
                    {
                        MessageBox.Show("Mã chi đoàn mà bạn nhập đã tồn tại!", "Trùng mã chi đoàn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Thất bại, thử lại sau!", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa điền đủ thông tin!", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (currentEditState == EditState.update)
            {
                if (textBoxMCDEdit.Text != "")
                {
                    if (textBoxNameEdit.Text == currentNameGroup)
                    {
                        MessageBox.Show("Thông tin không có sự thay đổi!", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (textBoxMCDEdit.Text != "" && textBoxNameEdit.Text != "")
                    {
                        if (GroupDAO.Instance.UpdateGroup(textBoxMCDEdit.Text, textBoxNameEdit.Text) > 0)
                        {
                            string stringNotification = "chi đoàn có mã: " + textBoxMCDEdit.Text;
                            currentNameGroup = textBoxNameEdit.Text;
                            LoadListGroup();

                            Alert(stringNotification, FormNotified.enmType.Edit);
                        }
                        else
                        {
                            MessageBox.Show("Thất bại, thử lại sau!", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa điền đủ thông tin!", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa điền đủ thông tin!", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (currentEditState == EditState.delete)
            {
                if (textBoxMCDEdit.Text != "")
                {
                    DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rs == DialogResult.Yes)
                    {
                        int result = GroupDAO.Instance.DeleteGroup(textBoxMCDEdit.Text);
                        if (result > 0)
                        {
                            string stringNotification = "chi đoàn có mã: " + textBoxMCDEdit.Text;
                            LoadListGroup();

                            Alert(stringNotification, FormNotified.enmType.Delete);
                        }
                        else if (result == -797)
                        {
                            MessageBox.Show("Chi đoàn này đã tồn tại đánh giá trong hệ thống, không thể xóa!", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Thất bại, thử lại sau!", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn chi đoàn cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        void ResetTextEdit()
        {
            textBoxMCDEdit.ResetText();
            textBoxNameEdit.ResetText();
        }

        void LoadMember(string idGroup)
        {
            DataTable dt = StudentDAO.Instance.GetListStudentByGroupID(idGroup);
            if (dt.Rows.Count != 0)
                dataGridViewMember.DataSource = dt;
            else
            {
                dt = TeacherDAO.Instance.GetListTeacherByGroupID(idGroup);
                dataGridViewMember.DataSource = dt;
            }
        }

        #endregion
        void LoadForm()
        {
            LoadListGroup();
            LoadInterface();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
        }

        private void dataGridViewGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewGroup.CurrentRow.Selected = true;
            try
            {
                currentIdGroup = dataGridViewGroup.Rows[e.RowIndex].Cells["id"].Value.ToString();
                currentNameGroup = dataGridViewGroup.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
                labelID.Text = dataGridViewGroup.Rows[e.RowIndex].Cells["id"].Value.ToString();
                textBoxMCDEdit.Text = dataGridViewGroup.Rows[e.RowIndex].Cells["id"].Value.ToString();
                labelName.Text = dataGridViewGroup.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
                textBoxNameEdit.Text = dataGridViewGroup.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
            }
            catch { }
            
            LoadMember(currentIdGroup);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
            LoadListGroup();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
            LoadListGroup();
        }

        private void buttonResetText_Click(object sender, EventArgs e)
        {
            ResetTextEdit();
            LoadListGroup();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ExecuteEditCommand();
        }

        private void buttonExitEdit_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
            LoadListGroup();
        }

        private void dataGridViewMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewMember.CurrentRow.Selected = true;
        }

        private void textBoxMCDEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
    }
}
