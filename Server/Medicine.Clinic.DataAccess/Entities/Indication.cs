
namespace Medicine.Clinic.DataAccess
{
    public class Indication : Entity, ICodedEntity, INamedEntity
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
    }
}
