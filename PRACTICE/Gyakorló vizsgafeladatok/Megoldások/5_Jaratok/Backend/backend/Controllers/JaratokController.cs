using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JaratokController : ControllerBase
    {
        public string ConnectionString = "server=localhost;uid=root;password=;database=vizsga";

        [HttpPost]
        public List<Model> GetJaratok(string legitarsasag, int tavolsag)
        {
            List<Model> models = new List<Model>();
            var connection = new MySqlConnection(ConnectionString);

            connection.Open();

            var sql = @"SELECT `legitarsasag`,`celallomas`,`ar` 
                        FROM `jaratok` 
                        WHERE `legitarsasag` LIKE @legitarsasag AND `tavolsag` > @tavolsag 
                        ORDER BY `ar` DESC;";

            var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@legitarsasag", legitarsasag + "%");
            cmd.Parameters.AddWithValue("@tavolsag", tavolsag);

            var datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                var model = new Model
                {
                    Legitarsasag = datareader.GetString(0),
                    Celallomas = datareader.GetString(1),
                    Ar = datareader.GetInt32(2)
                };

                models.Add(model);
            }

            connection.Close();

            return models;
        }
    }
}
