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

        public DataTable GetListScoresTeacher(string typeScores, string semester, string group)
        {
            StringBuilder sb = new StringBuilder();
            string query = "select id, MSGV, ketQuaDanhGia, xepLoai, thanhTichTieuBieu, doanVienUuTu, ghiChu, idKetQuaChiDoan from KetQuaGiangVien";
            sb.Append(query);
            int[] input = new int[3] { 1, 1, 1 };

            if (typeScores == "Chưa hoàn thành")
                input[0] = 0;
            if (semester == "")
                input[1] = 0;
            if (group == "")
                input[2] = 0;

            if ((input[0] + input[1] + input[2]) == 0)
            {
                sb.Append(" where idKetQuaChiDoan in (select id from KetQuaChiDoan where daXong = 0)");
            }
            else if (input[0] == 1)
            {
                sb.Append(" where idKetQuaChiDoan in (select id from KetQuaChiDoan where");
                if (input[1] == 1)
                {
                    sb.Append(" idNamHoc = '" + semester + "' and");
                }
                if (input[2] == 1)
                {
                    sb.Append(" idChiDoan = '" + group + "' and");
                }
                sb.Append(" daXong = 1)");
            }
            else if (input[1] == 1)
            {
                sb.Append(" where idKetQuaChiDoan in (select id from KetQuaChiDoan where");
                if (input[2] == 1)
                {
                    sb.Append(" idChiDoan = '" + group + "' and");
                }
                sb.Append(" daXong = 0)");
            }
            else if (input[2] == 1)
            {
                sb.Append(" where idKetQuaChiDoan in (select id from KetQuaChiDoan where idChiDoan = '" + group + "' and daXong = 0)");
            }

            return DataProvider.Instance.ExecuteQuery(sb.ToString());
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
