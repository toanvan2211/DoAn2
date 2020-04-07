using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.NewFolder1
{
    public class GoodTeacher
    {
        private int id;
        private string idTeacher;
        private string idSemester;
        private byte vote;
        private byte totalVote;
        public int Id { get => id; set => id = value; }
        public string IdTeacher { get => idTeacher; set => idTeacher = value; }
        public string IdSemester { get => idSemester; set => idSemester = value; }
        public byte Vote { get => vote; set => vote = value; }
        public byte TotalVote { get => totalVote; set => totalVote = value; }

        public GoodTeacher() { }

        public GoodTeacher(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdTeacher = (string)row["MSSV"];
            this.IdSemester = (string)row["idNamHoc"];
            this.Vote = (byte)row["phieuBau"];
            this.TotalVote = (byte)row["tongPhieu"];
        }
    }
}
