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
    public partial class FormStudent : Form
    {
        private string currentGroup = "Tất cả";
        private string currentSex = "Tất cả";
        private string currentIsMember = "Tất cả";
        private string currentEditState = EditState.none;

        private struct EditState
        {
            public static string none = "Không";
            public static string add = "Thêm";
            public static string update = "Sửa";
            public static string delete = "Xóa";
        }

        public FormStudent()
        {
            InitializeComponent();
        }
        private void FormStudent_Load(object sender, EventArgs e)
        {
            LoadGroup();
            currentGroup = "Tất cả";
            comboBoxSex.SelectedIndex = 0;
            LoadListStudent();
        }
        //ComboBox
        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentGroup = comboBoxGroup.Text;
            LoadListStudent();
        }

        private void comboBoxSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSex = comboBoxSex.Text;
            LoadListStudent();
        }

        private void comboBoxGroupEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentGroup = comboBoxGroupEdit.Text;
            LoadListStudent();
        }

        private void comboBoxSexEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSex = comboBoxSexEdit.Text;
            LoadListStudent();
        }
        //RadioButton
        private void radioButtonHave_CheckedChanged(object sender, EventArgs e)
        {
            GetCurrentRadio(panelRadio);
            LoadListStudent();
        }

        private void radioButtonAllMember_CheckedChanged(object sender, EventArgs e)
        {
            GetCurrentRadio(panelRadio);
            LoadListStudent();
        }
        private void radioButtonHaveEdit_CheckedChanged(object sender, EventArgs e)
        {
            GetCurrentRadio(panelRadioEdit);
            LoadListStudent();
        }
        //DataGridView
        private void dataGridViewStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Main panel
                dataGridViewStudent.CurrentRow.Selected = true;
                labelMSSV.Text = dataGridViewStudent.Rows[e.RowIndex].Cells["MSSV"].Value.ToString();
                labelName.Text = dataGridViewStudent.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
                //Edit panel
                textBoxMSSVEdit.Text = dataGridViewStudent.Rows[e.RowIndex].Cells["MSSV"].Value.ToString();
                textBoxNameEdit.Text = dataGridViewStudent.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
            }
            catch { }
        }
        //Button
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ExecuteEditCommand();
        }

        private void buttonResetText_Click(object sender, EventArgs e)
        {
            ResetTextEdit();
        }

        private void buttonExitEdit_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
        }

        #region method
        void GetCurrentRadio(Panel pnl)
        {
            foreach (RadioButton item in pnl.Controls)
            {
                if (item.Checked)
                {
                    currentIsMember = item.Text;
                }
            }
        }
        void LoadListStudent()
        {
            dataGridViewStudent.DataSource = StudentDAO.Instance.GetListStudent(currentGroup, currentSex, currentIsMember);
        }

        void LoadGroup()
        {
            comboBoxGroup.DataSource = GroupDAO.Instance.GetListGroup();
            comboBoxGroup.DisplayMember = "id";
            comboBoxGroupEdit.DataSource = GroupDAO.Instance.GetListGroup();
            comboBoxGroupEdit.DisplayMember = "id";
        }
        void AddAndUpdateState()
        {
            //Show the panel
            panelEdit.Visible = true;
            panelEdit.Location = panelDefault.Location;
            panelDefault.Visible = false;
            //Button in panel
            AcceptButton = buttonEdit;
            buttonEdit.Text = currentEditState;
            buttonResetText.Visible = true;
            //Change Location button
            buttonEdit.Location = new Point(buttonResetText.Location.X - 83, buttonResetText.Location.Y);
            //Other controls
            textBoxMSSVEdit.Enabled = true;
            textBoxMSSVEdit.ReadOnly = false;
            textBoxNameEdit.Enabled = true;
            textBoxNameEdit.ReadOnly = false;
            comboBoxGroupEdit.Enabled = true;
            comboBoxSexEdit.Enabled = true;
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
                textBoxMSSVEdit.Enabled = false;
            }
            else if (btn.Tag.ToString() == "delete")
            {
                currentEditState = EditState.delete;
                //Show the panel
                panelEdit.Visible = true;
                panelEdit.Location = panelDefault.Location;
                panelDefault.Visible = false;
                //Button in panel
                AcceptButton = buttonEdit;
                buttonResetText.Visible = false;
                buttonEdit.Text = currentEditState;
                //Change Location button
                buttonEdit.Location = buttonResetText.Location;
                //Other controls
                textBoxMSSVEdit.Enabled = false;
                textBoxNameEdit.Enabled = false;
                comboBoxGroupEdit.Enabled = true;
                comboBoxSexEdit.Enabled = true;
                panelRadioEdit.Enabled = true;
            }
            else if (btn.Tag.ToString() == "exitEdit")
            {
                //AcceptButton
                AcceptButton = null;
                //Hide the panel edit
                panelEdit.Visible = false;
                panelDefault.Visible = true;
                panelEdit.Location = new Point(panelDefault.Location.X, panelDefault.Location.Y + panelDefault.Size.Height + 6);
            }
        }

        void ExecuteEditCommand()
        {
            if (currentEditState == EditState.add)
            {
                if (textBoxMSSVEdit.Text != "" && textBoxNameEdit.Text != "")
                {
                    bool getIsMember = false;
                    foreach (RadioButton item in panelRadioEdit.Controls)
                    {
                        if (item.Checked == true)
                        {
                            if (item.Text == "Có")
                            {
                                getIsMember = true;
                                break;
                            }
                            else
                            {
                                getIsMember = false;
                                break;
                            }
                        }
                    }
                    int result = StudentDAO.Instance.AddStudent(textBoxMSSVEdit.Text, textBoxNameEdit.Text, comboBoxSexEdit.Text, comboBoxGroupEdit.Text, getIsMember);
                    if (result > 0)
                    {
                        LoadListStudent();
                    }
                    else if (result == -1)
                    {
                        MessageBox.Show("MSSV mà bạn nhập đã được sử dụng!", "Trùng MSSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (textBoxMSSVEdit.Text != "" && textBoxNameEdit.Text != "")
                {
                    bool getIsMember = false;
                    foreach (RadioButton item in panelRadioEdit.Controls)
                    {
                        if (item.Checked == true)
                        {
                            if (item.Text == "Có")
                            {
                                getIsMember = true;
                                break;
                            }
                            else
                            {
                                getIsMember = false;
                                break;
                            }
                        }
                    }
                    if (StudentDAO.Instance.UpdateStudent(textBoxMSSVEdit.Text, textBoxNameEdit.Text, comboBoxSexEdit.Text, comboBoxGroupEdit.Text, getIsMember) != 0) { LoadListStudent(); }
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
                if (textBoxMSSVEdit.Text != "")
                {
                    DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rs == DialogResult.Yes)
                    {
                        if (StudentDAO.Instance.DeleteStudent(textBoxMSSVEdit.Text) != 0) { LoadListStudent(); }
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
            comboBoxGroupEdit.SelectedIndex = 0;
            comboBoxSexEdit.SelectedIndex = 0;
            panelEdit.Controls[0].ResetText();
            textBoxMSSVEdit.ResetText();
            textBoxNameEdit.ResetText();
        }
        #endregion
    }
}
