using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokeAppMVC.Contracts;
using PokeAppMVC.Models;
using PokeAppMVC;

namespace PokeAppMVC.Controllers
{
    public class MainController : Controller
    {
        private List<PokeApi> _Pokemon;
        private List<PokemonTCGApi> _PokemonCards;
        private List<NewPokemonModel> _newPokemonModels;


        public partial class Welcome
        {
            public static Welcome FromJson(string data) => JsonConvert.DeserializeObject<Welcome>(data);
            
        }

        public MainController()
        {
         _Pokemon = new List<PokeApi>();
            _PokemonCards = new List<PokemonTCGApi>();
            _newPokemonModels = new List<NewPokemonModel>();
        }


        public static async Task<List<PokeApi>> GetOnePokemon(int pokeId)
        {
            List<PokeApi> _pokemon = new List<PokeApi>();
            //Define your base url
            string baseURL = $"http://pokeapi.co/api/v2/pokemon/{pokeId}/";
            //Have your api call in try/catch block.
            try
            {

                using (HttpClient client = new HttpClient())
                {

                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {

                        using (HttpContent content = res.Content)
                        {

                            string data = await content.ReadAsStringAsync(); 
                            if (data != null)
                            {
                                //Parses the data to a object
                                var dataObj = JObject.Parse(data);
                                //this will create a new instance of PokeApi, and string interpolate the name property to the JSON object.
                                ////Which will convert it to a string, since each property value is a instance of JToken.





                                try // Need to get rid of this try catch and replace it with a if(["types"].count > 1{})
                                {
                                    PokeApi PokeApis = new PokeApi(name: $"{dataObj["name"]}" // for the pokemon's name
                                    , spriteUrl: $"{dataObj["sprites"]["front_default"]}" // for the sprite url
                                    , types: $"{dataObj["types"][0]["type"]["name"] + "/" + dataObj["types"][1]["type"]["name"]}" //for the types  
                                    , pokedexId: $"{dataObj["id"]}");
                                    //Console.WriteLine("Pokemon Name: {0} \nSprite URL: {1} \nPokemon Type(s): {2}\nPokedex ID: {3}", PokeApis.name, PokeApis.spriteUrl, PokeApis.types, PokeApis.pokedexId);
                                    _pokemon.Add(PokeApis);
                                    return _pokemon;


                                }
                                catch (Exception ex)
                                {
                                    PokeApi PokeApis = new PokeApi(name: $"{dataObj["name"]}" // for the pokemon's name
                                    , spriteUrl: $"{dataObj["sprites"]["front_default"]}" // for the sprite url
                                    , types: $"{dataObj["types"][0]["type"]["name"]}" //for the types  - dont know if it prints for dual type
                                    , pokedexId: $"{dataObj["id"]}");

                                    //Console.WriteLine("Pokemon Name: {0} \nSprite URL: {1} \nPokemon Type: {2}\nPokedex ID: {3}", PokeApis.name, PokeApis.spriteUrl, PokeApis.types, PokeApis.pokedexId);
                                    _pokemon.Add(PokeApis);
                                    return _pokemon;
                                }




                            }
                            else
                            {
                                //If data is null log it into console.
                                Console.WriteLine("Data is null!");
                                return null;
                            }
                        }
                    }
                }
                //Catch any exceptions and log it into the console.
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        public static async Task<List<PokemonTCGApi>> GetPokemonCards(string selectedPokemon)
        {
           List<PokemonTCGApi> _pokemonCards = new List<PokemonTCGApi>();
            string baseUrl = $"https://api.pokemontcg.io/v1/cards?name={selectedPokemon}"; //Sets the base url... This utilises compisite strings

            //try
            //{

                using (HttpClient client = new HttpClient())
                {

                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {

                        using (HttpContent content = res.Content)
                        {

                            var data = await content.ReadAsStringAsync();

                            if (data != null)
                            {
                                //Now log your data in the console
                                //Console.WriteLine("data------------{0}", data);
                                JObject parsed = JObject.Parse(data);

                            //PokemonTCGApi pokeapi = new PokemonTCGApi(cardName: $"{parsed["cards"][0]["name"]}");


                            // var RootObjects = JsonConvert.DeserializeObject<List<PokemonTCGApi>>(parsed.ToString()); //Error in this line of code.



                            //for (int x = 0; x < RootObjects.Count; x++)
                            //{
                            //}

                            //dynamic dynJson = JsonConvert.DeserializeObject(data);
                            //foreach (var x in parsed)
                            //{

                            //}

                            // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
                            //
                            //    using PokeAppMVC;
                            //




                        //    var welcome = Welcome.FromJson(data);

                         //List<JSONClass> test = JsonConvert.DeserializeObject<List<JSONClass>>(parsed.ToString());

                            // var obj = JsonConvert.DeserializeObject<PokemonTCGApi>(data);
                            //  List<PokemonTCGApi> obj = JsonConvert.DeserializeObject<List<PokemonTCGApi>>(data);
                            // PokemonTCGApi[] objList = new JavaScriptSerializer().Deserialize<Order[]>(orderJson);

                            //var obj = JsonConvert.DeserializeObject(data);

                            //List<JSONClass.Card> list = JsonConvert.DeserializeObject<List<JSONClass.Card>>(data);


   








                            for (int x = 0; x < 10; x++)// Could just make it a fixed loop
                                {
                                try {
                                PokemonTCGApi PokeApis = new PokemonTCGApi(cardName: $"{parsed["cards"][x]["name"]}" // for the pokemon's name
                                , imageUrl: $"{parsed["cards"][x]["imageUrl"]}" // for the sprite url
                                , types: $"{parsed["cards"][x]["types"][0]}" //for the types  
                                , artist: $"{parsed["cards"][x]["artist"]}");
                                _pokemonCards.Add(PokeApis);

                                }
                                catch (Exception ex)
                                {
                                    
                                }

                                }

                                //var list = JsonConvert.DeserializeObject<List<PokemonTCGApi>>(parsed.ToString());
                                


                                //for(int x = 0; x < list.Count; x++)
                                //{

                                //}























                                return _pokemonCards;
                            
                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                                return null;
                            }
                            return null;
                        }
                        return null;
                    }
                    return null;
                }
                return null;
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine("Exception Hit------------");
            //    Console.WriteLine(exception);
            //    return _pokemonCards;
            //}
        }

        public static Task<List<PokemonTCGApi>> GetCardFromID(int pokedexID)
        {
            var _pokemon = GetOnePokemon(pokedexID).Result;
            //(name: $"{dataObj["name"]}"
        //    JObject parsed = JObject.Parse(_pokemon.ToString());
            var _pokemonCards = GetPokemonCards(_pokemon[0].name);
            return _pokemonCards;
        }

        public static async Task<List<NewPokemonModel>> GetBoth(int pokedexID)
        {
            List<NewPokemonModel> _newPokemonModels = new List<NewPokemonModel>();


            var _pokemon = GetOnePokemon(pokedexID).Result;

            var _pokemonCards = GetPokemonCards(_pokemon[0].name).Result;

            NewPokemonModel newPokemonModel = new NewPokemonModel(_pokemon, _pokemonCards);
            _newPokemonModels.Add(newPokemonModel);

            return _newPokemonModels; // DO NOT RETURN _POKEMONCARDS, RETURN NEW ARRAY
        }


        //HTTP Listeners
        [HttpGet("api/v1/pokemon/pokedexid/{pokedexID}")]
        public IActionResult GetAll(int pokedexID)
        {
            return Ok(GetOnePokemon(pokedexID).Result);
        }

        [HttpGet("api/v1/cards/name/{pokemonName}")]
        public IActionResult GetAllCards(string pokemonName)
        {
            return Ok(GetPokemonCards(pokemonName).Result);
        }

        [HttpGet("api/v1/cards/pokedexid/{pokedexID}")]
        public IActionResult Getcardfromid(int pokedexID)
        {
            return Ok(GetCardFromID(pokedexID).Result);
        }

        [HttpGet("api/v1/both/{pokedexID}")]
        public IActionResult Getboth(int pokedexID)
        {
            return Ok(GetBoth(pokedexID).Result);
        }


    }
}
