using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JatekokController : ControllerBase
    {
        public string ConnectionString = "server=localhost;uid=root;password=;database=vizsga";

        [HttpPost]
        public List<Model> GetJatekok(string kiado, int ar)
        {
            List<Model> models = new List<Model>();
            var connection = new MySqlConnection(ConnectionString);

            connection.Open();

            var sql = @"SELECT `kiado`,`mufaj`,`jatekido` 
                        FROM `jatekok` 
                        WHERE `kiado` LIKE @kiado AND `ar` < @ar 
                        ORDER BY `jatekido` DESC;";

            var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@kiado", kiado + "%");
            cmd.Parameters.AddWithValue("@ar", ar);

            var datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                var model = new Model
                {
                    Kiado = datareader.GetString(0),
                    Mufaj = datareader.GetString(1),
                    Jatekido = datareader.GetInt32(2)
                };

                models.Add(model);
            }

            connection.Close();

            return models;
        }
    }
}
