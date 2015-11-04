using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicine.Clinic.Client.Model;
using NUnit.Framework;

namespace ClientTests
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void ValidateCode_TestReturnedEmptyString() 
        {
            string code = "code";
            Assert.IsTrue(Validation.Instance.ValidateCode(code));

            code = string.Empty;
            Assert.IsFalse(Validation.Instance.ValidateCode(code));
        }
    }
}
