using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoTest : DtoEntity
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Cost { get; set; }
        [DataMember]
        public DtoSpecimen DefaultSpecimen { get; set; }
        [DataMember]
        public bool IsEdit { get; set; }
    }
}