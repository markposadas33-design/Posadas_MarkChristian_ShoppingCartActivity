using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posadas_Quiz_2_3
{
    internal class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int Stock;

        public Product(int id, string name, double price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public string DisplayProduct()
        {
            return $"{Id}. {Name} - ₱{Price} (Stock: {Stock})";
        }

        // Method that also went missing
        // Chosen required method.
        public bool HasEnoughStock(int quantity)
        {
            return quantity <= Stock;
        }
    }
}
