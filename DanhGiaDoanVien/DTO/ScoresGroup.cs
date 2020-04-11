using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DTO
{
    public class ScoresGroup
    {
        private int id;
        private string idSemester;
        private string rank;
        private byte excellentMember;
        private byte greatMember;
        private byte mediumMember;
        private byte babMember;
        private byte totalMember;
        private byte totalStudent;
        private byte totalTeacher;
        private byte totalGoodMember;
        private string note;
        private bool isHandle = false;

        public int Id { get => id; set => id = value; }
        public string IdSemester { get => idSemester; set => idSemester = value; }
        public string Rank { get => rank; set => rank = value; }
        public byte ExcellentMember { get => excellentMember; set => excellentMember = value; }
        public byte GreatMember { get => greatMember; set => greatMember = value; }
        public byte MediumMember { get => mediumMember; set => mediumMember = value; }
        public byte BabMember { get => babMember; set => babMember = value; }
        public byte TotalMember { get => totalMember; set => totalMember = value; }
        public byte TotalStudent { get => totalStudent; set => totalStudent = value; }
        public byte TotalTeacher { get => totalTeacher; set => totalTeacher = value; }
        public byte TotalGoodMember { get => totalGoodMember; set => totalGoodMember = value; }
        public bool IsHandle { get => isHandle; set => isHandle = value; }
        public string Note { get => note; set => note = value; }

        public ScoresGroup() { }
        public ScoresGroup(DataRow row)
        {
            Id = (int)row["id"];
            IdSemester = (string)row["idNamHoc"];
            Rank = (string)row["xepLoai"];
            ExcellentMember = (byte)row["xuatSac"];
            GreatMember = (byte)row["kha"];
            MediumMember = (byte)row["trungBinh"];
            BabMember = (byte)row["yeuKem"];
            TotalMember = (byte)row["tongDoanVien"];
            TotalStudent = (byte)row["tongSV"];
            TotalTeacher = (byte)row["tongGV"];
            TotalGoodMember = (byte)row["tongDVUT"];
            Note = (string)row["ghiChu"];
        }
    }
}
