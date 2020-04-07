using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.NewFolder1
{
    public class Student
    {
        private string idStudent;
        private string name;
        private string classroom;
        private bool sex;
        private string group;
        private bool isMember;
        
        public string IdStudent { get => idStudent; set => idStudent = value; }
        public string Name { get => name; set => name = value; }
        public string Classroom { get => classroom; set => classroom = value; }
        public bool Sex { get => sex; set => sex = value; }
        public string Group { get => group; set => group = value; }
        public bool IsMember { get => isMember; set => isMember = value; }

        public Student() { }
        public Student(DataRow row)
        {
            this.IdStudent = (string)row["MSSV"];
            this.Name = (string)row["ten"];
            this.Classroom = (string)row["lop"];
            this.Sex = (bool)row["gioiTinh"];
            this.Group = (string)row["chiDoan"];
            this.IsMember = (bool)row["doanVien"];
        }
    }
}
