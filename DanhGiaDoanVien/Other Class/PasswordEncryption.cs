using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.Other_Class
{
    public class PasswordEncryption
    {
        private static PasswordEncryption instance;
        public static PasswordEncryption Instance
        {
            get { if (instance == null) instance = new PasswordEncryption(); return instance; }
            private set { instance = value; }
        }
        public PasswordEncryption() { }
        public string GetHash(string password)
        {
            MD5 myMD5 = MD5.Create();

            byte[] bytePassword = Encoding.UTF8.GetBytes(password);
            byte[] hash = myMD5.ComputeHash(bytePassword);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
