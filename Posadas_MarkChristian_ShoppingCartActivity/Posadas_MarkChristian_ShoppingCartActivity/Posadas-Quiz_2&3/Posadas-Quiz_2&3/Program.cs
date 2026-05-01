namespace Posadas_Quiz_2_3
{
    class Program
    {
        // Main must be static as entry point of the program
        static void Main()
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

            // created a cart array
            CartItem[] cart = new CartItem[100];
            int cartCount = 0;

            bool shopping = true;

            // MAIN MENU LOOP
            while (shopping)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Manage Cart");
                Console.WriteLine("3. Checkout");

                Console.Write("Choose option: ");
                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
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
                                Console.WriteLine("Product ID does not exist");
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

                        int quantity = 0;
                        bool isValidQuantity = false;

                        // loop for quantity validation
                        while (!isValidQuantity)
                        {
                            Console.Write("Enter quantity: ");
                            string qtyInput = Console.ReadLine();

                            // checking if numeric
                            if (!int.TryParse(qtyInput, out quantity))
                            {
                                Console.WriteLine("Invalid input");
                                continue;
                            }

                            // checking if the quantity is valid
                            if (quantity <= 0)
                            {
                                Console.WriteLine("Quantity must be greater than 0");
                                continue;
                            }

                            // Check stock using method
                            if (!selectedProduct.HasEnoughStock(quantity))
                            {
                                Console.WriteLine("Not enough stocks");
                                continue;
                            }

                            isValidQuantity = true;
                        }

                        // Computing the total of the item purchased (subtotal)
                        double subtotal = quantity * selectedProduct.Price;

                        // checking if item is already in the cart
                        bool found = false;
                        for (int i = 0; i < cartCount; i++)
                        {
                            // update existing cart item
                            if (cart[i].Product.Id == selectedProduct.Id)
                            {
                                cart[i].Quantity += quantity;
                                cart[i].Subtotal += subtotal;
                                found = true;
                                break;
                            }
                        }

                        // Just add new item
                        if (!found)
                        {
                            cart[cartCount] = new CartItem(selectedProduct, quantity);
                            cartCount++;
                        }

                        // deduct the stock
                        selectedProduct.Stock -= quantity;

                        break;

                    case "2":
                        bool managingCart = true;

                        while (managingCart)
                        {
                            Console.WriteLine("\n=== MANAGE CART ===");
                            Console.WriteLine("1. View Cart");
                            Console.WriteLine("2. Remove Item");
                            Console.WriteLine("3. Update Quantity");
                            Console.WriteLine("4. Clear Cart");
                            Console.WriteLine("5. Checkout");
                            Console.WriteLine("6. Back");

                            Console.Write("Choose option: ");
                            string cartChoice = Console.ReadLine();

                            switch (cartChoice)
                            {
                                case "1":
                                    Console.WriteLine("\n=== YOUR CART ===");

                                    if (cartCount == 0)
                                    {
                                        Console.WriteLine("Cart is empty.");
                                    }
                                    else
                                    {
                                        for (int i = 0; i < cartCount; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. {cart[i].Product.Name} x{cart[i].Quantity} = ₱{cart[i].Subtotal}");
                                        }
                                    }
                                    break;

                                case "2":
                                    Console.WriteLine("Remove item - (to be implemented)");
                                    break;

                                case "3":
                                    Console.WriteLine("Update quantity - (to be implemented)");
                                    break;

                                case "4":
                                    Console.WriteLine("Clear cart - (to be implemented)");
                                    break;

                                case "5":
                                    managingCart = false;
                                    shopping = false;
                                    break;

                                case "6":
                                    managingCart = false;
                                    break;

                                default:
                                    Console.WriteLine("Invalid choice.");
                                    break;
                            }
                        }
                        break;

                    case "3":
                        shopping = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            // will compute the grand total
            double grandTotal = 0;
            for (int i = 0; i < cartCount; i++)
            {
                grandTotal += cart[i].Subtotal;
            }

            // creating a discount variable
            double discount = 0;

            // if the total is 5000 above: add 10% discount
            if (grandTotal >= 5000)
            {
                discount = grandTotal * 0.10;
            }

            // applying the discount
            double finalTotal = grandTotal - discount;

            // create a receipt
            Console.WriteLine("\n=== RECEIPT ===");
            for (int i = 0; i < cartCount; i++)
            {
                Console.WriteLine($"{cart[i].Product.Name} x{cart[i].Quantity} = ₱{cart[i].Subtotal}");
            }

            Console.WriteLine($"Grand Total: ₱{grandTotal}");
            Console.WriteLine($"Discount: ₱{discount}");
            Console.WriteLine($"Final Total: ₱{finalTotal}");

            // reshow the product to see the new stocks
            Console.WriteLine("\n-----|REMAINING STOCKS|-----");
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine(products[i].DisplayProduct());
            }

            // END
        }
    }
}