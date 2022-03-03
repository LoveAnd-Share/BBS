using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection("server=.;database=BBS;uid=sa;pwd=123456");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users", sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataTable res = ds.Tables[0];
            DataRow dataRow = res.Rows[0];
            var value = dataRow["UserNo"].ToString();
        }
    }
}
