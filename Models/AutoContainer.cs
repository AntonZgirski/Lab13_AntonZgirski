namespace _16_ASP.NET_Practice_01_02_2023.Models
{
    public class AutoContainer
    {
        private List<Auto> autos;
        public List<Auto> GetAutos()
        {
            return autos;
        }
        public void AddAuto(Auto auto)
        {
            autos.Add(auto);
        }

        public AutoContainer()
        {
           autos = new List<Auto>();
        }
    }
}
