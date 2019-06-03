using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateBencher.EntityClasses;


namespace NHibernateBencher.Mapping {
    
    
    public class ItemcategoryMap : ClassMapping<ItemCategory> {
        
        public ItemcategoryMap() {
			Schema("dbo");
			Lazy(false);
			Id(x => x.CategoryID, map => map.Generator(Generators.Identity));
			Property(x => x.CategoryName);
			Bag(x => x.Inventories, colmap =>  { colmap.Key(x => x.Column("CategoryID")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
