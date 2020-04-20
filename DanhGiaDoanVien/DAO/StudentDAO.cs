using DanhGiaDoanVien.DTO;
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

        public DataTable GetListStudent()
        {
            string query = "USP_GetListStudent";
            return DataProvider.Instance.ExecuteQuery(query);
        }

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
            if (group == "")
            {
                try
                {
                    query = "insert into SinhVien (MSSV, ten, gioiTinh, doanVien)" +
                    "values ('" + idStudent + "', '" + name + "', '" + sex + "', '" + isMember + "')";
                    return DataProvider.Instance.ExecuteNonQuery(query);
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    return -1;
                }
            }
            else
            {
                try
                {
                    return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idStudent, name, sex, group, isMember });
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    return -1;
                }
            }
            
        }

        public int UpdateStudent(string idStudent, string name, string sex, string group, bool isMember)
        {
            string query = "USP_UpdateStudent @idStudent , @name , @sex , @group , @isMember";
            if (group == "")
            {
                try
                {
                    query = "update SinhVien set ten = '" + name + "', gioiTinh = '" + sex + "', doanVien = N'" + isMember + "' where MSSV = '" + idStudent + "'";
                    return DataProvider.Instance.ExecuteNonQuery(query);
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    return -1;
                }
            }
            else
            {
                return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idStudent, name, sex, group, isMember });
            }
        }

        public int UpdateStudent(Student student, string name, string sex, string group, bool isMember)
        {
            string query = "update SinhVien set ";
            StringBuilder sb = new StringBuilder();
            sb.Append(query);

            bool[] check = new bool[4] { true, true, true, true };
            string[] values = new string[3] { name, sex, group };
            string[] nameProperties = new string[4] { "ten", "gioiTinh", "chiDoan", "doanVien" };
            int count = 0;
            if (student.Name == name)
            {
                check[0] = false;
                count++;
            }
            if (student.Sex == sex)
            {
                check[1] = false;
                count++;
            }
            if (student.Group == group)
            {
                check[2] = false;
                count++;
            }
            if (student.IsMember == isMember)
            {
                check[3] = false;
                count++;
            }

            if (count == 4)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < check.Length - 1; i++)
                {
                    if (check[i] == true)
                    {
                        if (i >= 1 && check[i - 1])
                        {
                            sb.Append(", ");
                        }
                        if (i == 2 && group == "")
                        {
                            sb.Append(nameProperties[i] + " = null");
                        }
                        else
                        {
                            sb.Append(nameProperties[i] + " = N'" + values[i] + "'");
                        }
                    }
                }
                if (check[3] == true)
                {
                    if (isMember == true)
                    {
                        if (count < 3)
                            sb.Append(", ");
                        sb.Append(nameProperties[3] + " = 1");
                    }
                    else
                    {
                        if (count < 3)
                            sb.Append(", ");
                        sb.Append(nameProperties[3] + " = 0");
                    }
                }
                sb.Append(" where MSSV = '" + student.IdStudent + "'");
                query = sb.ToString();

                if (check[1] == true && check[2] == false)
                {
                    DataProvider.Instance.ExecuteNonQuery("USP_ChangeSexStudent @idGroup , @sex , @oldSex", new object[] { student.Group, sex, student.Sex });
                }

                if (check[2] == true)
                {
                    DataProvider.Instance.ExecuteNonQuery("USP_ChangeGroupStudent @idStudent , @idGroup , @idOldGroup , @sex , @oldSex", new object[] { student.IdStudent, group, student.Group, sex, student.Sex });
                }

                return DataProvider.Instance.ExecuteNonQuery(query);
            }
        }

        public int DeleteStudent(string idStudent)
        {
            string query = "USP_DeleteStudent @idStudent";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idStudent });
        }

        public DataTable GetListStudentByGroupID(string idGroup)
        {
            string query = "select MSSV as id, ten, gioiTinh, chiDoan, doanVien from SinhVien where chiDoan = '" + idGroup + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
