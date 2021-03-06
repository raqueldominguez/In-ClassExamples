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

namespace WPF_ToyClass
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
            double price = 0;
            string manufacturer, name, image;
            manufacturer = txtManufacturer.Text;
            name = txtName.Text;
            image = txtImage.Text;

            Toy toys = new Toy(manufacturer, name, Convert.ToDouble(price), image);

            if (string.IsNullOrWhiteSpace(txtManufacturer.Text) == true)
            {
                MessageBox.Show("Please enter a valid Manufacturer.");
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) == true)
            {
                MessageBox.Show("Please enter a valid Toy Name.");
            }

            if (string.IsNullOrWhiteSpace(txtImage.Text) == true)
            {
                MessageBox.Show("Please enter a valid Image URL.");
            }

            if (double.TryParse(txtPrice.Text, out price) == false)
            {
                MessageBox.Show("Please enter a valid Price.");
            }

            lstToy.Items.Add(toys);
        }

        private void lstToy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Toy selectedToy = (Toy)lstToy.SelectedItem;
            MessageBox.Show($"Found in aisle {selectedToy.GetAisle().ToString()}");

            var uri = new Uri(selectedToy.Image);
            var img = new BitmapImage(uri);
            imgToy.Source = img;
        }
    }
}
