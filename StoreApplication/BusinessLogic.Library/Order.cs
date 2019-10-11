using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Library
{
    public class Order
    {

        public Address StoreLocation { get; set; }
        public Customer Customer { get; set; }

        public string OrderDateTime { get; set; }

        public List<Product> Products { get; set; }


        public Order(Address storelocation, Customer customer, string orderDateTime)
        {
            this.StoreLocation = storelocation;
            this.Customer = customer;
            this.OrderDateTime = orderDateTime;

        }

        public void IncludeProduct(Product product)
        {
            Products.Add(product);
        }
    }
}



