using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JSON_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PokemonInfo pokemon;
        private Boolean showBack;

        public MainWindow()
        {
            InitializeComponent();
            cboPokemon.Items.Clear();

            string url = "https://pokeapi.co/api/v2/pokemon?offset=00&limit=1200";

            using (var client = new HttpClient())
            {
                //string json = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?offset=00&limit=1200").Result;
                var response = client.GetAsync(url).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    PokemonAPI api = JsonConvert.DeserializeObject<PokemonAPI>(json);
                    foreach (var pokemon in api.results)
                    {
                        cboPokemon.Items.Add(pokemon);
                    }
                    
                }

                /*PokemonAPI api = JsonConvert.DeserializeObject<PokemonAPI>(json);

                foreach (Pokemon item in api.results)
                {
                    cboPokemon.Items.Add(item);
                }*/
            }

        }

        private void btnToggle_Click(object sender, RoutedEventArgs e)
        {
            if (showBack)
            {
                imgPokemon.Source = new BitmapImage(new Uri(pokemon.sprites.back_default));
                showBack = false;
            }
            else
            {
                imgPokemon.Source = new BitmapImage(new Uri(pokemon.sprites.back_default));
                showBack = true;
            }
        }

        private void cboPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pokemon selected = (Pokemon)cboPokemon.SelectedItem;
            using (var client = new HttpClient())
            {
                //string json = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?offset=00&limit=1200").Result;
                var response = client.GetAsync(selected.url).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    PokemonInfo api = JsonConvert.DeserializeObject<PokemonInfo>(json);

                    imgPokemon.Source = new BitmapImage(new Uri(api.sprites.front_default));
                    showBack = true;
                }

                /*txtHeight.Text = pokemon.height;
                txtWeight.Text = pokemon.weight;*/
            }
        }
    }
}
