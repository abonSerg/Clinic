using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoConcreteTest : DtoEntity
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public DtoOrder Order { get; set; }
        [DataMember]
        public DtoTest Test { get; set; }
    }
}