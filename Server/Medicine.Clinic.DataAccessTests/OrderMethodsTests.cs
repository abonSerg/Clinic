using Medicine.Clinic.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Clinic.DataAccessTests
{
    [TestFixture]
    public class OrderMethodsTests
    {
        [Test]
        public void ValidateOrder_StringReturned() 
        {
            var order = new Order()
            {
                ClinicalInfo = string.Empty,
                Number = "string"
            };

            string result = OrderMethods.ValidateOrder(order);
            Assert.AreEqual(result, "c");
        }
    }
}
