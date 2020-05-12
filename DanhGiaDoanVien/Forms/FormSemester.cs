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
    public partial class FormSemester : Form
    {
        private string currentEditState = EditState.none;
        private int currentIndex = -1;
        private Semester currentSemester = new Semester();

        private struct EditState
        {
            public static string none = "Không";
            public static string add = "Thêm";
            public static string update = "Sửa";
            public static string delete = "Xóa";
        }

        #region method
        void LoadInterface()
        {
            if (FormMain.typeAccount == "giảng viên")
                panelAdmin.Visible = false;
        }
        void LoadListSemester()
        {
            dataGridViewSemester.DataSource = SemesterDAO.Instance.GetListSemester();
        }

        void AddAndUpdateState()
        {
            //Show the panel
            panelEdit.Visible = true;
            panelDefault.Visible = false;
            //Location
            panelEdit.Location = panelDefault.Location;
            //Button in panel
            AcceptButton = buttonEdit;
            buttonEdit.Text = currentEditState;
            buttonResetText.Visible = true;
            //Other controls
            textBoxIdSemester.Enabled = true;
            textBoxIdSemester.ReadOnly = false;
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
                textBoxIdSemester.Enabled = false;
            }
            else if (btn.Tag.ToString() == "delete")
            {
                currentEditState = EditState.delete;
                //Show the panel
                panelEdit.Visible = true;
                panelDefault.Visible = false;
                //Location
                panelEdit.Location = panelDefault.Location;
                //Button in panel
                buttonEdit.FlatAppearance.BorderColor = Color.Red;
                buttonEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
                buttonEdit.FlatAppearance.MouseDownBackColor = Color.Red;
                AcceptButton = buttonEdit;
                buttonResetText.Visible = false;
                buttonEdit.Text = currentEditState;
                //Other controls
                textBoxIdSemester.Enabled = false;
                textBoxNameEdit.Enabled = false;
            }
            else if (btn.Tag.ToString() == "exitEdit")
            {
                //AcceptButton
                AcceptButton = null;
                //Location
                panelEdit.Location = new Point(256, 182);
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
                if (textBoxIdSemester.Text != "" && textBoxNameEdit.Text != "")
                {
                    int result = SemesterDAO.Instance.AddSemester(textBoxIdSemester.Text, textBoxNameEdit.Text);
                    if (result > 0)
                    {
                        string stringNotification = "năm học có mã: " + textBoxIdSemester.Text;
                        textBoxIdSemester.ResetText();
                        textBoxNameEdit.ResetText();
                        LoadListSemester();

                        Alert(stringNotification, FormNotified.enmType.Insert);
                    }
                    else if (result == -1)
                    {
                        MessageBox.Show("Mã năm học mà bạn nhập đã tồn tại!", "Trùng mã năm học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Thất bại, thử lại sau", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa điền đủ thông tin", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (currentEditState == EditState.update)
            {
                if (currentSemester.Name == textBoxNameEdit.Text)
                {
                    MessageBox.Show("Thông tin không có sự thay đổi!", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (textBoxIdSemester.Text != "" && textBoxNameEdit.Text != "")
                {
                    if (SemesterDAO.Instance.UpdateSemester(textBoxIdSemester.Text, textBoxNameEdit.Text) != 0) 
                    {
                        string stringNotification = "năm học có mã: " + textBoxIdSemester.Text;

                        currentSemester.Name = textBoxNameEdit.Text;
                        LoadListSemester();

                        Alert(stringNotification, FormNotified.enmType.Edit);
                    }
                    else
                    {
                        MessageBox.Show("Thất bại, thử lại sau", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa điền đủ thông tin", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (currentEditState == EditState.delete)
            {
                if (textBoxIdSemester.Text != "")
                {
                    DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rs == DialogResult.Yes)
                    {
                        int result = SemesterDAO.Instance.DeleteSemester(textBoxIdSemester.Text);
                        if (result > 0)
                        {
                            string stringNotification = "năm học có mã: " + textBoxIdSemester.Text;
                            LoadListSemester();

                            Alert(stringNotification, FormNotified.enmType.Delete);
                        }
                        else if (result == -797)
                        {
                            MessageBox.Show("Năm học này đã tồn tại đánh giá trong hệ thống, không thể xóa!", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Thất bại, thử lại sau", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn năm học cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        void ResetTextEdit()
        {
            textBoxIdSemester.ResetText();
            textBoxNameEdit.ResetText();
        }

        void LoadMember(string idGroup)
        {
            DataTable dt = StudentDAO.Instance.GetListStudentByGroupID(idGroup);
            if (dt.Rows.Count != 0)
                dataGridViewSemester.DataSource = dt;
            else
            {
                dt = TeacherDAO.Instance.GetListTeacherByGroupID(idGroup);
                dataGridViewSemester.DataSource = dt;
            }
        }

        void LoadGroupInSemester()
        {
            dataGridViewGroup.DataSource = SemesterDAO.Instance.GetGroupInSemester(currentSemester.Id);
        }

        #endregion

        public FormSemester()
        {
            InitializeComponent();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ExecuteEditCommand();
        }

        private void buttonResetText_Click(object sender, EventArgs e)
        {
            ResetText();
        }

        private void buttonExitEdit_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
            LoadListSemester();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
            LoadListSemester();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
            LoadListSemester();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
            LoadListSemester();
        }

        private void dataGridViewSemester_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewSemester.CurrentRow.Selected = true;
            try
            {
                currentIndex = e.RowIndex;
                labelID.Text = dataGridViewSemester.Rows[e.RowIndex].Cells["Id1"].Value.ToString();
                textBoxIdSemester.Text = dataGridViewSemester.Rows[e.RowIndex].Cells["Id1"].Value.ToString();
                labelName.Text = dataGridViewSemester.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
                textBoxNameEdit.Text = dataGridViewSemester.Rows[e.RowIndex].Cells["Name1"].Value.ToString();

                currentSemester.Id = labelID.Text;
                currentSemester.Name = labelName.Text;                
            }
            catch
            {
                currentIndex = -1;
            }

            if (currentIndex != -1)
            {
                LoadGroupInSemester();
            }
        }

        private void FormSemester_Load(object sender, EventArgs e)
        {
            LoadListSemester();
            LoadInterface();
        }

        private void textBoxIdSemester_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }
    }
}
