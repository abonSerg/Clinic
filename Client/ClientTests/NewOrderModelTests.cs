using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTests
{
    [TestFixture]
    public class NewOrderModelTests
    {
        [Test]
        public void DeleteCheckedTests_TestReturnedStringWithoutInputCode()
        {
            var tubestList = new BindingList<TubeForGrid>();

            var tube1 = new TubeForGrid()
            {
                Tests = "qwe, asd, zxc"
            };
            tubestList.Add(tube1);

            var tube2 = new TubeForGrid()
            {
                Tests = "asd, qwe, zxc"
            };
            tubestList.Add(tube2);

            var tube3 = new TubeForGrid()
            {
                Tests = "asd, zxc, qwe"
            };
            tubestList.Add(tube3);

            var tube4 = new TubeForGrid()
            {
                Tests = "qwe"
            };
            tubestList.Add(tube4);

            var updatedTubesList = new NewOrderModel().DeleteCheckedTests(tubestList, "qwe");

            string updatedTestsString = "asd, zxc";
            Assert.AreEqual(updatedTubesList[0].Tests, updatedTestsString);
            Assert.AreEqual(updatedTubesList[1].Tests, updatedTestsString);
            Assert.AreEqual(updatedTubesList[2].Tests, updatedTestsString);
            Assert.IsEmpty(updatedTubesList[3].Tests);
            
        }
    }
}
