namespace NHibernateBencher.EntityClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Books")]
    public partial class Books
    {
        public Books()
        {
            this.BookTransactions = new HashSet<BookTransaction>();
        }
    
        public virtual int BookID { get; set; }
        public virtual string BookName { get; set; }
        public virtual Nullable<int> CategoryID { get; set; }
        public virtual Nullable<int> AuthorID { get; set; }
        public virtual string Pages { get; set; }
        public virtual string YearOfPublish { get; set; }
        public virtual Nullable<decimal> Ratings { get; set; }
        public virtual string Quantity { get; set; }
    
        public virtual Authors Author { get; set; }
        public virtual BookCategory BookCategory { get; set; }
        public virtual ICollection<BookTransaction> BookTransactions { get; set; }
    }
}
