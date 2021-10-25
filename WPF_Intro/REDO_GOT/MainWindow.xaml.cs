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

namespace REDO_GOT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Quote> q = new List<Quote>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnQuote_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://got-quotes.herokuapp.com/quotes";
            Quote quote;
            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                quote = JsonConvert.DeserializeObject<Quote>(json);
            }
            lstQuotes.Items.Add(quote);
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
                string jsonString = JsonConvert.SerializeObject(q);
                File.WriteAllText("GOT_Quotes.json", jsonString);
        }
    }
}
