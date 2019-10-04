using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Library
{
    public class Order
    {
        //List<Product> ProductNames;
        Product ProductName;

        double Total;
        int Quantity;
        double Price;
        public Order(Product productname, string location, )
        {

        }
         

        public void CreateNewOrder(Product name)
        {
            ordernames.Add(name);
            
        }

        public double Calculate()
        {
            return Quantity * Price;
        }


        public class ModifyOrder
        {

        }

    }
}



