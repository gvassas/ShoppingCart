using IndividualAssignment2A.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividualAssignment2A.Models
{
    public class CartRepository
    {
         public CartRepository()
         {
         }

         public Cart GetCart()
         {
             Cart cart = new Cart();
             // Session.
             string sessionID = HttpContext.Current.Session.SessionID;
             cart.SessionID   = sessionID;
             cart.Products = new List<SingleProduct>();
             List<SingleProduct> products = new List<SingleProduct>();
             // Get product visits.
             CartAssignmentEntities context = new CartAssignmentEntities();
             var productVisits = context.ProductVisits.Where(x => x.sessionID == sessionID);
             // Add single products in the same visit to the cart.
             foreach(ProductVisit productVisit in productVisits) {
                 Product product = context.Products.Where(x => x.productID == productVisit.productID).FirstOrDefault();
                 if (product != null)
                 {
                     SingleProduct singleProduct = new SingleProduct();
                     singleProduct.Quantity = (int)productVisit.qtyOrdered;
                     singleProduct.ProductID = productVisit.productID;
                     singleProduct.Price = (decimal)product.price;
                     singleProduct.ProdName = product.productName;
                     cart.Products.Add(singleProduct);
                 }
             }
             return cart;
         }  
        }
    }
