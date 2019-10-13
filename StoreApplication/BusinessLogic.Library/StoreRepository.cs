using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessLogic.Library
{
    public class StoreRepository
    {
        /// <summary>
        /// A repository for data access for store objects and their Locations/Addresses.
        /// </summary>
        private readonly ICollection<Address> _data;

        public StoreRepository(ICollection<Address> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public IEnumerable<Address> GetStoresByCity(string input = null)
        {
            if (input == null)
            {
                foreach (var item in _data)
                {
                    yield return item;
                }
            }
            else
            {
                foreach (var item in _data.Where(r => r.City.Contains(input)))
                {
                    yield return item;
                }
            }
        }
        public Address GetStoreById(int id)
        {
            return _data.First(r => r.Id == id);
        }

        public void DisplayOrderHistoryOfLocation(Address location)
        {
            foreach (var item in location.Orders)
            {
                Console.WriteLine(item);
            }
        }
        public void AddOrder(Address location, Order order)
        {
            location.Orders.Add(order);
        }
    }
}
