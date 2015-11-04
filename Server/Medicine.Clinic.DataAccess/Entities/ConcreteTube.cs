using System;


namespace Medicine.Clinic.DataAccess
{
    public class ConcreteTube : Entity, IOrderedEntity, ICodedEntity
    {
        public virtual string Code { get; set; }
        public virtual Order Order { get; set; }
        public virtual Tube Tube { get; set; }
        public virtual DateTime? ReceivedDt { get; set; }
    }
}


