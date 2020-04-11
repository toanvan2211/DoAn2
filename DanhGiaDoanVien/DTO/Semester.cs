using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.NewFolder1
{
    public class Semester
    {
        private string id;
        private string name;
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public Semester() { }

        public Semester(DataRow row)
        {
            this.Id = (string)row["id"];
            this.Name = (string)row["ten"];
        }
    }
}
