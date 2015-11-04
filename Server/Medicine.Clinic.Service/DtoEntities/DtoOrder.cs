using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoOrder : DtoEntity
    {
        [DataMember]
        public string Number{ get; set; }
        [DataMember]
        public DtoVisit Visit { get; set; }
        [DataMember]
        public string ClinicalInfo { get; set; }
    }
}