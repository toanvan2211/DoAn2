using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    public class GoodTeacherDAO
    {
        private static GoodTeacherDAO instance;
        public static GoodTeacherDAO Instance
        {
            get { if (instance == null) instance = new GoodTeacherDAO(); return instance; }
            private set { instance = value; }
        }
        public GoodTeacherDAO() { }

        public DataTable GetInfo(int idScoresGroup, string idTeacher)
        {
            string query = "select * from DoanVienUuTuGV where idKetQuaChiDoan = " + idScoresGroup + " and MSGV = '" + idTeacher + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int SaveVote(int idScoresGroup, string idTeacher, int voteFor, int totalVote)
        {
            string query = "update DoanVienUuTuGV set phieuBau = " + voteFor + ", tongPhieu = " + totalVote + " where idKetQuaChiDoan = " + idScoresGroup + " and MSGV = '" + idTeacher + "'";

            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void ResetGoodMember(int id, string idTeacher)
        {
            string query = "delete DoanVienUuTuGV where idKetQuaChiDoan = " + id + " and  MSGV = '" + idTeacher + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
            query = "update KetQuaGiangVien set doanVienUuTu = 0 where idKetQuaChiDoan = " + id + " and MSGV = '" + idTeacher + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
