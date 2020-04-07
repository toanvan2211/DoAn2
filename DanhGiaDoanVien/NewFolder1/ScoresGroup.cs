using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.NewFolder1
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

        public ScoresGroup() { }
        public ScoresGroup(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdSemester = (string)row["idNamHoc"];
            this.Rank = (string)row["xepLoai"];
            this.ExcellentMember = (byte)row["xuatSac"];
            this.GreatMember = (byte)row["kha"];
            this.MediumMember = (byte)row["trungBinh"];
            this.BabMember = (byte)row["yeuKem"];
            this.TotalMember = (byte)row["tongDoanVien"];
            this.TotalStudent = (byte)row["tongSV"];
            this.TotalTeacher = (byte)row["tongGV"];
            this.TotalGoodMember = (byte)row["tongDVUT"];
        }
    }
}
