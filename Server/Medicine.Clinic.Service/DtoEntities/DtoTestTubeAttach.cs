using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoTestTubeAttach
    {
        [DataMember]
        public DtoConcreteTest DtoConcreteTest { get; set; }
        [DataMember]
        public DtoConcreteTube DtoConctereTube { get; set; }
    }
}