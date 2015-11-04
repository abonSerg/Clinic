using Medicine.Clinic.DataAccess.EntitiesException.SpecimenException;
using Medicine.Clinic.DataAccess.EntitiesException.TubeExceptions;
using log4net;
using NHibernate.Exceptions;

namespace Medicine.Clinic.DataAccess
{
    public class SpecimenMethods : DbAccess
    {
        private static SpecimenMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(SpecimenMethods));

        public static SpecimenMethods Instance
        {
            get
            {
                instance = instance ?? new SpecimenMethods();
                return instance;
            }
        }

        internal static void ValidateSpecimen(Specimen specimen)
        {
            if (string.IsNullOrEmpty(specimen.Code) || string.IsNullOrEmpty(specimen.Name))
            {
                throw new SpecimenMandatoryFieldsException();
            }
            else
            {
                if (string.IsNullOrEmpty(specimen.DefaultTube.Code))
                {
                    throw new SpecimenDefaultTubeException();
                }
            }
        }


        public string InsertSpecimen(Specimen specimen)
        {
            try
            {
                ValidateSpecimen(specimen);
                specimen.DefaultTube.Id = TubeMethods.Instance.GetTubeByCode(specimen.DefaultTube.Code).Id;
                InsertSpecimenEntity<Specimen>(specimen);
                string message = string.Format("Specimen {0} saved", specimen.Code);
                log.Info(message);
                return string.Empty;
            }
            catch (SpecimenException e)
            {
                log.Error(string.Format("Error saving Specimen with Code = {0}, ErrorMessage: {1}", specimen.Code, e.Message));
                return e.Message;
            }
            catch (GenericADOException e)
            {
                log.Error(string.Format("Error saving Specimen with Code = {0}, ErrorMessage: not UNIQUE Code {0}/{1}", specimen.Code, e.Message));
                return "Code will be UNIQUE!";
            }  
        }

        public string UpdateSpecimen(Specimen specimen)
        {
            try
            {
                ValidateSpecimen(specimen);
                specimen.DefaultTube.Id = TubeMethods.Instance.GetTubeByCode(specimen.DefaultTube.Code).Id;
                UpdateSpecimenEntity<Specimen>(specimen);
                string message = string.Format("Specimen {0} changed", specimen.Code);
                log.Info(message);
                return string.Empty;
            }
            catch (SpecimenException e)
            {
                log.Error(string.Format("Error changing Specimen with Code = {0}, ErrorMessage: {1}", specimen.Code, e.Message));
                return e.Message;
            }
            catch (GenericADOException e)
            {
                log.Error(string.Format("Error changing Specimen with Code = {0}, ErrorMessage: not UNIQUE Code {0}/{1}", specimen.Code, e.Message));
                return "Code will be UNIQUE!";
            } 
        }

        public Specimen[] GetSpecimens(string code, string name)
        {
            return GetEntities<Specimen>(code, name);
        }

        public Specimen GetSpecimenByCode(string code)
        {
            return GetEntityByCode<Specimen>(code);
        }
    }
}
