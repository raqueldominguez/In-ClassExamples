using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace _P__JSON_Serialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<GamesAPI> AllGames = new List<GamesAPI>();
        public MainWindow()
        {
            InitializeComponent();
            cboFilter.Items.Add("All");
            string[] lines = File.ReadAllLines("all_games.csv").Skip(1).ToArray();

            foreach (string line in lines)
            {
                string[] pieces = line.Split(",");

                //0         1           2               3           4                5
                //name  platform    release_date    summary     meta_score      user_review

                GamesAPI g = new GamesAPI()
                {
                    name = pieces[0].Trim(),
                    platform = pieces[1].Trim(),
                    release_date = pieces[2].Trim(),
                    summary = pieces[3].Trim(),
                    meta_score = Convert.ToInt32(pieces[4]),
                    user_review = pieces[5].Trim()
                };

                if (cboFilter.Items.Contains(g.platform.Trim()) == false)
                {
                    cboFilter.Items.Add(g.platform.Trim());
                }

                lstGames.Items.Add(g);
                AllGames.Add(g);
            }
            lblResultCount.Content = $"Result Count: {lstGames.Items.Count.ToString("n0")}"; 
        }

        private void cboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = cboFilter.Text;
            lstGames.Items.Clear();
            foreach (GamesAPI games in AllGames)
            {
                if (selected.ToLower() == "All")
                {
                    lstGames.Items.Add(games);
                }
                else if(selected == games.platform)
                {
                    lstGames.Items.Add(games);
                }
            }
        }


        private void lstGames_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            GamesAPI selectedgame = (GamesAPI)lstGames.SelectedItem;

           /* if (selectedgame is null)
            {
                return;
            }*/

            Export wd = new Export();
            wd.SetData(selectedgame);
            wd.Show();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(lstGames.Items, Formatting.Indented);
            string selectedgame = cboFilter.Text;
            File.WriteAllText($"{selectedgame}_games.json", json);
        }
    }
}
