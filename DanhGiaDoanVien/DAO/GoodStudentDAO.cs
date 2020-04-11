using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    public class GoodStudentDAO
    {
        private static GoodStudentDAO instance;
        public static GoodStudentDAO Instance
        {
            get { if (instance == null) instance = new GoodStudentDAO(); return instance; }
            private set { instance = value; }
        }
        public GoodStudentDAO() { }
    }
}
