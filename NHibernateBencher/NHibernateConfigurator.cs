using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernateBencher.EntityClasses;
using NHibernateBencher.Mapping;
using System;

//[assembly: NHibernateBencher]

namespace NHibernateBencher
{
    public class NHibernateConfigurator
    {
        private static ISessionFactory _sessionFactory = null;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = CreateNHibernateConfiguration();
                    var mapping = CreateMapping();
                    configuration.AddMapping(mapping);
                    //configuration.AddAssembly(typeof(NHibernateConfigurator).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                    if (_sessionFactory == null)
                        throw new InvalidOperationException("Could not build SessionFactory");
                }

                return _sessionFactory;
            }
        }

        public static HbmMapping CreateMapping()
        {
            ModelMapper mapper = new ModelMapper();

            mapper.AddMapping<AdminssMap>();
            mapper.AddMapping<AddressMap>();
            mapper.AddMapping<AuthorsMap>();
            mapper.AddMapping<BookcategoryMap>();
            mapper.AddMapping<BookMap>();
            mapper.AddMapping<BooktransactionMap>();
            mapper.AddMapping<ContactdetailsMap>();
            mapper.AddMapping<InventoryMap>();
            mapper.AddMapping<ItemcategoryMap>();
            mapper.AddMapping<ItemtransactionMap>();
            mapper.AddMapping<UserdetailsMap>();
            mapper.AddMapping<UsersMap>();

            // Create an array of types that are not mapped.
            HbmMapping mapping = mapper.CompileMappingFor(new[] {
                typeof(Address),typeof(Authors),typeof(Admins),typeof(Users),typeof(UserDetails),
                typeof(ContactDetails),typeof(Books),typeof(BookCategory),typeof(BookTransaction),
                typeof(Inventory),typeof(ItemCategory),typeof(ItemTransaction) });

            return mapping;
        }


        public static Configuration CreateNHibernateConfiguration()
        {
            //NHibernateProfiler.Initialize();
            var config = new Configuration();
            config.DataBaseIntegration(db =>
            {
                db.ConnectionString = Constants.connectionString;
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();

                // db.LogSqlInConsole = true;
            });

            return config;
        }
        public static ISession OpenSession()
        {
            ISession session;
            session = SessionFactory.OpenSession();
            if (session == null)
                throw new InvalidOperationException("Cannot open session");

            return session;
        }

    }
}