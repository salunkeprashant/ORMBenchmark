using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateBencher.EntityClasses;


namespace NHibernateBencher.Mapping {
    
    
    public class InventoryMap : ClassMapping<Inventory> {
        
        public InventoryMap() {
			Schema("dbo");
			Lazy(false);
			Id(x => x.ItemID, map => map.Generator(Generators.Identity));
			Property(x => x.ItemName);
			Property(x => x.ItemDescription);
			Property(x => x.Quantity);

            Property(x => x.CategoryID, map => { map.Insert(false); map.Update(false); map.Column("CategoryID"); });
            ManyToOne(x => x.ItemCategory, map =>
            {
                map.Column("CategoryID");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

            Bag(x => x.ItemTransactions, colmap => { colmap.Key(x => x.Column("ItemID")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
