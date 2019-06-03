namespace NHibernateBencher.EntityClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class Authors
    {
        public Authors()
        {
            this.Books = new HashSet<Books>();
        }
    
        public virtual int AuthorID { get; set; }
        public virtual string AuthorName { get; set; }
        public virtual string BookPublished { get; set; }
    
        public virtual ICollection<Books> Books { get; set; }
    }
}
