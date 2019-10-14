using System;
using BusinessLogic.Library;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml.Serialization;




namespace StoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataSource = new List<Customer>();
            var locations = new List<Address>();

            Console.WriteLine("Welcome!");
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine();
                //Console.WriteLine("a:\t");
                Console.WriteLine("b:\tStore Locator");
                //Console.WriteLine("c:\tAdd a new customer");
                //Console.WriteLine("b:\tSearch Customer");
                //Console.WriteLine("c:\tDisplay Order Details by Order Id");
                //Console.WriteLine("b:\tDisplay all Order History of a Store Location");
                //Console.WriteLine("c:\tDisplay all Order History of a Customer");
                Console.WriteLine();
                Console.Write("Enter menu option, or \"q\" to quit: ");
                var input = Console.ReadLine();
                if ( input == "a")
                {

                }
            }
            
            //Customer colton = new Customer();
            //Address address = new Address();
            //string orderDateTime = "DateTime";
            //Order order = new Order(address, colton, orderDateTime);

        }
    }
}
