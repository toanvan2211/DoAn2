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
        public FormEvaluateTeacher()
        {
            InitializeComponent();
        }

        #region method
        void LoadEvalutaionTeacher()
        {
            dataGridViewScoresTeacher.DataSource = ScoresTeacherDAO.Instance.GetListScoresTeacher();
        }

        void CreateScoresTeacher(string idTeacher, string idSemester)
        {
            ScoresTeacherDAO.Instance.AddScoresTeacher(idTeacher, idSemester);
        }
        #endregion

        private void FormEvaluateTeacher_Load(object sender, EventArgs e)
        {

            LoadEvalutaionTeacher();
        }
    }
}
