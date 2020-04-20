using DanhGiaDoanVien.Other_Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    class ScoresTeacherDAO
    {
        private static ScoresTeacherDAO instance;
        public static ScoresTeacherDAO Instance
        {
            get { if (instance == null) instance = new ScoresTeacherDAO(); return instance; }
            private set { instance = value; }
        }
        public ScoresTeacherDAO() { }

        public object GetListScoresTeacher()
        {
            DanhGiaDoanVienDataContext db = new DanhGiaDoanVienDataContext();

            return db.KetQuaGiangViens.Select(p => p);
        }
        public int AddScoresTeacher(string idTeacher, string idScoresGroup)
        {
            string query = "USP_AddScoresTeacher @idTeacher, @idScoresGroup";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idTeacher, idScoresGroup });
        }
    }
}
