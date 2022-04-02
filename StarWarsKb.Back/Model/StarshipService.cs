using StarWarsKb.Back.Model.POCO;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public class StarshipService : IStarshipService
    {
        public Starship CreateFromPOCO(StarshipPOCO poco)
        {
            var starship = new Starship
            {
                Consumables = poco.consumables,
                HyperdriveRating = poco.hyperdrive_rating,
                Manufacturer = poco.manufacturer,
                MaxAtmospheringSpeed = poco.max_atmosphering_speed,
                MGLT = poco.MGLT,
                Model = poco.model,
                StarWarId = poco.id,
                Name = poco.name,
                StarshipClass = poco.starship_class
            };

            starship.Lenght = int.TryParse(poco.lenght, out var lenght) ? lenght : -1;
            starship.CargoCapacity = long.TryParse(poco.cargo_capacity, out var cap) ? cap : -1;
            starship.CrewCount = int.TryParse(poco.crew, out var crew) ? crew : -1;
            starship.PassengersCount = int.TryParse(poco.passengers, out var pass) ? pass : -1;
            starship.CostInCredits = long.TryParse(poco.cost_in_credits, out var cost) ? cost : -1;

            return starship;
        }
    }
}