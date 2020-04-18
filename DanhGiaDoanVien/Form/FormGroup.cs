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

namespace DanhGiaDoanVien
{
    public partial class FormGroup : Form
    {
        private string currentIdGroup = "";
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
        void LoadListGroup()
        {
            dataGridViewGroup.DataSource = GroupDAO.Instance.GetListGroup();
        }

        void CreateGroup(string idGroup, string name)
        {
            int result;
            result = GroupDAO.Instance.AddGroup(idGroup, name);
            if (result > 0)
            {
                LoadListGroup();
            }
            else if (result == -1)
            {
                MessageBox.Show("ID mà bạn nhập đã được sử dụng!", "Trùng ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Thất bại, thử lại sau", "Đã xảy ra lỗi");
            }
        }

        void UpdateGroup(string idGroup, string name)
        {
            int result;
            result = GroupDAO.Instance.UpdateGroup(idGroup, name);
            if (result > 0)
            {
                LoadListGroup();
            }
            else
            {
                MessageBox.Show("Thất bại, thử lại sau", "Đã xảy ra lỗi");
            }
        }

        void DeleteGroup(string idGroup)
        {
            int result;
            result = GroupDAO.Instance.DeleteGroup(idGroup);
            if (result > 0)
            {
                LoadListGroup();
            }
            else
            {
                MessageBox.Show("Thất bại, thử lại sau", "Đã xảy ra lỗi");
            }
        }

        void AddMemberToGroup(Teacher[] teacher, string idGroup) 
        {
            //Đổi id chi đoàn của giảng viên hoặc sinh viên thành một id mới, chi đoàn cũ sẽ giảm số thành viên, chi đoàn này sẽ tăng thành viên
            GroupDAO.Instance.AddMemberToGroup(teacher, idGroup);
        }

        void AddMemberToGroup(Student[] student, string idGroup)
        {
            //Đổi id chi đoàn của giảng viên hoặc sinh viên thành một id mới, chi đoàn cũ sẽ giảm số thành viên, chi đoàn này sẽ tăng thành viên
            GroupDAO.Instance.AddMemberToGroup(student, idGroup);
        }
        #endregion
        void LoadForm()
        {
            LoadListGroup();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
        }

        #region method
        void AddAndUpdateState()
        {
            //Show the panel
            panelEdit.Visible = true;
            //Button in panel
            AcceptButton = buttonEdit;
            buttonEdit.Text = currentEditState;
            buttonResetText.Visible = true;
            //Change Location button
            buttonEdit.Location = new Point(buttonResetText.Location.X - 83, buttonResetText.Location.Y);
            //Other controls
            textBoxMCDEdit.Enabled = true;
            textBoxMCDEdit.ReadOnly = false;
            textBoxNameEdit.Enabled = true;
            textBoxNameEdit.ReadOnly = false;
            panelEdit.Enabled = true;
        }

        void ChangeState(Button btn)
        {
            if (btn.Tag.ToString() == "add")
            {
                currentEditState = EditState.add;
                AddAndUpdateState();
            }
            else if (btn.Tag.ToString() == "update")
            {
                currentEditState = EditState.update;
                AddAndUpdateState();
                textBoxMCDEdit.Enabled = false;
            }
            else if (btn.Tag.ToString() == "delete")
            {
                currentEditState = EditState.delete;
                //Show the panel
                panelEdit.Visible = true;
                //Button in panel
                AcceptButton = buttonEdit;
                buttonResetText.Visible = false;
                buttonEdit.Text = currentEditState;
                //Change Location button
                buttonEdit.Location = buttonResetText.Location;
                //Other controls
                textBoxMCDEdit.Enabled = false;
                textBoxNameEdit.Enabled = false;
            }
            else if (btn.Tag.ToString() == "exitEdit")
            {
                //AcceptButton
                AcceptButton = null;
                //Hide the panel edit
                panelEdit.Visible = false;
            }
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
                        LoadListGroup();
                    }
                    else if (result == -1)
                    {
                        MessageBox.Show("Mã chi đoàn mà bạn nhập đã tồn tại!", "Trùng mã chi đoàn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Thất bại, thử lại sau", "Đã xảy ra lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa điền đủ thông tin", "Đã xảy ra lỗi");
                }
            }
            else if (currentEditState == EditState.update)
            {
                if (textBoxMCDEdit.Text != "" && textBoxNameEdit.Text != "")
                {
                    if (GroupDAO.Instance.UpdateGroup(textBoxMCDEdit.Text, textBoxNameEdit.Text) != 0) { LoadListGroup(); }
                    else
                    {
                        MessageBox.Show("Thất bại, thử lại sau", "Đã xảy ra lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa điền đủ thông tin", "Đã xảy ra lỗi");
                }
            }
            else if (currentEditState == EditState.delete)
            {
                if (textBoxMCDEdit.Text != "")
                {
                    DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rs == DialogResult.Yes)
                    {
                        if (GroupDAO.Instance.DeleteGroup(textBoxMCDEdit.Text) != 0) { LoadListGroup(); }
                        else
                        {
                            MessageBox.Show("Thất bại, thử lại sau", "Đã xảy ra lỗi");
                        }
                    }
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

        private void dataGridViewGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewGroup.CurrentRow.Selected = true;
            try
            {
                currentIdGroup = dataGridViewGroup.Rows[e.RowIndex].Cells["id"].Value.ToString();
                textBoxID.Text = dataGridViewGroup.Rows[e.RowIndex].Cells["id"].Value.ToString();
                textBoxMCDEdit.Text = dataGridViewGroup.Rows[e.RowIndex].Cells["id"].Value.ToString();
                textBoxName.Text = dataGridViewGroup.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
                textBoxNameEdit.Text = dataGridViewGroup.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
            }
            catch { }
            
            LoadMember(currentIdGroup);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
        }

        private void buttonResetText_Click(object sender, EventArgs e)
        {
            ResetTextEdit();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ExecuteEditCommand();
        }

        private void buttonExitEdit_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
        }
    }
}
