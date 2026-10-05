using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KerekparokController : ControllerBase
    {
        public string ConnectionString = "server=localhost;uid=root;password=;database=vizsga";

        [HttpPost]
        public List<Model> GetKerekparok(string gyarto, int ar)
        {
            List<Model> models = new List<Model>();
            var connection = new MySqlConnection(ConnectionString);

            connection.Open();

            var sql = @"SELECT `gyarto`,`tipus`,`ar` 
                        FROM `kerekparok` 
                        WHERE `gyarto` LIKE @gyarto AND `ar` > @ar 
                        ORDER BY `ar` DESC;";

            var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@gyarto", gyarto + "%");
            cmd.Parameters.AddWithValue("@ar", ar);

            var datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                var model = new Model
                {
                    Gyarto = datareader.GetString(0),
                    Tipus = datareader.GetString(1),
                    Ar = datareader.GetInt32(2)
                };

                models.Add(model);
            }

            connection.Close();

            return models;
        }
    }
}
