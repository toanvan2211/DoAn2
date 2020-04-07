﻿using System;
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
    public partial class FormTeacher : Form
    {
        public FormTeacher()
        {
            InitializeComponent();
            LoadTeacher();
        }

        void LoadTeacher()
        {
            DataClassesDataContext db = new DataClassesDataContext();
            dataGridViewTeacher.DataSource = db.GiangViens.Select(t => t);
        }
    }
}
