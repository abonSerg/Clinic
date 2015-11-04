using System;

namespace Medicine.Clinic.DataAccess
{
    public class Interpretation : Entity, IOrderedEntity
    {
        public virtual Order Order { get; set; }
        public virtual string Text { get; set; }
        public virtual char Condition { get; set; }
        public virtual DateTime? SignOutDt { get; set; }
    }
}
