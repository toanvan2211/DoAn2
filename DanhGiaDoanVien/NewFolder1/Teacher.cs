using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.NewFolder1
{
    public class Teacher
    {
        private string idTeacher;
        private string name;
        private bool sex;
        private string group;
        private bool isMember;
        public string IdTeacher { get => idTeacher; set => idTeacher = value; }
        public string Name { get => name; set => name = value; }
        public bool Sex { get => sex; set => sex = value; }
        public string Group { get => group; set => group = value; }
        public bool IsMember { get => isMember; set => isMember = value; }

        public Teacher() { }
        public Teacher(DataRow row)
        {
            this.IdTeacher = (string)row["MSCB"];
            this.Name = (string)row["ten"];
            this.Sex = (bool)row["gioiTinh"];
            this.Group = (string)row["chiDoan"];
            this.IsMember = (bool)row["doanVien"];
        }
    }
}
