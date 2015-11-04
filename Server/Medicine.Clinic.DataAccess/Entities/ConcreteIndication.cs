
namespace Medicine.Clinic.DataAccess
{
    public class ConcreteIndication : Entity, IOrderedEntity, ICodedEntity
    {
        public virtual string Code { get; set; }
        public virtual Order Order { get; set; }
        public virtual Indication Indication { get; set; }
    }
}
