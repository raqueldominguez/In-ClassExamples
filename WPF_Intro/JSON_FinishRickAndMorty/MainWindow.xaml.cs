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

namespace JSON_FinishRickAndMorty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cboCharacters.Items.Clear();

            using (var client = new HttpClient())
            {
                /*Info info = new Info();
                info.pages = 34;
                for (int j = 0; j < info.pages; j++)
                {*/

                string url = "https://rickandmortyapi.com/api/character";
                while (url != null)
                {
                    string jsonData = client.GetStringAsync("https://rickandmortyapi.com/api/character?pages{i}").Result;

                    RickAndMortyAPI api = JsonConvert.DeserializeObject<RickAndMortyAPI>(jsonData);

                    foreach (Character item in api.results)
                    {
                        cboCharacters.Items.Add(item);
                    }
                    url = api.info.next;
                }

                //}                 
            }
            
        }

        private void cboCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character selected = (Character)cboCharacters.SelectedItem;

            lblCharacterName.Content = selected.name;

            imgCharacter.Source = new BitmapImage(new Uri(selected.image));

            MessageBox.Show($"The url is {selected.url}");

        }
    }
}
