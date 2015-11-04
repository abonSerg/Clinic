using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicine.Clinic.DataAccess;
using Clinic1 = Medicine.Clinic.DataAccess.Clinic;
using Moq;
using NUnit.Framework;

namespace Medicine.Clinic.DataAccessTests
{
    [TestFixture]
    public class ApartmentMethodsTest
    {
        [Test]
        public void ValidateApartment_EmptyStringReturned()
        {
            var apartment = new Apartment()
            {
                BedId = 1,
                RoomId = 1,
                Id = 1,
                Clinic = new Clinic1()
                {
                    Id = 1,
                    Code = "h",
                    Name = "Clinic",
                    Address = "Address"
                }
            };

            string res = ApartmentMethods.ValidateApartment(apartment);
            Assert.IsNullOrEmpty(res);
        }

        [Test]
        public void ValidateApartment_NotEmptyStringReturned()
        {
            var apartment = new Apartment()
            {
                BedId = 1,
                RoomId = 1,
                Id = 1,
                Clinic = new Clinic1()
                {
                    Id = 1,
                    Code = "",
                    Name = "Clinic",
                    Address = "Address"
                }
            };

            string result = ApartmentMethods.ValidateApartment(apartment);
            Assert.IsNotNullOrEmpty(result);
        }
    }
}
