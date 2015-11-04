using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoIndication : DtoEntity
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool IsEdit { get; set; }
    }
}