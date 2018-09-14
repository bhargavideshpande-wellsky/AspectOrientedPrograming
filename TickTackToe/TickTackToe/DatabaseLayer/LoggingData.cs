
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TickTackToe.Model;

namespace TickTackToe.DatabaseLayer
{
    public class LoggingData
    {
        public void AddLog(LogDetails log)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=TAVDESK128;Initial Catalog=Users;User ID=sa;Password=test123!@#";
            con.Open();
            string query = "insert into  LogDetails values (@RequestType,@RequestStatus,@ExceptionDetails)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@RequestType", log.RequestType));
            cmd.Parameters.Add(new SqlParameter("@RequestStatus", log.RequestStatus));
            cmd.Parameters.Add(new SqlParameter("@ExceptionDetails", log.ExceptionDetails));

            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}
