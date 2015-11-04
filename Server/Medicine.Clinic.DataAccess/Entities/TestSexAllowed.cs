
namespace Medicine.Clinic.DataAccess
{
    public class TestSexAllowed : Entity
    {
        public virtual Test Test { get; set; }
        public virtual Sex Sex { get; set; }
    }
}
