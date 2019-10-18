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
        private static Order StartNewOrder(OrderDetails orderDetails, Customer customer, Location location)
        {
            Order Order = new Order();
            Order.Location = location;
            Order.Customer = customer;
            Order.OrderDetails.Add(orderDetails);
            return Order;
        }
        public static void Main()
        {
            //XmlSerializer serializer = Dependencies.CreateXmlSerializer();

            using IStoreRepository storeRepository = Dependencies.CreateStoreRepository();
            RunUi(storeRepository);
        }

        public static void RunUi(IStoreRepository storeRepository)
        {
            //string connectionString = SecretConfiguration.ConnectionString;

            //var stores = storeRepository.GetAllLocations();
            //Console.WriteLine("Do you even get here?");
            //while (stores.Count > 0) //if there are stores, print them out
            //{
            //    for (int i = 1; i <= stores.Count; i++)
            //    {
            //        Console.WriteLine("stores was >0");
            //        Location address = stores[i - 1];
                  
            //        var storeString = $"{i}: \"{address.Address}\""; //prints out locations
            //        Console.WriteLine(storeString);

            //    }
                
            //}


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
                        var stores = storeRepository.GetAllLocations(); //display all locations
                        if (stores.Count == 0) //if no stores
                        {
                            Console.WriteLine("No Stores.");
                        }
                    while (stores.Count > 0) //if there are stores, print them out
                    {
                        for (int i = 1; i <= stores.Count; i++)
                        {
                            Location address = stores[i - 1];

                            var storeString = $"{i}: \"{address.Address}\""; //prints out locations
                            Console.WriteLine(storeString);

                        }
                        Console.WriteLine();
                        Console.WriteLine("Enter menu option or \"b\" to go back");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out var storeNum)
                                && storeNum > 0 && storeNum <= stores.Count) //check which one they select
                        {
                            var store = stores[storeNum - 1];
                            var orders = store.OrderHistory;

                            while (true)
                            {
                                Console.WriteLine();
                                var restaurantString = $"\"{store.Address}\"";
                                Console.WriteLine(restaurantString);
                                Console.WriteLine();
                                if (orders.Count > 0) //if Store has Order History, give option to display order history
                                {
                                  Console.WriteLine("r:\tDisplay Order History.");
                                }
                                  Console.WriteLine("a:\tStart New Order.");  //plus rest of menu
                                  Console.WriteLine();
                                  Console.Write("Enter valid menu option, or \"b\" to go back, or \"q\" to quit: ");
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
                                        Console.WriteLine("Press \"b\" to Go Back");

                                        input = Console.ReadLine();
                                        if (input == "b")
                                        {
                                            Console.WriteLine();
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
                                else if (input == "a") //start new order
                                {
                                    //Ask if they are new or returning customer?
                                    Console.WriteLine("Are you a new or returning customer?");
                                    Console.WriteLine();
                                    Console.WriteLine("Press \"n\" for new or \"r\" for returning or \"b\"to go back");
                                    input = Console.ReadLine();
                                    if(input == "n")
                                    {
                                        //you are a new customer, what is first name? set and save, what is your last name? set and save
                                        Console.WriteLine("Enter First Name:");
                                        Console.WriteLine();
                                        input = Console.ReadLine();
                                        Customer NewCustomer = new Customer();
                                        NewCustomer.FirstName = input;
                                        Console.WriteLine("Enter Last Name:");
                                        Console.WriteLine();
                                        input = Console.ReadLine();
                                        NewCustomer.LastName = input;
                                        Console.WriteLine("Adding to DB...");
                                        storeRepository.AddCustomer(NewCustomer);
                                        storeRepository.Save();
                                        OrderDetails orderDetails = new OrderDetails();
                                        Location location = store;
                                        Order order = StartNewOrder(orderDetails, NewCustomer, location);

                                    }
                                    else if (input == "r")
                                    {
                                        // you are returing customer, so Search Customer by name, select number
                                        Console.WriteLine("Please write your first name");
                                        input = Console.ReadLine();
                                        //maybe put input validation
                                        var Customer = storeRepository.GetCustomerByName(input);
                                        while (Customer.Count > 0)
                                        {
                                            Console.WriteLine();
                                            for (int i = 1; i <= Customer.Count; i++)
                                            {
                                                Customer customer = Customer[i - 1];
                                                Console.WriteLine($"{i}:"
                                                    + $" Customer ID: \"{customer.Id}\""
                                                    + $" FirstName {customer.FirstName}"
                                                    + $" LastName {customer.LastName}");

                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("Enter Valid Memu Option or press \"b\" to Go Back"); //Go back to entering first name

                                            input = Console.ReadLine();

                                            if (int.TryParse(input, out var custNum)
                                                     && custNum > 0 && custNum <= Customer.Count)
                                            {
                                                var selectedCustomer = Customer[custNum - 1];

                                                    Console.WriteLine("Begin Order, Enter Product");
                    
                                                    //Call BeginOrder method passing (customer, 

                                               // }
                                            }

                                            else if (input == "b")
                                            {
                                                Console.WriteLine();
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
                                    else if (input == "b")
                                    {
                                        Console.WriteLine();
                                        break;         // go back to Location
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Invalid input \"{input}\".");
                                        s_logger.Warn($"Invalid input \"{input}\".");
                                    }
                                }
                                else if (input =="b") //go back to Location Selection
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


                        else if (input == "q") //quit application from
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
                else if (input == "q") //quit application from
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
        public Order StartNewOrder(OrderDetails orderDetails, Customer customer, Location location)
        {
            Order Order = new Order();
            Order.Location = location;
            Order.Customer = customer;
            Order.OrderDetails.Add(orderDetails);
            return Order;
        }
    }
}