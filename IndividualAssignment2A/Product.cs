//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndividualAssignment2A
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.ProductVisits = new HashSet<ProductVisit>();
        }
    
        public int productID { get; set; }
        public string productName { get; set; }
        public Nullable<decimal> price { get; set; }
    
        public virtual ICollection<ProductVisit> ProductVisits { get; set; }
    }
}
