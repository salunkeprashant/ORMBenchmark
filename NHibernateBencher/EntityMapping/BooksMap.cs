using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateBencher.EntityClasses;


namespace NHibernateBencher.Mapping {
    
    
    public class BookMap : ClassMapping<Books> {
        
        public BookMap() {
			Schema("dbo");
			Lazy(false);
			Id(x => x.BookID, map => map.Generator(Generators.Identity));
			Property(x => x.BookName);
			Property(x => x.Pages);
			Property(x => x.YearOfPublish);
			Property(x => x.Ratings);
			Property(x => x.Quantity);

            Property(x => x.CategoryID, map => { map.Insert(false); map.Update(false); map.Column("CategoryID"); });
            ManyToOne(x => x.BookCategory, map => 
			{
                map.Column("CategoryID");
				map.NotNullable(true);
				map.Cascade(Cascade.None);
			});

            Property(x => x.AuthorID, map => { map.Insert(false); map.Update(false); map.Column("AuthorID"); });
            ManyToOne(x => x.Author, map => 
			{
			    map.Column("AuthorID");
				map.NotNullable(true);
				map.Cascade(Cascade.None);
			});

			Bag(x => x.BookTransactions, colmap =>  { colmap.Key(x => x.Column("BookID")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
