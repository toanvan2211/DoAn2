using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanhGiaDoanVien.DTO
{
    public class ScoresTeacher
    {
        private int id;
        private int idScoresGroup;
        private string idTeacher;
        private string evaluation;
        private string rank;
        private string achievement;
        private bool isGoodMember;
        private string note;
        public int Id { get => id; set => id = value; }
        public int IdScoresGroup { get => idScoresGroup; set => idScoresGroup = value; }
        public string IdTeacher { get => idTeacher; set => idTeacher = value; }
        public string Evaluation { get => evaluation; set => evaluation = value; }
        public string Rank { get => rank; set => rank = value; }
        public string Achievement { get => achievement; set => achievement = value; }
        public bool IsGoodMember { get => isGoodMember; set => isGoodMember = value; }
        public string Note { get => note; set => note = value; }

        public ScoresTeacher() { }
        public ScoresTeacher(DataRow row)
        {
            Id = (int)row["id"];
            IdScoresGroup = (int)row["idNamHoc"];
            IdTeacher = (string)row["MSGV"];
            Evaluation = (string)row["ketQuaDanhGia"];
            Rank = (string)row["xepLoai"];
            Achievement = (string)row["thanhTichTieuBieu"];
            Note = (string)row["ghiChu"];
            IsGoodMember = (bool)row["doanVienUuTu"];
        }

        public ScoresTeacher(DataGridViewRow row)
        {
            Id = Convert.ToInt32(row.Cells["Id1"].Value.ToString());
            IdScoresGroup = Convert.ToInt32(row.Cells["IdScoresGroup1"].Value.ToString());
            IdTeacher = row.Cells["IdTeacher1"].Value.ToString();
            Evaluation = row.Cells["Evaluation1"].Value.ToString();
            Rank = row.Cells["Rank1"].Value.ToString();
            Achievement = row.Cells["Achievement1"].Value.ToString();
            Note = row.Cells["Note1"].Value.ToString();
            IsGoodMember = Convert.ToBoolean(row.Cells["GoodMember1"].Value.ToString());
        }
    }
}
