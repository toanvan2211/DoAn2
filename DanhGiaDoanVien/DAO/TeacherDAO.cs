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

        public int AddTeacher(string idTeacher, string name, string sex, string group, bool isMember)
        {
            string query = "USP_AddTeacher @idTeacher , @name , @sex , @group , @isMember";
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idTeacher, name, sex, group, isMember });
            }catch (System.Data.SqlClient.SqlException)
            {
                return -1;
            }
        }

        public int UpdateTeacher(string idTeacher, string name, string sex, string group, bool isMember)
        {
            string query = "USP_UpdateTeacher @idTeacher , @name , @sex , @group , @isMember";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idTeacher, name, sex, null, isMember });
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
                        sb.Append(nameProperties[i] + " = N'" + values[i] + "'");
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

                if (check[1] == true)
                {
                    DataProvider.Instance.ExecuteNonQuery("USP_ChangeSexTeacher @idGroup , @sex , @oldSex", new object[] { teacher.Group, sex, teacher.Sex });
                }

                if (check[2] == true)
                {
                    DataProvider.Instance.ExecuteNonQuery("USP_ChangeGroupTeacher @idTeacher , @idGroup , @idOldGroup , @sex , @oldSex", new object[] { teacher.IdTeacher, group, teacher.Group, sex, teacher.Sex });
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
