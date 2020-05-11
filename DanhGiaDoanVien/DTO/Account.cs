using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DTO
{
    public class Account
    {
        private string user;
        private string password;
        private string idTeacher;
        private string typeAccount;
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string IdTeacher { get => idTeacher; set => idTeacher = value; }
        public string TypeAccount { get => typeAccount; set => typeAccount = value; }

        public Account() { }
        public Account(DataRow row)
        {
            this.User = (string)row["taiKhoan"];
            this.Password = (string)row["matKhau"];
            this.IdTeacher = (string)row["MSGV"];
            this.TypeAccount = (string)row["loaiTaiKhoan"];
        }
    }
}
