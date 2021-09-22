using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_ContactList
{
    class Contacts
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }

        public Contacts()
        {
            ID = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Photo = string.Empty;
        }

        public override string ToString()
        {
            return $"{FirstName}, {LastName}, {Email}";
        }
    }
}
