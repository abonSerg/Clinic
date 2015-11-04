
namespace Medicine.Clinic.DataAccess
{
    public class Tube : Entity, ICodedEntity, INamedEntity
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual int Volume { get; set; }
    }
}
