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
    public class LoginDAO
    {
        private static LoginDAO instance;
        public static LoginDAO Instance
        {
            get { if (instance == null) instance = new LoginDAO(); return instance; }
            private set { instance = value; }
        }
        public LoginDAO() { }

        public InfoAccount GetInfo(string userName)
        {
            InfoAccount info = new InfoAccount();
            info.UserName = userName;

            string query = "select * from taiKhoan where taiKhoan = '" + userName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count == 0)
                return null;

            if (!string.IsNullOrEmpty(data.Rows[0]["MSGV"].ToString()))
            {
                info.IdMember = data.Rows[0]["MSGV"].ToString();
                query = "select * from GiangVien where MSGV = '" + info.IdMember + "'";
                data = DataProvider.Instance.ExecuteQuery(query);
                info.Name = data.Rows[0]["ten"].ToString();
            }

            return info;
        }

        public bool CheckPassword(string userName, string password)
        {
            bool check = false;
            string query = "USP_Login @userName , @password";

            password = PasswordEncryption.Instance.GetHash(password);

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, password });
            
            if (data.Rows.Count != 0)
            {
                check = true;
            }
            return check;                
        }
    }
}
