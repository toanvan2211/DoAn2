using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    class ScoresStudentDAO
    {
        private static ScoresStudentDAO instance;
        public static ScoresStudentDAO Instance
        {
            get { if (instance == null) instance = new ScoresStudentDAO(); return instance; }
            private set { instance = value; }
        }
        public ScoresStudentDAO() { }

        public int AddScoresStudent(string idStudent, string idSemester)
        {
            string query = "USP_AddScoresGroup @idStudent, @idSemester";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idStudent, idSemester });
        }
    }
}
