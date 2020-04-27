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
    class ScoresTeacherDAO
    {
        private static ScoresTeacherDAO instance;
        public static ScoresTeacherDAO Instance
        {
            get { if (instance == null) instance = new ScoresTeacherDAO(); return instance; }
            private set { instance = value; }
        }
        public ScoresTeacherDAO() { }

        public DataTable GetInfo(int idScoresGroup, string MSGV)
        {
            string query = "select gv.ten as tenGV, nam.ten as tenNamHoc, kqcd.idChiDoan from KetQuaChiDoan kqcd, GiangVien gv, nam where kqcd.idNamHoc = nam.id and gv.MSGV = '" + MSGV + "' and kqcd.id = " + idScoresGroup;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetRankAndAmountOfExcellent(int idScoresGroup)
        {
            string query = "select xepLoai, xuatSac, tongDVUT from KetQuaChiDoan where id = " + idScoresGroup;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetListScoresTeacherByID(string idGroup, string idSemester)
        {
            string query = "select id from KetQuaChiDoan where idChiDoan = '" + idGroup + "' and idNamHoc = '" + idSemester + "'";

            int id = Convert.ToInt32(DataProvider.Instance.ExecuteQuery(query).Rows[0]["id"]);

            query = "select id, MSGV, ketQuaDanhGia, xepLoai, thanhTichTieuBieu, doanVienUuTu, ghiChu, idKetQuaChiDoan from KetQuaGiangVien where idKetQuaChiDoan = " + id;

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetListScoresTeacherByID(string id, int a) //a = 1 idGroup, a = 2 idSemester
        {
            if (a == 1)
            {
                string query = "select id, MSGV, ketQuaDanhGia, xepLoai, thanhTichTieuBieu, doanVienUuTu, ghiChu, idKetQuaChiDoan from KetQuaGiangVien where idKetQuaChiDoan in (select id from KetQuaChiDoan where idChiDoan = '" + id + "')";
                return DataProvider.Instance.ExecuteQuery(query);
            }
            else if (a == 2)
            {
                string query = "select id, MSGV, ketQuaDanhGia, xepLoai, thanhTichTieuBieu, doanVienUuTu, ghiChu, idKetQuaChiDoan from KetQuaGiangVien where idKetQuaChiDoan in (select id from KetQuaChiDoan where idNamHoc = '" + id + "')";
                return DataProvider.Instance.ExecuteQuery(query);
            }
            return null;
        }

        public DataTable GetListScoresTeacher()
        {
            string query = "select id, MSGV, ketQuaDanhGia, xepLoai, thanhTichTieuBieu, doanVienUuTu, ghiChu, idKetQuaChiDoan from KetQuaGiangVien";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public int AddScoresTeacher(string idTeacher, string idScoresGroup)
        {
            string query = "USP_AddScoresTeacher @idTeacher, @idScoresGroup";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idTeacher, idScoresGroup });
        }

        public int UpdateScoresTeacher(ScoresTeacher tc)
        {
            string query = "update KetQuaGiangVien set ketQuaDanhGia = N'" + tc.Evaluation + "', xepLoai = N'" + tc.Rank +
                "', thanhTichTieuBieu = N'" + tc.Achievement + "', ghiChu = N'" + tc.Note +
                "', doanVienUuTu = '" + tc.IsGoodMember + "' where id = " + tc.Id;

            string qr = "";
            DataTable dt = new DataTable();

            qr = "select xepLoai from KetQuaGiangVien where id = " + tc.Id;
            dt = DataProvider.Instance.ExecuteQuery(qr);

            string oldRank = dt.Rows[0]["xepLoai"].ToString();

            if (oldRank != tc.Rank) //Nếu xếp loại bị thay đổi thì thay đổi số lượng trong bảng KetQuaChiDoan
            {
                switch (oldRank)
                {
                    case "Xuất sắc":
                        qr = "update KetQuaChiDoan set xuatSac -= 1 where id = " + tc.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                    case "Khá":
                        qr = "update KetQuaChiDoan set kha -= 1 where id = " + tc.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                    case "Trung bình":
                        qr = "update KetQuaChiDoan set trungBinh -= 1 where id = " + tc.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                    case "Yếu kém":
                        qr = "update KetQuaChiDoan set yeuKem -= 1 where id = " + tc.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                }

                switch (tc.Rank)
                {
                    case "Xuất sắc":
                        qr = "update KetQuaChiDoan set xuatSac += 1 where id = " + tc.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                    case "Khá":
                        qr = "update KetQuaChiDoan set kha += 1 where id = " + tc.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                    case "Trung bình":
                        qr = "update KetQuaChiDoan set trungBinh += 1 where id = " + tc.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                    case "Yếu kém":
                        qr = "update KetQuaChiDoan set yeuKem += 1 where id = " + tc.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                }
            }

            //Xử lý bảng DoanVienUuTuGV
            if (tc.IsGoodMember == true)
            {
                qr = "select * from DoanVienUuTuGV where MSGV = '" + tc.IdTeacher + "' and idKetQuaChiDoan = " + tc.IdScoresGroup;
                dt = DataProvider.Instance.ExecuteQuery(qr);
                if (dt.Rows.Count == 0)
                {
                    qr = "insert into DoanVienUuTuGV values ('" + tc.IdTeacher + "', " + tc.IdScoresGroup + ", 0, 0)";
                    DataProvider.Instance.ExecuteNonQuery(qr);
                }
            }
            else
            {
                qr = "select * from DoanVienUuTuGV where MSGV = '" + tc.IdTeacher + "' and idKetQuaChiDoan = " + tc.IdScoresGroup;
                dt = DataProvider.Instance.ExecuteQuery(qr);

                if (dt.Rows.Count > 0)
                {
                    qr = "delete DoanVienUuTuGV where MSGV = '" + tc.IdTeacher + "' and idKetQuaChiDoan = " + tc.IdScoresGroup;
                    DataProvider.Instance.ExecuteNonQuery(qr);
                }
            }

            return DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
