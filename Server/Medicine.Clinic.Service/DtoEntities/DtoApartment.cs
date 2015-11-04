using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoApartment : DtoEntity
    {
        [DataMember]
        public DtoClinic Clinic { get; set; }
        [DataMember]
        public int RoomId { get; set; }
        [DataMember]
        public int BedId { get; set; }
        [DataMember]
        public bool IsEdit { get; set; }
    }
}