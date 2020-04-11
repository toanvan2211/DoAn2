using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    public class GroupDAO
    {
        private static GroupDAO instance;
        public static GroupDAO Instance
        {
            get { if (instance == null) instance = new GroupDAO();return instance; }
            private set { instance = value; }
        }
        public GroupDAO() { }

        public DataTable GetListGroup()
        {
            string query = "USP_GetListGroup";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
