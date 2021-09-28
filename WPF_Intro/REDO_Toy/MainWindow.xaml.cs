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

            double price;

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
            if (string.IsNullOrWhiteSpace(txtImage.Text) == true)
            {
                MessageBox.Show("Please enter a valid image.");
            }
            /*
                        Toy toys = new Toy();
                        toys.Manufacturer = txtManufacturer.Text;
                        toys.Name = txtName.Text;
                        toys.Price = price;
                        toys.Image = txtImage.Text;*/
            //^without a class with parameters

            string manufacturer = txtManufacturer.Text;
            string name = txtName.Text;
             price = Convert.ToDouble(txtPrice.Text);
            string image = txtImage.Text;
            Toy toys = new Toy(manufacturer, name, price, image);


            lstToy.Items.Add(toys);

            txtManufacturer.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtImage.Clear();
        }

        private void lstToy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Toy selectedToy = (Toy)lstToy.SelectedItem;
            MessageBox.Show($"Your toy can be found in aisle {selectedToy.GetAisle().ToString()}");

            var uri = new Uri(selectedToy.Image);
            var img = new BitmapImage(uri);
            imgToy.Source = img;
        }
    }
}
