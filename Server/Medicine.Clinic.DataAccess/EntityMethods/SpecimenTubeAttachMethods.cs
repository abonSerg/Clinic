using System.Linq;
using NHibernate;
using NHibernate.Linq;
using log4net;

namespace Medicine.Clinic.DataAccess
{
    public class SpecimenTubeAttachMethods : DbAccess
    {
        private static SpecimenTubeAttachMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(SpecimenTubeAttachMethods));

        public static SpecimenTubeAttachMethods Instance
        {
            get
            {
                instance = instance ?? new SpecimenTubeAttachMethods();
                return instance;
            }
        }

        public void InsertSpecimenTubeAttach(SpecimenTubeAttach specimenTubeAttach)
        {
           var result = InsertEntity<SpecimenTubeAttach>(specimenTubeAttach);
           if (result) 
           {
               log.Info(string.Format("ConcreteSpecimen {0} to Tube {1}  attached", specimenTubeAttach.ConcreteSpecimen.Id, specimenTubeAttach.ConcreteTube.Id));
           }
        }

        public void DeleteSpecimenTubeAttach(SpecimenTubeAttach specimenTubeAttach)
        {
            var result = DeleteEntity<SpecimenTubeAttach>(specimenTubeAttach);
            if (result)
            {
                log.Info(string.Format("SpecimenTubeAttach {0} attach deleted", specimenTubeAttach.Id));
            }
        }

        public SpecimenTubeAttach[] GetSpecimenTubeAttachesBySpecimen(string concreteSpecimenCode)
        {
            ISession session = writeSessionsFactory.OpenSession();
            return session.Query<SpecimenTubeAttach>()
                          .Cacheable()
                          .Where(specimenTube => specimenTube.ConcreteSpecimen.Code == concreteSpecimenCode)
                          .ToArray();
        }

        public SpecimenTubeAttach[] GetSpecimenTubeAttachesByOrder(string orderNumdber)
        {
            ISession session = writeSessionsFactory.OpenSession();
            return session.Query<SpecimenTubeAttach>()
                          .Cacheable()
                          .Where(specimenTube => specimenTube.ConcreteTube.Order.Number == orderNumdber)
                          .ToArray();
        }
    }
}
