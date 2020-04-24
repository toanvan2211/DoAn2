using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DTO
{
    public class GoodStudent
    {
        private int id;
        private string idStudent;
        private int idScoresGroup;
        private int vote;
        private int totalVote;
        public int Id { get => id; set => id = value; }
        public string IdStudent { get => idStudent; set => idStudent = value; }
        public int IdScoresGroup { get => idScoresGroup; set => idScoresGroup = value; }
        public int Vote { get => vote; set => vote = value; }
        public int TotalVote { get => totalVote; set => totalVote = value; }

        public GoodStudent() { }

        public GoodStudent(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdStudent = (string)row["MSSV"];
            this.IdScoresGroup = (int)row["idKetQuaChiDoan"];
            this.Vote = (int)row["phieuBau"];
            this.TotalVote = (int)row["tongPhieu"];
        }
    }
}
