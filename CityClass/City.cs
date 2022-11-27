namespace CityClass
{
    public class City
    {
        private int _population;
        private double _square;
        public int Population { get => _population; set { _population = value; } }
        public double Square { get => _square; set { _square = value; } }
        public City(int population, double square)
        {
            Population = population;
            Square = square;
        }
    }
}
