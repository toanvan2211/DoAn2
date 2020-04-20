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
    public partial class FormEvaluateGroup : Form
    {
        private string idCurrentSemester = "";
        private List<Semester> listSemester = new List<Semester>();
        
        public FormEvaluateGroup()
        {
            InitializeComponent();
        }

        #region method

        void LoadListScoresGroup()
        {
            if (idCurrentSemester == "")
                dataGridViewScoresGroup.DataSource = ScoresGroupDAO.Instance.GetListScoresGroup();
            else
            {
                dataGridViewScoresGroup.DataSource = ScoresGroupDAO.Instance.GetListScoresGroup(idCurrentSemester);
            }
        }

        void LoadListGroup()
        {
            comboBoxGroup.DataSource = GroupDAO.Instance.GetListGroupNoScores(idCurrentSemester);
            comboBoxGroup.DisplayMember = "id";
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

        private ScoresGroup EvaluateGroup(ScoresGroup scoresGroup)
        {
            if (((scoresGroup.GreatMember / scoresGroup.TotalMember) * 100) >= 80 && scoresGroup.BabMember == 0)
            {
                scoresGroup.Rank = "Chi đoàn vững mạnh";
            }
            else if (((scoresGroup.GreatMember / scoresGroup.TotalMember) * 100) >= 60 && scoresGroup.BabMember == 0)
            {
                scoresGroup.Rank = "Chi đoàn khá";
            }
            else if (((scoresGroup.GreatMember / scoresGroup.TotalMember) * 100) >= 50 && ((scoresGroup.BabMember / scoresGroup.TotalMember) * 100) <= 20)
            {
                scoresGroup.Rank = "Chi đoàn trung bình";
            }
            else
            {
                scoresGroup.Rank = "Chi đoàn yếu kém";
            }

            return scoresGroup;
        }

        private ScoresGroup CountRankMember(ScoresGroup scoresGroup, ScoresStudent[] listMember)
        {
            for (int i = 0; i < listMember.Length; i++)
            {
                if (listMember[i].Rank == "Xuất sắc")
                {
                    scoresGroup.ExcellentMember++;
                }
                else if (listMember[i].Rank == "Khá")
                {
                    scoresGroup.GreatMember++;
                }
                else if (listMember[i].Rank == "Trung bình")
                {
                    scoresGroup.MediumMember++;
                }
                else if (listMember[i].Rank == "Yếu kém")
                {
                    scoresGroup.BabMember++;
                }
            }
            scoresGroup.TotalMember = (int)(listMember.Length + 1);

            return scoresGroup;
        }
        private ScoresGroup CountRankMember(ScoresGroup scoresGroup, ScoresTeacher[] listMember)
        {
            for (int i = 0; i < listMember.Length; i++)
            {
                if (listMember[i].Rank == "Xuất sắc")
                {
                    scoresGroup.ExcellentMember++;
                }
                else if (listMember[i].Rank == "Khá")
                {
                    scoresGroup.GreatMember++;
                }
                else if (listMember[i].Rank == "Trung bình")
                {
                    scoresGroup.MediumMember++;
                }
                else if (listMember[i].Rank == "Yếu kém")
                {
                    scoresGroup.BabMember++;
                }
            }
            scoresGroup.TotalMember = (int)(listMember.Length + 1);

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

            if (comboBoxGroup.Text != "")
            {
                comboBoxGroup.SelectedIndex = 0;
            }
            comboBoxRank.SelectedIndex = 0;
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
        }

        private void buttonCreateList_Click(object sender, EventArgs e)
        {
            if (idCurrentSemester == "")
            {
                MessageBox.Show("Vui lòng chọn năm học", "Chưa chọn năm học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CreateScoresGroup(comboBoxGroup.Text, idCurrentSemester);
            LoadListGroup();
            LoadListScoresGroup();
        }

        private void dataGridViewScoresGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
