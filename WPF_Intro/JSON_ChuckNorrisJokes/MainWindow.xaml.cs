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

namespace JSON_ChuckNorrisJokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cboCategory.Items.Clear();
            cboCategory.Items.Add("all");

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync("https://api.chucknorris.io/jokes/categories").Result;

                List<string> categories = JsonConvert.DeserializeObject<List<string>>(json);

                foreach (string cat in categories)
                {
                    cboCategory.Items.Add(cat);
                }
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            ChuckNorrisAPI selected = (ChuckNorrisAPI)cboCategory.SelectedItem;

            using (var client = new HttpClient())
            {
                if (selected.ToString() == "all")
                {
                        string json = client.GetStringAsync("https://api.chucknorris.io/jokes/random").Result;

                        List<string> categories = JsonConvert.DeserializeObject<List<string>>(json);

                        lstJoke.Items.Add(json);
                }
                else
                {
                        string json = client.GetStringAsync($"https://api.chucknorris.io/jokes/random?category="+ selected.ToString()).Result;

                        ChuckNorrisAPI joke = JsonConvert.DeserializeObject<List<string>>(json);

                        lstJoke.Items.Add(json);
                }
            }
        }
    }
}
