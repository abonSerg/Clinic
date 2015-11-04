
namespace Medicine.Clinic.DataAccess
{
    public class SpecimenTubeAttach : Entity
    {
        public virtual ConcreteSpecimen ConcreteSpecimen { get; set; }
        public virtual ConcreteTube ConcreteTube { get; set; }
    }
}
