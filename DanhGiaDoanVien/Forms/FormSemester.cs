using DanhGiaDoanVien.DAO;
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

        private struct EditState
        {
            public static string none = "Không";
            public static string add = "Thêm";
            public static string update = "Sửa";
            public static string delete = "Xóa";
        }

        #region method
        void LoadListSemester()
        {
            dataGridViewSemester.DataSource = SemesterDAO.Instance.GetListSemester();
        }

        void AddAndUpdateState()
        {
            //Show the panel
            panelEdit.Visible = true;
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
            }
            else if (btn.Tag.ToString() == "update")
            {
                currentEditState = EditState.update;
                AddAndUpdateState();
                textBoxIdSemester.Enabled = false;
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
                //Other controls
                textBoxIdSemester.Enabled = false;
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
                if (textBoxIdSemester.Text != "" && textBoxNameEdit.Text != "")
                {
                    int result = SemesterDAO.Instance.AddSemester(textBoxIdSemester.Text, textBoxNameEdit.Text);
                    if (result > 0)
                    {
                        LoadListSemester();
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
                if (textBoxIdSemester.Text != "" && textBoxNameEdit.Text != "")
                {
                    if (SemesterDAO.Instance.UpdateSemester(textBoxIdSemester.Text, textBoxNameEdit.Text) != 0) 
                    { 
                        LoadListSemester(); 
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
            else if (currentEditState == EditState.delete)
            {
                if (textBoxIdSemester.Text != "")
                {
                    DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rs == DialogResult.Yes)
                    {
                        if (SemesterDAO.Instance.DeleteSemester(textBoxIdSemester.Text) != 0)
                        {
                            LoadListSemester();
                        }
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
                textBoxID.Text = dataGridViewSemester.Rows[e.RowIndex].Cells["Id1"].Value.ToString();
                textBoxIdSemester.Text = dataGridViewSemester.Rows[e.RowIndex].Cells["Id1"].Value.ToString();
                textBoxName.Text = dataGridViewSemester.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
                textBoxNameEdit.Text = dataGridViewSemester.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
            }
            catch { }
        }

        private void FormSemester_Load(object sender, EventArgs e)
        {
            LoadListSemester();
        }
    }
}
