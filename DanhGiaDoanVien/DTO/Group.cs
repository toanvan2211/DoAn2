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
        private byte amountMembet;
        private byte totalStudent;
        private byte totalTeacher;
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public byte AmountMembet { get => amountMembet; set => amountMembet = value; }
        public byte TotalStudent { get => totalStudent; set => totalStudent = value; }
        public byte TotalTeacher { get => totalTeacher; set => totalTeacher = value; }

        public Group() { }
        public Group(DataRow row)
        {
            Id = (string)row["id"];
            Name = (string)row["ten"];
            AmountMembet = (byte)row["soDoanVien"];
            TotalStudent = (byte)row["tongSV"];
            totalTeacher = (byte)row["tongGV"];
        }
    }
}
