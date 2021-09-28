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

namespace REDO_Contacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string[] lines = File.ReadAllLines("contacts.txt");

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] pieces = line.Split("|");

                Contact contact = new Contact(Convert.ToInt32(pieces[0]), pieces[1], pieces[2], pieces[3], pieces[4]);
                lstContacts.Items.Add(contact);
            }
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            Contact c = (Contact)lstContacts.SelectedItem;
            txtFirstName.Text = c.Firstname;
            txtLastName.Text = c.Lastname;
            txtEmail.Text = c.Email;

            var uri = new Uri(c.Photo);
            var img = new BitmapImage(uri);
            imgPhoto.Source = img;
        }
    }
}
