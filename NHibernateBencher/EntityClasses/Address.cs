namespace NHibernateBencher.EntityClasses
{
    using System;
    
    public partial class Address
    {
        public virtual int AddressID { get; set; }
        public virtual Nullable<int> UserID { get; set; }
        public virtual string AddressLine { get; set; }
        public virtual string CityName { get; set; }
        public virtual string StateName { get; set; }
    
        public virtual Users User { get; set; }
    }
}
