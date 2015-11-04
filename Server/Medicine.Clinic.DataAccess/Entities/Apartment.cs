
namespace Medicine.Clinic.DataAccess
{
    public class Apartment:Entity
    {
        public virtual Clinic Clinic { get; set; }
        public virtual int RoomId { get; set; }
        public virtual int BedId { get; set; }
    }
}
