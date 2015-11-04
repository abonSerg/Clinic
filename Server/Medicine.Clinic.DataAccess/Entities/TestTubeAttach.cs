
namespace Medicine.Clinic.DataAccess
{
    public class TestTubeAttach : Entity
    {
        public virtual ConcreteTest ConcreteTest { get; set; }
        public virtual ConcreteTube ConcreteTube { get; set; }
    }
}
