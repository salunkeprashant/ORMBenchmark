using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateBencher.EntityClasses;


namespace NHibernateBencher.Mapping {
    
    
    public class UsersMap : ClassMapping<Users> {
        
        public UsersMap() {
			Schema("dbo");
			Lazy(false);
			Id(x => x.UserID, map => map.Generator(Generators.Identity));
			Property(x => x.JoiningDate);
			Bag(x => x.Addresses, colmap =>  { colmap.Key(x => x.Column("UserID")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.BookTransactions, colmap =>  { colmap.Key(x => x.Column("UserID")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.ContactDetails, colmap =>  { colmap.Key(x => x.Column("UserID")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.ItemTransactions, colmap =>  { colmap.Key(x => x.Column("UserID")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.UserDetails, colmap =>  { colmap.Key(x => x.Column("UserID")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
