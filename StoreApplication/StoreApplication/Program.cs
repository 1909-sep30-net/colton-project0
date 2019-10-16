using System;
using BusinessLogic.Library;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
using NLog;



namespace StoreApplication
{
    class Program
    {
        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {

            var dataSource = new List<Address>();
            var storeRepository = new StoreRepository(dataSource);
            var dataSource2 = new List<Product>();
            var productRepository = new ProductRepository(dataSource2);
            XmlSerializer serializer = Dependencies.CreateXmlSerializer();
            //var serializer = new XmlSerializer(typeof(List<Address>));

            Console.WriteLine("Welcome!");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("b:\tStore Locator"); //put your menus
                Console.WriteLine();
                Console.Write("Enter menu option, or \"q\" to quit: ");
                var input = Console.ReadLine();
                if (input == "b") //Open store locator
                {
                    Console.WriteLine("Enter City Name");
                    var input2 = Console.ReadLine();

                    var stores = storeRepository.GetStoresByCity(input2).ToList(); //search stores by City name
                    Console.WriteLine();
                    if (stores.Count == 0) //if no restaurants
                    {
                        Console.WriteLine("No Stores.");
                    }
                    while (stores.Count > 0) //if there are restaurants, print them out
                    {
                        for (int i = 1; i <= stores.Count; i++)
                        {
                            Address address = stores[i - 1];
                            //var store = stores[i - 1];
                            var storeString = $"{i}: \"{address.Street}\" \"{address.City}\"";
                            Console.WriteLine(storeString);

                        }
                        Console.WriteLine();
                        Console.WriteLine("Enter menu option or \"b\" to go back");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out var storeNum)
                                && storeNum > 0 && storeNum <= stores.Count) //check which one they select
                        {
                            var store = stores[storeNum - 1];
                            var orders = store.Orders;
                            while (true)
                            {
                                Console.WriteLine();
                                var restaurantString = $"\"{store.Street}\" \"{store.City}stores\"";
                                Console.WriteLine(restaurantString);
                                Console.WriteLine();
                                if (orders.Count > 0) //if Store has Order History, give option to display order history
                                {
                                    Console.WriteLine("r:\tDisplay Order History.");
                                }
                                Console.WriteLine("a:\tStart New Order.");  //plus rest of menu
                                Console.WriteLine();
                                Console.Write("Enter valid menu option, or \"b\" to go back: ");
                                input = Console.ReadLine();
                                if (input == "r" && orders.Count > 0)
                                {
                                    while (orders.Count > 0)
                                    {
                                        Console.WriteLine();
                                        for (int i = 1; i <= orders.Count; i++)
                                        {
                                            Order order = orders[i - 1];
                                            Console.WriteLine($"{i}:"
                                                + $" Order No: \"{order.Id}\""
                                                + $" Date: {order.OrderDateTime}"
                                                + $" Total: \"{order.Total}\"");
                                        }
                                        Console.WriteLine();
                                        Console.WriteLine("Enter valid menu option,"
                                            + " or \"b\" to go back: ");

                                        input = Console.ReadLine();
                                        if (int.TryParse(input, out var reviewNum) && reviewNum > 0 && reviewNum <= orders.Count)

                                        {
                                            if (input == "b")
                                            {
                                                Console.WriteLine();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine($"Invalid input \"{input}\".");
                                                s_logger.Warn($"Invalid input \"{input}\".");

                                            }
                                        }
                                        else if (input == "b")
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine($"Invalid input \"{input}\".");
                                            s_logger.Warn($"Invalid input \"{input}\".");
                                        }
                                    }
                                }
                                else if (input == "a") //start new order
                                {
                                    var newOrder = new Order();
                                    var products = productRepository.GetProductByName(input2).ToList();
                                    while (newOrder.ReceiptValue == null)
                                    {
                                        Console.WriteLine();
                                        for (int i = 1; i <= orders.Count; i++)
                                        {
                                            Product order = products[i - 1];
                                            Console.WriteLine($"{i}:"
                                                + $" Order No: \"{order.Name}\""
                                                + $" Date: {order.Price}"
                                                + $" Total: \"{order.Code}\"");
                                        }
                                        Console.WriteLine();
                                        Console.Write("Select Product and quantity: ");
                                        Console.WriteLine("Enter valid menu option,"
                                            + " or \"b\" to go back: ");

                                        input = Console.ReadLine();
                                        if (int.TryParse(input, out var productNum) && productNum > 0 && productNum <= products.Count)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Added to cart");

                                        }

                                    }
                                }
                            }


                        }
                    }
                } }
