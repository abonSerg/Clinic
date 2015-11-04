
namespace Medicine.Clinic.DataAccess
{
    public class Specimen : Entity, ICodedEntity, INamedEntity
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual Tube DefaultTube { get; set; }
    }
}
