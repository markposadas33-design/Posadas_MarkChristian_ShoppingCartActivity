using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posadas_Quiz_2_3
{
    // for the receipt
    internal class CartItem
    {
        public Product Product;
        public int Quantity;
        public double Subtotal;

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Subtotal = product.Price * quantity;
        }
    }
}
