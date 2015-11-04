using System;
using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoConcreteTube : DtoEntity
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public DtoOrder Order { get; set; }
        [DataMember]
        public DtoTube Tube { get; set; }
        [DataMember]
        public DateTime? ReceivedDt { get; set; }
        [DataMember]
        public bool IsEdit { get; set; }
    }
}