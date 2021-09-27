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

namespace WPF_ContactList
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
                Contacts contact = new Contacts();
                string line = lines[i];
                string[] pieces = line.Split('|');

                contact.ID = Convert.ToInt32(pieces[0]);
                contact.FirstName = pieces[1];
                contact.LastName = pieces[2];
                contact.Email = pieces[3];
                contact.Photo = pieces[4];
                lstContacts.Items.Add(contact);
            }
        }


        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            Contacts c = (Contacts)lstContacts.SelectedItem;
            txtFirstName.Text = c.FirstName;
            txtLastName.Text = c.LastName;
            txtEmail.Text = c.Email;

            var uri = new Uri(c.Photo);
            var img = new BitmapImage(uri);
            imgPhoto.Source = img;
        }

    }
}