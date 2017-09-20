using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DemoWeb.Models
{
    public class UserHandler
    {
        private SqlConnection con;
        private void connection()
        {
            String conString = ConfigurationManager.ConnectionStrings["UserModel"].ToString();
            con = new SqlConnection(conString);
        }

        // Add New User
        public bool AddUser(User user)
        {
            connection();


            con.Open();
            if (con != null && con.State == ConnectionState.Open)
            {

                String sql = "INSERT INTO [User] (ID, name) VALUES (@ID, @name)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", user.ID);
                cmd.Parameters.AddWithValue("@name", user.name);


                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                    return true;
                else
                    return false;
            }

            return false;
        }

        // Get all list user
        public List<User> GetUser()
        {
            connection();
            List<User> userLists = new List<User>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandText = "select * from [User]";

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                userLists.Add(
                    new User
                    {
                        ID = Convert.ToInt32(dr["Id"]),
                        name = Convert.ToString(dr["Name"]),
                    });
            }

            return userLists;
        }

        // Update user detail
        public bool UpdateUser(User user)
        {
            connection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandText = "update [User] set ID=@ID, name=@name";

            cmd.Parameters.AddWithValue("@ID", user.ID);
            cmd.Parameters.AddWithValue("@name", user.name);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // Delete user
        public bool DeleteUser(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandText = "delete from [User] where ID=@ID";

            cmd.Parameters.AddWithValue("@ID", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}