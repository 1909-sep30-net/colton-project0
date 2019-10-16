using Microsoft.EntityFrameworkCore;
using StoreApplication.DataAccess.Entities;
using StoreApplication.DataAccess;
//using Library.Interfaces;
//using Library.Models;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;


namespace StoreApplication
{
    class Dependencies
    {
        public static IRestaurantRepository CreateRestaurantRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);

            var dbContext = new Project0Context(optionsBuilder.Options);

            return new RestaurantRepository(dbContext);
        }

        public static XmlSerializer CreateXmlSerializer() =>
            new XmlSerializer(typeof(List<Address>));

    }
}
