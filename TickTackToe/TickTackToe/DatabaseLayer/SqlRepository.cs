using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TickTackToe.Database;
using TickTackToe.Model;

namespace TickTackToe.DatabaseLayer
{
    public class SqlRepository : IRepository
    {
        public string AddData(UserDetails user)
        {
            string Email = null;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=TAVDESK128;Initial Catalog=Users;User ID=sa;Password=test123!@#";
            con.Open();
            string query1 = "select *from UserDetails where EmailId ='"+ user.EmailId+"'";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            using (SqlDataReader sq = cmd1.ExecuteReader())
            {
                while (sq.Read())
                {
                    Email = sq.GetString(sq.GetOrdinal("EmailId"));
                }
            }
            if (Email == null)
            {
                string token = Guid.NewGuid().ToString();
               
                string query = "insert into  UserDetails values (@FName,@LName,@EmailId,@AccessToken)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@FName", user.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LName", user.LastName));
                cmd.Parameters.Add(new SqlParameter("@EmailId", user.EmailId));
                cmd.Parameters.Add(new SqlParameter("@AccessToken", token));

                cmd.ExecuteNonQuery();
                con.Close();
                return "User Added Successfully";
            }
            else
            {
                return "";
            }

        }
    }
}
