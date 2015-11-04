using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicine.Clinic.DataAccess;
using NUnit.Framework;
using Clinic1 = Medicine.Clinic.DataAccess.Clinic;
using Moq;

namespace Medicine.Clinic.DataAccessTests
{
    [TestFixture]
    public class VisitMethodsTest
    {
        [Test]
        public void ValidateVisit_EmptyStringReturned()
        {
            var visit = new Visit()
            {
                BillingNumber = "1",
                Id = 1,
                Patient = new Patient()
                {
                    Dob = DateTime.Now,
                    Dod = DateTime.Now,
                    FirstName = "FName",
                    LastName = "LName",
                    MiddleName = "MName",
                    Mrn = "2222",
                    Sex = new Sex() { },
                    Ssn = "00-000-00-00"
                },
                Apartment = new Apartment()
                {
                    Id = 1,
                    Clinic = new Clinic1() { },
                    BedId = 2,
                    RoomId = 4,
                },
                Doctor = new Doctor()
                {
                    Code = "w"
                }

            };

            //Mock<PatientMethods> patientMethObject =new  Mock<PatientMethods>();
            //patientMethObject.Setup(x => x.GetPatientByMrn("2222")).Returns(new Patient() { Dod = null });

            Mock<PatientMethods> patientMethObject = new Mock<PatientMethods>();
            patientMethObject.Setup(x => x.GetPatientByMrn("2222")).Returns(new Patient() { Id = 2});

            Mock<DoctorMethods> doctorMethObject =new  Mock<DoctorMethods>();
            doctorMethObject.Setup(x => x.GetDoctorByCode("w")).Returns(new Doctor() { Clinic = new Clinic1 { Id = 1 } });

            Mock<ApartmentMethods> apartmentMethObject =new  Mock<ApartmentMethods>();
            apartmentMethObject.Setup(x => x.GetApartmentById(1)).Returns(new Apartment() { Clinic = new Clinic1 { Id = 1 } });


            string res = VisitMethods.ValidateVisit(visit);
            Assert.IsNullOrEmpty(res);
        }
    }
}
