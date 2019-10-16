using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Library
{
    public class Address
    {
        private int _storeNo;
        private string _street;
        private string _city;
        private int _zipcode;
        private string _state;

        public int StoreNo
        {
            get => _storeNo;
            set
            {
                _storeNo = value;
            }
        }
        public string Street
        {
            get => _street;
            set
            {
                _street = value;
            }
        }
        public string City
        {
            get => _city;
            set
            {
                _city = value;
            }
        }
        public int Zipcode
        {
            get => _zipcode;
            set
            {
                _zipcode = value;
            }
        }
        public string State
        {
            get => _state;
            set
            {
                _state = value;
            }
        }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
        
