using System;

namespace Medicine.Clinic.DataAccess
{
    public class ConcreteSpecimen : Entity, IOrderedEntity, ICodedEntity
    {
        public virtual string Code { get; set; }
        public virtual Order Order { get; set; }
        public virtual Specimen Specimen { get; set; }
        public virtual DateTime? CollectedDt { get; set; }
        public virtual int Volume { get; set; }
    }
}
