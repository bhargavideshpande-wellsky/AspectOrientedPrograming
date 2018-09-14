using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TickTackToe
{
    public class Authorization
    {
        public string Authentication(string apiKey)
        {
            string token = null, response=null;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=TAVDESK128;Initial Catalog=Users;User ID=sa;Password=test123!@#";
            con.Open();
            string query1 = "select *from UserDetails where AccessToken='" + apiKey + "'";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            using (SqlDataReader sq = cmd1.ExecuteReader())
            {
                while (sq.Read())
                {
                    token = sq.GetString(sq.GetOrdinal("AccessToken"));
                }
            }
            if(token == null)
            {
                return response;
            }
            else
            {
                return token;
            }
        }
    }
}
