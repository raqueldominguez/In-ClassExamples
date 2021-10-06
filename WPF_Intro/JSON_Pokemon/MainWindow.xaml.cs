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
        public MainWindow()
        {
            InitializeComponent();
            cboPokemon.Items.Clear();

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?offset=00&limit=1200").Result;

                PokemonAPI api = JsonConvert.DeserializeObject<PokemonAPI>(json);

                foreach (Pokemon item in api.results)
                {
                    cboPokemon.Items.Add(item);
                }
            }

        }

        private void btnToggle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cboPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pokemon pokemon = (Pokemon)cboPokemon.SelectedItem;

            txtHeight.Text = pokemon.height;
            txtWeight.Text = pokemon.weight;
        }
    }
}
