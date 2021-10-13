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

namespace _P__GOT_Quote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<GOTAPI> quotessss = new List<GOTAPI>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnQuote_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://got-quotes.herokuapp.com/quotes";
            using (var client = new HttpClient())
            {

                string json = client.GetStringAsync(url).Result;
                GOTAPI quote = JsonConvert.DeserializeObject<GOTAPI>(json);
                lstQuotes.Items.Add(quote);

            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            using (var clien = new HttpClient())
            {
                string FileName = "GOT_Quotes.json";
                string jsonString = JsonConvert.SerializeObject(quotessss);
                File.WriteAllText(FileName, jsonString);
            }          

        }
    }
}
