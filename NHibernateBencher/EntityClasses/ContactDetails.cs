
namespace NHibernateBencher.EntityClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContactDetails
    {
        public virtual int ID { get; set; }
        public virtual Nullable<int> UserID { get; set; }
        public virtual Nullable<long> MobileNo { get; set; }
        public virtual string EmailAddress { get; set; }
    
        public virtual Users User { get; set; }
    }
}
