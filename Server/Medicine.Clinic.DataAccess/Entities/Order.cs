
namespace Medicine.Clinic.DataAccess
{
    public class Order : Entity
    {
        public virtual string Number { get; set; }
        public virtual Visit Visit { get; set; }
        public virtual string ClinicalInfo { get; set; }
    }
}
