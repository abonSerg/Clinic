using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoConcreteIndication : DtoEntity
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public DtoOrder Order { get; set; }
        [DataMember]
        public DtoIndication Indication { get; set; }
    }
}