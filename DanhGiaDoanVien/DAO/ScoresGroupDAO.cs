using DanhGiaDoanVien.Other_Class;
using System;
using System.Collections.Generic;
using System.Data;
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

        public object GetListScoresGroup()
        {
            DanhGiaDoanVienDataContext db = new DanhGiaDoanVienDataContext();

            return db.KetQuaChiDoans.Select(k => k);
        }

        public object GetListScoresGroup(string idSemester)
        {
            DanhGiaDoanVienDataContext db = new DanhGiaDoanVienDataContext();

            return db.KetQuaChiDoans.Where(p => p.idNamHoc == idSemester);
        }

        public void AddScoresGroup(string idGroup, string idSemester)
        {
            string query = "USP_AddScoresGroup @idGroup , @idSemester";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { idGroup, idSemester });
        }
    }
}
