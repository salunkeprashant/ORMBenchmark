using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateBencher.EntityClasses;


namespace NHibernateBencher.Mapping {
    
    
    public class ContactdetailsMap : ClassMapping<ContactDetails> {
        
        public ContactdetailsMap() {
			Schema("dbo");
			Lazy(false);
			Id(x => x.ID, map => map.Generator(Generators.Identity));
			Property(x => x.MobileNo);
			Property(x => x.EmailAddress);

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
