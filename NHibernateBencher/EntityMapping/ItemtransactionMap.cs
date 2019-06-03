using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateBencher.EntityClasses;


namespace NHibernateBencher.Mapping {
    
    
    public class ItemtransactionMap : ClassMapping<ItemTransaction> {
        
        public ItemtransactionMap() {
			Schema("dbo");
			Lazy(false);
			Id(x => x.TransactionID, map => map.Generator(Generators.Identity));
			Property(x => x.IssueDate);
			Property(x => x.ReturnDate);

            ManyToOne(x => x.Admin, map =>
            {
                map.Column("AdminID");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

            ManyToOne(x => x.User, map =>
            {
                map.Column("UserID");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

            ManyToOne(x => x.Inventory, map =>
            {
                map.Column("ItemID");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });


        }
    }
}
