using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KonyvekController : ControllerBase
    {
        public string ConnectionString = "server=localhost;uid=root;password=;database=vizsga";

        [HttpPost]
        public List<Model> GetKonyvek(string kiado, int oldalszam)
        {
            List<Model> models = new List<Model>();
            var connection = new MySqlConnection(ConnectionString);

            connection.Open();

            var sql = @"SELECT `kiado`,`mufaj`,`ar` 
                        FROM `konyvek` 
                        WHERE `kiado` LIKE @kiado AND `oldalszam` > @oldalszam 
                        ORDER BY `ar` ASC;";

            var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@kiado", kiado + "%");
            cmd.Parameters.AddWithValue("@oldalszam", oldalszam);

            var datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                var model = new Model
                {
                    Kiado = datareader.GetString(0),
                    Mufaj = datareader.GetString(1),
                    Ar = datareader.GetInt32(2)
                };

                models.Add(model);
            }

            connection.Close();

            return models;
        }
    }
}
