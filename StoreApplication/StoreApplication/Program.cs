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
        private static void StartNewOrder(Customer customer, Location location)
        {
            using IStoreRepository storeRepository = Dependencies.CreateStoreRepository();




        }
        public static void Main()
        {
            //XmlSerializer serializer = Dependencies.CreateXmlSerializer();

            using IStoreRepository storeRepository = Dependencies.CreateStoreRepository();
            RunUi(storeRepository);
        }

        public static void RunUi(IStoreRepository storeRepository)
        {

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
                            var orders = storeRepository.GetOrderHistory(storeNum);
                           

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
                                        List<BusinessLogic.Library.Customer> colton = storeRepository.GetCustomer(NewCustomer.FirstName, NewCustomer.LastName);

                                        Dictionary<BusinessLogic.Library.Product, int> invent101 = storeRepository.GetInventoryByStoreId(location.Id);
                                        PrintInventory(invent101);
                                        Console.WriteLine();
                                        Console.WriteLine("Type the name of the item you'd like to purchase.");
                                        string item1 = Console.ReadLine();
                                        int Q = NewCustomer.Id;
                                        foreach (Product p in invent101.Keys)
                                        {
                                            if (p.Name == item1)
                                            {
                                                Console.WriteLine("How many would you like to buy?");
                                                string quantity = Console.ReadLine();
                                                invent101.TryGetValue(p, out int value);
                                                if (int.TryParse(quantity, out var D) && (D <= 0 || ((value - D) <= 0)))//checks if inventory will go below 0
                                                {
                                                    Console.WriteLine("You have to enter more than 0 and inventory can't go below 0");
                                                    Console.WriteLine("How many would you like to buy?");
                                                    quantity = Console.ReadLine();

                                                }
                                                if (int.TryParse(quantity, out D) && D > 1 && D <= value)
                                                {
                                                    Order order = new Order()
                                                    {
                                                        OrderDateTime = DateTime.Now,
                                                        Total = p.Price,
                                                        CustomerId = Q,
                                                        Location = location,
                                                        OrderDetails = new List<OrderDetails>()

                                                    };

                                                    OrderDetails orderdetails = new OrderDetails()
                                                    {

                                                        Product = p,
                                                        Quantity = D

                                                    };
                                                    order.OrderDetails.Add(orderdetails);


                                                    storeRepository.AddOrder(order);
                                                    storeRepository.Save();

                                                    InventoryItem inventoryItem = new InventoryItem();
                                                    inventoryItem.Product = p;
                                                    inventoryItem.Quantity = value - D;
                                                    inventoryItem.Location = location;
                                                    storeRepository.UpdateInventory(inventoryItem);
                                                    storeRepository.Save();
                                                    Console.WriteLine($"Thanks for Shopping! Press \"q\" to quit!");
                                                    input = Console.ReadLine();

                                                    if (input == "q")
                                                    {
                                                        s_logger.Info("Exiting application.");
                                                        System.Environment.Exit(1);
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



                                        Console.WriteLine();


                                        

                                    }
                                    else if (input == "r")
                                    {
                                        // you are returing customer, so Search Customer by name, select number
                                        Console.WriteLine("Please write your first name");
                                        input = Console.ReadLine();
                                        //maybe put input validation
                                        var Customer = storeRepository.GetCustomerByName(input);
                                        if(Customer.Count < 0)
                                        {
                                            Console.WriteLine($"You haven't been here before... Press\"b\" to go back...");
                                            input = Console.ReadLine();
                                            if (input == "b") 
                                            {
                                                break;
                                            }
                                            
                                            
                                            else
                                            {
                                                    Console.WriteLine();
                                                    Console.WriteLine($"Invalid input\"{input}\".");
                                                    s_logger.Warn($"Invalid input \"{input}\".");
                                            }
                                            
                                        }
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

                                                OrderDetails orderDetails = new OrderDetails();
                                                Location location = store;
                                                List<BusinessLogic.Library.Customer> colton = storeRepository.GetCustomer(selectedCustomer.FirstName, selectedCustomer.LastName);

                                                Dictionary<BusinessLogic.Library.Product, int> invent101 = storeRepository.GetInventoryByStoreId(location.Id);
                                                PrintInventory(invent101);
                                                Console.WriteLine();
                                                Console.WriteLine("Type the name of the item you'd like to purchase.");
                                                string item1 = Console.ReadLine();
                                                int Q = selectedCustomer.Id;
                                                foreach (Product p in invent101.Keys)
                                                {
                                                    if (p.Name == item1)
                                                    {
                                                        Console.WriteLine("How many would you like to buy?");
                                                        string quantity = Console.ReadLine();
                                                        invent101.TryGetValue(p, out int value);
                                                        if (int.TryParse(quantity, out var D) && (D<=0 || ((value-D) <=0)))
                                                        {
                                                            Console.WriteLine("You have to enter more than 0 and inventory can't go below 0");
                                                            Console.WriteLine("How many would you like to buy?");
                                                            quantity = Console.ReadLine();
                                                            
                                                        }
                                                        if (int.TryParse(quantity, out D) && D>1 && D<=value)
                                                        {
                                                            Order order = new Order()
                                                            {
                                                                OrderDateTime = DateTime.Now,
                                                                Total = p.Price,
                                                                CustomerId = Q,
                                                                Location = location,
                                                                OrderDetails = new List<OrderDetails>()

                                                            };

                                                            OrderDetails orderdetails = new OrderDetails()
                                                            {

                                                                Product = p,
                                                                Quantity = D

                                                            };
                                                            order.OrderDetails.Add(orderdetails);


                                                            storeRepository.AddOrder(order);
                                                            storeRepository.Save();
                                                            
                                                            InventoryItem inventoryItem = new InventoryItem();
                                                            inventoryItem.Product = p;
                                                            inventoryItem.Quantity = value - D;
                                                            inventoryItem.Location = location;
                                                            storeRepository.UpdateInventory(inventoryItem);
                                                            storeRepository.Save();
                                                            Console.WriteLine($"Thanks for Shopping! Press \"q\" to quit!");
                                                            input = Console.ReadLine();
                                                            if(input == "q")
                                                            {
                                                                s_logger.Info("Exiting application.");
                                                                System.Environment.Exit(1);
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
                            System.Environment.Exit(1);
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
                    System.Environment.Exit(1);
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
        static void PrintInventory(Dictionary<BusinessLogic.Library.Product, int> invent101)
        {
            Console.WriteLine("This is what we have at our store! ");
            foreach (var item in invent101)
            {
                Console.WriteLine($" Product: {item.Key.Name} Stock: {item.Value} Price: ${item.Key.Price}");

            }
        }

    }
}