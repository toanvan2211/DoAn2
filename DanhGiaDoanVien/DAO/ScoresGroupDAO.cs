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

        public object GetListScoresGroup()
        {
            DanhGiaDoanVienDataContext db = new DanhGiaDoanVienDataContext();

            return db.KetQuaChiDoans.Select(k => k);
        }

        public object GetListScoresGroup(string idSemester)
        {
            DanhGiaDoanVienDataContext db = new DanhGiaDoanVienDataContext();

            return db.KetQuaChiDoans.Where(p => p.idNamHoc == idSemester);
        }

        public DataTable GetListScoresStudentByID(string idGroup, string idSemester)
        {
            string query = "select id from KetQuaChiDoan where idChiDoan = '" + idGroup + "'";

            int id = Convert.ToInt32(DataProvider.Instance.ExecuteQuery(query).Rows[0]["id"]);

            query = "select * from KetQuaSinhVien where idKetQuaChiDoan = " + id;

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetListScoresStudentByID(string id, int a) //a = 1 idGroup, a = 2 idSemester
        {
            if (a == 1)
            {
                string query = "select * from KetQuaSinhVien where idKetQuaChiDoan in (select id from KetQuaChiDoan where idChiDoan = '" + id + "')";
                return DataProvider.Instance.ExecuteQuery(query);
            }
            else if (a == 2)
            {
                string query = "select * from KetQuaSinhVien where idKetQuaChiDoan in (select id from KetQuaChiDoan where idNamHoc = '" + id + "')";
                return DataProvider.Instance.ExecuteQuery(query);
            }
            return null;
        }

        public void AddScoresGroup(string idGroup, string idSemester)
        {
            string query = "USP_AddScoresGroup @idGroup , @idSemester";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { idGroup, idSemester });

            string id;
            query = "select id from KetQuaChiDoan where idNamHoc = '" + idSemester + "' and idChiDoan = '" + idGroup + "'";

            id = DataProvider.Instance.ExecuteQuery(query).Rows[0]["id"].ToString();

            query = "select * from SinhVien where chiDoan = '" + idGroup + "'";
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

            query = "select * from GiangVien where chiDoan = '" + idGroup + "'";
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

        public int DeleteScoresGroup(int id)
        {
            string query = "USP_DeleteScoresGroup @id";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
        }
    }
}
