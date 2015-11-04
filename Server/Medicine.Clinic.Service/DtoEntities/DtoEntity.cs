using System.Runtime.Serialization;

namespace Medicine.Clinic.Service
{
    [DataContract]
    public class DtoEntity
    {
        [DataMember]
        public int Id { get; set; }
    }
}