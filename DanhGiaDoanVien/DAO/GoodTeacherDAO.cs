using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    public class GoodTeacherDAO
    {
        private static GoodTeacherDAO instance;
        public static GoodTeacherDAO Instance
        {
            get { if (instance == null) instance = new GoodTeacherDAO(); return instance; }
            private set { instance = value; }
        }
        public GoodTeacherDAO() { }
    }
}
