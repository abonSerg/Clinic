using System;

namespace Medicine.Clinic.DataAccess
{
    public class Patient : Entity, IPerson
    {
        public virtual string Mrn { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string Ssn { get; set; }
        public virtual DateTime Dob { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual DateTime? Dod { get; set; }
    }

    
    
}
