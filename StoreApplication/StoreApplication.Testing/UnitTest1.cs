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
            colton.Fname = anyNameValue;
            Assert.Equal(anyNameValue, colton.Fname);
        }
        [Fact]
        public void LName_NonEmptyValue_StoresCorrectly()
        {
            const string anyNameValue = "clary";
            colton.Lname = anyNameValue;
            Assert.Equal(anyNameValue, colton.Lname);

        }
        [Fact]
        public void FName_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => colton.Fname = string.Empty);
        }
        [Fact]
        public void LName_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => colton.Lname = string.Empty);
        }
        //[Fact]
        //public void Order_DoesNotMakeInventoryZero()
        //{
        //    Assert.False(Inventory == 0);
        //}
       
    }
}
