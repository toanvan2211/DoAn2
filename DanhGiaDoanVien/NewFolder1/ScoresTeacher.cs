using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.NewFolder1
{
    public class ScoresTeacher
    {
        private int id;
        private string idSemester;
        private string idTeacher;
        private string evaluation;
        private string rank;
        private string achievement;
        private bool isGoodTeacher;
        public int Id { get => id; set => id = value; }
        public string IdSemester { get => idSemester; set => idSemester = value; }
        public string IdTeacher { get => idTeacher; set => idTeacher = value; }
        public string Evaluation { get => evaluation; set => evaluation = value; }
        public string Rank { get => rank; set => rank = value; }
        public string Achievement { get => achievement; set => achievement = value; }
        public bool IsGoodTeacher { get => isGoodTeacher; set => isGoodTeacher = value; }

        public ScoresTeacher() { }
        public ScoresTeacher(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdSemester = (string)row["idNamHoc"];
            this.IdTeacher = (string)row["MSCB"];
            this.Evaluation = (string)row["ketQuaDanhGia"];
            this.Rank = (string)row["xepLoai"];
            this.Achievement = (string)row["thanhTichTieuBieu"];
            this.IsGoodTeacher = (bool)row["doanVienUuTu"];
        }
    }
}
