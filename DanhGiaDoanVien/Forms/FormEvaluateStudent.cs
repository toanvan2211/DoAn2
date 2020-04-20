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
    public partial class FormEvaluateStudent : Form
    {
        private string idCurrentSemester = "";
        private string idCurrentGroup = "";

        public FormEvaluateStudent()
        {
            InitializeComponent();
        }

        #region method

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

        private ScoresStudent Evaluate(ScoresStudent scores)
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
                        scores.Rank = "Xuất sắc";
                    }
                }
                else if (scores.AverageSemester1 >= 1.5 && scores.AverageSemester2 >= 1.5 && scores.TotalAverage >= 2.0)
                {
                    if (scores.AverageTrainingPoint >= 70 && scores.PointTraning1 >= 60 && scores.PointTraning2 >= 60)
                    {
                        scores.Rank = "Khá";
                    }
                }
                else if (scores.AverageSemester1 >= 1.0 && scores.AverageSemester2 >= 1.0 && scores.TotalAverage >= 1.5)
                {
                    if (scores.PointTraning1 >= 50 && scores.PointTraning2 >= 50)
                    {
                        scores.Rank = "Trung bình";
                    }
                }
                else if (scores.AverageSemester1 < 1.0 || scores.AverageSemester2 < 1.0)
                {
                    scores.Rank = "Yếu kém";
                }
                else if (scores.PointTraning1 < 30 || scores.PointTraning2 < 30 || scores.AverageTrainingPoint < 50)
                {
                    scores.Rank = "Yếu kém";
                }
                else
                {
                    scores.Rank = "Yếu kém";
                }
            }
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

        void CreateScoresStudent(string idStudent, string idSemester)
        {
            ScoresStudentDAO.Instance.AddScoresStudent(idStudent, idSemester);
        }

        #endregion

        private void FormEvaluateStudent_Load(object sender, EventArgs e)
        {
            LoadComboBoxGroup();
            LoadComboBoxSemester();

            comboBoxSemester.SelectedIndex = 0;
            comboBoxGroup.SelectedIndex = 0;

            LoadScoresStudent();
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
    }
}
