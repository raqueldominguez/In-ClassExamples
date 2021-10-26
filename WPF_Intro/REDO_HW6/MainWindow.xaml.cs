using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace REDO_HW6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Wine> wines = new List<Wine>();
        public MainWindow()
        {
            InitializeComponent();
            cboCountry.Items.Add("All");

            string url = "http://pcbstuou.w27.wh-2.com/webservices/3033/api/Wine/Reviews";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    wines = JsonConvert.DeserializeObject<List<Wine>>(json);

                    foreach (Wine w in wines)
                    {
                        if (cboCountry.Items.Contains(w.country) == false)
                        {
                            cboCountry.Items.Add(w.country);
                        }
                    }
                }
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(lstWines.Items, Formatting.Indented);
            File.WriteAllText("wines.json", json);
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            string selectedCountry = (string)cboCountry.Text;

            foreach (var w in wines)
            {
                if (selectedCountry == "All")
                {
                    lstWines.Items.Add(w);
                }
                else if (selectedCountry == w.country)
                {
                    lstWines.Items.Add(w);
                }
            }
        }

        private void lstWines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string selectedWine = (string)lstWines.SelectedItem;

            NewWindow wd = new NewWindow();
            wd.ShowInfo(Convert.ToString(selectedWine));
            wd.Show();
        }
    }
}
