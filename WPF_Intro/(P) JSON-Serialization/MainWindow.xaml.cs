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
        List<GamesAPI> games = new List<GamesAPI>();
        public MainWindow()
        {
            InitializeComponent();

            string[] lines = File.ReadAllLines("all_games.csv");

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] pieces = line.Split(",");

                GamesAPI games = new GamesAPI(pieces[0],pieces[1], pieces[2], pieces[3], Convert.ToInt32(pieces[5]), pieces[6]);

                if (games.)
                {
                    cboFilter.Items.Add(pieces[1]);
                }
            }
        }

        private void cboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GamesAPI selected = (GamesAPI)cboFilter.SelectedItem;
            lstGames.Items.Add(selected.name);
        }

        private void lstGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Export export = new Export();
            export.ShowDialog();
        }
    }
}
