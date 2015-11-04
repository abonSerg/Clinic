
namespace Medicine.Clinic.DataAccess
{
    public class ConcreteTest : Entity, IOrderedEntity, ICodedEntity
    {
        public virtual string Code { get; set; }
        public virtual Order Order { get; set; }
        public virtual Test Test { get; set; }
    }
}
