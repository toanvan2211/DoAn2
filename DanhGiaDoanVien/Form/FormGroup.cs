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

namespace DanhGiaDoanVien
{
    public partial class FormGroup : Form
    {
        public FormGroup()
        {
            InitializeComponent();
            LoadForm();
        }
        #region method
        void LoadListGroup()
        {
            dataGridViewGroup.DataSource = GroupDAO.Instance.GetListGroup();
        }

        void CreateGroup(string idGroup, string name)
        {
            int result;
            result = GroupDAO.Instance.AddGroup(idGroup, name);
            if (result > 0)
            {
                LoadListGroup();
            }
            else if (result == -1)
            {
                MessageBox.Show("ID mà bạn nhập đã được sử dụng!", "Trùng ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Thất bại, thử lại sau", "Đã xảy ra lỗi");
            }
        }

        void UpdateGroup(string idGroup, string name)
        {
            int result;
            result = GroupDAO.Instance.UpdateGroup(idGroup, name);
            if (result > 0)
            {
                LoadListGroup();
            }
            else
            {
                MessageBox.Show("Thất bại, thử lại sau", "Đã xảy ra lỗi");
            }
        }

        void DeleteGroup(string idGroup)
        {
            int result;
            result = GroupDAO.Instance.DeleteGroup(idGroup);
            if (result > 0)
            {
                LoadListGroup();
            }
            else
            {
                MessageBox.Show("Thất bại, thử lại sau", "Đã xảy ra lỗi");
            }
        }

        void AddMemberToGroup(Teacher[] teacher, string idGroup) 
        {
            //Đổi id chi đoàn của giảng viên hoặc sinh viên thành một id mới, chi đoàn cũ sẽ giảm số thành viên, chi đoàn này sẽ tăng thành viên
            GroupDAO.Instance.AddMemberToGroup(teacher, idGroup);
        }

        void AddMemberToGroup(Student[] student, string idGroup)
        {
            //Đổi id chi đoàn của giảng viên hoặc sinh viên thành một id mới, chi đoàn cũ sẽ giảm số thành viên, chi đoàn này sẽ tăng thành viên
            GroupDAO.Instance.AddMemberToGroup(student, idGroup);
        }
        #endregion
        void LoadForm()
        {
            LoadListGroup();
        }
    }
}
