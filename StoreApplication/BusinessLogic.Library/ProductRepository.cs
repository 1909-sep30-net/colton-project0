using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessLogic.Library
{
    public class ProductRepository
    {

        private readonly ICollection<Product> _data;

        public ProductRepository(ICollection<Product> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public IEnumerable<Product> GetProductByName(string input = null)
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
                foreach (var item in _data.Where(r => r.Name.Contains(input)))
                {
                    yield return item;
                }
            }
        }
        public Product GetProductById(int id)
        {
            return _data.First(r => r.Code == id);
        }

    }
}
