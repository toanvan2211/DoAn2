﻿using DanhGiaDoanVien.DAO;
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
    public partial class FormGroup : Form
    {
        public FormGroup()
        {
            InitializeComponent();
            LoadForm();
        }

        void LoadForm()
        {
            LoadListGroup();
        }

        void LoadListGroup()
        {
            dataGridViewGroup.DataSource = GroupDAO.Instance.GetListGroup();
        }
    }
}
