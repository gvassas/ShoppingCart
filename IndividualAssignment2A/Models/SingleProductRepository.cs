using IndividualAssignment2A.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividualAssignment2A.Models
{
    public class SingleProductRepository
    {
        public SingleProduct ReturnProduct(int productID)
        {
            int quantity = 1;

            CartAssignmentEntities db = new CartAssignmentEntities();

            Product product = db.Products.Where(x => x.productID == productID).FirstOrDefault();
            decimal a = Convert.ToDecimal(product.price);
            SingleProduct myCart = new SingleProduct(a, product.productID, product.productName, quantity);
            return myCart;
        }

        public List<SingleProduct> GetAllProducts()
        {
            List<SingleProduct> products = new List<SingleProduct>();
            return products;
        }

    }
}