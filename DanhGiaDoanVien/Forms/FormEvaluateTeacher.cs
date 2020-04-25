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
    public partial class FormEvaluateTeacher : Form
    {
        private string idCurrentSemester = "";
        private string idCurrentGroup = "";
        private int currentIndex = -1;
        GoodTeacher gtc;

        public FormEvaluateTeacher()
        {
            InitializeComponent();
        }

        #region method
        void LoadScoresTeacher()
        {
            if (idCurrentSemester == "" && idCurrentGroup == "")
            {
                dataGridViewScoresTeacher.DataSource = ScoresTeacherDAO.Instance.GetListScoresTeacher();
            }
            else if (idCurrentSemester != "" && idCurrentGroup == "")
            {
                dataGridViewScoresTeacher.DataSource = ScoresTeacherDAO.Instance.GetListScoresTeacherByID(idCurrentSemester, 2);
            }
            else if (idCurrentSemester == "" && idCurrentGroup != "")
            {
                dataGridViewScoresTeacher.DataSource = ScoresTeacherDAO.Instance.GetListScoresTeacherByID(idCurrentGroup, 1);
            }
            else
            {
                dataGridViewScoresTeacher.DataSource = ScoresTeacherDAO.Instance.GetListScoresTeacherByID(idCurrentGroup, idCurrentSemester);
            }
        }
        ScoresTeacher CreateScoresTeacherByRowIndex(int index)
        {
            ScoresTeacher tc = new ScoresTeacher();
            tc.Id = Convert.ToInt32(dataGridViewScoresTeacher.Rows[index].Cells["Id1"].Value.ToString());
            tc.IdScoresGroup = Convert.ToInt32(dataGridViewScoresTeacher.Rows[index].Cells["IdScoresGroup1"].Value.ToString());
            tc.Evaluation = dataGridViewScoresTeacher.Rows[index].Cells["Evaluation1"].Value.ToString();
            tc.IdTeacher = dataGridViewScoresTeacher.Rows[index].Cells["IdTeacher"].Value.ToString();
            tc.Rank = dataGridViewScoresTeacher.Rows[index].Cells["Rank1"].Value.ToString();
            tc.Achievement = dataGridViewScoresTeacher.Rows[index].Cells["Achievement1"].Value.ToString();
            tc.IsGoodMember = Convert.ToBoolean(dataGridViewScoresTeacher.Rows[index].Cells["GoodMember1"].Value.ToString());
            tc.Note = dataGridViewScoresTeacher.Rows[index].Cells["Note1"].Value.ToString();
            
            return tc;
        }

        ScoresTeacher CreateScoresTeacherByText()
        {
            ScoresTeacher tc = new ScoresTeacher();
            tc.Id = Convert.ToInt32(dataGridViewScoresTeacher.Rows[currentIndex].Cells["Id1"].Value.ToString());
            tc.IdScoresGroup = Convert.ToInt32(dataGridViewScoresTeacher.Rows[currentIndex].Cells["IdScoresGroup1"].Value.ToString());
            tc.IdTeacher = textBoxMSGV.Text;
            tc.Evaluation = comboBoxEvaluation.Text;
            tc.Rank = comboBoxRank.Text;
            tc.Achievement = textBoxAchievement.Text;
            tc.IsGoodMember = checkBoxGoodMember.Checked ? true : false;
            tc.Note = textBoxNote.Text;

            return tc;
        }

        void CellClick()
        {
            if (currentIndex != -1)
            {
                string MSGV = dataGridViewScoresTeacher.Rows[currentIndex].Cells["IdTeacher1"].Value.ToString();
                int idKQCD;

                if (int.TryParse(dataGridViewScoresTeacher.Rows[currentIndex].Cells["IdScoresGroup1"].Value.ToString(), out idKQCD))
                {
                    DataTable dataProvide = ScoresTeacherDAO.Instance.GetInfo(idKQCD, MSGV);

                    textBoxName.Text = dataProvide.Rows[0]["tenGV"].ToString();
                    textBoxSemester.Text = dataProvide.Rows[0]["tenNamHoc"].ToString();
                    textBoxMSGV.Text = MSGV;
                    comboBoxEvaluation.Text = dataGridViewScoresTeacher.Rows[currentIndex].Cells["Evaluation1"].Value.ToString();
                    comboBoxRank.Text = dataGridViewScoresTeacher.Rows[currentIndex].Cells["Rank1"].Value.ToString();
                    textBoxGroup.Text = dataProvide.Rows[0]["idChiDoan"].ToString();
                    textBoxAchievement.Text = dataGridViewScoresTeacher.Rows[currentIndex].Cells["Achievement1"].Value.ToString();
                    textBoxNote.Text = dataGridViewScoresTeacher.Rows[currentIndex].Cells["Note1"].Value.ToString();
                    checkBoxGoodMember.Checked = Convert.ToBoolean(dataGridViewScoresTeacher.Rows[currentIndex].Cells["GoodMember1"].Value.ToString());

                    if (checkBoxGoodMember.Checked == true)
                    {
                        gtc = new GoodTeacher(GoodTeacherDAO.Instance.GetInfo(idKQCD, MSGV).Rows[0]);
                    }
                    else
                    {
                        gtc = null;
                    }
                }
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
        #endregion

        private void FormEvaluateTeacher_Load(object sender, EventArgs e)
        {
            LoadComboBoxGroup();
            LoadComboBoxSemester();

            comboBoxSemester.SelectedIndex = 0;
            comboBoxGroup.SelectedIndex = 0;

            LoadScoresTeacher();
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
            LoadScoresTeacher();
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
            LoadScoresTeacher();
        }

        private void dataGridViewScoresTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ScoresTeacherDAO.Instance.UpdateScoresTeacher(CreateScoresTeacherByText());
            LoadScoresTeacher();
            CellClick();
        }

        private void buttonVoteGoodMember_Click(object sender, EventArgs e)
        {
            if (gtc != null)
            {
                using (FormVote fmvte = new FormVote(gtc, textBoxName.Text, textBoxSemester.Text))
                {
                    fmvte.ShowDialog();
                }
                int idKQCD = Convert.ToInt32(dataGridViewScoresTeacher.Rows[currentIndex].Cells["IdScoresGroup1"].Value.ToString());
                gtc = new GoodTeacher(GoodTeacherDAO.Instance.GetInfo(idKQCD, gtc.IdTeacher).Rows[0]); //Cập nhật lại thông tin giảng viên sau khi tắt form
            }
            else
            {
                MessageBox.Show("Chưa chọn giảng viên, hoặc giảng viên này không phải là đoàn viên ưu tú!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            DialogResult quest = MessageBox.Show("Bạn có chắc muốn cập nhật toàn bộ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (quest == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewScoresTeacher.Rows)
                {
                    ScoresTeacher tc1 = new ScoresTeacher(row);
                    ScoresTeacherDAO.Instance.UpdateScoresTeacher(tc1);
                }
                LoadScoresTeacher();
                CellClick();
            }
        }

        private void buttonSaveSelect_Click(object sender, EventArgs e)
        {
            foreach (int rowIndex in dataGridViewScoresTeacher.SelectedCells.Cast<DataGridViewCell>().Select(x => x.RowIndex).Distinct())
            {
                ScoresTeacher tc = CreateScoresTeacherByRowIndex(rowIndex);
                ScoresTeacherDAO.Instance.UpdateScoresTeacher(tc);
            }
            LoadScoresTeacher();
            CellClick();
        }
    }
}
