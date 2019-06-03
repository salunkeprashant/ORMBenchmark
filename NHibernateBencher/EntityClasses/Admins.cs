namespace NHibernateBencher.EntityClasses
{
    using System;
    using System.Collections.Generic;

    public partial class Admins
    {
        public Admins()
        {
            this.BookTransactions = new HashSet<BookTransaction>();
            this.ItemTransactions = new HashSet<ItemTransaction>();
        }
    
        public virtual int AdminID { get; set; }
        public virtual string AdminName { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    
        public virtual ICollection<BookTransaction> BookTransactions { get; set; }
        public virtual ICollection<ItemTransaction> ItemTransactions { get; set; }
    }
}
