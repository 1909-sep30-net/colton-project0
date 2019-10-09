using System;
using BusinessLogic.Library;

namespace StoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer colton = new Customer();
            Address address = new Address();
            string orderDateTime = "DateTime";
            Order order = new Order(address, colton, orderDateTime);

        }
    }
}
