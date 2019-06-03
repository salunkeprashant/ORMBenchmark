using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateBencher.EntityClasses;


namespace NHibernateBencher.Mapping {
    
    
    public class AuthorsMap : ClassMapping<Authors> {
        
        public AuthorsMap() {
			Schema("dbo");
			Lazy(false);
			Id(x => x.AuthorID, map => map.Generator(Generators.Identity));
			Property(x => x.AuthorName);
			Property(x => x.BookPublished);
			Bag(x => x.Books, colmap =>  { colmap.Key(x => x.Column("AuthorID")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
