namespace NHibernateBencher.EntityClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            this.Inventories = new HashSet<Inventory>();
        }
    
        public virtual int CategoryID { get; set; }
        public virtual string CategoryName { get; set; }
    
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
