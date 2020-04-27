using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanhGiaDoanVien.DTO
{
    public class ScoresGroup
    {
        private int id;
        private string idGroup;
        private string idSemester;
        private string rank;
        private int excellentMember;
        private int greatMember;
        private int mediumMember;
        private int badMember;
        private int totalMember;
        private int totalStudent;
        private int totalFemalStudent;
        private int totalTeacher;
        private int totalFemalTeacher;
        private int totalGoodMember;
        private string note;

        public int Id { get => id; set => id = value; }
        public string IdSemester { get => idSemester; set => idSemester = value; }
        public string Rank { get => rank; set => rank = value; }
        public int ExcellentMember { get => excellentMember; set => excellentMember = value; }
        public int GreatMember { get => greatMember; set => greatMember = value; }
        public int MediumMember { get => mediumMember; set => mediumMember = value; }
        public int BadMember { get => badMember; set => badMember = value; }
        public int TotalMember { get => totalMember; set => totalMember = value; }
        public int TotalStudent { get => totalStudent; set => totalStudent = value; }
        public int TotalTeacher { get => totalTeacher; set => totalTeacher = value; }
        public int TotalGoodMember { get => totalGoodMember; set => totalGoodMember = value; }
        public string Note { get => note; set => note = value; }
        public int TotalFemalStudent { get => totalFemalStudent; set => totalFemalStudent = value; }
        public int TotalFemalTeacher { get => totalFemalTeacher; set => totalFemalTeacher = value; }
        public string IdGroup { get => idGroup; set => idGroup = value; }

        public ScoresGroup() { }
        public ScoresGroup(DataRow row)
        {
            Id = (int)row["id"];
            IdGroup = (string)row["idChiDoan"];
            IdSemester = (string)row["idNamHoc"];
            Rank = (string)row["xepLoai"];
            ExcellentMember = (int)row["xuatSac"];
            GreatMember = (int)row["kha"];
            MediumMember = (int)row["trungBinh"];
            BadMember = (int)row["yeuKem"];
            TotalMember = (int)row["tongDoanVien"];
            TotalStudent = (int)row["tongSV"];
            TotalTeacher = (int)row["tongGV"];
            TotalFemalStudent = (int)row["tongNuSV"];
            TotalFemalTeacher = (int)row["tongNuGV"];
            TotalGoodMember = (int)row["tongDVUT"];
            Note = (string)row["ghiChu"];
        }

        public ScoresGroup(DataGridViewRow row)
        {
            Id = Convert.ToInt32(row.Cells["Id1"].Value.ToString());
            IdGroup = row.Cells["IdGroup1"].Value.ToString();
            IdSemester = row.Cells["Semester1"].Value.ToString();
            Rank = row.Cells["Rank1"].Value.ToString();
            ExcellentMember = Convert.ToInt32(row.Cells["Excellent1"].Value.ToString());
            GreatMember = Convert.ToInt32(row.Cells["Great1"].Value.ToString());
            MediumMember = Convert.ToInt32(row.Cells["Medium1"].Value.ToString());
            BadMember = Convert.ToInt32(row.Cells["Bad1"].Value.ToString());
            TotalMember = Convert.ToInt32(row.Cells["TotalMember1"].Value.ToString());
            TotalStudent = Convert.ToInt32(row.Cells["TotalStudent1"].Value.ToString());
            TotalTeacher = Convert.ToInt32(row.Cells["TotalTeacher1"].Value.ToString());
            TotalFemalStudent = Convert.ToInt32(row.Cells["TotalFemaleStudent1"].Value.ToString());
            TotalFemalTeacher = Convert.ToInt32(row.Cells["TotalFemaleTeacher1"].Value.ToString());
            TotalGoodMember = Convert.ToInt32(row.Cells["TotalGoodMember1"].Value.ToString());
            Note = row.Cells["Note1"].Value.ToString();
        }
    }
}
