using DanhGiaDoanVien.Other_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        public AccountDAO() { }

        public int ChangePassword(string userName, string password)
        {
            password = PasswordEncryption.Instance.GetHash(password);
            string query = "update taiKhoan set matKhau = '" + password + "' where taiKhoan = '" + userName + "'";

            return DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
