using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmekController : ControllerBase
    {
        public string ConnectionString = "server=localhost;uid=root;password=;database=vizsga";

        [HttpPost]
        public List<Model> GetFilmek(string studio, int hossz)
        {
            List<Model> models = new List<Model>();
            var connection = new MySqlConnection(ConnectionString);

            connection.Open();

            var sql = @"SELECT `studio`,`mufaj`,`bevetel` 
                        FROM `filmek` 
                        WHERE `studio` LIKE @studio AND `hossz` > @hossz 
                        ORDER BY `bevetel` DESC;";

            var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@studio", studio + "%");
            cmd.Parameters.AddWithValue("@hossz", hossz);

            var datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                var model = new Model
                {
                    Studio = datareader.GetString(0),
                    Mufaj = datareader.GetString(1),
                    Bevetel = datareader.GetInt32(2)
                };

                models.Add(model);
            }

            connection.Close();

            return models;
        }
    }
}
