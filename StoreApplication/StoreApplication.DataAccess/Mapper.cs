using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lib = BusinessLogic.Library;

namespace StoreApplication.DataAccess
{
    class Mapper
    {
        public static lib.Customer MapCustomer(Entities.Customer customer)
        {
            return new lib.Customer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
               LastName = customer.LastName
            };
        }

        public static Entities.Customer MapCustomer(lib.Customer customer)
        {
            return new Entities.Customer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName
                
            };
        }
        public static lib.Location MapLocation(Entities.Location location)
        {
            return new lib.Location
            {
                Id = location.Id,
                Address = location.Address,
                Inventory = location.Inventory.Select(Mapper.MapInventoryItem).ToList(),
                OrderHistory = location.Orders.Select(Mapper.MapOrders).ToList()


            };
        }
        public static Entities.Location MapLocation(lib.Location location)
        {
            return new Entities.Location
            {
                Id = location.Id,
                Address = location.Address,
                Inventory = location.Inventory.Select(Mapper.MapInventoryItem).ToList(),
                Orders = location.OrderHistory.Select(Mapper.MapOrders).ToList(),


            };
        }
        public static Entities.Orders MapOrders(lib.Order order)
        {
            return new Entities.Orders
            {
                Id = order.Id,
                LocationId = order.Location.Id,
                CustomerId = order.Customer.Id,
                OrderDetails = order.OrderDetails.Select(Mapper.MapOrderDetails).ToList(),
                OrderTime = order.OrderDateTime
                
                

            };
        }
        public static lib.Order MapOrders(Entities.Orders order)
        {
            return new lib.Order
            {
                Id = order.Id,
                Location = Mapper.MapLocation(order.Location),
                Customer = Mapper.MapCustomer(order.Customer),
                OrderDateTime = order.OrderTime,
                OrderDetails = order.OrderDetails.Select(Mapper.MapOrderDetails).ToList()
             



            };
        }
        public static lib.InventoryItem MapInventoryItem(Entities.Inventory inventoryItem)
        {
            return new lib.InventoryItem
            {
                Product = Mapper.MapProduct(inventoryItem.Product),
                Quantity = inventoryItem.Quantity,
                Location = Mapper.MapLocation(inventoryItem.Location)
            };
        }
        public static Entities.Inventory MapInventoryItem(lib.InventoryItem inventoryItem)
        {
            return new Entities.Inventory
            {
                ProductId = inventoryItem.Product.Id,
                LocationId = inventoryItem.Location.Id, 

                Quantity = inventoryItem.Quantity,
                



            };
        }
        public static lib.OrderDetails MapOrderDetails(Entities.OrderDetails orderDetails)
        {
            return new lib.OrderDetails
            {
                Id = orderDetails.Order.Id,
                Quantity = (int)orderDetails.Quantity,
                Product = Mapper.MapProduct(orderDetails.Product)
            };
        }
        public static Entities.OrderDetails MapOrderDetails(lib.OrderDetails orderDetails)
        {
            return new Entities.OrderDetails
            {
                OrderId = orderDetails.Id,
                ProductId = orderDetails.Product.Id,
                Quantity = orderDetails.Quantity
                

            };
        }
        public static lib.Product MapProduct(Entities.Product product)
        {
            return new lib.Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = (double)product.Price
            };
        }
        public static Entities.Product MapProduct(lib.Product product)
        {
            return new Entities.Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = (decimal)product.Price

            };
        }




    }
}
