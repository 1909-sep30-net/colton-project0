using System;
using BusinessLogic.Library.Interfaces;
using BusinessLogic.Library;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using NLog;
using StoreApplication.DataAccess;




namespace StoreApplication
{
    class Program
    {
        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

        public static void Main()
        {
            //XmlSerializer serializer = Dependencies.CreateXmlSerializer();

            /*using IStoreRepository storeRepository = Dependencies.
                CreateStoreRepository();
            RunUi(storeRepository/*, serializer*///);
        }
        public static void RunUi(IStoreRepository storeRepository/*,
            XmlSerializer serializer*/)
        {
            //string connectionString = SecretConfiguration.ConnectionString;


            Console.WriteLine("Welcome to Azeroth!");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("b:\tDisplay Locations");
                Console.WriteLine();
                Console.Write("Enter menu option, or \"q\" to quit: ");
                var input = Console.ReadLine();
                if (input == "b") //Open store locator
                {
                    Console.WriteLine();


                    var stores = storeRepository.GetLocationById(1).ToList(); //search stores by City name
                    if (stores.Count == 0) //if no stores
                    {
                        Console.WriteLine("No Stores.");
                    }
                    while (stores.Count > 0) //if there are stores, print them out
                    {
                        for (int i = 1; i <= stores.Count; i++)
                        {
                            Location address = stores[i - 1];

                            var storeString = "";//$"{i}: \"{address.Street}\" \"{address.City}\""; //prints out locations
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
                                var restaurantString = "";//$"\"{store.Street}\" \"{store.City}stores\"";
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
                                if (input == "r" && orders.Count > 0) //if they want to display order history and orders exist for location
                                {
                                    while (orders.Count > 0)
                                    {
                                        Console.WriteLine();
                                        for (int i = 1; i <= orders.Count; i++)//prints out order history for location of selection
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
                                        if (int.TryParse(input, out var reviewNum) && reviewNum > 0 && reviewNum <= orders.Count)//select order
                                        {
                                            Location location = stores[reviewNum - 1];
                                            List<Order> orders2 = location.Orders;
                                            while (true)
                                            {
                                                Console.WriteLine();
                                                var storeString = "";//$"\"{location.City}\"";
                                                if (orders?.Count > 0)
                                                {
                                                    storeString += $", with score {location.Orders}"
                                                        + $" from {orders2.Count} review";
                                                    if (orders2.Count > 1)
                                                    {
                                                        storeString += "s";
                                                    }
                                                }
                                                else
                                                {
                                                    storeString += ", with no orders";
                                                }
                                                Console.WriteLine(storeString);
                                                Console.WriteLine();
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

                                        }
                                    }

                                }
                                else if (input == "a") //start new order
                                {
                                    //var newOrder = new Order();
                                    //var products = productRepository.GetProductByName().ToList();
                                    //while (newOrder.ReceiptValue == null)
                                    //{
                                    //    Console.WriteLine();
                                    //    for (int i = 1; i <= orders.Count; i++)
                                    //    {
                                    //        Product order = products[i - 1];
                                    //        Console.WriteLine($"{i}:"
                                    //            + $" Order No: \"{order.Name}\""
                                    //            + $" Date: {order.Price}"
                                    //            + $" Total: \"{order.Code}\"");
                                    //    }
                                    //    Console.WriteLine();
                                    //    Console.Write("Select Product and quantity: ");
                                    //    Console.WriteLine("Enter valid menu option,"
                                    //        + " or \"b\" to go back: ");

                                    //    input = Console.ReadLine();
                                    //    if (int.TryParse(input, out var productNum) && productNum > 0 && productNum <= products.Count)
                                    //    {
                                    //        Console.WriteLine();
                                    //        Console.WriteLine("Added to cart");

                                    //    }

                                    //}
                                }



                            }
                        }


                        else if (input == "q")
                        {
                            s_logger.Info("Exiting application.");
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
                else if (input == "q")
                {
                    s_logger.Info("Exiting application.");
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Invalid input\"{input}\".");
                    s_logger.Warn($"Invalid input \"{input}\".");
                }

            }
        }
    }
}