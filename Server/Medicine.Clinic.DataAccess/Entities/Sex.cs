
namespace Medicine.Clinic.DataAccess
{
    public class Sex : Entity, ICodedEntity, INamedEntity
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
    }
}
