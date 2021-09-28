using System;
using System.Collections.Generic;
using System.Text;

namespace REDO_Contacts
{
    public class Contact
    {
        public int Id {get;set;}

        public string Firstname {get;set;}

        public string Lastname {get;set;}

        public string Email {get;set;}

        public string Photo {get;set;}

        public Contact()
        {
            Id = 0;
            Firstname = string.Empty;
            Lastname = string.Empty;
            Email = string.Empty;
            Photo = string.Empty;
        }

        public Contact(int id, string firstname, string lastname, string email, string photo)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Photo = photo;
        }

        public override string ToString()
        {
            return $"{Lastname}, {Firstname}"; 
        }

    }
}
