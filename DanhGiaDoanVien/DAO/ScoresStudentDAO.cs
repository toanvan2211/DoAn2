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
            //string query = "select * from KetQuaSinhVien";
            string query = "select id, MSSV, diemHK1, diemHK2, DRLHK1, DRLHK2, tongHK, DRL, xepLoai, thanhTichTieuBieu, doanVienUuTu, ghiChu, idKetQuaChiDoan from KetQuaSinhVien";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetInfo(int idScoresGroup, string MSSV)
        {
            string query = "select sv.ten as tenSV, nam.ten as tenNamHoc, kqcd.idChiDoan from KetQuaChiDoan kqcd, SinhVien sv, nam where kqcd.idNamHoc = nam.id and sv.MSSV = '" + MSSV + "' and kqcd.id = " + idScoresGroup;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int AddScoresStudent(string idStudent, string idSemester)
        {
            string query = "USP_AddScoresStudent @idStudent, @idSemester";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idStudent, idSemester });
        }

        public int UpdateScoresStudent(ScoresStudent st)
        {
            string query = "update KetQuaSinhVien set diemHK1 = " + st.AverageSemester1 +
                ", diemHK2 = " + st.AverageSemester2 + ", tongHK = " + st.TotalAverage +
                ", DRLHK1 = " + st.PointTraning1 + ", DRLHK2 = " + st.PointTraning2 + 
                ", DRL = " + st.AverageTrainingPoint + ", xepLoai = N'" + st.Rank + 
                "', thanhTichTieuBieu = N'" + st.Achievement + "', ghiChu = N'" + st.Note + 
                "', doanVienUuTu = '" + st.IsGoodMember + "' where id = " + st.Id;

            string qr = "";
            DataTable dt = new DataTable();

            qr = "select xepLoai from KetQuaSinhVien where id = " + st.Id;
            dt = DataProvider.Instance.ExecuteQuery(qr);

            string oldRank = dt.Rows[0]["xepLoai"].ToString();

            if (oldRank != st.Rank) //Nếu xếp loại bị thay đổi thì thay đổi số lượng trong bảng KetQuaChiDoan
            {
                switch (oldRank)
                {
                    case "Xuất sắc":
                        qr = "update KetQuaChiDoan set xuatSac -= 1 where id = " + st.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                    case "Khá":
                        qr = "update KetQuaChiDoan set kha -= 1 where id = " + st.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                    case "Trung bình":
                        qr = "update KetQuaChiDoan set trungBinh -= 1 where id = " + st.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                    case "Yếu kém":
                        qr = "update KetQuaChiDoan set yeuKem -= 1 where id = " + st.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                }

                switch (st.Rank)
                {
                    case "Xuất sắc":
                        qr = "update KetQuaChiDoan set xuatSac += 1 where id = " + st.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                    case "Khá":
                        qr = "update KetQuaChiDoan set kha += 1 where id = " + st.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                    case "Trung bình":
                        qr = "update KetQuaChiDoan set trungBinh += 1 where id = " + st.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                    case "Yếu kém":
                        qr = "update KetQuaChiDoan set yeuKem += 1 where id = " + st.IdScoresGroup;
                        DataProvider.Instance.ExecuteNonQuery(qr);
                        break;
                }
            }

            //Xử lý bảng DoanVienUuTuSV
            if (st.IsGoodMember == true)
            {
                qr = "select * from DoanVienUuTuSV where MSSV = '" + st.IdStudent + "' and idKetQuaChiDoan = " + st.IdScoresGroup;
                dt = DataProvider.Instance.ExecuteQuery(qr);
                if (dt.Rows.Count == 0)
                {
                    qr = "insert into DoanVienUuTuSV values ('" + st.IdStudent + "', " + st.IdScoresGroup + ", 0, 0)";
                    DataProvider.Instance.ExecuteNonQuery(qr);
                }
            }
            else
            {
                qr = "select * from DoanVienUuTuSV where MSSV = '" + st.IdStudent + "' and idKetQuaChiDoan = " + st.IdScoresGroup;
                dt = DataProvider.Instance.ExecuteQuery(qr);

                if (dt.Rows.Count > 0)
                {
                    qr = "delete DoanVienUuTuSV where MSSV = '" + st.IdStudent + "' and idKetQuaChiDoan = " + st.IdScoresGroup;
                    DataProvider.Instance.ExecuteNonQuery(qr);
                }
            }

            return DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
