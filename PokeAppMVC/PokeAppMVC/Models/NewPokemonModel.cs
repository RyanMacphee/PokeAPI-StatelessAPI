using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeAppMVC.Models
{
    public class NewPokemonModel
    {

        public List<PokeApi> pokeapi { get; set; }
        public List<PokemonTCGApi> poketcgapi {get; set;}

        public NewPokemonModel(List<PokeApi> pokeapi, List<PokemonTCGApi> poketcgapi)
        {
            this.pokeapi = pokeapi;
            this.poketcgapi = poketcgapi;
        }
    }
}
