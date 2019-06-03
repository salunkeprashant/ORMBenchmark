using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateBencher.EntityClasses;


namespace NHibernateBencher.Mapping {
    
    
    public class AdminssMap : ClassMapping<Admins> {
        
        public AdminssMap() {
			Schema("dbo");
			Lazy(false);
			Id(x => x.AdminID, map => map.Generator(Generators.Identity));
			Property(x => x.AdminName);
			Property(x => x.Username);
			Property(x => x.Password);
			Bag(x => x.BookTransactions, colmap =>  { colmap.Key(x => x.Column("AdminID")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.ItemTransactions, colmap =>  { colmap.Key(x => x.Column("AdminID")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
