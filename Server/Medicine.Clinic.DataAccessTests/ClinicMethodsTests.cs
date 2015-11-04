using Medicine.Clinic.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic1 = Medicine.Clinic.DataAccess.Clinic;

namespace Medicine.Clinic.DataAccessTests
{
    [TestFixture]
    class ClinicMethodsTests
    {
        [Test]
        public void ValidateClinic_EmptyStringReturned()
        {
            var clinic = new Clinic1()
            {
                Name = "name",
                Address = "Address"
            };

            string result = ClinicMethods.ValidateClinic(clinic);
            Assert.IsNullOrEmpty(result);
        }

    }
}
