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
    class ScoresStudentDAO
    {
        private static ScoresStudentDAO instance;
        public static ScoresStudentDAO Instance
        {
            get { if (instance == null) instance = new ScoresStudentDAO(); return instance; }
            private set { instance = value; }
        }
        public ScoresStudentDAO() { }

        public DataTable GetListScoresStudent()
        {
            string query = "select * from KetQuaSinhVien";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int AddScoresStudent(string idStudent, string idSemester)
        {
            string query = "USP_AddScoresStudent @idStudent, @idSemester";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idStudent, idSemester });
        }

        public DataTable LoadProvide()
        {
            string query = "select * from KetQuaChiDoan, SinhVien, nam";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        //public int UpdateScoresStudent(ScoresStudent st)
        //{
        //    string query = "USP_UpdateScoresStudent @id , @sm1 , @sm2 , @ttsm , @st1 , @st2 , @tp , @rank , @achi , @note , @igm";
        //    return DataProvider.Instance.ExecuteNonQuery(query, new object[] { st.Id, st.AverageSemester1, st.AverageSemester2, st.TotalAverage, st.PointTraning1, st.PointTraning2, st.AverageTrainingPoint, st.Rank, st.Achievement, st.Note, st.IsGoodMember });
        //}

        public int UpdateScoresStudent(ScoresStudent st)
        {
            string query = "update KetQuaSinhVien set diemHK1 = " + st.AverageSemester1 +
                ", diemHK2 = " + st.AverageSemester2 + ", tongHK = " + st.TotalAverage +
                ", DRLHK1 = " + st.PointTraning1 + ", DRLHK2 = " + st.PointTraning2 + 
                ", DRL = " + st.AverageTrainingPoint + ", xepLoai = N'" + st.Rank + 
                "', thanhTichTieuBieu = N'" + st.Achievement + "', ghiChu = N'" + st.Note + 
                "', doanVienUuTu = '" + st.IsGoodMember + "' where id = " + st.Id;

            return DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
