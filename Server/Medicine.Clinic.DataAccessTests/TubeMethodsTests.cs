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
    public class TubeMethodsTests
    {
        [Test]
        public void ValidateTube_VolumeException()
        {
            var tube = new Tube()
            {
                Code = "code",
                Name = "name",
                Volume = 1001

            };
            bool isExceptionExist = false;
            try
            {
                TubeMethods.ValidateTube(tube);
            }
            catch (Exception) 
            {
                isExceptionExist = true;
            }

            Assert.IsTrue(isExceptionExist);
          ;
        }
    }
}
