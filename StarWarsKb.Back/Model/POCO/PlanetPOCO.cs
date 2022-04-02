using System;
using System.Collections.Generic;

namespace StarWarsKb.Back.Model.POCO
{
    public class PlanetPOCO : IStarWarPOCOEntity
    {
        public PlanetPOCO()
        {
            residents = new List<string>();
            films = new List<string>();
        }
        
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string rotation_period { get; set; }
        public string orbital_period { get; set; }
        public string diameter { get; set; }
        public string climate { get; set; }
        public string gravity { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set; }
        public string population { get; set; }
        public IList<string> residents { get; set; }
        public IList<string> films { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        
        public override string ToString()
        {
            return name;
        }
    }
}