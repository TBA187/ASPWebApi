using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using MotmWebApi.Models;

namespace MotmWebApi.Controllers
{
    public class PlayerApiController : ApiController
    {
        // GET: api/PlayerApi
        public List<Player> Get()
        {
            var listOfPlayers = new List<Player>();

            using (var connection = new MySqlConnection("user id=alphajob_org;" +
                           "password=Q1fshaXh0rgxhGj1n7;server=mysql49.unoeuro.com;" +
                           "database=alphajob_org_db;" +
                           "connection timeout=30"))
            {
                connection.Open();
                string sql = "SELECT * FROM Player ORDER BY playerId ASC LIMIT 11";
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = new Player();
                            p.playerId = (int)reader["playerId"];
                            p.playerName = reader["playerName"].ToString();
                            p.playerNr = (int)reader["playerNr"];
                            p.position = reader["position"].ToString();
                            listOfPlayers.Add(p);
                        }
                    }
                }
                connection.Close();
            }
            return listOfPlayers;
        }

        // GET: api/PlayerApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PlayerApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PlayerApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PlayerApi/5
        public void Delete(int id)
        {
        }
    }
}
