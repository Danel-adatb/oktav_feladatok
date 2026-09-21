using System.Reflection.Metadata.Ecma335;

namespace szerszamok
{
    internal class Szerszam
    {
        //sorszám,gyártó,szerszám típusa,ár,áramforrás,kölcsönzési díj
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string ToolType { get; set; }
        public int Price { get; set; }
        public string Source { get; set; }
        public int RentPrice { get; set; }

        public Szerszam(
            string dataRow
        )
        {
            string[] data = dataRow.Split([','], StringSplitOptions.RemoveEmptyEntries);
            this.Id = Int32.Parse(data[0]);
            this.Manufacturer = data[1];
            this.ToolType = data[2];
            this.Price = Int32.Parse(data[3]);
            this.Source = data[4];
            this.RentPrice = Int32.Parse(data[5]);
        }

        public override string ToString()
        {
            return $"Sorszám: {this.Id}\nGyártó {this.Manufacturer}\nSzerszám típus: {this.ToolType}\nÁr: {this.Price}\nÁramforrás: {this.Source}\nKölcsönzéis díj: {this.RentPrice}\n-------------------------------";
        }

        public bool worthToRent()
        {
            double deadline = this.Price * 0.2;

            return Convert.ToDouble(this.RentPrice) < deadline ? true : false ;
        }
    }
}
