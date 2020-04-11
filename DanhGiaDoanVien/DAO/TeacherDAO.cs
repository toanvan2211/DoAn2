using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    public class TeacherDAO
    {
        private static TeacherDAO instance;
        public static TeacherDAO Instance
        {
            get { if (instance == null) instance = new TeacherDAO(); return instance; }
            private set { instance = value; }
        }
        public TeacherDAO() { }

        public DataTable GetListTeacher(string group, string sex, string isMember)
        {
            string query = "";
 
            if (group == "Tất cả" && sex == "Tất cả" && isMember == "Tất cả")
            {
                query = "USP_GetListTeacher";
            }
            else if (group == "Tất cả")
            {
                if (sex == "Tất cả")
                {
                    if (isMember == "Có")
                        query = "select * from GiangVien where doanVien = 'True'";
                    else
                        query = "select * from GiangVien where doanVien = 'False'";
                }
                if (sex != "Tất cả")
                {
                    if (isMember == "Có")
                        query = "select * from GiangVien where doanVien = 'True' and gioiTinh = N'" + sex + "'";
                    else if (isMember == "Không")
                        query = "select * from GiangVien where doanVien = 'False' and gioiTinh = N'" + sex + "'";
                    else
                        query = "select * from GiangVien where gioiTinh = N'" + sex + "'";
                }
            }
            else if (group != "Tất cả")
            {
                if (sex == "Tất cả")
                {
                    if (isMember == "Có")
                        query = "select * from GiangVien where doanVien = 'True' and chiDoan = '" + group + "'";
                    else if (isMember == "Không")
                        query = "select * from GiangVien where doanVien = 'False' and chiDoan = '" + group + "'";
                    else
                        query = "select * from GiangVien where chiDoan = '" + group + "'";
                }
                if (sex != "Tất cả")
                {
                    if (isMember == "Có")
                        query = "select * from GiangVien where doanVien = 'True' and gioiTinh = N'" + sex + "' and chiDoan = '" + group + "'";
                    else if (isMember == "Không")
                        query = "select * from GiangVien where doanVien = 'False' and gioiTinh = N'" + sex + "' and chiDoan = '" + group + "'";
                    else
                        query = "select * from GiangVien where gioiTinh = N'" + sex + "' and chiDoan = '" + group + "'";
                }
            }
                
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
