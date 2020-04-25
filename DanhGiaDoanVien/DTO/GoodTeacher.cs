using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DTO
{
    public class GoodTeacher
    {
        private int id;
        private string idTeacher;
        private int idScoresGroup;
        private int vote;
        private int totalVote;
        public int Id { get => id; set => id = value; }
        public string IdTeacher { get => idTeacher; set => idTeacher = value; }
        public int IdScoresGroup { get => idScoresGroup; set => idScoresGroup = value; }
        public int Vote { get => vote; set => vote = value; }
        public int TotalVote { get => totalVote; set => totalVote = value; }

        public GoodTeacher() { }

        public GoodTeacher(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdTeacher = (string)row["MSGV"];
            this.IdScoresGroup = (int)row["idKetQuaChiDoan"];
            this.Vote = (int)row["phieuBau"];
            this.TotalVote = (int)row["tongPhieu"];
        }
    }
}
