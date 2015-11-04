
namespace Medicine.Clinic.DataAccess
{
    public class Visit : Entity
    {
        public virtual string BillingNumber { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}
