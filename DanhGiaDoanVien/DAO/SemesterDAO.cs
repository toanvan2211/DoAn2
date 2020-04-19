using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    class SemesterDAO
    {
        private static SemesterDAO instance;
        public static SemesterDAO Instance
        {
            get { if (instance == null) instance = new SemesterDAO(); return instance; }
            private set { instance = value; }
        }
        public SemesterDAO() { }

        public DataTable GetListSemester()
        {
            string query = "select * from nam";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int AddSemester(string idSemester, string name)
        {
            string query = "USP_AddSemester @idSemester , @name";
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idSemester, name });
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return -1;
            }
        }

        public int UpdateSemester(string idSemester, string name)
        {
            string query = "USP_UpdateSemester @idSemester , @name";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idSemester, name });
        }

        public int DeleteSemester(string idSemester)
        {
            string query = "USP_DeleteSemester @idSemester";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idSemester });
        }
    }
}
