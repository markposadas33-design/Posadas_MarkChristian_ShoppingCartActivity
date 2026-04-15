namespace Posadas_Quiz_2_3
{
    class Program
    {
        public void Main()
        {
            Product[] products = new Product[]
            {
                new Product(1, "San Miguel Pale Pilsen", 65, 20),
                new Product(2, "Red Horse", 90, 15),
                new Product(3, "Heineken", 120, 10),
                new Product(4, "Jack Daniel's Whiskey", 1500, 5),
                new Product(5, "Absolut Vodka", 1200, 5),
                new Product(6, "Smirnoff Vodka", 1100, 6),
                new Product(7, "Bacardi Rum", 950, 7),
                new Product(8, "Jose Cuervo Tequila", 1300, 4)
            };

            bool shopping = true;

            // loop for products
            while (shopping)
            {
                // display Menu
                Console.WriteLine("\n-----|PRODUCT MENU|-----");
                for (int i = 0; i < products.Length; i++)
                {
                    Console.WriteLine(products[i].DisplayProduct());
                }

                int productID = 0;
                bool validProduct = false;

                // loop for product validation
                while (!validProduct)
                {
                    Console.Write("Enter product number: ");
                    string input = Console.ReadLine();

                    // check if numeric
                    if (!int.TryParse(input, out productID))
                    {
                        Console.WriteLine("Input must be numeric");
                        continue;
                    }

                    // check if the product id is existing
                    if (productID < 1 || productID > products.Length)
                    {
                        Console.WriteLine("Product ID doesn't exist");
                        continue;
                    }

                    // checking the stock
                    if (products[productID - 1].Stock <= 0)
                    {
                        Console.WriteLine("Out of Stock");
                        continue;
                    }

                    // breaking the loop when it's already valid
                    validProduct = true;
                }

                Product selectedProduct = products[productID - 1];
            }
        }
    }
}