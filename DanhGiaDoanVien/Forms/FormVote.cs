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
    public partial class FormVote : Form
    {
        GoodStudent st;
        GoodTeacher tc;
        public FormVote(GoodStudent mb, string name, string semester)
        {
            InitializeComponent();
            st = mb;
            LoadData(mb, name, semester);
        }

        public FormVote(GoodTeacher mb, string name, string semester)
        {
            InitializeComponent();
            tc = mb;
            LoadData(mb, name, semester);
        }

        #region method
        void LoadData(GoodStudent st, string name, string semester)
        {
            textBoxIdMember.Text = st.IdStudent;
            textBoxVoteFor.Text = st.Vote.ToString();
            textBoxTotalVote.Text = st.TotalVote.ToString();
            textBoxName.Text = name;
            textBoxSemester.Text = semester;
        }

        void LoadData(GoodTeacher tc, string name, string semester)
        {
            textBoxIdMember.Text = tc.IdTeacher;
            textBoxVoteFor.Text = tc.Vote.ToString();
            textBoxTotalVote.Text = tc.TotalVote.ToString();
            textBoxName.Text = name;
            textBoxSemester.Text = semester;
        }

        void SaveVote()
        {
            if (st == null)
            {
                GoodTeacherDAO.Instance.SaveVote(tc.IdScoresGroup, tc.IdTeacher, Convert.ToInt32(textBoxVoteFor.Text), Convert.ToInt32(textBoxTotalVote.Text));
            }
            else
            {
                GoodStudentDAO.Instance.SaveVote(st.IdScoresGroup, st.IdStudent, Convert.ToInt32(textBoxVoteFor.Text), Convert.ToInt32(textBoxTotalVote.Text));
            }
        }

        #endregion

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveVote();
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxTotalVote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
