using System;
using System.Collections.Generic;
using System.Text;

namespace cukraszda
{
    public class Cake
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool Chosen { get; set; }
        public int Portion { get; set; }

        public Cake(
            string name,
            int price,
            bool chosen,
            int portion
        )
        {
            this.Name = name;
            this.Price = price;
            this.Chosen = chosen;
            this.Portion = portion;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price} Ft";
        }
    }
}
