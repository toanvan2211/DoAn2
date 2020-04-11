using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    class SemesterDAO
    {
        private static SemesterDAO instance;
        public static SemesterDAO Instance
        {
            get { if (instance == null) instance = new SemesterDAO(); return instance; }
            private set { instance = value; }
        }
        public SemesterDAO() { }
    }
}
