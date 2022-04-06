using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Core
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class SqlHelper
    {
        public string ConnectionString
        {
            get;
            set;
        } = "Data source=.;Initial Catalog=BBS;User ID=sa;Password=123456;Encrypt=True;TrustServerCertificate=True";
        public DataTable ExecuteTable(string cmdText,params SqlParameter[] sqlParameters)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(cmdText,sqlConnection);
            //添加数据库的参数
            sqlCommand.Parameters.AddRange(sqlParameters);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }
        public int ExecuteNonQuery(string cmdText, params SqlParameter[] sqlParameters)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(cmdText,sqlConnection);
            sqlCommand.Parameters.AddRange(sqlParameters);
            return sqlCommand.ExecuteNonQuery();
        }
    }
}
