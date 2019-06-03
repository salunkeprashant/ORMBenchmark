namespace NHibernateBencher.EntityClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventory
    {
        public Inventory()
        {
            this.ItemTransactions = new HashSet<ItemTransaction>();
        }
    
        public int ItemID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string Quantity { get; set; }
    
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ICollection<ItemTransaction> ItemTransactions { get; set; }
    }
}
