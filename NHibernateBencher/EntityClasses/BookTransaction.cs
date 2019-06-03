
namespace NHibernateBencher.EntityClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookTransaction
    {
        public virtual int TransactionID { get; set; }
        public virtual Nullable<int> AdminID { get; set; }
        public virtual Nullable<int> UserID { get; set; }
        public virtual Nullable<int> BookID { get; set; }
        public virtual Nullable<System.DateTime> IssueDate { get; set; }
        public virtual Nullable<System.DateTime> ReturnDate { get; set; }
    
        public virtual Admins Admin { get; set; }
        public virtual Books Book { get; set; }
        public virtual Users User { get; set; }
    }
}
