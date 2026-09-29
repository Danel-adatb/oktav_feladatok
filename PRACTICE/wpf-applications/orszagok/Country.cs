namespace orszagok
{
    public class Country
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public string Continent { get; set; }

        public Country(string name, int population, string continent)
        {
            this.Name = name;
            this.Population = population;
            this.Continent = continent;
        }
    }
}
