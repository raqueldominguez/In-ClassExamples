using System;
using System.Collections.Generic;
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

namespace REDO_Toy
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string manufacturer = txtManufacturer.Text;
            string name = txtName.Text;
            double price = Convert.ToDouble(txtPrice.Text);
            string image = txtImageURL.Text;

            Toy toys = new Toy(manufacturer, name, Convert.ToDouble(price), image);

            if (string.IsNullOrWhiteSpace(txtManufacturer.Text) == true)
            {
                MessageBox.Show("Please enter a valid manufacturer.");
            }
            if (string.IsNullOrWhiteSpace(txtName.Text) == true)
            {
                MessageBox.Show("Please enter a valid name.");
            }
            if (double.TryParse(txtPrice.Text, out price) == false)
            {
                MessageBox.Show("Please enter a valid price.");
            }
            if (string.IsNullOrWhiteSpace(txtImageURL.Text) == true)
            {
                MessageBox.Show("Please enter a valid image URL.");
            }

            lstToy.Items.Add(toys);
        }

        private void lstToy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Toy selectedToy = (Toy)lstToy.SelectedItem;
            MessageBox.Show($"Found in aisle {selectedToy.GetAisle().ToString()}");

            var uri = new Uri(selectedToy.Image);
            var img = new BitmapImage(uri);
            imgToy.Source = img;
        }
    }
}
