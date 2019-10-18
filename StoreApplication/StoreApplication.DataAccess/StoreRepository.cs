using System;
using System.Collections.Generic;
using System.Linq;
using StoreApplication.DataAccess.Entities;
using NLog;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Library.Interfaces;
using BusinessLogic.Library;

namespace StoreApplication.DataAccess
{
    public class StoreRepository //: IStoreRepository, IDisposable
    {
        /// <summary>
        /// A repository for data access for store objects and their Locations/Addresses.
        /// </summary>
        //private readonly ICollection<Address> _data;
        private readonly Project0Context _dbContext;
        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();



        public StoreRepository(Project0Context dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public IEnumerable<BusinessLogic.Library.Location> GetLocationByAddress(string input = null)
        {
            IQueryable<DataAccess.Entities.Location> items = _dbContext.Location
                .Include(r => r.Orders).AsNoTracking();

            if (input != null)
            {
                items = items.Where(r => r.Address.Contains(input));
            }
            return items.Select(Mapper.MapLocation);
        }
        public BusinessLogic.Library.Location GetLocationById(int id) =>
            Mapper.MapLocation(_dbContext.Location.Find(id));

        public void AddCustomer(BusinessLogic.Library.Customer customer)
        {
            _dbContext.Customer.Add(Mapper.MapCustomer(customer));
        }

        public List<Order> GetOrderHistory(string search = null)
        {
           return _dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.Location)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .Select(Mapper.MapOrders).ToList();
        }
        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(Mapper.MapOrders(order));
            //if (location.Id != 0)
            //{
            //    s_logger.Warn($"Order to be  added has an ID ({location.Id}) already: ignoring.");
            //}

            //s_logger.Info($"Adding order to store with ID {location.Id}");

            //if (location != null)
            //{
            //    // get the db's version of that restaurant
            //    // (can't use Find with Include)
            //    Entities.Location LocationEntity = _dbContext.Location
            //        .Include(r => r.Id).First(r => r.Id == location.Id);
            //    Orders newEntity = Mapper.MapOrders(order);
            //    LocationEntity.Orders.Add(newEntity);
            //    // also, modify the parameters
            //    location.OrderHistory.Add(order);
            //}
            //else
            //{
            //    Orders newEntity = Mapper.MapOrders(order);
            //    _dbContext.Add(newEntity);
            //}
        }

        public void Save()
        {
            s_logger.Info("Saving changes to the database");
            _dbContext.SaveChanges();
        }
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                _disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }

    }
}
