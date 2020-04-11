using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DTO
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
        private string note;
        private bool isHandle = false;
        public int Id { get => id; set => id = value; }
        public string IdSemester { get => idSemester; set => idSemester = value; }
        public string IdTeacher { get => idTeacher; set => idTeacher = value; }
        public string Evaluation { get => evaluation; set => evaluation = value; }
        public string Rank { get => rank; set => rank = value; }
        public string Achievement { get => achievement; set => achievement = value; }
        public bool IsGoodTeacher { get => isGoodTeacher; set => isGoodTeacher = value; }
        public bool IsHandle { get => isHandle; set => isHandle = value; }
        public string Note { get => note; set => note = value; }

        public ScoresTeacher() { }
        public ScoresTeacher(DataRow row)
        {
            Id = (int)row["id"];
            IdSemester = (string)row["idNamHoc"];
            IdTeacher = (string)row["MSCB"];
            Evaluation = (string)row["ketQuaDanhGia"];
            Rank = (string)row["xepLoai"];
            Achievement = (string)row["thanhTichTieuBieu"];
            Note = (string)row["ghiChu"];
            IsGoodTeacher = (bool)row["doanVienUuTu"];
        }
    }
}
