
namespace Medicine.Clinic.DataAccess
{
    public class Test : Entity, ICodedEntity, INamedEntity
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual double Cost { get; set; }
        public virtual Specimen DefaultSpecimen { get; set; }
    }
}
