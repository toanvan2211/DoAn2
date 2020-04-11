using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.NewFolder1
{
    public class GoodStudent
    {
        private int id;
        private string idStudent;
        private string idSemester;
        private byte vote;
        private byte totalVote;
        public int Id { get => id; set => id = value; }
        public string IdStudent { get => idStudent; set => idStudent = value; }
        public string IdSemester { get => idSemester; set => idSemester = value; }
        public byte Vote { get => vote; set => vote = value; }
        public byte TotalVote { get => totalVote; set => totalVote = value; }

        public GoodStudent() { }

        public GoodStudent(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdStudent = (string)row["MSSV"];
            this.IdSemester = (string)row["idNamHoc"];
            this.Vote = (byte)row["phieuBau"];
            this.TotalVote = (byte)row["tongPhieu"];
        }
    }
}
