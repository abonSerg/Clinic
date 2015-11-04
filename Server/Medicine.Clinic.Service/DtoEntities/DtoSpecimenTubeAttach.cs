using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoSpecimenTubeAttach
    {
        [DataMember]
        public DtoConcreteSpecimen ConcreteSpecimen { get; set; }
        [DataMember]
        public DtoConcreteTube ConcreteTube { get; set; }
    }
}