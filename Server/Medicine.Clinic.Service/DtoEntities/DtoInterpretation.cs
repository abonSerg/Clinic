using System;
using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoInterpretation : DtoEntity
    {
        [DataMember]
        public DtoOrder Order { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public char Condition { get; set; }
        [DataMember]
        public DateTime? SignOutDt { get; set; }
        [DataMember]
        public bool IsEdit { get; set; }
    }
}