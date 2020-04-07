using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.NewFolder1
{
    public class ScoresStudent
    {
        private int id;
        private string idSemester;
        private string idStudent;
        private float averageSemester1;
        private float averageSemester2;
        private float totalAverage;
        private byte pointTraning1;
        private byte pointTraning2;
        private byte averageTraningPoint;
        private string rank;
        private string achievement;
        private bool isGoodMember;

        public int Id { get => id; set => id = value; }
        public string IdSemester { get => idSemester; set => idSemester = value; }
        public string IdStudent { get => idStudent; set => idStudent = value; }
        public float AverageSemester1 { get => averageSemester1; set => averageSemester1 = value; }
        public float AverageSemester2 { get => averageSemester2; set => averageSemester2 = value; }
        public float TotalAverage { get => totalAverage; set => totalAverage = value; }
        public byte PointTraning1 { get => pointTraning1; set => pointTraning1 = value; }
        public byte PointTraning2 { get => pointTraning2; set => pointTraning2 = value; }
        public byte AverageTrainingPoint { get => averageTraningPoint; set => averageTraningPoint = value; }
        public string Rank { get => rank; set => rank = value; }
        public string Achievement { get => achievement; set => achievement = value; }
        public bool IsGoodMember { get => isGoodMember; set => isGoodMember = value; }

        public ScoresStudent() { }
        public ScoresStudent(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdSemester = (string)row["idNamHoc"];
            this.IdStudent = (string)row["MSSV"];
            this.AverageSemester1 = (float)row["diemHK1"];
            this.AverageSemester2 = (float)row["diemHK2"];
            this.TotalAverage = (float)row["tongHK"];
            this.PointTraning1 = (byte)row["DRLHK1"];
            this.PointTraning2 = (byte)row["DRLHK2"];
            this.AverageTrainingPoint = (byte)row["DRL"];
            this.Rank = (string)row["xepLoai"];
            this.Achievement = (string)row["thanhTichTieuBieu"];
            this.IsGoodMember = (bool)row["doanVienUuTu"];
        }
    }
}
