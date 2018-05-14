using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using MotmWebApi.Models;

namespace MotmWebApi.Controllers
{
    public class ClubApiController : ApiController
    {
        // GET: api/ClubApi
        [HttpGet]
        public List<Club> Get()
        {
            var listOfClubs = new List<Club>();

            using (var connection = new MySqlConnection("user id=alphajob_org;" +
                                 "password=Q1fshaXh0rgxhGj1n7;server=mysql49.unoeuro.com;" +
                                 "database=alphajob_org_db;" +
                                 "connection timeout=30"))
            {
                connection.Open();
                //string sql = "SELECT * FROM Club";
                string sql = "SELECT * FROM Club AS C " +
                    "INNER JOIN Team AS T on C.clubId = T.fk_clubId " +
                    "INNER JOIN TeamHasPlayer AS THS ON T.teamId = THS.fk_teamId " +
                    "INNER JOIN Player AS P ON THS.fk_playerId = P.playerId";
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var c = new Club();
                            c.clubId = (int)reader["clubId"];
                            c.clubName = reader["clubName"].ToString();
                            c.clubAddress = reader["clubAddress"].ToString();
                            c.clubLogo = reader["clubLogo"].ToString();
                            listOfClubs.Add(c);
                        }
                    }
                }
                connection.Close();
            }

            return listOfClubs;
        }

        // GET: api/ClubApi/5
        [HttpGet]
        public Club Get(int id)
        {
            Club club = new Club();

            using (var connection = new MySqlConnection("user id=alphajob_org;" +
                                 "password=Q1fshaXh0rgxhGj1n7;server=mysql49.unoeuro.com;" +
                                 "database=alphajob_org_db;" +
                                 "connection timeout=30"))
            {
                connection.Open();
                string sql = "SELECT * FROM Club where clubId =" + id;
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Club c = club;
                            c.clubId = (int)reader["clubId"];
                            c.clubName = reader["clubName"].ToString();
                            c.clubAddress = reader["clubAddress"].ToString();
                            c.clubLogo = reader["clubLogo"].ToString();
                        }
                    }
                }
                connection.Close();
            }

            return club;
        }

        // POST: api/ClubApi
        //[Route("api/ClubApi")]
        //[AcceptVerbs("MKCOL")]
        [HttpPost]
        public Club PostClub([FromBody]Club c)
        {
            Club newClub = new Club
            {
                clubId = c.clubId,
                clubName = c.clubName,
                clubAddress = c.clubAddress,
                clubLogo = c.clubLogo
            };

            using (var connection = new MySqlConnection("user id=alphajob_org;" +
                                 "password=Q1fshaXh0rgxhGj1n7;server=mysql49.unoeuro.com;" +
                                 "database=alphajob_org_db;" +
                                 "connection timeout=30"))
            {
                connection.Open();
                string sql = "INSERT INTO Club (clubName, clubAddress, clubLogo) VALUES(" + "'" + c.clubName + "'" + ", " + "'" + c.clubAddress + "'" + ", " + "'" + c.clubLogo + "'" + ")";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            return newClub;
        }

        // PUT: api/ClubApi/5
        [HttpPut]
        public Club PutClub(int id, [FromBody]Club c)
        {
            Club updatedClub = new Club
            {
                clubName = c.clubName,
                clubAddress = c.clubAddress,
                clubLogo = c.clubLogo
            };

            using (var connection = new MySqlConnection("user id=alphajob_org;" +
                                 "password=Q1fshaXh0rgxhGj1n7;server=mysql49.unoeuro.com;" +
                                 "database=alphajob_org_db;" +
                                 "connection timeout=30"))
            {
                connection.Open();
                string sql = "UPDATE Club SET clubName = '" + c.clubName + "', clubAddress = '" + c.clubAddress + "', clubLogo = '" + c.clubLogo + "' WHERE clubId =" + id;
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            return updatedClub;
        }

        // DELETE: api/ClubApi/5
        [HttpDelete]
        public void Delete(int id)
        {
            using (var connection = new MySqlConnection("user id=alphajob_org;" +
                                "password=Q1fshaXh0rgxhGj1n7;server=mysql49.unoeuro.com;" +
                                "database=alphajob_org_db;" +
                                "connection timeout=30"))
            {
                connection.Open();
                string sql = "DELETE FROM Club WHERE clubId =" + id;
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
