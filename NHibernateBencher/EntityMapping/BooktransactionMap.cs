using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernateBencher.EntityClasses;


namespace NHibernateBencher.Mapping {
    
    
    public class BooktransactionMap : ClassMapping<BookTransaction> {
        public BooktransactionMap() {
			Schema("dbo");
			Lazy(false);

			this.Id(x => x.TransactionID, map => map.Generator(Generators.Identity));
			this.Property(x => x.IssueDate);
			this.Property(x => x.ReturnDate);

            this.Property(x => x.AdminID, map => { map.Insert(false); map.Update(false); map.Column("AdminID"); });
            this.ManyToOne(x => x.Admin, map =>
            {
                map.Column("AdminID");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

            this.Property(x => x.UserID, map => { map.Insert(false); map.Update(false); map.Column("UserID"); });
            this.ManyToOne(x => x.User, map =>
            {
                map.Column("UserID");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });

            this.Property(x => x.BookID, map => { map.Insert(false); map.Update(false); map.Column("BookID"); });
            this.ManyToOne(x => x.Book, map =>
            {
                map.Column("BookID");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });
        }
    }
}
