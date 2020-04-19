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
        private int vote;
        private int totalVote;
        public int Id { get => id; set => id = value; }
        public string IdStudent { get => idStudent; set => idStudent = value; }
        public string IdSemester { get => idSemester; set => idSemester = value; }
        public int Vote { get => vote; set => vote = value; }
        public int TotalVote { get => totalVote; set => totalVote = value; }

        public GoodStudent() { }

        public GoodStudent(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdStudent = (string)row["MSSV"];
            this.IdSemester = (string)row["idNamHoc"];
            this.Vote = (int)row["phieuBau"];
            this.TotalVote = (int)row["tongPhieu"];
        }
    }
}
