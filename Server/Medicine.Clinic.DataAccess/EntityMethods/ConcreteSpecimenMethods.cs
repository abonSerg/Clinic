using log4net;

namespace Medicine.Clinic.DataAccess
{
    public class ConcreteSpecimenMethods : DbAccess
    {
        private static ConcreteSpecimenMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(ConcreteSpecimenMethods));

        public static ConcreteSpecimenMethods Instance
        {
            get
            {
                instance = instance ?? new ConcreteSpecimenMethods();
                return instance;
            }
        }

        public string InsertConcreteSpecimen(ConcreteSpecimen specimen)
        {

            specimen.Code = GenerateConcreteSpecimenNumber();
            var result = InsertEntity<ConcreteSpecimen>(specimen);
            if (result)
            {
                log.Info(string.Format("Concrete specimen {0} saved", specimen.Code));
                return specimen.Code;
            }
            else
            {
                return string.Empty; 
            }
        }

        public bool UpdateConcreteSpecimen(ConcreteSpecimen specimen)
        {
            var result = UpdateEntity<ConcreteSpecimen>(specimen);
            if (result)
            {
                log.Info(string.Format("Concrete specimen {0} changed", specimen.Code));
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool DeleteConcreteSpecimen(ConcreteSpecimen specimen)
        {
            specimen.Id = ConcreteSpecimenMethods.Instance.GetConcreteSpecimenByCode(specimen.Code).Id;
            var result = DeleteEntity<ConcreteSpecimen>(specimen);
            if (result)
            {
                log.Info(string.Format("Concrete specimen {0} deleted", specimen.Code));
                return true;
            }
            else
            {
                return false;
            }
        }

        public ConcreteSpecimen[] GetAllConcreteSpecimens()
        {
            return GetAllEntities<ConcreteSpecimen>();
        }

        public ConcreteSpecimen[] GetConcreteSpecimensByOrder(string number)
        {
            return GetEntitiesByOrder<ConcreteSpecimen>(number);
        }

        public ConcreteSpecimen GetConcreteSpecimenById(int id)
        {
            return GetEntityById<ConcreteSpecimen>(id);
        }

        public string GenerateConcreteSpecimenNumber()
        {
            return GenerateEntityCode<ConcreteSpecimen>();
        }

        public ConcreteSpecimen GetConcreteSpecimenByCode(string code)
        {
            return GetEntityByCode<ConcreteSpecimen>(code);
        }
    }
}
