using DanhGiaDoanVien.DTO;
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


        public DataTable GetListTeacher()
        {
            string query = "USP_GetListTeacher";
            return DataProvider.Instance.ExecuteQuery(query);
        }


        public DataTable GetListTeacher(string group, string sex, string isMember)
        {
            StringBuilder sbd = new StringBuilder();
            string query = "select * from GiangVien";
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

        public int AddTeacher(string idTeacher, string name, string sex, string group, bool isMember)
        {
            string query = "USP_AddTeacher @idTeacher , @name , @sex , @group , @isMember";
            
            if (group == "")
            {
                try
                {
                    query = "insert into GiangVien " +
                    "values ('" + idTeacher + "', '" + name + "', '" + sex + "', default, '" + isMember + "')";
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
                    return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idTeacher, name, sex, group, isMember });
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    return -1;
                }
            }
        }

        public int UpdateTeacher(Teacher teacher, string name, string sex, string group, bool isMember)
        {
            string query = "update GiangVien set ";
            StringBuilder sb = new StringBuilder();
            sb.Append(query);

            bool[] check = new bool[4] { true, true, true, true};
            string[] values = new string[3] { name, sex, group};
            string[] nameProperties = new string[4] { "ten", "gioiTinh", "chiDoan", "doanVien" };
            int count = 0;
            if (teacher.Name == name)
            {
                check[0] = false;
                count++;
            }
            if (teacher.Sex == sex)
            {
                check[1] = false;
                count++;
            }
            if (teacher.Group == group)
            {
                check[2] = false;
                count++;
            }
            if (teacher.IsMember == isMember)
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
                sb.Append(" where MSGV = '" + teacher.IdTeacher + "'");
                query = sb.ToString();

                string temp = "";

                //Only thay đổi group
                if (check[2] == true)
                {
                    temp = "select * from GiangVien gv, KetQuaChiDoan kqcd where gv.ChiDoan = kqcd.idChiDoan and daXong = 0 and gv.MSGV = '" + teacher.IdTeacher + "'";

                    DataTable data = DataProvider.Instance.ExecuteQuery(temp);
                    if (data.Rows.Count != 0)
                    {
                        return -696;
                    }

                    temp = "update ChiDoan set soThanhVien -= 1, tongGV -= 1 where id = '" + teacher.Group + "'";
                    DataProvider.Instance.ExecuteNonQuery(temp);
                    temp = "update ChiDoan set soThanhVien += 1, tongGV += 1 where id = '" + group + "'";
                    DataProvider.Instance.ExecuteNonQuery(temp);
                }

                //Only thay đổi giới tính
                if (check[1] == true && check[2] == false)
                {
                    if (teacher.Sex == "Nam")
                    {
                        temp = "update chiDoan set tongNuGV += 1 where id = '" + teacher.Group + "'";
                        DataProvider.Instance.ExecuteNonQuery(temp);
                    }
                    else
                    {
                        temp = "update chiDoan set tongNuGV -= 1 where id = '" + teacher.Group + "'";
                        DataProvider.Instance.ExecuteNonQuery(temp);
                    }
                }
                else if (check[1] == true && check[2] == true)
                {
                    if (teacher.Sex == "Nam")
                    {
                        temp = "update chiDoan set tongNuGV += 1 where id = '" + group + "'";
                        DataProvider.Instance.ExecuteNonQuery(temp);
                    }
                    else
                    {
                        temp = "update chiDoan set tongNuGV -= 1 where id = '" + teacher.Group + "'";
                        DataProvider.Instance.ExecuteNonQuery(temp);
                    }
                }
                else if (check[1] == false && check[2] == true)
                {
                    if (teacher.Sex == "Nữ")
                    {
                        temp = "update chiDoan set tongNuGV -= 1 where id = '" + teacher.Group + "'";
                        DataProvider.Instance.ExecuteNonQuery(temp);
                        temp = "update chiDoan set tongNuGV += 1 where id = '" + group + "'";
                        DataProvider.Instance.ExecuteNonQuery(temp);
                    }
                }

                return DataProvider.Instance.ExecuteNonQuery(query);
            }
        }

        public int DeleteTeacher(string idTeacher)
        {
            string query = "USP_DeleteTeacher @idTeacher";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idTeacher});
        }

        public int ChangeGroup(string idTeacher, string idGroup)
        {
            string query = "USP_ChangeGroup @idTeacher , @idGroup";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idTeacher, idGroup });
        }

        public DataTable GetListTeacherByGroupID(string idGroup)
        {
            string query = "select MSGV as id, ten, gioiTinh, chiDoan, doanVien from GiangVien where chiDoan = '" + idGroup + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
