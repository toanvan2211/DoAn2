﻿using DanhGiaDoanVien.DAO;
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
        private bool checkDownRank = false;
        
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
                    comboBoxRank.ResetText();
            }
            else
            {
                textBoxIdGroup.ResetText();
                textBoxMember.ResetText();
                textBoxTeacher.ResetText();
                textBoxStudent.ResetText();
                textBoxExcellent.ResetText();
                textBoxGreate.ResetText();
                textBoxMedium.ResetText();
                textBoxBad.ResetText();
                textBoxNote.ResetText();
                textBoxGoodMember.ResetText();
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

        ScoresGroup CreateScoresGroupByText()
        {
            ScoresGroup sg = new ScoresGroup();
            sg.Id = Convert.ToInt32(dataGridViewScoresGroup.Rows[currentIndex].Cells["Id1"].Value.ToString());
            sg.IdSemester = dataGridViewScoresGroup.Rows[currentIndex].Cells["Semester1"].Value.ToString();
            sg.ExcellentMember = Convert.ToInt32(dataGridViewScoresGroup.Rows[currentIndex].Cells["Excellent1"].Value.ToString());
            sg.GreatMember = Convert.ToInt32(dataGridViewScoresGroup.Rows[currentIndex].Cells["Great1"].Value.ToString());
            sg.MediumMember = Convert.ToInt32(dataGridViewScoresGroup.Rows[currentIndex].Cells["Medium1"].Value.ToString());
            sg.BadMember = Convert.ToInt32(dataGridViewScoresGroup.Rows[currentIndex].Cells["Bad1"].Value.ToString());
            sg.TotalMember = Convert.ToInt32(dataGridViewScoresGroup.Rows[currentIndex].Cells["TotalMember1"].Value.ToString());
            sg.TotalStudent = Convert.ToInt32(dataGridViewScoresGroup.Rows[currentIndex].Cells["TotalStudent1"].Value.ToString());
            sg.TotalTeacher = Convert.ToInt32(dataGridViewScoresGroup.Rows[currentIndex].Cells["TotalTeacher1"].Value.ToString());
            sg.TotalGoodMember = Convert.ToInt32(dataGridViewScoresGroup.Rows[currentIndex].Cells["TotalGoodMember1"].Value.ToString());
            sg.TotalFemalStudent = Convert.ToInt32(dataGridViewScoresGroup.Rows[currentIndex].Cells["TotalFemaleStudent1"].Value.ToString());
            sg.TotalFemalTeacher = Convert.ToInt32(dataGridViewScoresGroup.Rows[currentIndex].Cells["TotalFemaleTeacher1"].Value.ToString());
            sg.Note = textBoxNote.Text;

            sg = EvaluateGroup(sg);

            return sg;
        }

        void LoadComboBoxGroupNoEmpty()
        {
            DataTable dt = ScoresGroupDAO.Instance.GetListGroupHaveScores();

            foreach (DataRow item in dt.Rows)
            {
                comboBoxGroup.Items.Add(item["idChiDoan"]);
            }
        }

        void LoadListGroup()
        {
            if (idCurrentSemester == "")
            {
                comboBoxGroupEmpty.DataSource = null;
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

                comboBoxSemester.Items.Add(item["ten"]);
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

        ScoresGroup EvaluateGroup(ScoresGroup scoresGroup)
        {
            if (scoresGroup.TotalMember == 0) // Nếu chi đoàn chưa có đoàn viên thì không đánh giá được, nên để xếp loại là ""
            {
                scoresGroup.Rank = RankGroup.rank4;
            }
            else
            {
                int greatMember = scoresGroup.ExcellentMember + scoresGroup.GreatMember;
                if ((((float)greatMember / (float)scoresGroup.TotalMember) * 100) >= 80 && scoresGroup.BadMember == 0)
                {
                    scoresGroup.Rank = RankGroup.rank1;
                }
                else if ((((float)greatMember / (float)scoresGroup.TotalMember) * 100) >= 60 && scoresGroup.BadMember == 0)
                {
                    scoresGroup.Rank = RankGroup.rank2;
                }
                else if ((((float)greatMember / (float)scoresGroup.TotalMember) * 100) >= 50 && (((float)scoresGroup.BadMember / (float)scoresGroup.TotalMember) * 100) <= 20)
                {
                    scoresGroup.Rank = RankGroup.rank3;
                }
                else
                {
                    scoresGroup.Rank = RankGroup.rank4;
                }
            }
            return scoresGroup;
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
                        case "Chi đoàn vững mạnh":
                            compareRank[0] = 1;
                            break;
                        case "Chi đoàn khá":
                            compareRank[0] = 2;
                            break;
                        case "Chi đoàn trung bình":
                            compareRank[0] = 3;
                            break;
                        case "Chi đoàn yếu kém":
                            compareRank[0] = 4;
                            break;
                    }
                    switch (rankHope)
                    {
                        case "Chi đoàn vững mạnh":
                            compareRank[1] = 1;
                            break;
                        case "Chi đoàn khá":
                            compareRank[1] = 2;
                            break;
                        case "Chi đoàn trung bình":
                            compareRank[1] = 3;
                            break;
                        case "Chi đoàn yếu kém":
                            compareRank[1] = 4;
                            break;
                    }
                    if (compareRank[0] <= compareRank[1])
                    {
                        if (compareRank[0] < compareRank[1])
                            checkDownRank = true;
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
            LoadComboBoxGroupNoEmpty();

            if (comboBoxGroupEmpty.Text != "")
            {
                comboBoxGroupEmpty.SelectedIndex = 0;
            }

            comboBoxGroup.SelectedIndex = 0;
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
                DialogResult dlr = MessageBox.Show("Bạn có thật sự muốn xóa?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    ScoresGroupDAO.Instance.DeleteScoresGroup(idCurrentScoresGroup);
                    LoadListScoresGroup();
                    LoadListGroup();
                    currentIndex = -1;
                    CellClick();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đánh giá muốn xóa!", "Chưa chọn đánh giá", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (currentIndex != -1)
            {
                ScoresGroup sg = new ScoresGroup();
                sg = CreateScoresGroupByText();
                string rankHope = comboBoxRank.Text;
                if (sg.Rank != "")
                {
                    sg = EvaluateGroup(sg);
                    if ((sg.Rank = CompareRankCondition(sg.Rank, rankHope)) != null) // Nếu rank đủ điểu kiện lớn hơn rank mong muốn thì duyệt, ngược lại thì thông báo
                    {
                        sg.Note = textBoxNote.Text;
                        ScoresGroupDAO.Instance.UpdateScoresGroup(sg.Id, sg.Rank, sg.Note);

                        if (checkDownRank)
                        {
                            ScoresGroupDAO.Instance.ResetGoodMember(sg.Id);
                            checkDownRank = false;
                        }
                        LoadListScoresGroup();
                        CellClick();
                    }
                    else
                    {
                        MessageBox.Show("Chi đoàn này không đủ điều kiện để được xếp loại \"" + rankHope + "\". Vui lòng xem xét lại!", "Không đủ điều kiện", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đánh giá muốn sửa!", "Chưa chọn đánh giá", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSaveSelect_Click(object sender, EventArgs e)
        {
            List<int> listRankError = new List<int>(); //Dùng để lưu lại id các kết quả không đủ điều kiện xếp loại
            foreach (int rowIndex in dataGridViewScoresGroup.SelectedCells.Cast<DataGridViewCell>().Select(x => x.RowIndex).Distinct())
            {
                ScoresGroup sg = EvaluateGroup(CreateScoresGroupByRowIndex(rowIndex));

                string rankHope = dataGridViewScoresGroup.Rows[rowIndex].Cells["Rank1"].Value.ToString();
                if ((sg.Rank = CompareRankCondition(sg.Rank, rankHope)) != null) //Đủ điều kiện xếp loại thì duyệt
                {
                    ScoresGroupDAO.Instance.UpdateScoresGroup(sg.Id, sg.Rank, sg.Note);

                    if (checkDownRank)
                    {
                        ScoresGroupDAO.Instance.ResetGoodMember(sg.Id);
                        checkDownRank = false;
                    }
                }
                else //Không thì lưu lại id kết quả để báo lỗi
                {
                    listRankError.Add(sg.Id);
                }
            }

            if (listRankError.Count != 0)
            {
                StringBuilder sbd = new StringBuilder();
                sbd.Append("Danh sách id các kết quả chi đoàn không đủ điều kiện xếp loại: ");
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
            LoadListScoresGroup();
            CellClick();
        }

        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            DialogResult quest = MessageBox.Show("Bạn có chắc muốn cập nhật toàn bộ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (quest == DialogResult.Yes)
            {
                List<int> listRankError = new List<int>(); //Dùng để lưu lại id các kết quả không đủ điều kiện xếp loại
                foreach (DataGridViewRow row in dataGridViewScoresGroup.Rows)
                {
                    string rankHope = row.Cells["Rank1"].Value.ToString();
                    ScoresGroup sg = new ScoresGroup(row);
                    sg = EvaluateGroup(sg);
                    if ((sg.Rank = CompareRankCondition(sg.Rank, rankHope)) != null) //Đủ điều kiện xếp loại thì duyệt
                    {
                        ScoresGroupDAO.Instance.UpdateScoresGroup(sg.Id, sg.Rank, sg.Note);
                        
                        if (checkDownRank)
                        {
                            ScoresGroupDAO.Instance.ResetGoodMember(sg.Id);
                            checkDownRank = false;
                        }
                    }
                    else //Không thì lưu lại id kết quả để báo lỗi
                    {
                        listRankError.Add(sg.Id);
                    }
                }

                if (listRankError.Count != 0)
                {
                    StringBuilder sbd = new StringBuilder();
                    sbd.Append("Danh sách id các kết quả chi đoàn không đủ điều kiện xếp loại: ");
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
                LoadListScoresGroup();
                CellClick();
            }
        }

        private void buttonCheckDone_Click(object sender, EventArgs e)
        {
            if (currentIndex != -1)
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc rằng muốn đánh dấu hoàn thành cho đánh giá này?", "Bạn chắc chứ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    ScoresGroup sg = new ScoresGroup(dataGridViewScoresGroup.Rows[currentIndex]);
                    if (sg.Rank == "")
                    {
                        MessageBox.Show("Kết quả này chưa có xếp loại. Vui lòng thử lại sau!", "Thiếu sót", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        ScoresGroupDAO.Instance.CheckDoneScoresGroup(sg.Id);
                        LoadListScoresGroup();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đánh giá bạn muốn hoàn thành!", "Chưa chọn đánh giá", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
