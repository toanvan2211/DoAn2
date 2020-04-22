using DanhGiaDoanVien.DAO;
using DanhGiaDoanVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanhGiaDoanVien
{
    public partial class FormEvaluateStudent : Form
    {
        private string idCurrentSemester = "";
        private string idCurrentGroup = "";
        private int currentIndex = -1;

        public FormEvaluateStudent()
        {
            InitializeComponent();
        }

        private struct Rank
        {
            public static string rank1 = "Xuất sắc";
            public static string rank2 = "Khá";
            public static string rank3 = "Trung bình";
            public static string rank4 = "Yếu kém";
        }

        #region method
        void CellClick()
        {
            if (currentIndex != -1)
            {
                string MSSV = dataGridViewStudent.Rows[currentIndex].Cells["IdStudent1"].Value.ToString();
                string idKQCD = dataGridViewStudent.Rows[currentIndex].Cells["IdScoresGroup1"].Value.ToString();
                DataGridViewRow row = dgvProvide.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["MSSV"].Value.ToString().Equals(MSSV)).First();
                textBoxName.Text = dgvProvide.Rows[row.Index].Cells["ten"].Value.ToString();
                row = dgvProvide.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["id"].Value.ToString().Equals(idKQCD)).First();
                textBoxSemester.Text = dgvProvide.Rows[row.Index].Cells["idNamHoc"].Value.ToString();
                textBoxMSSV.Text = MSSV;
                textBoxPoint1.Text = dataGridViewStudent.Rows[currentIndex].Cells["PointSemester11"].Value.ToString();
                textBoxPoint2.Text = dataGridViewStudent.Rows[currentIndex].Cells["PointSemester21"].Value.ToString();
                textBoxTrain1.Text = dataGridViewStudent.Rows[currentIndex].Cells["TrainSemester11"].Value.ToString();
                textBoxTrain2.Text = dataGridViewStudent.Rows[currentIndex].Cells["TrainSemester21"].Value.ToString();
                textBoxRank.Text = dataGridViewStudent.Rows[currentIndex].Cells["Rank1"].Value.ToString();
                textBoxGroup.Text = dgvProvide.Rows[row.Index].Cells["idChiDoan"].Value.ToString();
                textBoxAchievement.Text = dataGridViewStudent.Rows[currentIndex].Cells["Achievement1"].Value.ToString();
                textBoxNote.Text = dataGridViewStudent.Rows[currentIndex].Cells["Note1"].Value.ToString();
                checkBoxGoodMember.Checked = Convert.ToBoolean(dataGridViewStudent.Rows[currentIndex].Cells["GoodMember1"].Value.ToString());
            }
        }

        void LoadProvide()
        {
            dgvProvide.DataSource = ScoresStudentDAO.Instance.LoadProvide();           
        }

        void LoadScoresStudent()
        {
            if (idCurrentSemester == "" && idCurrentGroup == "")
            {
                dataGridViewStudent.DataSource = ScoresStudentDAO.Instance.GetListScoresStudent();
            }
            else if (idCurrentSemester != "" && idCurrentGroup == "" )
            {
                dataGridViewStudent.DataSource = ScoresGroupDAO.Instance.GetListScoresStudentByID(idCurrentSemester, 2);
            }
            else if (idCurrentSemester == "" && idCurrentGroup != "")
            {
                dataGridViewStudent.DataSource = ScoresGroupDAO.Instance.GetListScoresStudentByID(idCurrentGroup, 1);
            }
            else
            {
                dataGridViewStudent.DataSource = ScoresGroupDAO.Instance.GetListScoresStudentByID(idCurrentGroup, idCurrentSemester);
            }
        }

        void LoadComboBoxGroup()
        {
            DataTable dataGroup = GroupDAO.Instance.GetListGroup();
            foreach (DataRow item in dataGroup.Rows)
            {
                comboBoxGroup.Items.Add(item["id"]);
            }
        }

        void LoadComboBoxSemester()
        {
            DataTable dataGroup = SemesterDAO.Instance.GetListSemester();
            foreach (DataRow item in dataGroup.Rows)
            {
                comboBoxSemester.Items.Add(item["id"]);
            }
        }

        ScoresStudent CreateScoresStudentByRowIndex(int index)
        {
            ScoresStudent st = new ScoresStudent();
            st.Id = Convert.ToInt32(dataGridViewStudent.Rows[index].Cells["Id1"].Value.ToString());
            st.IdScoresGroup = dataGridViewStudent.Rows[index].Cells["IdScoresGroup1"].Value.ToString();
            st.IdStudent = dataGridViewStudent.Rows[index].Cells["IdStudent1"].Value.ToString();
            st.Rank = dataGridViewStudent.Rows[index].Cells["Rank1"].Value.ToString();
            st.Achievement = dataGridViewStudent.Rows[index].Cells["Achievement1"].Value.ToString();
            st.IsGoodMember = Convert.ToBoolean(dataGridViewStudent.Rows[index].Cells["GoodMember1"].Value.ToString());
            st.Note = dataGridViewStudent.Rows[index].Cells["Note1"].Value.ToString();
            try
            {
                st.AverageSemester1 = float.Parse(dataGridViewStudent.Rows[index].Cells["PointSemester11"].Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                st.AverageSemester2 = float.Parse(dataGridViewStudent.Rows[index].Cells["PointSemester21"].Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                st.TotalAverage = Convert.ToInt32(dataGridViewStudent.Rows[index].Cells["PointSemester1"].Value.ToString());
                st.PointTraning1 = Convert.ToInt32(dataGridViewStudent.Rows[index].Cells["TrainSemester11"].Value.ToString());
                st.PointTraning2 = Convert.ToInt32(dataGridViewStudent.Rows[index].Cells["TrainSemester21"].Value.ToString());
                st.AverageTrainingPoint = Convert.ToInt32(dataGridViewStudent.Rows[index].Cells["TrainSemester1"].Value.ToString());
                
                return st;
            }
            catch { return st; }
        }

        ScoresStudent CreateScoresStudentByText()
        {
            ScoresStudent st = new ScoresStudent();
            st.Id = Convert.ToInt32(dataGridViewStudent.Rows[currentIndex].Cells["Id1"].Value.ToString());
            st.IdScoresGroup = dataGridViewStudent.Rows[currentIndex].Cells["IdScoresGroup1"].Value.ToString();
            st.IdStudent = dataGridViewStudent.Rows[currentIndex].Cells["IdStudent1"].Value.ToString();
            st.Achievement = textBoxAchievement.Text;
            st.IsGoodMember = checkBoxGoodMember.Checked ? true : false;
            st.Note = textBoxNote.Text;
            try
            {
                st.AverageSemester1 = float.Parse(textBoxPoint1.Text, CultureInfo.InvariantCulture.NumberFormat);
                st.AverageSemester2 = float.Parse(textBoxPoint2.Text, CultureInfo.InvariantCulture.NumberFormat);
                st.PointTraning1 = Convert.ToInt32(textBoxTrain1.Text);
                st.PointTraning2 = Convert.ToInt32(textBoxTrain2.Text);
                
                return st;
            }
            catch { return st; }
        }

        private ScoresStudent Evaluate(ScoresStudent scores)
        {
            scores.TotalAverage = CalculationScores(scores.AverageSemester1, scores.AverageSemester2);
            scores.AverageTrainingPoint = CalculationScores(scores.PointTraning1, scores.PointTraning2);
            try
            {
                if (scores.AverageSemester1 != 0 && scores.AverageSemester2 != 0)
                {
                    scores.TotalAverage = (scores.AverageSemester1 + scores.AverageSemester2) / 2;
                }
                if (scores.PointTraning1 != 0 && scores.PointTraning2 != 0)
                {
                    scores.AverageTrainingPoint = (byte)((scores.PointTraning1 + scores.PointTraning2) / 2);
                }
                if (scores.AverageTrainingPoint != 0 && scores.TotalAverage != 0)
                {
                    if (scores.AverageSemester1 >= 2.5 && scores.AverageSemester2 >= 2.5)
                    {
                        if (scores.AverageTrainingPoint >= 80 && scores.PointTraning1 >= 70 && scores.PointTraning2 >= 70)
                        {
                            scores.Rank = Rank.rank1;
                        }
                        else if(scores.AverageTrainingPoint >= 70 && scores.PointTraning1 >= 60 && scores.PointTraning2 >= 60)
                        {
                            scores.Rank = Rank.rank2;
                        }
                        else if (scores.PointTraning1 >= 50 && scores.PointTraning2 >= 50)
                        {
                            scores.Rank = Rank.rank3;
                        }
                        else if (scores.PointTraning1 < 30 || scores.PointTraning2 < 30 || scores.AverageTrainingPoint < 50)
                        {
                            scores.Rank = Rank.rank4;
                        }
                    }
                    else if (scores.AverageSemester1 >= 1.5 && scores.AverageSemester2 >= 1.5 && scores.TotalAverage >= 2.0)
                    {
                        if (scores.AverageTrainingPoint >= 70 && scores.PointTraning1 >= 60 && scores.PointTraning2 >= 60)
                        {
                            scores.Rank = Rank.rank2;
                        }
                        else if (scores.PointTraning1 >= 50 && scores.PointTraning2 >= 50)
                        {
                            scores.Rank = Rank.rank3;
                        }
                        else if (scores.PointTraning1 < 30 || scores.PointTraning2 < 30 || scores.AverageTrainingPoint < 50)
                        {
                            scores.Rank = Rank.rank4;
                        }
                    }
                    else if (scores.AverageSemester1 >= 1.0 && scores.AverageSemester2 >= 1.0 && scores.TotalAverage >= 1.5)
                    {
                        if (scores.PointTraning1 >= 50 && scores.PointTraning2 >= 50)
                        {
                            scores.Rank = Rank.rank3;
                        }
                        else if (scores.PointTraning1 < 30 || scores.PointTraning2 < 30 || scores.AverageTrainingPoint < 50)
                        {
                            scores.Rank = Rank.rank4;
                        }
                    }
                    else if (scores.AverageSemester1 < 1.0 || scores.AverageSemester2 < 1.0)
                    {
                        scores.Rank = Rank.rank4;
                    }
                    else if (scores.PointTraning1 < 30 || scores.PointTraning2 < 30 || scores.AverageTrainingPoint < 50)
                    {
                        scores.Rank = Rank.rank4;
                    }
                    else
                    {
                        scores.Rank = Rank.rank4;
                    }
                }
                else
                {
                    scores.Rank = "";
                }
            }
            catch { }
            return scores;
        }

        private float CalculationScores(float a, float b)
        {
            float c;
            c = (a + b) / 2;
            return c;
        }

        private int CalculationScores(int a, int b)
        {
            int c;
            c = (a + b) / 2;
            return c;
        }

        #endregion

        private void FormEvaluateStudent_Load(object sender, EventArgs e)
        {
            LoadComboBoxGroup();
            LoadComboBoxSemester();

            comboBoxSemester.SelectedIndex = 0;
            comboBoxGroup.SelectedIndex = 0;

            LoadScoresStudent();
            LoadProvide();
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
            LoadScoresStudent();
            LoadProvide();
        }

        private void comboBoxSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSemester.SelectedIndex == 0)
            {
                idCurrentSemester = "";
            }
            else
            {
                idCurrentSemester = comboBoxSemester.Text;
            }
            LoadScoresStudent();
        }

        private void dataGridViewStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                currentIndex = e.RowIndex;
            }
            catch
            {
                currentIndex = -1;
            }
            CellClick();
        }

        private void buttonAuto_Click(object sender, EventArgs e)
        {
            List<int> listIndex = new List<int>() { };
            List<ScoresGroup> listSG = new List<ScoresGroup>();
            foreach (int rowIndex in dataGridViewStudent.SelectedCells.Cast<DataGridViewCell>().Select(x => x.RowIndex).Distinct())
            {
                listIndex.Add(rowIndex);
                ScoresStudent st = Evaluate(CreateScoresStudentByRowIndex(rowIndex));
                ScoresStudentDAO.Instance.UpdateScoresStudent(st);
            }
            LoadScoresStudent();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ScoresStudentDAO.Instance.UpdateScoresStudent(Evaluate(CreateScoresStudentByText()));
            LoadScoresStudent();
        }
    }
}
