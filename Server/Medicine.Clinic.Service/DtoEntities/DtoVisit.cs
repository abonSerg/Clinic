using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoVisit : DtoEntity
    {
        [DataMember]
        public virtual string BillingNumber { get; set; }
        [DataMember]
        public virtual DtoPatient Patient { get; set; }
        [DataMember]
        public virtual DtoDoctor Doctor { get; set; }
        [DataMember]
        public virtual DtoApartment Apartment { get; set; }
    }
}