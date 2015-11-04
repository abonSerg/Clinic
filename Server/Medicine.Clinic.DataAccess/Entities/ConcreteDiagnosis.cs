
namespace Medicine.Clinic.DataAccess
{
    public class ConcreteDiagnosis : Entity, IOrderedEntity, ICodedEntity
    {
        public virtual string Code { get; set; }
        public virtual Order Order { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }        
    }
}
