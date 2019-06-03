namespace NHibernateBencher.EntityClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public Users()
        {
            this.Addresses = new HashSet<Address>();
            this.BookTransactions = new HashSet<BookTransaction>();
            this.ContactDetails = new HashSet<ContactDetails>();
            this.ItemTransactions = new HashSet<ItemTransaction>();
            this.UserDetails = new HashSet<UserDetails>();
        }
    
        public virtual int UserID { get; set; }
        public virtual Nullable<System.DateTime> JoiningDate { get; set; }
    
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<BookTransaction> BookTransactions { get; set; }
        public virtual ICollection<ContactDetails> ContactDetails { get; set; }
        public virtual ICollection<ItemTransaction> ItemTransactions { get; set; }
        public virtual ICollection<UserDetails> UserDetails { get; set; }
    }
}
