using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndividualAssignment2A.ViewModels
{
    public class SingleProduct
    {
        
        [Range(01, 100, ErrorMessage = "Quantity is required")]
        public int Quantity {get; set;}
        public string ProdName { get; set; }
        public decimal Price { get; set; }
        public int ProductID { get; set; }


        public SingleProduct() { }

        public SingleProduct(decimal price, int productID, string prodName, int quantity)
        {
            Price = price;
            ProductID = productID;
            ProdName = prodName;
            Quantity = quantity;
        }


    }
}
