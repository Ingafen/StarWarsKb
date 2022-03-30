namespace StarWars.Infrastructure.Model;

public class Character : IDataItem 
{
    public Character()
    {
        Films = new List<Film>();
        Species = new List<Spec>();
        Startships = new List<Starship>();
        Vehicles = new List<Vehicle>();
    }
    
    public string Name { get; set; }
    public int Height { get; set; }
    public double Mass { get; set; }
    public string HairColor { get; set; }
    public string SkinColor { get; set; }
    public string EyeColor { get; set; }
    public string BirthYear { get; set; }
    public string Gender { get; set; }
    public Planet HomeWorld { get; set; }
    public List<Film> Films { get; set; }
    public List<Spec> Species { get; set; }
    public List<Vehicle> Vehicles { get; set; }
    public List<Starship> Startships { get; set; }
    public int Id { get; set; }
}