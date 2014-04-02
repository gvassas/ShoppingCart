using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividualAssignment2A.Models
{
    public class ProductRepository
    {
        public List<Product> DisplayProducts()
        {
            CartAssignmentEntities context = new CartAssignmentEntities();
            return context.Products.ToList();                   
        }       
    }
}