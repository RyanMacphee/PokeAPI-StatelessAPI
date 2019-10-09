using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeAppMVC.Models
{
    public class PokeApi
    {
        public string name { get; set; }
        public string spriteUrl { get; set; }
        public string types { get; set; }
        public string pokedexId { get; set; }

        public PokeApi(string name, string spriteUrl, string types, string pokedexId)
        {
            this.name = name;
            this.spriteUrl = spriteUrl;
            this.types = types;
            this.pokedexId = pokedexId;
        }
    }
}
