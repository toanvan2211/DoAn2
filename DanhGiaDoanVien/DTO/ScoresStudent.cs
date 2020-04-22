using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DTO
{
    public class ScoresStudent
    {
        private int id;
        private string idScoresGroup;
        private string idStudent;
        private float averageSemester1;
        private float averageSemester2;
        private float totalAverage;
        private int pointTraning1;
        private int pointTraning2;
        private int averageTraningPoint;
        private string rank;
        private string achievement;
        private bool isGoodMember;
        private string note;

        public int Id { get => id; set => id = value; }
        public string IdScoresGroup { get => idScoresGroup; set => idScoresGroup = value; }
        public string IdStudent { get => idStudent; set => idStudent = value; }
        public float AverageSemester1 { get => averageSemester1; set => averageSemester1 = value; }
        public float AverageSemester2 { get => averageSemester2; set => averageSemester2 = value; }
        public float TotalAverage { get => totalAverage; set => totalAverage = value; }
        public int PointTraning1 { get => pointTraning1; set => pointTraning1 = value; }
        public int PointTraning2 { get => pointTraning2; set => pointTraning2 = value; }
        public int AverageTrainingPoint { get => averageTraningPoint; set => averageTraningPoint = value; }
        public string Rank { get => rank; set => rank = value; }
        public string Achievement { get => achievement; set => achievement = value; }
        public bool IsGoodMember { get => isGoodMember; set => isGoodMember = value; }
        public string Note { get => note; set => note = value; }

        public ScoresStudent() { }
        public ScoresStudent(DataRow row)
        {
            Id = (int)row["id"];
            IdScoresGroup = (string)row["idKetQuaChiDoan"];
            IdStudent = (string)row["MSSV"];
            AverageSemester1 = (float)row["diemHK1"];
            AverageSemester2 = (float)row["diemHK2"];
            TotalAverage = (float)row["tongHK"];
            PointTraning1 = (int)row["DRLHK1"];
            PointTraning2 = (int)row["DRLHK2"];
            AverageTrainingPoint = (int)row["DRL"];
            Rank = (string)row["xepLoai"];
            Achievement = (string)row["thanhTichTieuBieu"];
            Note = (string)row["ghiChu"];
            IsGoodMember = (bool)row["doanVienUuTu"];
        }
    }
}
