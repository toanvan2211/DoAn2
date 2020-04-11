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
    }
}
