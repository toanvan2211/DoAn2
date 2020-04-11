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

        void LoadListStudent()
        {
            dataGridViewStudent.DataSource = StudentDAO.Instance.GetListStudent(currentGroup, currentSex, currentIsMember);
        }

        void LoadGroup()
        {
            comboBoxGroup.DataSource = GroupDAO.Instance.GetListGroup();
            comboBoxGroup.DisplayMember = "id";
        }

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
            LoadListStudent();
        }

        private void radioButtonAllMember_CheckedChanged(object sender, EventArgs e)
        {
            GetCurrentRadio(panelRadio);
            LoadListStudent();
        }

        private void dataGridViewStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridViewStudent.CurrentRow.Selected = true;
                labelMSSV.Text = dataGridViewStudent.Rows[e.RowIndex].Cells["MSSV"].Value.ToString();
                labelName.Text = dataGridViewStudent.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
            }
            catch { }
        }
    }
}
