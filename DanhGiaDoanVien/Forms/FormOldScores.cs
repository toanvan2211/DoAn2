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
    public partial class FormOldScores : Form
    {
        private int currentIndex = -1;
        private string currentSemester = "Tất cả";
        private string currentGroup = "Tất cả";
        List<Semester> listSemester = new List<Semester>();
        private int idCurrentScores = -1;

        public FormOldScores()
        {
            InitializeComponent();
        }

        private void FormOldScores_Load(object sender, EventArgs e)
        {
            LoadComboBoxSemester();
            LoadComboBoxGroup();
            LoadListOldScores(currentSemester, currentGroup);
            comboBoxGroup.SelectedIndex = 0;
            comboBoxSemester.SelectedIndex = 0;
        }

        #region method
        void LoadComboBoxSemester()
        {
            DataTable data = SemesterDAO.Instance.GetListSemester();
            foreach (DataRow item in data.Rows)
            {
                Semester sm = new Semester(item);
                listSemester.Add(sm);
                comboBoxSemester.Items.Add(item["ten"]);
            }
        }

        void LoadComboBoxGroup()
        {
            DataTable data = GroupDAO.Instance.GetListGroup();
            foreach (DataRow item in data.Rows)
            {
                comboBoxGroup.Items.Add(item["id"]);
            }
        }

        void LoadListOldScores(string semester, string group)
        {
            dataGridViewOldScores.DataSource = ScoresGroupDAO.Instance.GetListOldScores(semester, group);
        }

        void CellClick()
        {
            if (currentIndex != -1)
            {
                textBoxIdGroup.Text = dataGridViewOldScores.Rows[currentIndex].Cells["idGroup1"].Value.ToString();
                textBoxMember.Text = dataGridViewOldScores.Rows[currentIndex].Cells["TotalMember1"].Value.ToString();
                textBoxTeacher.Text = dataGridViewOldScores.Rows[currentIndex].Cells["TotalTeacher1"].Value.ToString();
                textBoxStudent.Text = dataGridViewOldScores.Rows[currentIndex].Cells["TotalStudent1"].Value.ToString();
                textBoxExcellent.Text = dataGridViewOldScores.Rows[currentIndex].Cells["Excellent1"].Value.ToString();
                textBoxGreate.Text = dataGridViewOldScores.Rows[currentIndex].Cells["Great1"].Value.ToString();
                textBoxMedium.Text = dataGridViewOldScores.Rows[currentIndex].Cells["Medium1"].Value.ToString();
                textBoxBad.Text = dataGridViewOldScores.Rows[currentIndex].Cells["Bad1"].Value.ToString();
                textBoxNote.Text = dataGridViewOldScores.Rows[currentIndex].Cells["Note1"].Value.ToString();
                textBoxGoodMember.Text = dataGridViewOldScores.Rows[currentIndex].Cells["TotalGoodMember1"].Value.ToString();
                textBoxRank.Text = dataGridViewOldScores.Rows[currentIndex].Cells["Rank1"].Value.ToString();
            }
        }
        #endregion

        private void comboBoxSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSemester.SelectedIndex == 0)
                currentSemester = comboBoxSemester.Text;
            else
                currentSemester = listSemester[comboBoxSemester.SelectedIndex - 1].Id;
            LoadListOldScores(currentSemester, currentGroup);
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentGroup = comboBoxGroup.Text;
            LoadListOldScores(currentSemester, currentGroup);
        }

        private void dataGridViewOldScores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                currentIndex = e.RowIndex;
                idCurrentScores = Convert.ToInt32(dataGridViewOldScores.Rows[e.RowIndex].Cells["Id1"].Value.ToString());
            }
            catch
            {
                idCurrentScores = -1;
            }
            CellClick();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (idCurrentScores != -1)
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa?", "Cẩn thận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlr == DialogResult.Yes)
                {
                    ScoresGroupDAO.Instance.DeleteScoresGroup(idCurrentScores);
                    LoadListOldScores(currentSemester, currentGroup);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn kết quả muốn xóa!", "Thiếu sót", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
