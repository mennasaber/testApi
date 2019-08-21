using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZaatAPI.Models;
using MySql.Data.MySqlClient;

namespace ZaatAPI.Controllers
{
    public class UsersController : ApiController
    {
        DBConnection db = new DBConnection();
        // GET: api/Users
        public List<User> Get()
        {
            List<User> listOfUsers = new List<User>();
            string query = "SELECT * FROM users";
            db.connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User u;
                if (reader[6] != DBNull.Value)
                {
                    System.Diagnostics.Debug.WriteLine(reader[6].ToString());
                    u = new User(int.Parse(reader[0].ToString()),
                    reader.GetString(1),
                    reader.GetString(2), reader.GetString(3),
                    reader.GetString(4), reader.GetBoolean(5), int.Parse(reader[6].ToString()));
                }
                else
                {
                    u = new User(int.Parse(reader[0].ToString()),
                    reader.GetString(1),
                    reader.GetString(2), reader.GetString(3),
                    reader.GetString(4), reader.GetBoolean(5), -1);
                }
                listOfUsers.Add(u);
            }
            db.connection.Close();
            return listOfUsers;
        }
        // POST: api/Users
        public void Post(User u)
        {
            string query = "INSERT INTO users (uName,uPassword,uGender,uStatue,uInChat) VALUES (@uName,@uPassword,@uGender,@uStatue,@uInChat)";
            db.connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            cmd.Parameters.AddWithValue("@uName", u.UName);
            cmd.Parameters.AddWithValue("@uPassword", u.UPassword);
            cmd.Parameters.AddWithValue("@uGender", u.UGender);
            cmd.Parameters.AddWithValue("@uStatue", u.UStatue);
            cmd.Parameters.AddWithValue("@uInChat", u.UInChat);
            cmd.ExecuteNonQuery();
            db.connection.Close();
        }
    }
}
