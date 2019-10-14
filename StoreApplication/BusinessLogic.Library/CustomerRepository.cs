using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessLogic.Library
{
    class CustomerRepository
    {
        private readonly ICollection<Customer> _customers;

        public CustomerRepository(ICollection<Customer> customers)
        {
            _customers = customers ?? throw new ArgumentNullException(nameof(customers));
        }
        public IEnumerable<Customer> GetCustomers(string input = null) //search with input
        {
            if (input == null)
            {
                foreach (var item in _customers)
                {
                    yield return item;
                }
            }
            else
            {
                foreach (var item in _customers.Where(r => r.Fname.Contains(input)))
                {
                    yield return item;
                }
            }
        }
    }
}
