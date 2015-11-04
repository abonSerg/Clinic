using System;
using Medicine.Clinic.DataAccess.EntitiesException.TubeExceptions;
using log4net;
using NHibernate.Exceptions;


namespace Medicine.Clinic.DataAccess
{
    public class TubeMethods : DbAccess
    {
        private static TubeMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(TubeMethods));

        public static TubeMethods Instance
        {
            get
            {
                instance = instance ?? new TubeMethods();
                return instance;
            }
        }

        public static void ValidateTube(Tube tube) 
        {
            if (string.IsNullOrEmpty(tube.Code) || string.IsNullOrEmpty(tube.Name))
            {
                throw new TubeMandatoryFieldsException();
            }
            else 
            {
                if (tube.Volume > 1000)
                {
                    throw new TubeVolumeException();
                }
            }
        }

        public string InsertTube(Tube tube)
        {
            try
            {
                ValidateTube(tube);
                InsertTubeEntity<Tube>(tube);
                string message = string.Format("Tube {0} saved", tube.Code);
                log.Info(message);
                return "s";
            }
            catch (TubeException e)
            {
                log.Error(string.Format ("Error saving Tube with Code = {0}, ErrorMessage: {1}",tube.Code,e.Message));
                return e.Message;
            }
            catch (GenericADOException e)
            {
                log.Error(string.Format("Error saving Tube with Code = {0}, ErrorMessage: not UNIQUE Code {0}/{1}", tube.Code, e.Message));
                return "Code will be UNIQUE!";
            }
        }

        public string UpdateTube(Tube tube)
        {
            try
            {
                ValidateTube(tube);
                UpdateTubeEntity<Tube>(tube);
                string message = string.Format("Tube {0} updated", tube.Code);
                log.Info(message);
                return "c";
            }
            catch (TubeException e)
            {
                log.Error(string.Format("Error saving Tube with Code = {0}, ErrorMessage: {1}", tube.Code, e.Message));
                return e.Message;
            }
            catch (GenericADOException e)
            {
                log.Error(string.Format("Error saving Tube with Code = {0}, ErrorMessage: not UNIQUE Code {0}/{1}", tube.Code, e.Message));
                return "Code will be UNIQUE!";
            }
        }

        public Tube[] GetTubes(string code, string name)
        {
            return GetEntities<Tube>(code, name);
        }

        public Tube GetTubeById(int id)
        {
            return GetEntityById<Tube>(id);
        }

        public Tube GetTubeByCode(string code)
        {
            return GetEntityByCode<Tube>(code);
        }
    }
}
