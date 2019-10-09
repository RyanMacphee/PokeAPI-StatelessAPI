using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeAppMVC.Models
{
    public class PokemonTCGApi
    {
        public string cardName { get; set; }
        public string imageUrl { get; set; }
        public string Types { get; set; }
        public string Artist { get; set; }
        

      //  public List<PokemonTCGApi> Cards { get; set; }

        public PokemonTCGApi(string cardName, string imageUrl, string types, string artist)
        {
            this.cardName = cardName;
            this.imageUrl = imageUrl;
            Types = types;
            Artist = artist;
        }

        public PokemonTCGApi(string cardName)
        {
            this.cardName = cardName;
        }
        //public class RootObject
        //{
        //    public List<PokemonTCGApi> cards { get; set; }
        //}
    } 
}

