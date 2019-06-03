namespace NHibernateBencher.EntityClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookCategory
    {
        public BookCategory()
        {
            this.Books = new HashSet<Books>();
        }
    
        public virtual int CategoryID { get; set; }
        public virtual string CategoryName { get; set; }
    
        public virtual ICollection<Books> Books { get; set; }
    }
}
