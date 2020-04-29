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
            StringBuilder sbd = new StringBuilder();
            string query = "select * from SinhVien";
            sbd.Append(query);

            int[] input = new int[3] { 1, 1, 1 };
            if (group == "Tất cả")
                input[0] = 0;
            if (sex == "Tất cả")
                input[1] = 0;
            if (isMember == "Tất cả")
                input[2] = 0;

            if (group == "")
                input[0] = 2;

            if (isMember == "Có")
                isMember = "True";
            else if (isMember == "Không")
                isMember = "False";

            if ((input[0] + input[1] + input[2]) == 0)
            {
                return DataProvider.Instance.ExecuteQuery(query);
            }
            else if (input[0] == 1)
            {
                sbd.Append(" where chiDoan = '" + group + "'");
                if (input[1] == 1)
                    sbd.Append(" and gioiTinh = N'" + sex + "'");
                if (input[2] == 1)
                    sbd.Append(" and doanVien = '" + isMember + "'");
            }
            else if (input[1] == 1)
            {
                sbd.Append(" where gioiTinh = N'" + sex + "'");
                if (input[2] == 1)
                    sbd.Append(" and doanVien = '" + isMember + "'");
                if (input[0] == 2)
                    sbd.Append(" and chiDoan is null");
            }
            else if (input[2] == 1)
            {
                sbd.Append(" where doanVien = '" + isMember + "'");
                if (input[0] == 2)
                    sbd.Append(" and chiDoan is null");
            }
            else if (input[0] == 2)
            {
                sbd.Append(" where chiDoan is null");
            }

            query = sbd.ToString();
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int AddStudent(string idStudent, string name, string sex, string group, bool isMember)
        {
            string query = "USP_AddStudent @idStudent , @name , @sex , @group , @isMember";
            if (group == "")
            {
                try
                {
                    query = "insert into SinhVien " +
                    "values ('" + idStudent + "', '" + name + "', '" + sex + "', default, '" + isMember + "')";
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

                string temp = "";
                
                //Only thay đổi group
                if (check[2] == true)
                {
                    temp = "select * from SinhVien sv, KetQuaChiDoan kqcd where sv.ChiDoan = kqcd.idChiDoan and daXong = 0 and sv.MSSV = '" + student.IdStudent + "'";

                    DataTable data = DataProvider.Instance.ExecuteQuery(temp);
                    if (data.Rows.Count != 0)
                    {
                        return -696;
                    }

                    temp = "update ChiDoan set soThanhVien -= 1, tongSV -= 1 where id = '" + student.Group + "'";
                    DataProvider.Instance.ExecuteNonQuery(temp);
                    temp = "update ChiDoan set soThanhVien += 1, tongSV += 1 where id = '" + group + "'";
                    DataProvider.Instance.ExecuteNonQuery(temp);
                }

                //Only thay đổi giới tính
                if (check[1] == true && check[2] == false)
                {
                    if (student.Sex == "Nam")
                    {
                        temp = "update chiDoan set tongNuSV += 1 where id = '" + student.Group + "'";
                        DataProvider.Instance.ExecuteNonQuery(temp);
                    }
                    else
                    {
                        temp = "update chiDoan set tongNuSV -= 1 where id = '" + student.Group + "'";
                        DataProvider.Instance.ExecuteNonQuery(temp);
                    }
                }
                else if (check[1] == true && check[2] == true)
                {
                    if (student.Sex == "Nam")
                    {
                        temp = "update chiDoan set tongNuSV += 1 where id = '" + group + "'";
                        DataProvider.Instance.ExecuteNonQuery(temp);
                    }
                    else
                    {
                        temp = "update chiDoan set tongNuSV -= 1 where id = '" + student.Group + "'";
                        DataProvider.Instance.ExecuteNonQuery(temp);
                    }
                }
                else if (check[1] == false && check[2] == true)
                {
                    if (student.Sex == "Nữ")
                    {
                        temp = "update chiDoan set tongNuSV -= 1 where id = '" + student.Group + "'";
                        DataProvider.Instance.ExecuteNonQuery(temp);
                        temp = "update chiDoan set tongNuSV += 1 where id = '" + group + "'";
                        DataProvider.Instance.ExecuteNonQuery(temp);
                    }
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
