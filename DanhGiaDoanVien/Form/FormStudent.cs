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
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
            LoadForm();
        }

        private void LoadForm()
        {
            DataClassesDataContext db = new DataClassesDataContext();
            dataGridViewTeacher.DataSource = db.SinhViens.Select(t => t);
        }
    }
}
