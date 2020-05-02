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
        private string typeScores = "Chưa hoàn thành";
        private int currentIndex = -1;
        private List<Semester> listSemester = new List<Semester>();
        GoodTeacher gtc;

        public FormEvaluateTeacher()
        {
            InitializeComponent();
        }

        struct EvalutationStruct
        {
            public static string evaluation1 = "HOÀN THÀNH XUẤT SẮC NHIỆM VỤ";
            public static string evaluation2 = "HOÀN THÀNH TỐT NHIỆM VỤ";
            public static string evaluation3 = "HOÀN THÀNH NHIỆM VỤ";
            public static string evaluation4 = "KHÔNG HOÀN THÀNH NHIỆM VỤ";
        }

        struct Rank
        {
            public static string rank1 = "Xuất sắc";
            public static string rank2 = "Khá";
            public static string rank3 = "Trung bình";
            public static string rank4 = "Yếu kém";
        }

        #region method
        void LoadScoresTeacher()
        {
            dataGridViewScoresTeacher.DataSource = ScoresTeacherDAO.Instance.GetListScoresTeacher(typeScores, idCurrentSemester, idCurrentGroup);
        }

        bool CheckConditionGoodTeacher(ScoresTeacher tc)
        {
            bool result = false;
            if (tc.Rank == "Xuất sắc")
            {
                result = true;
            }
            return result;
        }

        ScoresTeacher Evaluation(ScoresTeacher tc) //Đánh giá giảng viên
        {            
            if (tc.Evaluation == EvalutationStruct.evaluation1)
            {
                tc.Rank = Rank.rank1;
            }
            else if (tc.Evaluation == EvalutationStruct.evaluation2)
            {
                tc.Rank = Rank.rank2;
            }
            else if (tc.Evaluation == EvalutationStruct.evaluation3)
            {
                tc.Rank = Rank.rank3;
            }
            else if (tc.Evaluation == EvalutationStruct.evaluation4)
            {
                tc.Rank = Rank.rank4;
            }
            return tc;
        }

        bool CheckConditionAmountGoodMember(ScoresTeacher tc)
        {
            bool result = false;
            DataTable data = ScoresTeacherDAO.Instance.GetRankAndAmountOfExcellent(tc.IdScoresGroup);
            string rank = data.Rows[0]["xepLoai"].ToString();
            int excellent = Convert.ToInt32(data.Rows[0]["xuatSac"].ToString());
            int goodMember = Convert.ToInt32(data.Rows[0]["tongDVUT"].ToString() + 1); //Cộng 1 ở đây là tính luôn giảng viên đang được xét thành DVUT

            if (rank == "Chi đoàn vững mạnh")
            {
                result = true;
            }
            else if (rank == "Chi đoàn khá")
            {
                if ((((float)goodMember / (float)excellent) * 100) <= 20)
                {
                    result = true;
                }
            }
            else if (rank == "Chi đoàn trung bình")
            {
                if ((((float)goodMember / (float)excellent) * 100) <= 10)
                {
                    result = true;
                }
            }
            else if (rank == "Chi đoàn yếu kém")
            {
                result = false;
            }

            return result;
        }

        string CompareRankCondition(string evaluatedRank, string rankHope)
        {
            string result = evaluatedRank;
            if (checkBoxAuto.Checked)
            {
                return result;
            }

            if (rankHope == "")
            {
                return rankHope;
            }
            else
            {
                if (evaluatedRank != rankHope)
                {
                    int[] compareRank = new int[2]; //Chuyển từ string rank sang int 1 2 3 4 tương ứng vs xs, khá, tb, yk
                    switch (evaluatedRank)
                    {
                        case "Xuất sắc":
                            compareRank[0] = 1;
                            break;
                        case "Khá":
                            compareRank[0] = 2;
                            break;
                        case "Trung bình":
                            compareRank[0] = 3;
                            break;
                        case "Yếu kém":
                            compareRank[0] = 4;
                            break;
                    }
                    switch (rankHope)
                    {
                        case "Xuất sắc":
                            compareRank[1] = 1;
                            break;
                        case "Khá":
                            compareRank[1] = 2;
                            break;
                        case "Trung bình":
                            compareRank[1] = 3;
                            break;
                        case "Yếu kém":
                            compareRank[1] = 4;
                            break;
                    }
                    if (compareRank[0] <= compareRank[1])
                    {
                        result = rankHope;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    result = evaluatedRank;
                }
            }
            return result;
        }

        ScoresTeacher CreateScoresTeacherByRowIndex(int index)
        {
            ScoresTeacher tc = new ScoresTeacher();
            if (currentIndex != -1)
            {
                tc.Id = Convert.ToInt32(dataGridViewScoresTeacher.Rows[index].Cells["Id1"].Value.ToString());
                tc.IdScoresGroup = Convert.ToInt32(dataGridViewScoresTeacher.Rows[index].Cells["IdScoresGroup1"].Value.ToString());
                tc.Evaluation = dataGridViewScoresTeacher.Rows[index].Cells["Evaluation1"].Value.ToString();
                tc.IdTeacher = dataGridViewScoresTeacher.Rows[index].Cells["IdTeacher1"].Value.ToString();
                tc.Rank = dataGridViewScoresTeacher.Rows[index].Cells["Rank1"].Value.ToString();
                tc.Achievement = dataGridViewScoresTeacher.Rows[index].Cells["Achievement1"].Value.ToString();
                tc.IsGoodMember = Convert.ToBoolean(dataGridViewScoresTeacher.Rows[index].Cells["GoodMember1"].Value.ToString());
                tc.Note = dataGridViewScoresTeacher.Rows[index].Cells["Note1"].Value.ToString();
                return tc;
            }
            else
            {
                return null;
            }
        }

        ScoresTeacher CreateScoresTeacherByText()
        {
            ScoresTeacher tc = new ScoresTeacher();
            if (currentIndex != -1)
            {
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
            else
            {
                return null;
            }
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

        void LoadListSemester()
        {
            DataTable dataGroup = SemesterDAO.Instance.GetListSemester();
            foreach (DataRow item in dataGroup.Rows)
            {
                Semester sm = new Semester(item);
                listSemester.Add(sm);
                comboBoxSemester.Items.Add(item["ten"]);
            }
        }
        #endregion

        private void FormEvaluateTeacher_Load(object sender, EventArgs e)
        {
            LoadComboBoxGroup();
            LoadListSemester();

            comboBoxSemester.SelectedIndex = 0;
            comboBoxGroup.SelectedIndex = 0;
            comboBoxScores.SelectedIndex = 0;

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
                idCurrentSemester = listSemester[comboBoxSemester.SelectedIndex - 1].Id;
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
            ScoresTeacher teacher = CreateScoresTeacherByText();
            if (teacher != null)
            {
                string rankHope = comboBoxRank.Text;
                teacher = Evaluation(teacher);
                if ((teacher.Rank = CompareRankCondition(teacher.Rank, rankHope)) != null) //Kiểm tra xem coi rankHope có lớn hơn rank điều kiện k, nếu nhỏ hơn thì duyệt
                {
                    if (checkBoxGoodMember.Checked) // Nếu giảng viên đc chọn là DVUT thì phải check điều kiện
                    {
                        if (CheckConditionGoodTeacher(teacher))
                        {
                            if (CheckConditionAmountGoodMember(teacher))
                            {
                                ScoresTeacherDAO.Instance.UpdateScoresTeacher(teacher);
                                LoadScoresTeacher();
                            }
                            else
                            {
                                MessageBox.Show("Số lượng DVUT trong chi đoàn đã đạt tối đa. Vui lòng cân nhắc lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Giảng viên này không đủ điều kiện để xét DVUT. Vui lòng xem xét lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else //Không thì thôi
                    {
                        ScoresTeacherDAO.Instance.UpdateScoresTeacher(teacher);
                        LoadScoresTeacher();
                    }
                    CellClick();
                }
                else
                {
                    MessageBox.Show("Giảng viên này không đủ điều kiện để được xếp loại \"" + rankHope + "\". Vui lòng xem xét lại!", "Không đủ điều kiện", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên mà bạn muốn sửa!", "Chưa chọn sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                List<int> listRankError = new List<int>(); //Dùng để lưu lại id các kết quả không đủ điều kiện xếp loại
                foreach (DataGridViewRow row in dataGridViewScoresTeacher.Rows)
                {
                    string rankHope = row.Cells["Rank1"].Value.ToString();
                    ScoresTeacher tc = new ScoresTeacher(row);
                    tc = Evaluation(tc);
                    if ((tc.Rank = CompareRankCondition(tc.Rank, rankHope)) != null) //Đủ điều kiện xếp loại thì duyệt
                    {
                        ScoresTeacherDAO.Instance.UpdateScoresTeacher(tc);
                    }
                    else
                    {
                        listRankError.Add(tc.Id);
                    }
                }

                if (listRankError.Count != 0)
                {
                    StringBuilder sbd = new StringBuilder();
                    sbd.Append("Danh sách id các kết quả giảng viên không đủ điều kiện xếp loại: ");
                    for (int i = 0; i < listRankError.Count; i++)
                    {
                        if (i < listRankError.Count - 1)
                        {
                            sbd.Append(listRankError[i] + ", ");
                        }
                        else
                        {
                            sbd.Append(listRankError[i] + ".");
                        }
                    }
                    sbd.Append("\nVui lòng kiểm tra lại!");
                    MessageBox.Show(sbd.ToString(), "Danh sách sai sót", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadScoresTeacher();
                CellClick();
            }
        }

        private void buttonSaveSelect_Click(object sender, EventArgs e)
        {
            List<int> listRankError = new List<int>(); //Dùng để lưu lại id các kết quả không đủ điều kiện xếp loại
            foreach (int rowIndex in dataGridViewScoresTeacher.SelectedCells.Cast<DataGridViewCell>().Select(x => x.RowIndex).Distinct())
            {
                string rankHope = dataGridViewScoresTeacher.Rows[rowIndex].Cells["Rank1"].Value.ToString();
                ScoresTeacher tc = CreateScoresTeacherByRowIndex(rowIndex);
                if (tc != null)
                {
                    tc = Evaluation(tc);
                    if ((tc.Rank = CompareRankCondition(tc.Rank, rankHope)) != null) //Đủ điều kiện xếp loại thì duyệt
                    {
                        ScoresTeacherDAO.Instance.UpdateScoresTeacher(tc);
                    }
                    else
                    {
                        listRankError.Add(tc.Id);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đánh giá muốn lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (listRankError.Count != 0)
            {
                StringBuilder sbd = new StringBuilder();
                sbd.Append("Danh sách id các kết quả giảng viên không đủ điều kiện xếp loại: ");
                for (int i = 0; i < listRankError.Count; i++)
                {
                    if (i < listRankError.Count - 1)
                    {
                        sbd.Append(listRankError[i] + ", ");
                    }
                    else
                    {
                        sbd.Append(listRankError[i] + ".");
                    }
                }
                sbd.Append("\nVui lòng kiểm tra lại!");
                MessageBox.Show(sbd.ToString(), "Danh sách sai sót", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadScoresTeacher();
            CellClick();
        }

        private void comboBoxScores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxScores.SelectedIndex == 0)
            {
                typeScores = "Chưa hoàn thành";
                panelEditTool.Visible = true;
            }
            else
            {
                typeScores = "Hoàn thành";
                panelEditTool.Visible = false;
            }
            LoadScoresTeacher();
        }
    }
}
