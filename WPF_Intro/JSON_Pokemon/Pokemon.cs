using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_Pokemon
{
    public class PokemonAPI
    {
        public List<Pokemon> results { get; set; }
        
    }

    public class Pokemon
    {
        public string name { get; set; }
        public string url { get; set; }
        public string weight { get; set; }
        public string height { get; set; }

        public override string ToString()
        {
            return $"{name}"; 
        }

        public Pokemon()
        {
            name = string.Empty;
            weight = string.Empty;
            height = string.Empty;
        }
    }
}
