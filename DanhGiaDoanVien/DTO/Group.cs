using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DTO
{
    public class Group
    {
        private string id;
        private string name;
        private int amountMembet;
        private int totalStudent;
        private int totalTeacher;
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int AmountMembet { get => amountMembet; set => amountMembet = value; }
        public int TotalStudent { get => totalStudent; set => totalStudent = value; }
        public int TotalTeacher { get => totalTeacher; set => totalTeacher = value; }

        public Group() { }
        public Group(DataRow row)
        {
            Id = (string)row["id"];
            Name = (string)row["ten"];
            AmountMembet = (int)row["soDoanVien"];
            TotalStudent = (int)row["tongSV"];
            totalTeacher = (int)row["tongGV"];
        }
    }
}
