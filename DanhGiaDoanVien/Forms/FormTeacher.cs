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
    public partial class FormTeacher : Form
    {
        private string currentGroup = "Tất cả";
        private string currentSex = "Tất cả";
        private string currentIsMember = "Tất cả";
        private string currentEditState = EditState.none;
        private int currentRowIndex = -1;
        private Teacher currentTeacher = new Teacher();

        private struct EditState
        {
             public static string none = "Không";
             public static string add = "Thêm";
             public static string update = "Sửa";
             public static string delete = "Xóa";
        }

        public FormTeacher()
        {
            InitializeComponent();
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            LoadGroup();
            comboBoxSex.SelectedIndex = 0;
            comboBoxSexEdit.SelectedIndex = 0;
            comboBoxMember.SelectedIndex = 0;
            comboBoxGroup.SelectedIndex = 0;
            LoadListTeacher();
        }
        //ComboBox
        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentGroup = comboBoxGroup.Text;
            LoadListTeacher();
        }

        private void comboBoxSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSex = comboBoxSex.Text;
            LoadListTeacher();
        }
        //DataGridView
        private void dataGridViewTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                currentRowIndex = e.RowIndex;
                dataGridViewTeacher.CurrentRow.Selected = true;

                currentTeacher.IdTeacher = dataGridViewTeacher.Rows[e.RowIndex].Cells["MSGV"].Value.ToString();
                currentTeacher.Name = dataGridViewTeacher.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
                currentTeacher.Sex = dataGridViewTeacher.Rows[e.RowIndex].Cells["Sex1"].Value.ToString();
                currentTeacher.Group = dataGridViewTeacher.Rows[e.RowIndex].Cells["Group1"].Value.ToString();
                string check = dataGridViewTeacher.Rows[e.RowIndex].Cells["IsMember1"].Value.ToString();
                if (check == "True")
                    currentTeacher.IsMember = true;
                else
                    currentTeacher.IsMember = false;
            }
            catch
            {
                currentRowIndex = -1;
            }

            if (currentRowIndex != -1)
            {
                if (currentEditState != EditState.none)
                {
                    //Edit panel
                    textBoxMSGVEdit.Text = currentTeacher.IdTeacher;
                    textBoxNameEdit.Text = currentTeacher.Name;
                    comboBoxGroupEdit.Text = currentTeacher.Group;
                    comboBoxSexEdit.Text = currentTeacher.Sex;
                    foreach (RadioButton item in panelRadioEdit.Controls)
                    {
                        if (item.Tag.ToString() == currentTeacher.IsMember.ToString())
                        {
                            item.Checked = true;
                            break;
                        }
                    }
                }
                else
                {
                    //Main panel
                    labelMSGV.Text = currentTeacher.IdTeacher;
                    labelName.Text = currentTeacher.Name;
                    labelSex.Text = currentTeacher.Sex;
                    labelGroup.Text = currentTeacher.Group;
                    labelIsMember.Text = currentTeacher.IsMember.ToString();
                }
            }
        }
        //Button
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
            LoadListTeacher();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
            LoadListTeacher();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
            LoadListTeacher();
        }

        private void buttonExitEdit_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
            LoadListTeacher();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ExecuteEditCommand();
        }

        private void buttonResetText_Click(object sender, EventArgs e)
        {
            ResetTextEdit();
        }
        #region Method
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
        void LoadListTeacher()
        {
            dataGridViewTeacher.DataSource = TeacherDAO.Instance.GetListTeacher(currentGroup, currentSex, currentIsMember);
        }

        void LoadGroup()
        {
            DataTable dataGroup = GroupDAO.Instance.GetListGroup();
            comboBoxGroup.Items.Add("Tất cả");
            comboBoxGroup.Items.Add("");
            comboBoxGroupEdit.Items.Add("");
            foreach (DataRow item in dataGroup.Rows)
            {
                comboBoxGroup.Items.Add(item["id"]);
                comboBoxGroupEdit.Items.Add(item["id"]);
            }
        }

        void AddAndUpdateState()
        {
            //Show the panel
            panelEdit.Visible = true;
            panelEdit.Location = new Point(144, 78);
            panelDefault.Visible = false;
            //Button in panel
            AcceptButton = buttonEdit;
            buttonEdit.Text = currentEditState;
            buttonResetText.Visible = true;
            //Change Location button
            buttonEdit.Location = new Point(buttonResetText.Location.X - 83, buttonResetText.Location.Y);
            //Other controls
            textBoxMSGVEdit.Enabled = true;
            textBoxMSGVEdit.ReadOnly = false;
            textBoxNameEdit.Enabled = true;
            textBoxNameEdit.ReadOnly = false;
            comboBoxGroupEdit.Enabled = true;
            comboBoxSexEdit.Enabled = true;
            panelEdit.Enabled = true;
        }

        void SetCurrent(string group, string sex, string isMember)
        {
            if (group == "")
                group = "Tất cả";

            currentGroup = group;
            currentSex = sex;
            currentIsMember = isMember;
        }

        void ChangeState(Button btn)
        {
            if ((btn.Tag.ToString() != "exitEdit"))
            {
                if (currentRowIndex != -1)
                {
                    textBoxNameEdit.Text = currentTeacher.Name;
                    textBoxMSGVEdit.Text = currentTeacher.IdTeacher;
                    comboBoxGroupEdit.Text = currentTeacher.Group;
                    comboBoxSexEdit.Text = currentTeacher.Sex;
                    foreach (RadioButton item in panelRadioEdit.Controls)
                    {
                        if (item.Tag.ToString() == currentTeacher.IsMember.ToString())
                        {
                            item.Checked = true;
                            break;
                        }
                    }
                }

                if (btn.Tag.ToString() == "add")
                {
                    panelDefault.Visible = false;
                    currentEditState = EditState.add;
                    buttonEdit.FlatAppearance.BorderColor = Color.MediumSeaGreen;
                    buttonEdit.FlatAppearance.MouseOverBackColor = default;
                    buttonEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
                    AddAndUpdateState();
                }
                else if (btn.Tag.ToString() == "update")
                {
                    panelDefault.Visible = false;
                    currentEditState = EditState.update;
                    AddAndUpdateState();
                    buttonEdit.FlatAppearance.BorderColor = Color.Aqua;
                    buttonEdit.FlatAppearance.MouseOverBackColor = default;
                    buttonEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
                    textBoxMSGVEdit.Enabled = false;
                }
                else if (btn.Tag.ToString() == "delete")
                {
                    panelDefault.Visible = false;
                    currentEditState = EditState.delete;
                    //Show the panel
                    panelEdit.Visible = true;
                    panelEdit.Location = new Point(144, 78);
                    panelDefault.Visible = false;
                    //Button in panel
                    AcceptButton = buttonEdit;
                    buttonResetText.Visible = false;
                    buttonEdit.Text = currentEditState;
                    buttonEdit.FlatAppearance.BorderColor = Color.Red;
                    buttonEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
                    buttonEdit.FlatAppearance.MouseDownBackColor = Color.Red;
                    //Change Location button
                    buttonEdit.Location = buttonResetText.Location;
                    //Other controls
                    textBoxMSGVEdit.Enabled = false;
                    textBoxNameEdit.Enabled = false;
                    comboBoxGroupEdit.Enabled = true;
                    comboBoxSexEdit.Enabled = true;
                    panelRadioEdit.Enabled = true;
                }
            }
            else
            {
                panelDefault.Visible = true;
                currentEditState = EditState.none;
                //AcceptButton
                AcceptButton = null;
                //Hide the panel edit
                panelEdit.Visible = false;
                panelDefault.Visible = true;
                panelEdit.Location = new Point(panelDefault.Location.X, panelDefault.Location.Y + panelDefault.Size.Height + 6);
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
                if (textBoxMSGVEdit.Text != "" && textBoxNameEdit.Text != "")
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
                    int result = TeacherDAO.Instance.AddTeacher(textBoxMSGVEdit.Text, textBoxNameEdit.Text, comboBoxSexEdit.Text, comboBoxGroupEdit.Text, getIsMember);
                    if (result >= 0)
                    {
                        string stringNotification = "giảng viên có mã: " + textBoxMSGVEdit.Text;

                        textBoxMSGVEdit.ResetText();
                        textBoxNameEdit.ResetText();
                        LoadListTeacher();

                        Alert(stringNotification, FormNotified.enmType.Insert);
                    }
                    else if (result == -1)
                    {
                        MessageBox.Show("MSGV mà bạn nhập đã tồn tại!", "Trùng MSGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (textBoxMSGVEdit.Text != "" && textBoxNameEdit.Text != "")
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
                    int result = TeacherDAO.Instance.UpdateTeacher(currentTeacher, textBoxNameEdit.Text, comboBoxSexEdit.Text, comboBoxGroupEdit.Text, getIsMember);

                    if (result > 0)
                    {
                        string stringNotification = "giảng viên có mã: " + textBoxMSGVEdit.Text;

                        currentTeacher.Name = textBoxNameEdit.Text;
                        currentTeacher.Sex = comboBoxSexEdit.Text;
                        currentTeacher.Group = comboBoxGroupEdit.Text;
                        currentTeacher.IsMember = getIsMember;
                        LoadListTeacher();

                        Alert(stringNotification, FormNotified.enmType.Edit);
                    }
                    else if (result == -1)
                    {
                        MessageBox.Show("Thông tin không có sự thay đổi", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (result == -696)
                    {
                        MessageBox.Show("Giảng viên này đang có trong kết quả đánh giá của chi đoàn. Không thể thay đổi chi đoàn vào lúc này!", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (textBoxMSGVEdit.Text != "")
                {
                    DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rs == DialogResult.Yes)
                    {
                        if (TeacherDAO.Instance.DeleteTeacher(textBoxMSGVEdit.Text) != 0) 
                        {
                            string stringNotification = "giảng viên có mã: " + textBoxMSGVEdit.Text;

                            LoadListTeacher();

                            Alert(stringNotification, FormNotified.enmType.Delete);
                        }
                        else
                        {
                            MessageBox.Show("Thất bại, thử lại sau", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập giảng viên cần xóa!", "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
            }
        }

        void ResetTextEdit()
        {
            comboBoxGroupEdit.SelectedIndex = 0;
            comboBoxSexEdit.SelectedIndex = 0;
            panelEdit.Controls[0].ResetText();
            textBoxMSGVEdit.ResetText();
            textBoxNameEdit.ResetText();
        }
        #endregion

        private void comboBoxMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentIsMember = comboBoxMember.Text;
            LoadListTeacher();
        }

        private void textBoxMSGVEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }
    }
}
