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

namespace WPF_Intro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //first way
            //lblOutput.Visibility = Visibility.Hidden;
            lblOutput.Content = "";
            lblDogOutput.Content = "";

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            int age = Convert.ToInt32(txtAge.Text);

            DateTime today = DateTime.Now;
            int birthYear = today.Year - age;

            //MessageBox.Show($"You were born in {birthYear.ToString("G0")}");
            lblOutput.Content = $"You were born in {birthYear.ToString("G0")}";
            lblOutput.Visibility = Visibility.Visible;
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            int dogAge = Convert.ToInt32(txtDogAge.Text);

            DateTime today = DateTime.Now;
            int birthYear = today.Year - dogAge;

            //MessageBox.Show($"You were born in {birthYear.ToString("G0")}");
            lblDogOutput.Content = $"You're fur baby was born in {birthYear.ToString("G0")}";
            lblDogOutput.Visibility = Visibility.Visible;
        }
    }
}
