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
        private string note;
        private bool isHandle = false;

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
        public bool IsHandle { get => isHandle; set => isHandle = value; }
        public string Note { get => note; set => note = value; }

        public ScoresStudent() { }
        public ScoresStudent(DataRow row)
        {
            Id = (int)row["id"];
            IdSemester = (string)row["idNamHoc"];
            IdStudent = (string)row["MSSV"];
            AverageSemester1 = (float)row["diemHK1"];
            AverageSemester2 = (float)row["diemHK2"];
            TotalAverage = (float)row["tongHK"];
            PointTraning1 = (byte)row["DRLHK1"];
            PointTraning2 = (byte)row["DRLHK2"];
            AverageTrainingPoint = (byte)row["DRL"];
            Rank = (string)row["xepLoai"];
            Achievement = (string)row["thanhTichTieuBieu"];
            Note = (string)row["ghiChu"];
            IsGoodMember = (bool)row["doanVienUuTu"];
        }
    }
}
