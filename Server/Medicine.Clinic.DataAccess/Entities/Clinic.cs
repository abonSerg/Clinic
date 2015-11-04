
namespace Medicine.Clinic.DataAccess
{
    public class Clinic : Entity, ICodedEntity, INamedEntity
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }

    }
}
