
namespace Medicine.Clinic.DataAccess
{
    public class Diagnosis : Entity, ICodedEntity, INamedEntity
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
    }
}
