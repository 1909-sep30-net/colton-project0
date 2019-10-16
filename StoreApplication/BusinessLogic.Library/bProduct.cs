using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Library
{
     public class  Product
    {
        public string Name { get; }
        public double Price { get;  }

        public int Code { get; set; }        
        public Product(string name, double price, int code)
        {
            this.Name = name;
            this.Price = price;
            this.Code = code;
        }
     
    }
}
