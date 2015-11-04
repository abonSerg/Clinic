using System;
using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoPatient : DtoEntity
    {
        [DataMember]
        public string Mrn { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string Ssn { get; set; }
        [DataMember]
        public DateTime Dob { get; set; }
        [DataMember]
        public DtoSex Sex { get; set; }
        [DataMember]
        public DateTime? Dod { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public bool IsEdit { get; set; }
    }
}