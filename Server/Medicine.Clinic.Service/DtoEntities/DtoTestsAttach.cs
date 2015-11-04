using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoTestsAttach : DtoEntity
    {
        [DataMember]
        public string TestCode { get; set; }
        [DataMember]
        public string TestName { get; set; }
        [DataMember]
        public string ConcreteTesCode { get; set; }
        [DataMember]
        public bool IsEdit { get; set; }
    }
}