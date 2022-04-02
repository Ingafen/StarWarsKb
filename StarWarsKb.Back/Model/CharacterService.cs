using System;
using StarWarsKb.Back.Model.POCO;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public class CharacterService : ICharacterService
    {
        public Character CreateFromPOCO(CharacterPOCO characterPoco)
        {
            //TODO: написать тесты
            var ch = new Character
            {
                BirthYear = characterPoco.birth_year,
                EyeColor = characterPoco.eye_color,
                HairColor = characterPoco.hair_color,
                Gender = characterPoco.gender,
                SkinColor = characterPoco.skin_color,
                Name = characterPoco.name,
                StarWarId = characterPoco.id
            };

            var homeWorldId = characterPoco.homeworld
                .Replace(@"https://swapi.dev/api/planets/", "")
                .Replace(@"/","");

            ch.HomeWorldId = int.Parse(homeWorldId);

            ch.Height = Int32.TryParse(characterPoco.height, out var height) ? height : -1;

            ch.Mass = double.TryParse(characterPoco.mass, out var mass) ? mass : -1;

            foreach (var url in characterPoco.starships)
            {
                var starshipId = url.Replace(@"https://swapi.dev/api/starships/", "")
                    .Replace(@"/","");
                ch.StarshipCharacters.Add(new StarshipsCharacters{CharacterId = characterPoco.id, StarshipId = int.Parse(starshipId)});
            }

            return ch;
        }
    }
}