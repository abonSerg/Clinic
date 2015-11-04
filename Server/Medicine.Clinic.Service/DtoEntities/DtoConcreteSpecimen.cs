using System;
using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoConcreteSpecimen : DtoEntity
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public  DtoOrder Order { get; set; }
        [DataMember]
        public DtoSpecimen Specimen { get; set; }
        [DataMember]
        public DateTime? CollectedDt { get; set; }
        [DataMember]
        public int Volume { get; set; }
    }
}