using NHibernate;
using NHibernate.Criterion;
using NHibernateBencher;
using NHibernateBencher.EntityClasses;
using System;
using System.Linq;

namespace RawBencher
{
    public class NHibernateORM
    {
        ISession session = NHibernateConfigurator.OpenSession();
        public void GetAllRecords()
        {
            using (var tx = session.BeginTransaction())
            {
                Users user = null;
                UserDetails userdetail = null;
                ContactDetails contactdetail = null;
                Address address = null;
                BookTransaction booktxn = null;


                var results = session.QueryOver(() => user)
               .JoinAlias(x => x.UserDetails, () => userdetail)
               .JoinAlias(x => x.ContactDetails, () => contactdetail)
               .JoinAlias(x => x.Addresses, () => address)
               .JoinAlias(x => x.BookTransactions, () => booktxn)
               .SelectList(list => list
               .Select(() => user.UserID)
               .Select(() => userdetail.FirstName)
               .Select(() => userdetail.LastName)
               .Select(() => contactdetail.MobileNo)
               .Select(() => contactdetail.EmailAddress)
               .Select(() => address.AddressLine)
               .Select(() => address.CityName)
               .Select(() => address.StateName)
               .Select(() => booktxn.IssueDate)
               .Select(() => booktxn.ReturnDate))
               .List<object[]>();

                tx.Commit();
            }
        }
    }
}
