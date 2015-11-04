using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoDoctor : DtoEntity
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public DtoClinic Clinic { get; set; }
        [DataMember]
        public bool IsEdit { get; set; }
    }
}