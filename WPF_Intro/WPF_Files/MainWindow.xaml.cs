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

namespace WPF_Files
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            //Transaction_date,Product,Price,Payment_Type,Name,City,State,Country,Account_Created,Last_Login,Latitude,Longitude
            //1/2/09 6:17,Product1,1200,Mastercard,carolina,Basildon,England,United Kingdom,1/2/09 6:00,1/2/09 6:08,51.5,-1.1166667

            string fileLocation = txtFile.Text;

            if (File.Exists(fileLocation) == false)
            {
                MessageBox.Show("Invaild file.   Try again.");
                txtFile.Clear();
                return;
            }

            string[] fileContents = File.ReadAllLines(fileLocation);

            for (int i = 1; i < fileContents.Length; i++)
            {
                string line = fileContents[i];

                string[] pieces = line.Split(',');
                //[0] - "1/2/09 6:17"
                //[1]- "Product1"
                //[2] - "1200"
                //...

                string trans_date = pieces[0];
                string product = pieces[1];
                string price = pieces[2];
                string paymentType = pieces[3];
                string name = pieces[4];
                string city = pieces[5];
                string state = pieces[6];
                string country = pieces[7];
                string account_created = pieces[8];
                string lastLogin = pieces[9];
                string lat = pieces[10];
                string longitude = pieces[11];


                SalesData sd = new SalesData(trans_date, product, price, paymentType, name, city, state, country, account_created, lastLogin, lat, longitude);
                //sd.Product = product;
                //sd.Payment_Type = paymentType;

                if (paymentType == "Mastercard" && product == "Product1")
                {
                    lstContents.Items.Add(sd);
                }

            }
        }

       /* private void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            string[] contents = { "Hello this is the contents of my file." };
            string file = "C:\Users\raxdo\Downloads\SalesJan2009.csv";
            file.WriteAllText(file, contents);
        }*/
    }
}
