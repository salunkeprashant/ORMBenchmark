using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateBencher.EntityClasses;


namespace NHibernateBencher.Mapping {
    
    
    public class AddressMap : ClassMapping<Address> {
        
        public AddressMap() {
			Schema("dbo");
			Lazy(false);
			Id(x => x.AddressID, map => map.Generator(Generators.Identity));
			Property(x => x.AddressLine);
			Property(x => x.CityName);
			Property(x => x.StateName);

            Property(x => x.UserID, map => { map.Insert(false); map.Update(false); map.Column("UserID"); });
            ManyToOne(x => x.User, map =>
            {
                map.Column("UserID");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });
        }
    }
}
