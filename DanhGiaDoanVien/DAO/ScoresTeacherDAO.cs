using System;
using System.Collections.Generic;
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
    }
}
