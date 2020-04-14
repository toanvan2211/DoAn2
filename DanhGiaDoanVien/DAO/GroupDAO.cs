using DanhGiaDoanVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    public class GroupDAO
    {
        private static GroupDAO instance;
        public static GroupDAO Instance
        {
            get { if (instance == null) instance = new GroupDAO();return instance; }
            private set { instance = value; }
        }
        public GroupDAO() { }

        public DataTable GetListGroup()
        {
            string query = "USP_GetListGroup";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int AddGroup(string idGroup, string name)
        {
            string query = "USP_AddGroup @idGroup , @name";
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idGroup, name });
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return -1;
            }
        }

        public int UpdateGroup(string idGroup, string name)
        {
            string query = "USP_UpdateGroup @idGroup , @name";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idGroup, name });
        }

        public int DeleteGroup(string idGroup)
        {
            string query = "USP_DeleteGroup @idGroup";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idGroup});
        }

        public void AddMemberToGroup(Teacher[] teacher, string idGroup)
        {
            for (int i = 0; i < teacher.Length; i++)
            {
                TeacherDAO.Instance.ChangeGroup(teacher[i].IdTeacher, idGroup);
            }
        }

        public void AddMemberToGroup(Student[] student, string idGroup)
        {
            for (int i = 0; i < student.Length; i++)
            {
                TeacherDAO.Instance.ChangeGroup(student[i].IdStudent, idGroup);
            }
        }
    }
}
