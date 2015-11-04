using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoTestSexAllowed : DtoEntity
    {
        [DataMember]
        public DtoTest Test { get; set; }
        [DataMember]
        public DtoSex Sex { get; set; }
    }
}