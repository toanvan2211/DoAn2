using DanhGiaDoanVien.DTO;
using DanhGiaDoanVien.Other_Class;
using System;
using System.Collections.Generic;
using System.Data;
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

        public DataTable GetListAccount()
        {
            string query = "select taiKhoan, MSGV, loaiTaiKhoan from TaiKhoan";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetListTeacherNoAccount()
        {
            string query = "select MSGV from GiangVien except (select MSGV from taiKhoan)";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int CreateAccount(Account account)
        {
            string query;
            account.Password = PasswordEncryption.Instance.GetHash(account.Password);
            if (account.IdTeacher != "")
                query = "insert into TaiKhoan values('" + account.User + "', '" + account.Password + "', '" + account.IdTeacher + "', N'" + account.TypeAccount + "')";
            else
                query = "insert into TaiKhoan values('" + account.User + "', '" + account.Password + "', NULL, N'" + account.TypeAccount + "')";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public int EditAccount(Account account)
        {
            string query;
            account.Password = PasswordEncryption.Instance.GetHash(account.Password);
            if (account.IdTeacher != "")
                query = "update TaiKhoan set matKhau = '" + account.Password + "', MSGV = '" + account.IdTeacher + "', loaiTaiKhoan = N'" + account.TypeAccount + "' where taiKhoan = '" + account.User + "'";
            else
                query = "update TaiKhoan set matKhau = '" + account.Password + "', MSGV = NULL, loaiTaiKhoan = N'" + account.TypeAccount + "' where taiKhoan = '" + account.User + "'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public int DeleteAccount(string userName)
        {
            string query = "delete TaiKhoan where taiKhoan = '" + userName + "'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
