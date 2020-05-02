using DanhGiaDoanVien.DTO;
using DanhGiaDoanVien.Other_Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    class ScoresGroupDAO
    {
        private static ScoresGroupDAO instance;
        public static ScoresGroupDAO Instance
        {
            get { if (instance == null) instance = new ScoresGroupDAO(); return instance; }
            private set { instance = value; }
        }
        public ScoresGroupDAO() { }

        public DataTable GetListScoresGroup()
        {
            string query = "select * from KetQuaChiDoan where daXong = 0";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetListGroupHaveScores()
        {
            string query = "select distinct idChiDoan from KetQuaChiDoan";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetListOldScores(string semester, string group)
        {
            StringBuilder sb = new StringBuilder();
            string query = "select * from KetQuaChiDoan where";

            sb.Append(query);

            int[] input = new int[2] { 1, 1 };

            if (semester == "Tất cả")
                input[0] = 0;
            if (group == "Tất cả")
                input[1] = 0;

            if ((input[0] + input[1]) == 0)
            {
                sb.Append(" daXong = 1");
            }
            else if (input[0] == 1)
            {
                sb.Append(" idNamHoc = '" + semester + "'");
                if (input[1] == 1)
                    sb.Append(" and idChiDoan = '" + group + "'");

                sb.Append(" and daXong = 1");
            }
            else if (input[1] == 1)
            {
                sb.Append(" idChiDoan = '" + group + "'");
                sb.Append(" and daXong = 1");
            }

            return DataProvider.Instance.ExecuteQuery(sb.ToString());
        }

        public DataTable GetListScoresGroup(string idSemester, string idGroup)
        {
            string query = "select * from KetQuaChiDoan where idChiDoan = '" + idGroup + "' and idNamHoc = '" + idSemester + "' and daXong = 0";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetListScoresGroupByID(string id, int a) //a = 1 idGroup, a = 2 idSemester
        {
            if (a == 1)
            {
                string query = "select * from KetQuaChiDoan where idChiDoan = '" + id + "' and daXong = 0";
                return DataProvider.Instance.ExecuteQuery(query);
            }
            else if (a == 2)
            {
                string query = "select * from KetQuaChiDoan where idNamHoc = '" + id + "' and daXong = 0";
                return DataProvider.Instance.ExecuteQuery(query);
            }
            return null;
        }

        public void ResetGoodMember(int id)
        {
            string query = "delete DoanVienUuTuGV where idKetQuaChiDoan = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
            query = "update KetQuaGiangVien set doanVienUuTu = 0 where idKetQuaChiDoan = " + id + " and doanVienUuTu = 1";
            DataProvider.Instance.ExecuteNonQuery(query);

            query = "delete DoanVienUuTuSV where idKetQuaChiDoan = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
            query = "update KetQuaSinhVien set doanVienUuTu = 0 where idKetQuaChiDoan = " + id + " and doanVienUuTu = 1";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public int CheckDoneScoresGroup(int id)
        {
            string query = "update KetQuaChiDoan set daXong = 1 where id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void AddScoresGroup(string idGroup, string idSemester)
        {
            string query = "USP_AddScoresGroup @idGroup , @idSemester";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { idGroup, idSemester });

            string id;
            query = "select id from KetQuaChiDoan where idNamHoc = '" + idSemester + "' and idChiDoan = '" + idGroup + "'";

            id = DataProvider.Instance.ExecuteQuery(query).Rows[0]["id"].ToString();

            query = "select * from SinhVien where chiDoan = '" + idGroup + "' and doanVien = 1";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Student st = new Student(item);
                    query = "USP_AddScoresStudent @MSSV , @id";
                    DataProvider.Instance.ExecuteNonQuery(query, new object[] { st.IdStudent, id });
                }
            }

            query = "select * from GiangVien where chiDoan = '" + idGroup + "' and doanVien = 1";
            dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Teacher tc = new Teacher(item);
                    query = "USP_AddScoresTeacher  @MSGV , @id";
                    DataProvider.Instance.ExecuteNonQuery(query, new object[] { tc.IdTeacher, id });
                }
            }
        }

        public int UpdateScoresGroup(int id, string rank, string note)
        {
            string query = "USP_UpdateScoresGroup @id , @rank , @note";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, rank, note });
        }

        public int DeleteScoresGroup(int id)
        {
            string query = "USP_DeleteScoresGroup @id";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
        }
    }
}
