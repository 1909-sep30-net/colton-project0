//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using System.Linq;
using System;
using BusinessLogic.Library;
namespace StoreApplication.Testing
{

    public class UnitTest1
    {
        readonly Customer colton = new Customer();
        [Fact]
        public void FName_NonEmptyValue_StoresCorrectly()
        {
            const string anyNameValue = "colton";
            colton.FirstName = anyNameValue;
            Assert.Equal(anyNameValue, colton.FirstName);
        }
        [Fact]
        public void LName_NonEmptyValue_StoresCorrectly()
        {
            const string anyNameValue = "clary";
            colton.LastName = anyNameValue;
            Assert.Equal(anyNameValue, colton.LastName);

        }
        [Fact]
        public void FName_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => colton.FirstName = string.Empty);
        }
        [Fact]
        public void LName_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => colton.LastName = string.Empty);
        }
        
       //public void Order_DoesNotMakeInventoryZero()
       // {
       //     Assert.False(Inventory == 0);
       // }


       
    }
}
