using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhGiaDoanVien.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private DataProvider() { }
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=danhGiaDoanVien;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand command = new SqlCommand(query, connect);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter ap = new SqlDataAdapter(command);
                ap.Fill(data);
                connect.Close();
            }
            return data;
        }
        
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                SqlCommand command = new SqlCommand(query, connect);

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connect.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                SqlCommand command = new SqlCommand(query, connect);

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connect.Close();
            }

            return data;
        }

        public int[] GetStatistical()
        {
            string query = "";
            DataTable data = new DataTable();
            int[] result = new int[6] { 0, 0, 0, 0, 0, 0 };

            query = "select count(*) as GV from GiangVien";
            data = DataProvider.Instance.ExecuteQuery(query);
            result[0] = Convert.ToInt32(data.Rows[0]["GV"].ToString());

            query = "select count(*) as SV from SinhVien";
            data = DataProvider.Instance.ExecuteQuery(query);
            result[1] = Convert.ToInt32(data.Rows[0]["SV"].ToString());

            query = "select count(*) as CD from ChiDoan";
            data = DataProvider.Instance.ExecuteQuery(query);
            result[2] = Convert.ToInt32(data.Rows[0]["CD"].ToString());

            query = "select count(*) as n from nam";
            data = DataProvider.Instance.ExecuteQuery(query);
            result[3] = Convert.ToInt32(data.Rows[0]["n"].ToString());

            query = "select count(*) as KQCD from KetQuaChiDoan";
            data = DataProvider.Instance.ExecuteQuery(query);
            result[4] = Convert.ToInt32(data.Rows[0]["KQCD"].ToString());

            query = "select count(*) as done from KetQuaChiDoan where daXong = 1";
            data = DataProvider.Instance.ExecuteQuery(query);
            result[5] = Convert.ToInt32(data.Rows[0]["done"].ToString());

            return result;
        }

    }
}
