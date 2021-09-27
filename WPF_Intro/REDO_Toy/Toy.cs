using System;
using System.Collections.Generic;
using System.Text;

namespace REDO_Toy
{
    public class Toy
    {
        public string Manufacturer {get;set;}
        public string Name {get;set;}
        public double Price {get;set;}
        public string Image { get; set; }
        private string  Aisle;

        public Toy()
        {
            Manufacturer = string.Empty;
            Name = string.Empty;
            Price = 0;
            Image = string.Empty;
            Aisle = string.Empty;
        }

        public Toy(string manufacturer, string name, double price, string image)
        {
            Manufacturer = manufacturer;
            Name = name;
            Price = price;
            Image = image;
        }

        public string GetAisle()
        {
            return $"{Manufacturer[0].ToString().ToUpper()} {Price.ToString().Trim()}";
        }

        public override string ToString()
        {
            return $"{Manufacturer} - {Name}";
        }
    }
}
