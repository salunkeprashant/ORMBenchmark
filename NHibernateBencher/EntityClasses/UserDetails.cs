namespace NHibernateBencher.EntityClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserDetails
    {
        public virtual int ID { get; set; }
        public virtual Nullable<int> UserID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Users User { get; set; }
    }
}
