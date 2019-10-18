using Microsoft.EntityFrameworkCore;
using StoreApplication.DataAccess.Entities;
using StoreApplication.DataAccess;
using BusinessLogic.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;



namespace StoreApplication
{
    class Dependencies
    {
        public static DataAccess.StoreRepository CreateStoreRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
             optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);

            var dbContext = new Project0Context(optionsBuilder.Options);

            return new DataAccess.StoreRepository(dbContext);
        }

        /* public static XmlSerializer CreateXmlSerializer() =>
            new XmlSerializer(typeof(List<Address>));*/

    }
}
