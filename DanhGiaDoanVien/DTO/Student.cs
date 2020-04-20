using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DTO
{
    public class Student
    {
        private string idStudent;
        private string name;
        private string classroom;
        private string sex;
        private string group;
        private bool isMember;

        public string IdStudent { get => idStudent; set => idStudent = value; }
        public string Name { get => name; set => name = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Group { get => group; set => group = value; }
        public bool IsMember { get => isMember; set => isMember = value; }

        public Student() { }
        public Student(DataRow row)
        {
            IdStudent = (string)row["MSSV"];
            Name = (string)row["ten"];
            Sex = (string)row["gioiTinh"];
            Group = (string)row["chiDoan"];
            IsMember = (bool)row["doanVien"];
        }
    }
}
