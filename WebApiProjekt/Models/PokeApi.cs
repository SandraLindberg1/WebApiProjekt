using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjekt.Models
{
    public class Pokeapi : PokeDTO
    {
        public int Id { get; set; }
    }

    public class PokeDTO
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public Pokeapi ToModel()
        {
            return new Pokeapi
            {
                Name = this.Name,
                Url = this.Url,
            };
        }
        public PokeDTO ToDTO()
        {
            return this;
        }
    }
}
