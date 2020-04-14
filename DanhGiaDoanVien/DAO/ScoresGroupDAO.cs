using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    class ScoresGroupDAO
    {
        private static ScoresGroupDAO instance;
        public static ScoresGroupDAO Instance
        {
            get { if (instance == null) instance = new ScoresGroupDAO(); return instance; }
            private set { instance = value; }
        }
        public ScoresGroupDAO() { }

        public int AddScoresGroup(string idGroup, string idSemester)
        {
            string query = "USP_AddScoresGroup @idGroup, @idSemester";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idGroup, idSemester });
        }
    }
}
