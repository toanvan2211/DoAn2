using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    public class GoodStudentDAO
    {
        private static GoodStudentDAO instance;
        public static GoodStudentDAO Instance
        {
            get { if (instance == null) instance = new GoodStudentDAO(); return instance; }
            private set { instance = value; }
        }
        public GoodStudentDAO() { }

        public DataTable GetInfo(int idScoresGroup, string idStudent)
        {
            string query = "select * from DoanVienUuTuSV where idKetQuaChiDoan = " + idScoresGroup + " and MSSV = '" + idStudent + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int SaveVote(int idScoresGroup, string idStudent, int voteFor, int totalVote)
        {
            string query = "update DoanVienUuTuSV set phieuBau = " + voteFor + ", tongPhieu = " + totalVote + " where idKetQuaChiDoan = " + idScoresGroup + " and MSSV = '" + idStudent + "'";

            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void ResetGoodMember(int id, string idStudent)
        {
            string query = "delete DoanVienUuTuSV where idKetQuaChiDoan = " + id + " and  MSSV = '" + idStudent + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
            query = "update KetQuaSinhVien set doanVienUuTu = 0 where idKetQuaChiDoan = " + id + " and MSSV = '" + idStudent + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
