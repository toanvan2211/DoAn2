using DanhGiaDoanVien.DAO;
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

        public FormEvaluateTeacher()
        {
            InitializeComponent();
        }

        #region method
        void LoadScoresTeacher()
        {
            dataGridViewScoresTeacher.DataSource = ScoresTeacherDAO.Instance.GetListScoresTeacher();
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

        void CreateScoresTeacher(string idTeacher, string idSemester)
        {
            ScoresTeacherDAO.Instance.AddScoresTeacher(idTeacher, idSemester);
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
    }
}
