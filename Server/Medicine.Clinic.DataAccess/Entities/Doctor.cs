
namespace Medicine.Clinic.DataAccess
{
    public class Doctor : Entity, ICodedEntity, IPerson
    {
        public virtual string Code { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
