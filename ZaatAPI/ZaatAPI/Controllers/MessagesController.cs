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
    public class MessagesController : ApiController
    {
        DBConnection db = new DBConnection();

        // GET: api/Messages
        public List<Message> Get()
        {
            List<Message> listOfMessages = new List<Message>();
            string query = "SELECT * FROM messages";
            db.connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Message m;

                m = new Message(int.Parse(reader[0].ToString()),reader[1].ToString(),reader[2].ToString(),reader[3].ToString());

                listOfMessages.Add(m);
            }
            db.connection.Close();
            return listOfMessages;
        }

        // POST: api/Messages
        public void Post(Message m)
        {
            string query = "INSERT INTO messages (message,mDate,uID) VALUES (@message,@mDate,@uID)";
            db.connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            cmd.Parameters.AddWithValue("@message", m.MContent);
            cmd.Parameters.AddWithValue("@mDate", m.MDate);
            cmd.Parameters.AddWithValue("@uID", m.UID);

            cmd.ExecuteNonQuery();
            db.connection.Close();
        }

        // DELETE: api/Messages/DeleteMessage
        [Route("api/Messages/DeleteMessage")]
        [HttpDelete]
        public void Delete([FromBody]int id)
        {
            string query = "DELETE FROM messages WHERE mID = '"+id+"'";
            db.connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, db.connection);
            cmd.ExecuteNonQuery();
            db.connection.Close();
        }
    }
}
