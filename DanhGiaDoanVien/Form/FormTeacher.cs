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

namespace DanhGiaDoanVien
{
    public partial class FormTeacher : Form
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

        public FormTeacher()
        {
            InitializeComponent();
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            comboBoxSex.SelectedIndex = 0;
            LoadGroup();
            currentGroup = "Tất cả";
            LoadListTeacher();
        }

        void LoadListTeacher()
        {
            dataGridViewTeacher.DataSource = TeacherDAO.Instance.GetListTeacher(currentGroup, currentSex, currentIsMember);
        }

        void LoadGroup()
        {
            comboBoxGroup.DataSource = GroupDAO.Instance.GetListGroup();
            comboBoxGroup.DisplayMember = "id";
        }

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

        private void radioButtonHave_CheckedChanged(object sender, EventArgs e)
        {
            GetCurrentRadio(panelRadio);
            LoadListTeacher();
        }

        private void radioButtonAllMember_CheckedChanged(object sender, EventArgs e)
        {
            GetCurrentRadio(panelRadio);
            LoadListTeacher();
        }

        private void dataGridViewTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridViewTeacher.CurrentRow.Selected = true;
                labelMSGV.Text = dataGridViewTeacher.Rows[e.RowIndex].Cells["idTeacher"].Value.ToString();
                labelName.Text = dataGridViewTeacher.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
            }
            catch { }
        }

        void ChangeState(Button btn)
        {
            if (btn.Tag.ToString() == "add")
            {
                currentEditState = EditState.add;
                //Show the panel
                panelEdit.Visible = true;
                panelEdit.Location = panelDefault.Location;
                panelDefault.Visible = false;
                //Button in panel
                buttonEdit.Text = currentEditState;
                buttonEdit.Visible = true;
                //Other controls
                textBoxMSGVEdit.Enabled = true;
                textBoxMSGVEdit.ReadOnly = false;
                textBoxNameEdit.Enabled = true;
                textBoxNameEdit.ReadOnly = false;
                comboBoxGroupEdit.Enabled = true;
                comboBoxSexEdit.Enabled = true;
                panelEdit.Enabled = true;
            }
            else if (btn.Tag.ToString() == "update")
            {
                currentEditState = EditState.update;
                //Show the panel
                panelEdit.Visible = true;
                panelEdit.Location = panelDefault.Location;
                panelDefault.Visible = false;
                //Button in panel
                buttonEdit.Text = currentEditState;
                buttonEdit.Visible = true;
                //Other controls
                textBoxMSGVEdit.Enabled = true;
                textBoxMSGVEdit.ReadOnly = false;
                textBoxNameEdit.Enabled = true;
                textBoxNameEdit.ReadOnly = false;
                comboBoxGroupEdit.Enabled = true;
                comboBoxSexEdit.Enabled = true;
                panelEdit.Enabled = true;
            }
            else if (btn.Tag.ToString() == "delete")
            {
                currentEditState = EditState.delete;
                //Show the panel
                panelEdit.Visible = true;
                panelEdit.Location = panelDefault.Location;
                panelDefault.Visible = false;
                //Button in panel
                buttonEdit.Visible = false;
                //Other controls
                textBoxMSGVEdit.Enabled = false;
                textBoxNameEdit.Enabled = false;
                comboBoxGroupEdit.Enabled = false;
                comboBoxSexEdit.Enabled = false;
                panelRadioEdit.Enabled = false;
            }
            else if (btn.Tag.ToString() == "exitEdit")
            {
                //Hide the panel edit
                panelEdit.Visible = false;
                panelDefault.Visible = true;
                panelEdit.Location = new Point(59, 184);
            }
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

        private void buttonExitEdit_Click(object sender, EventArgs e)
        {
            ChangeState((Button)sender);
        }
    }
}
