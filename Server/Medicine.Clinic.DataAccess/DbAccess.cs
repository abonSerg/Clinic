using System;
using System.Data;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using log4net;
using NHibernate.Exceptions;



namespace Medicine.Clinic.DataAccess
{
    public abstract class DbAccess
    {
        protected ISessionFactory writeSessionsFactory;
        protected ISessionFactory readSessionsFactory;
        public static readonly ILog parentLog = LogManager.GetLogger(typeof(DbAccess));
        
        private void Configure()
        {
            writeSessionsFactory = new Configuration().Configure().BuildSessionFactory();
            readSessionsFactory = new Configuration().Configure().BuildSessionFactory();
        }

        protected DbAccess()
        {
            Configure();
        }

        protected bool InsertEntity<T>(T entity)
        {
            using (ISession writeSession = writeSessionsFactory.OpenSession())
            {
                using (ITransaction tx = writeSession.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        writeSession.Save(entity);
                        tx.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        parentLog.Error(e.Message);
                        return false;
                    }
                }
            }          
        }

        protected void InsertSpecimenEntity<T>(T entity)
        {
            using (ISession writeSession = writeSessionsFactory.OpenSession())
            {
                using (ITransaction tx = writeSession.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    writeSession.Save(entity);
                    tx.Commit();
                }
            }
        }

        protected void UpdateSpecimenEntity<T>(T entity)
        {
            using (ISession writeSession = writeSessionsFactory.OpenSession())
            {
                using (ITransaction tx = writeSession.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    writeSession.Update(entity);
                    tx.Commit();
                }
            }
        }


        protected void InsertTubeEntity<T>(T entity)
        {
            using (ISession writeSession = writeSessionsFactory.OpenSession())
            {
                using (ITransaction tx = writeSession.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    writeSession.Save(entity);
                    tx.Commit();
                }
            }
        }

        protected void UpdateTubeEntity<T>(T entity) where T : Entity
        {
            using (ISession writeSession = writeSessionsFactory.OpenSession())
            {
                using (ITransaction tx = writeSession.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    writeSession.Update(entity);
                    tx.Commit(); 
                }
            }
        }

        protected bool UpdateEntity<T>(T entity) where T : Entity
        {
            using (ISession writeSession = writeSessionsFactory.OpenSession())
            {
                using (ITransaction tx = writeSession.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        writeSession.Update(entity);
                        tx.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        parentLog.Error(e.Message);
                        return false;
                    }
                }
            }
        }

        protected bool DeleteEntity<T>(T entity) where T : Entity
        {
            using (ISession writeSession = writeSessionsFactory.OpenSession())
            {
                using (ITransaction tx = writeSession.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        writeSession.Delete(entity);
                        tx.Commit();
                        return true;
                    }
                    catch(Exception e)
                    {
                        parentLog.Error(e.Message);
                        return false;
                    } 
                }
            }
        }

        protected T[] GetAllEntities<T>()
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Query<T>().Cacheable().ToArray();
        }

        protected T[] GetEntities<T>(string code, string name) where T : ICodedEntity, INamedEntity
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Query<T>()
                              .Cacheable()
                              .Where(entity => entity.Code.Contains(code))
                              .Where(entity => entity.Name.Contains(name))
                              .ToArray();
        }


        protected T[] GetEntitiesByOrder<T>(string number) where T : IOrderedEntity
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Query<T>()
                              .Cacheable()
                              .Where(entity => entity.Order.Number == number)
                              .ToArray();
        }

        protected T[] GetPersonEntities<T>(string code, string firstName, string lastName) where T : IPerson, ICodedEntity
        {
            ISession session = writeSessionsFactory.OpenSession();
            return session.Query<T>()
                          .Cacheable()
                          .Where(entity => entity.Code.Contains(code))
                          .Where(entity => entity.FirstName.Contains(firstName))
                          .Where(entity => entity.LastName.Contains(lastName))
                          .ToArray();
        }

        protected T GetEntityById<T>(int id) where T : Entity
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Get<T>(id);
            
        }

        protected T GetEntityByCode<T>(string code) where T : ICodedEntity
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Query<T>()
                              .Cacheable()
                              .SingleOrDefault<T>(entity => entity.Code == code);
        }

        protected string GenerateEntityCode<T>()
        {
            string s = DateTime.Now.Ticks.ToString();
            char[] chars = s.ToCharArray();
            string code = string.Empty;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i <= chars.Length - 1; i++)
            {
                if (i >= 11)
                {
                    builder.Append(chars[i].ToString());
                    if (i == chars.Length - 1)
                    {
                        string t = builder.ToString();
                        code = t;
                        builder.Clear();
                    }
                }
            }
            
            if (typeof(T) == typeof(ConcreteTest))
            {
                return code = "Tst" + code;
            }
            if (typeof(T) == typeof(Order))
            {
                return code = "Ord" + code;
            }
            if (typeof(T) == typeof(ConcreteTube))
            {
                return code = "Tb" + code;
            }
            if (typeof(T) == typeof(ConcreteSpecimen))
            {
                return code = "Spc" + code;
            }
            if (typeof(T) == typeof(ConcreteIndication))
            {
                return code = "Ind" + code;
            }
            if ((typeof(T) == typeof(Visit)) || (typeof(T) == typeof(Patient)))
            {
                return code;
            }
            if (typeof(T) == typeof(ConcreteDiagnosis))
            {
                return code = "Dgn" + code;
            }
            else 
            {
                return string.Empty;
            }
        }
    }
}