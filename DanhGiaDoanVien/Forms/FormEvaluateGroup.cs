using DanhGiaDoanVien.DAO;
using DanhGiaDoanVien.DTO;
using DanhGiaDoanVien.Other_Class;
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
    public partial class FormEvaluateGroup : Form
    {
        private string idCurrentSemester = "";
        private List<Semester> listSemester = new List<Semester>();
        private int idCurrentScoresGroup = -1;
        private int currentIndex = -1;
        private string idCurrentGroup = "";
        
        public FormEvaluateGroup()
        {
            InitializeComponent();
        }

        private struct RankGroup
        {
            public static string rank1 = "Chi đoàn vững mạnh";
            public static string rank2 = "Chi đoàn khá";
            public static string rank3 = "Chi đoàn trung bình";
            public static string rank4 = "Chi đoàn yếu kém";
        }

        #region method
        void CellClick()
        {
            if (currentIndex != -1)
            {
                textBoxIdGroup.Text = dataGridViewScoresGroup.Rows[currentIndex].Cells["idGroup1"].Value.ToString();
                textBoxMember.Text = dataGridViewScoresGroup.Rows[currentIndex].Cells["TotalMember1"].Value.ToString();
                textBoxTeacher.Text = dataGridViewScoresGroup.Rows[currentIndex].Cells["TotalTeacher1"].Value.ToString();
                textBoxStudent.Text = dataGridViewScoresGroup.Rows[currentIndex].Cells["TotalStudent1"].Value.ToString();
                textBoxExcellent.Text = dataGridViewScoresGroup.Rows[currentIndex].Cells["Excellent1"].Value.ToString();
                textBoxGreate.Text = dataGridViewScoresGroup.Rows[currentIndex].Cells["Great1"].Value.ToString();
                textBoxMedium.Text = dataGridViewScoresGroup.Rows[currentIndex].Cells["Medium1"].Value.ToString();
                textBoxBad.Text = dataGridViewScoresGroup.Rows[currentIndex].Cells["Bad1"].Value.ToString();
                textBoxNote.Text = dataGridViewScoresGroup.Rows[currentIndex].Cells["Note1"].Value.ToString();
                textBoxGoodMember.Text = dataGridViewScoresGroup.Rows[currentIndex].Cells["TotalGoodMember1"].Value.ToString();
                string rank1 = dataGridViewScoresGroup.Rows[currentIndex].Cells["Rank1"].Value.ToString();
                if (rank1 != "")
                    comboBoxRank.Text = dataGridViewScoresGroup.Rows[currentIndex].Cells["Rank1"].Value.ToString();
                else
                    comboBoxRank.Text = "";
            }
        }

        void LoadListScoresGroup()
        {
            if (idCurrentSemester == "" && idCurrentGroup == "")
            {
                dataGridViewScoresGroup.DataSource = ScoresGroupDAO.Instance.GetListScoresGroup();
            }
            else if (idCurrentSemester != "" && idCurrentGroup == "")
            {
                dataGridViewScoresGroup.DataSource = ScoresGroupDAO.Instance.GetListScoresGroupByID(idCurrentSemester, 2);
            }
            else if (idCurrentSemester == "" && idCurrentGroup != "")
            {
                dataGridViewScoresGroup.DataSource = ScoresGroupDAO.Instance.GetListScoresGroupByID(idCurrentGroup, 1);
            }
            else
            {
                dataGridViewScoresGroup.DataSource = ScoresGroupDAO.Instance.GetListScoresGroup(idCurrentSemester, idCurrentGroup);
            }
        }

        void LoadListGroup()
        {
            if (idCurrentSemester == "")
            {
                return;
            }
            comboBoxGroupEmpty.DataSource = GroupDAO.Instance.GetListGroupNoScores(idCurrentSemester);
            comboBoxGroupEmpty.DisplayMember = "id";
        }

        void LoadListSemester()
        {
            DataTable dt = SemesterDAO.Instance.GetListSemester();

            comboBoxSemester.Items.Add("Tất cả");
            foreach (DataRow item in dt.Rows)
            {
                Semester sm = new Semester(item);
                listSemester.Add(sm);

                comboBoxSemester.Items.Add(item["id"]);
            }
        }

        ScoresGroup CreateScoresGroupByRowIndex(int index)
        {
            ScoresGroup sg = new ScoresGroup();
            sg.Id = Convert.ToInt32(dataGridViewScoresGroup.Rows[index].Cells["Id1"].Value.ToString());
            sg.IdSemester = dataGridViewScoresGroup.Rows[index].Cells["Semester1"].Value.ToString();
            sg.Rank = dataGridViewScoresGroup.Rows[index].Cells["Rank1"].Value.ToString();
            sg.ExcellentMember = Convert.ToInt32(dataGridViewScoresGroup.Rows[index].Cells["Excellent1"].Value.ToString());
            sg.GreatMember = Convert.ToInt32(dataGridViewScoresGroup.Rows[index].Cells["Great1"].Value.ToString());
            sg.MediumMember = Convert.ToInt32(dataGridViewScoresGroup.Rows[index].Cells["Medium1"].Value.ToString());
            sg.BadMember = Convert.ToInt32(dataGridViewScoresGroup.Rows[index].Cells["Bad1"].Value.ToString());
            sg.TotalMember = Convert.ToInt32(dataGridViewScoresGroup.Rows[index].Cells["TotalMember1"].Value.ToString());
            sg.TotalStudent = Convert.ToInt32(dataGridViewScoresGroup.Rows[index].Cells["TotalStudent1"].Value.ToString());
            sg.TotalTeacher = Convert.ToInt32(dataGridViewScoresGroup.Rows[index].Cells["TotalTeacher1"].Value.ToString());
            sg.TotalGoodMember = Convert.ToInt32(dataGridViewScoresGroup.Rows[index].Cells["TotalGoodMember1"].Value.ToString());
            sg.TotalFemalStudent = Convert.ToInt32(dataGridViewScoresGroup.Rows[index].Cells["TotalFemaleStudent1"].Value.ToString());
            sg.TotalFemalTeacher = Convert.ToInt32(dataGridViewScoresGroup.Rows[index].Cells["TotalFemaleTeacher1"].Value.ToString());
            sg.Note = dataGridViewScoresGroup.Rows[index].Cells["Note1"].Value.ToString();

            return sg;
        }

        void EditScoresGroup()
        {
            ScoresGroup res = new ScoresGroup();
            res.Id = Convert.ToInt32(dataGridViewScoresGroup.Rows[currentIndex].Cells["Id1"].Value.ToString());
            if (comboBoxRank.Text != "")
                res.Rank = comboBoxRank.Text;
            res.Note = textBoxNote.Text;
            ScoresGroupDAO.Instance.UpdateScoresGroup(res.Id, res.Rank, res.Note);
        }

        private ScoresGroup EvaluateGroup(ScoresGroup scoresGroup)
        {
            try
            {
                if (((scoresGroup.GreatMember / scoresGroup.TotalMember) * 100) >= 80 && scoresGroup.BadMember == 0)
                {
                    scoresGroup.Rank = RankGroup.rank1;
                }
                else if (((scoresGroup.GreatMember / scoresGroup.TotalMember) * 100) >= 60 && scoresGroup.BadMember == 0)
                {
                    scoresGroup.Rank = RankGroup.rank2;
                }
                else if (((scoresGroup.GreatMember / scoresGroup.TotalMember) * 100) >= 50 && ((scoresGroup.BadMember / scoresGroup.TotalMember) * 100) <= 20)
                {
                    scoresGroup.Rank = RankGroup.rank3;
                }
                else
                {
                    scoresGroup.Rank = RankGroup.rank4;
                }
            }
            catch {  }
            return scoresGroup;
        }

        void CreateScoresGroup(string idGroup, string idSemester)
        {
            ScoresGroupDAO.Instance.AddScoresGroup(idGroup, idSemester);
        }
        #endregion

        private void FormEvaluateGroup_Load(object sender, EventArgs e)
        {

            LoadListScoresGroup();
            LoadListGroup();
            LoadListSemester();

            if (comboBoxGroupEmpty.Text != "")
            {
                comboBoxGroupEmpty.SelectedIndex = 0;
            }
            comboBoxRank.SelectedIndex = 1;
            comboBoxSemester.SelectedIndex = 0;
        }

        private void comboBoxSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSemester.SelectedIndex == 0)
            {
                idCurrentSemester = "";
            }
            else
                idCurrentSemester = listSemester[comboBoxSemester.SelectedIndex - 1].Id;
            LoadListScoresGroup();
            LoadListGroup();
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGroup.SelectedIndex == 0)
            {
                idCurrentGroup = "";
            }
            else
            {
                idCurrentGroup = comboBoxGroup.Text;
            }
            LoadListScoresGroup();
        }

        private void buttonCreateList_Click(object sender, EventArgs e)
        {
            if (idCurrentSemester == "")
            {
                MessageBox.Show("Vui lòng chọn năm học!", "Chưa chọn năm học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (comboBoxGroupEmpty.Text == "")
            {
                MessageBox.Show("Vui lòng chọn chi đoàn!", "Chưa chọn chi đoàn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CreateScoresGroup(comboBoxGroupEmpty.Text, idCurrentSemester);
            LoadListGroup();
            LoadListScoresGroup();
        }

        private void dataGridViewScoresGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                currentIndex = e.RowIndex;
                idCurrentScoresGroup = Convert.ToInt32(dataGridViewScoresGroup.Rows[e.RowIndex].Cells["Id1"].Value.ToString());
            }
            catch { }
            CellClick();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (idCurrentScoresGroup != -1)
            {
                ScoresGroupDAO.Instance.DeleteScoresGroup(idCurrentScoresGroup);
                LoadListScoresGroup();
                LoadListGroup();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đánh giá muốn xóa!", "Chưa chọn đánh giá", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            EditScoresGroup();
            LoadListScoresGroup();
        }

        private void buttonSaveSelect_Click(object sender, EventArgs e)
        {
            foreach (int rowIndex in dataGridViewScoresGroup.SelectedCells.Cast<DataGridViewCell>().Select(x => x.RowIndex).Distinct())
            {
                ScoresGroup sg = EvaluateGroup(CreateScoresGroupByRowIndex(rowIndex));
                ScoresGroupDAO.Instance.UpdateScoresGroup(sg.Id, sg.Rank, sg.Note);
            }
            LoadListScoresGroup();
            CellClick();
        }

        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            DialogResult quest = MessageBox.Show("Bạn có chắc muốn cập nhật toàn bộ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (quest == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewScoresGroup.Rows)
                {
                    ScoresGroup sg1 = new ScoresGroup(row);
                    ScoresGroupDAO.Instance.UpdateScoresGroup(sg1.Id, sg1.Rank, sg1.Note);
                }
                LoadListScoresGroup();
                CellClick();
            }
        }
    }
}
