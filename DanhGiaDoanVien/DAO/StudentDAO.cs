using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    public class StudentDAO
    {
        private static StudentDAO instance;
        public static StudentDAO Instance
        {
            get { if (instance == null) instance = new StudentDAO(); return instance; }
            private set { instance = value; }
        }
        public StudentDAO() { }

        public DataTable GetListStudent(string group, string sex, string isMember)
        {
            string query = "";

            if (group == "Tất cả" && sex == "Tất cả" && isMember == "Tất cả")
            {
                query = "USP_GetListStudent";
            }
            else if (group == "Tất cả")
            {
                if (sex == "Tất cả")
                {
                    if (isMember == "Có")
                        query = "select * from SinhVien where doanVien = 'True'";
                    else
                        query = "select * from SinhVien where doanVien = 'False'";
                }
                if (sex != "Tất cả")
                {
                    if (isMember == "Có")
                        query = "select * from SinhVien where doanVien = 'True' and gioiTinh = N'" + sex + "'";
                    else if (isMember == "Không")
                        query = "select * from SinhVien where doanVien = 'False' and gioiTinh = N'" + sex + "'";
                    else
                        query = "select * from SinhVien where gioiTinh = N'" + sex + "'";
                }
            }
            else if (group != "Tất cả")
            {
                if (sex == "Tất cả")
                {
                    if (isMember == "Có")
                        query = "select * from SinhVien where doanVien = 'True' and chiDoan = '" + group + "'";
                    else if (isMember == "Không")
                        query = "select * from SinhVien where doanVien = 'False' and chiDoan = '" + group + "'";
                    else
                        query = "select * from SinhVien where chiDoan = '" + group + "'";
                }
                if (sex != "Tất cả")
                {
                    if (isMember == "Có")
                        query = "select * from SinhVien where doanVien = 'True' and gioiTinh = N'" + sex + "' and chiDoan = '" + group + "'";
                    else if (isMember == "Không")
                        query = "select * from SinhVien where doanVien = 'False' and gioiTinh = N'" + sex + "' and chiDoan = '" + group + "'";
                    else
                        query = "select * from SinhVien where gioiTinh = N'" + sex + "' and chiDoan = '" + group + "'";
                }
            }

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int AddStudent(string idStudent, string name, string sex, string group, bool isMember)
        {
            string query = "USP_AddStudent @idStudent , @name , @sex , @group , @isMember";
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idStudent, name, sex, group, isMember });
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return -1;
            }
        }

        public int UpdateStudent(string idStudent, string name, string sex, string group, bool isMember)
        {
            string query = "USP_UpdateStudent @idStudent , @name , @sex , @group , @isMember";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idStudent, name, sex, group, isMember });
        }

        public int DeleteStudent(string idStudent)
        {
            string query = "USP_DeleteStudent @idStudent";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idStudent });
        }
    }
}
