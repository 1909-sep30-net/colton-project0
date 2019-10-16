using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Library
{
    public class Order
    {
        public int Id { get; set; }
        public Address StoreLocation { get; set; }
        public Customer Customer { get; set; }

        public Dictionary<Product, double> ReceiptValue = new Dictionary<Product, double>();

        public double Total { get; set; }
        public string OrderDateTime { get; set; }

        public List<Product> Products { get; set; }

        public Order()
        {

        }
        public Order(Address storelocation, Customer customer, string orderDateTime, List<Product> Quantities, List<double> prices)
        {
            this.StoreLocation = storelocation;
            this.Customer = customer;
            this.OrderDateTime = orderDateTime;
            foreach(Product I in Quantities)
            {
                foreach(double price in prices)
                {
                    this.ReceiptValue.Add(I, price);
                }
            }

        }

        
        public void IncludeProduct(Product product)
        {
            Products.Add(product);
        }
    }
}



