using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DTO
{
    public class InfoAccount
    {
        public string UserName { get; set; }
        public string IdMember { get; set; }
        public string Name { get; set; }

        public InfoAccount() { }

        public InfoAccount(DataRow data)
        {
            UserName = data["taiKhoan"].ToString();
            IdMember = data["id"].ToString();
            Name = data["ten"].ToString();
        }
    }
}
