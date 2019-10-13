using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Library
{
    public class Address
    {
        private int id;
        private string street;
        private string city;
        private int zipcode;
        private string state;

        public int Id
        {
            get => id;
            set
            {
                id = value;
            }
        }
        public string Street
        {
            get => street;
            set
            {
                street = value;
            }
        }
        public string City
        {
            get => city;
            set
            {
                city = value;
            }
        }
        public int Zipcode
        {
            get => zipcode;
            set
            {
                zipcode = value;
            }
        }
        public string State
        {
            get => state;
            set
            {
                state = value;
            }
        }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
        
