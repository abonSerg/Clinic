using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoConcreteDiagnosis : DtoEntity
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public DtoOrder Order { get; set; }
        [DataMember]
        public DtoDiagnosis Diagnosis { get; set; } 
    }
}