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
        private int vote;
        private int totalVote;
        public int Id { get => id; set => id = value; }
        public string IdTeacher { get => idTeacher; set => idTeacher = value; }
        public string IdSemester { get => idSemester; set => idSemester = value; }
        public int Vote { get => vote; set => vote = value; }
        public int TotalVote { get => totalVote; set => totalVote = value; }

        public GoodTeacher() { }

        public GoodTeacher(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdTeacher = (string)row["MSSV"];
            this.IdSemester = (string)row["idNamHoc"];
            this.Vote = (int)row["phieuBau"];
            this.TotalVote = (int)row["tongPhieu"];
        }
    }
}
