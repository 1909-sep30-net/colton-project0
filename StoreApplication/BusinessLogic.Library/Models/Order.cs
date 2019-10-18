﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Library
{
    public class Order
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public Customer Customer { get; set; }

        

        public double Total { get; set; }
        public DateTime OrderDateTime { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }

        public Order()
        {
            OrderDateTime = DateTime.Now;
        }

        /* public Order(Location storelocation, Customer customer, string orderDateTime, List<Product> Quantities, List<double> prices)
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

        } */

        
        /* public void IncludeProduct(Product product)
        {
            Products.Add(product);
        } */
    }
}


