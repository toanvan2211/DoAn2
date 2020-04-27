using DanhGiaDoanVien.DAO;
using DanhGiaDoanVien.DTO;
using DanhGiaDoanVien.Forms;
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
        private List<Semester> listSemester = new List<Semester>();
        GoodStudent gst;

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
                int idKQCD;

                if (int.TryParse(dataGridViewStudent.Rows[currentIndex].Cells["IdScoresGroup1"].Value.ToString(), out idKQCD))
                {
                    DataTable dataProvide = ScoresStudentDAO.Instance.GetInfo(idKQCD, MSSV);

                    textBoxName.Text = dataProvide.Rows[0]["tenSV"].ToString();
                    textBoxSemester.Text = dataProvide.Rows[0]["tenNamHoc"].ToString();
                    textBoxMSSV.Text = MSSV;
                    textBoxPoint1.Text = dataGridViewStudent.Rows[currentIndex].Cells["PointSemester11"].Value.ToString();
                    textBoxPoint2.Text = dataGridViewStudent.Rows[currentIndex].Cells["PointSemester21"].Value.ToString();
                    textBoxTrain1.Text = dataGridViewStudent.Rows[currentIndex].Cells["TrainSemester11"].Value.ToString();
                    textBoxTrain2.Text = dataGridViewStudent.Rows[currentIndex].Cells["TrainSemester21"].Value.ToString();
                    comboBoxRank.Text = dataGridViewStudent.Rows[currentIndex].Cells["Rank1"].Value.ToString();
                    textBoxGroup.Text = dataProvide.Rows[0]["idChiDoan"].ToString();
                    textBoxAchievement.Text = dataGridViewStudent.Rows[currentIndex].Cells["Achievement1"].Value.ToString();
                    textBoxNote.Text = dataGridViewStudent.Rows[currentIndex].Cells["Note1"].Value.ToString();
                    checkBoxGoodMember.Checked = Convert.ToBoolean(dataGridViewStudent.Rows[currentIndex].Cells["GoodMember1"].Value.ToString());

                    if (checkBoxGoodMember.Checked == true)
                    {
                        gst = new GoodStudent(GoodStudentDAO.Instance.GetInfo(idKQCD, MSSV).Rows[0]);
                    }
                    else
                    {
                        gst = null;
                    }
                }
            }
        }

        void LoadScoresStudent()
        {
            if (idCurrentSemester == "" && idCurrentGroup == "")
            {
                dataGridViewStudent.DataSource = ScoresStudentDAO.Instance.GetListScoresStudent();
            }
            else if (idCurrentSemester != "" && idCurrentGroup == "" )
            {
                dataGridViewStudent.DataSource = ScoresStudentDAO.Instance.GetListScoresStudentByID(idCurrentSemester, 2);
            }
            else if (idCurrentSemester == "" && idCurrentGroup != "")
            {
                dataGridViewStudent.DataSource = ScoresStudentDAO.Instance.GetListScoresStudentByID(idCurrentGroup, 1);
            }
            else
            {
                dataGridViewStudent.DataSource = ScoresStudentDAO.Instance.GetListScoresStudentByID(idCurrentGroup, idCurrentSemester);
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
            DataTable dataSM = SemesterDAO.Instance.GetListSemester();
            foreach (DataRow item in dataSM.Rows)
            {
                Semester sm = new Semester(item);
                listSemester.Add(sm);
            }
            foreach (DataRow item in dataSM.Rows)
            {
                comboBoxSemester.Items.Add(item["ten"]);
            }
        }

        bool CheckConditionGoodMember(ScoresStudent st) //Kiểm tra xem sinh viên này có đủ điều kiện để bình xét đoàn viên ưu tú hay không
        {
            bool result = false;
            if (st.Rank == "Xuất sắc" && st.AverageSemester1 >= 2.5 && st.AverageSemester2 >= 2.5 && st.AverageTrainingPoint >= 80)
            {
                result = true;
            }
            return result;
        }

        bool CheckConditionAmountGoodMember(ScoresStudent st)
        {
            bool result = false;
            DataTable data = ScoresStudentDAO.Instance.GetRankAndAmountOfExcellent(st.IdScoresGroup);
            string rank = data.Rows[0]["xepLoai"].ToString();
            int excellent = Convert.ToInt32(data.Rows[0]["xuatSac"].ToString());
            int goodMember = Convert.ToInt32(data.Rows[0]["tongDVUT"].ToString() + 1); //Cộng 1 ở đây là tính luôn sinh viên đang được xét thành DVUT

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

        bool CompareRankCondition(string evaluatedRank, string rankHope)
        {
            bool result = false;
            if (rankHope == "")
            {
                return true;
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
                        result = true;
                    }
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }

        ScoresStudent CreateScoresStudentByRowIndex(int index)
        {
            ScoresStudent st = new ScoresStudent();
            if (currentIndex != -1)
            {
                st.Id = Convert.ToInt32(dataGridViewStudent.Rows[index].Cells["Id1"].Value.ToString());
                st.IdScoresGroup = Convert.ToInt32(dataGridViewStudent.Rows[index].Cells["IdScoresGroup1"].Value.ToString());
                st.IdStudent = dataGridViewStudent.Rows[index].Cells["IdStudent1"].Value.ToString();
                st.Rank = dataGridViewStudent.Rows[index].Cells["Rank1"].Value.ToString();
                st.Achievement = dataGridViewStudent.Rows[index].Cells["Achievement1"].Value.ToString();
                st.IsGoodMember = Convert.ToBoolean(dataGridViewStudent.Rows[index].Cells["GoodMember1"].Value.ToString());
                st.Note = dataGridViewStudent.Rows[index].Cells["Note1"].Value.ToString();

                float temp = 0;
                float.TryParse(dataGridViewStudent.Rows[index].Cells["PointSemester11"].Value.ToString(), out temp);
                st.AverageSemester1 = temp;
                float.TryParse(dataGridViewStudent.Rows[index].Cells["PointSemester21"].Value.ToString(), out temp);
                st.AverageSemester2 = temp;
                int temp1 = 0;
                int.TryParse(dataGridViewStudent.Rows[index].Cells["TrainSemester11"].Value.ToString(), out temp1);
                st.PointTraning1 = temp1;
                int.TryParse(dataGridViewStudent.Rows[index].Cells["TrainSemester21"].Value.ToString(), out temp1);
                st.PointTraning2 = temp1;

                return st;
            }
            else
            {
                return null;
            }            
        }

        ScoresStudent CreateScoresStudentByText()
        {
            ScoresStudent st = new ScoresStudent();
            if (currentIndex != -1)
            {
                st.Id = Convert.ToInt32(dataGridViewStudent.Rows[currentIndex].Cells["Id1"].Value.ToString());
                st.IdScoresGroup = Convert.ToInt32(dataGridViewStudent.Rows[currentIndex].Cells["IdScoresGroup1"].Value.ToString());
                st.IdStudent = dataGridViewStudent.Rows[currentIndex].Cells["IdStudent1"].Value.ToString();
                st.Achievement = textBoxAchievement.Text;
                st.IsGoodMember = checkBoxGoodMember.Checked ? true : false;
                st.Note = textBoxNote.Text;

                float temp = 0;
                float.TryParse(textBoxPoint1.Text, out temp);
                st.AverageSemester1 = temp;
                float.TryParse(textBoxPoint2.Text, out temp);
                st.AverageSemester2 = temp;
                int temp1 = 0;
                int.TryParse(textBoxTrain1.Text, out temp1);
                st.PointTraning1 = temp1;
                int.TryParse(textBoxTrain2.Text, out temp1);
                st.PointTraning2 = temp1;

                return st;
            }
            else
            {
                return null;
            }
        }

        private ScoresStudent Evaluate(ScoresStudent scores)
        {
            scores.TotalAverage = (scores.AverageSemester1 + scores.AverageSemester2) / 2;
            scores.AverageTrainingPoint = (int)((scores.PointTraning1 + scores.PointTraning2) / 2);

            if (scores.AverageSemester1 >= 2.5 && scores.AverageSemester2 >= 2.5)
            {
                if (scores.AverageTrainingPoint >= 80 && scores.PointTraning1 >= 70 && scores.PointTraning2 >= 70)
                {
                    scores.Rank = Rank.rank1;
                }
                else if (scores.AverageTrainingPoint >= 70 && scores.PointTraning1 >= 60 && scores.PointTraning2 >= 60)
                {
                    scores.Rank = Rank.rank2;
                }
                else if (scores.PointTraning1 >= 50 && scores.PointTraning2 >= 50)
                {
                    scores.Rank = Rank.rank3;
                }
                else
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
                else
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
                else
                {
                    scores.Rank = Rank.rank4;
                }
            }
            else if (scores.AverageSemester1 < 1.0 || scores.AverageSemester2 < 1.0)
            {
                scores.Rank = Rank.rank4;
            }
            else
            {
                scores.Rank = Rank.rank4;
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
                idCurrentSemester = listSemester[comboBoxSemester.SelectedIndex - 1].Id;
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

        private void buttonAuto_Click(object sender, EventArgs e) //Cập nhật toàn bộ
        {
            DialogResult quest = MessageBox.Show("Bạn có chắc muốn cập nhật toàn bộ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (quest == DialogResult.Yes)
            {
                List<int> listRankError = new List<int>(); //Dùng để lưu lại id các kết quả không đủ điều kiện xếp loại
                foreach (DataGridViewRow row in dataGridViewStudent.Rows)
                {
                    string rankHope = row.Cells["Rank1"].Value.ToString();
                    ScoresStudent st = new ScoresStudent(row);
                    st = Evaluate(st);
                    if (CompareRankCondition(st.Rank, rankHope))
                    {
                        st.Rank = rankHope;
                        ScoresStudentDAO.Instance.UpdateScoresStudent(st);
                    }
                    else
                    {
                        listRankError.Add(st.Id);
                    }
                }

                if (listRankError.Count != 0)
                {
                    StringBuilder sbd = new StringBuilder();
                    sbd.Append("Danh sách các kết quả sinh viên không đủ điều kiện xếp loại: ");
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
                LoadScoresStudent();
                CellClick();
            }
        }

        private void buttonSaveSelect_Click(object sender, EventArgs e) //Chỉ cập nhật những hàng đc chọn
        {
            List<int> listRankError = new List<int>(); //Dùng để lưu lại id các kết quả không đủ điều kiện xếp loại
            foreach (int rowIndex in dataGridViewStudent.SelectedCells.Cast<DataGridViewCell>().Select(x => x.RowIndex).Distinct())
            {
                string rankHope = dataGridViewStudent.Rows[rowIndex].Cells["Rank1"].Value.ToString();
                ScoresStudent st = Evaluate(CreateScoresStudentByRowIndex(rowIndex));
                st = Evaluate(st);
                if (CompareRankCondition(st.Rank, rankHope))
                {
                    st.Rank = rankHope;
                    ScoresStudentDAO.Instance.UpdateScoresStudent(st);
                }
                else
                {
                    listRankError.Add(st.Id);
                }
            }

            if (listRankError.Count != 0)
            {
                StringBuilder sbd = new StringBuilder();
                sbd.Append("Danh sách các kết quả sinh viên không đủ điều kiện xếp loại: ");
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
            LoadScoresStudent();
            CellClick();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ScoresStudent student = CreateScoresStudentByText();
            if (student != null)
            {
                string rankHope = comboBoxRank.Text;
                student = Evaluate(student);
                if (CompareRankCondition(student.Rank, rankHope))
                {
                    student.Rank = rankHope;
                    if (checkBoxGoodMember.Checked) // Nếu sinh viên đc chọn là DVUT thì phải check điều kiện
                    {
                        if (CheckConditionGoodMember(student))
                        {
                            if (CheckConditionAmountGoodMember(student)) // Kiểm tra xem số lượng DVUT trong kết quả chi đoàn đã đạt tối đa chưa
                            {
                                ScoresStudentDAO.Instance.UpdateScoresStudent(student);
                                LoadScoresStudent();
                            }
                            else
                            {
                                MessageBox.Show("Số lượng DVUT trong chi đoàn đã đạt tối đa. Vui lòng cân nhắc lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sinh viên này không đủ điều kiện để xét DVUT. Vui lòng xem xét lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else // Không thì thôi
                    {
                        ScoresStudentDAO.Instance.UpdateScoresStudent(student);
                        LoadScoresStudent();
                    }
                    CellClick();
                }
                else
                {
                    MessageBox.Show("Sinh viên này không đủ điều kiện để được xếp loại \"" + rankHope + "\". Vui lòng xem xét lại!", "Không đủ điều kiện", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #region KeyPress   
        private void textBoxPoint1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = textBoxPoint1;
            float x;
            string test = tb.Text + e.KeyChar;

            if (test[test.Length - 1] == '.')
                test = test + "00";
            
            float.TryParse(test, out x);

            if (x > 4) // Nếu lớn hơn 4 thì chặn
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) //Nếu k phải là số, control, '.' thì chặn
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) && tb.Text.Length == 1) // Nếu là số và đc nhập vào ở vị trí thứ 2 thì chặn
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (tb.Text.Length == 0 || tb.Text.Length > 1)) // Nếu là dấu '.' và nhập vào ở vị trí đầu tiên hoặc sau 2 thì chặn
            {
                e.Handled = true;
            }

            if (tb.Text.Length == 4 && !char.IsControl(e.KeyChar)) // Nếu quá 4 kí tự thì chặn
            {
                e.Handled = true;
            }
        }

        private void textBoxPoint2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = textBoxPoint2;
            float x;
            string test = tb.Text + e.KeyChar;

            if (test[test.Length - 1] == '.')
                test = test + "00";

            float.TryParse(test, out x);

            if (x > 4) // Nếu lớn hơn 4 thì chặn
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) //Nếu k phải là số, control, '.' thì chặn
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) && tb.Text.Length == 1) // Nếu là số và đc nhập vào ở vị trí thứ 2 thì chặn
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (tb.Text.Length == 0 || tb.Text.Length > 1)) // Nếu là dấu '.' và nhập vào ở vị trí đầu tiên hoặc sau 2 thì chặn
            {
                e.Handled = true;
            }

            if (tb.Text.Length == 4 && !char.IsControl(e.KeyChar)) // Nếu quá 4 kí tự thì chặn
            {
                e.Handled = true;
            }
        }

        private void textBoxTrain1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = textBoxTrain1;
            int x;
            string test = tb.Text + e.KeyChar;

            int.TryParse(test, out x);

            if (x > 100) // Nếu lớn hơn 100 thì chặn
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //Nếu k phải là số, control, '.' thì chặn
            {
                e.Handled = true;
            }
        }

        private void textBoxTrain2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = textBoxTrain2;
            int x;
            string test = tb.Text + e.KeyChar;
            
            int.TryParse(test, out x);

            if (x > 100) // Nếu lớn hơn 100 thì chặn
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //Nếu k phải là số, control, '.' thì chặn
            {
                e.Handled = true;
            }
        }


        private void KeyPress_Column3(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            float x;
            string test = tb.Text + e.KeyChar;

            if (test[test.Length - 1] == '.')
                test = test + "00";

            float.TryParse(test, out x);

            if (x > 4) // Nếu lớn hơn 4 thì chặn
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) //Nếu k phải là số, control, '.' thì chặn
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) && tb.Text.Length == 1) // Nếu là số và đc nhập vào ở vị trí thứ 2 thì chặn
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (tb.Text.Length == 0 || tb.Text.Length > 1)) // Nếu là dấu '.' và nhập vào ở vị trí đầu tiên hoặc sau 2 thì chặn
            {
                e.Handled = true;
            }

            if (tb.Text.Length == 4 && !char.IsControl(e.KeyChar)) // Nếu quá 4 kí tự thì chặn
            {
                e.Handled = true;
            }
        }

        private void KeyPress_Column5(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int x;
            string test = tb.Text + e.KeyChar;

            int.TryParse(test, out x);

            if (x > 100) // Nếu lớn hơn 100 thì chặn
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //Nếu k phải là số, control, '.' thì chặn
            {
                e.Handled = true;
            }
        }
        #endregion

        private void dataGridViewStudent_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(KeyPress_Column3);
            e.Control.KeyPress -= new KeyPressEventHandler(KeyPress_Column5);
            if (dataGridViewStudent.CurrentCell.ColumnIndex == 3 || dataGridViewStudent.CurrentCell.ColumnIndex == 4)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(KeyPress_Column3);
                }
            }
            else if (dataGridViewStudent.CurrentCell.ColumnIndex == 5 || dataGridViewStudent.CurrentCell.ColumnIndex == 6)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(KeyPress_Column5);
                }
            }
        }

        private void buttonVoteGoodMember_Click(object sender, EventArgs e)
        {
            if (gst != null)
            {
                using (FormVote fmvte = new FormVote(gst, textBoxName.Text, textBoxSemester.Text))
                {
                    fmvte.ShowDialog();
                }
                int idKQCD = Convert.ToInt32(dataGridViewStudent.Rows[currentIndex].Cells["IdScoresGroup1"].Value.ToString());
                gst = new GoodStudent(GoodStudentDAO.Instance.GetInfo(idKQCD, gst.IdStudent).Rows[0]);
            }
            else
            {
                MessageBox.Show("Chưa chọn sinh viên, hoặc sinh viên này không phải là đoàn viên ưu tú!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
