using IndividualAssignment2A.Repositories;
using IndividualAssignment2A.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace IndividualAssignment2A.Models
{
    public class ProductVisitRepository
    {
        //Add ProductVisit, or update it if same item is added more than once
        public void AddProductVisit(SingleProduct singleProduct)
        {
            string sessionID = HttpContext.Current.Session.SessionID;
            CartAssignmentEntities context = new CartAssignmentEntities();
            var productVisit = context.ProductVisits.Where(x => x.sessionID == sessionID
                                                          && x.productID == singleProduct.ProductID).FirstOrDefault();
            int quantity = singleProduct.Quantity;
            string name = singleProduct.ProdName;
            int prodID = singleProduct.ProductID;

            //if no ProductVisit exists from current SessionID
            if (productVisit == null)
            {
                ProductVisit prodVisit = new ProductVisit();
                CartAssignmentEntities db = new CartAssignmentEntities();
                prodVisit.qtyOrdered = quantity;
                prodVisit.productID = prodID;
                prodVisit.sessionID = sessionID;
                prodVisit.updated = DateTime.Now;

                db.ProductVisits.Add(prodVisit);
                db.SaveChanges();
            }
            //if a ProductVisit exists for current session but for a different product
            else if (productVisit != null && productVisit.productID != prodID)
            {
                ProductVisit prodVisit = new ProductVisit();
                CartAssignmentEntities cart = new CartAssignmentEntities();

                prodVisit.qtyOrdered = quantity;
                prodVisit.productID = prodID;
                prodVisit.sessionID = HttpContext.Current.Session.SessionID;
                prodVisit.updated = DateTime.Now;

                cart.ProductVisits.Add(prodVisit);
                cart.SaveChanges();
            }
            //Update, if a ProductVisit exists for current session and same product
            else
            {
                productVisit.qtyOrdered += quantity;
                productVisit.updated = DateTime.Now;
                context.SaveChanges();
            }

        }

        //Update ProductVisit while in ViewCart (not adding quantity input but instead setting property to its value)
        public void UpdateCart(SingleProduct singleProduct)
        {
            string sessionID = HttpContext.Current.Session.SessionID;
            CartAssignmentEntities context = new CartAssignmentEntities();
            var productVisit = context.ProductVisits.Where(x => x.sessionID == sessionID
                                                          && x.productID == singleProduct.ProductID).FirstOrDefault();
            int quantity = singleProduct.Quantity;
            string name = singleProduct.ProdName;
            int prodID = singleProduct.ProductID;
            productVisit.qtyOrdered = quantity;
            productVisit.updated = DateTime.Now;
            context.SaveChanges();
        }

        //Remove ProductVisit entry based on session and product ID
        public void RemoveProductVisit(int? prodID)
        {
            CartAssignmentEntities db = new CartAssignmentEntities();
            ProductVisitRepository prodVis = new ProductVisitRepository();
            string sessionID = HttpContext.Current.Session.SessionID;
            var productVisit = db.ProductVisits.Where(x => x.productID == prodID && x.sessionID == sessionID).FirstOrDefault();
            db.ProductVisits.Remove(productVisit);
            db.SaveChanges();
        }

        //Delete all ProductVisit objects with a certain sessionID                      
        public void DeleteProductVisits(string sessionID)
        {
            CartAssignmentEntities db = new CartAssignmentEntities();
            var productVisits = db.ProductVisits.Where(x => x.sessionID == sessionID).ToList();
            VisitRepository visRep = new VisitRepository();
            foreach (ProductVisit productVisit in productVisits)
            {
                if (productVisit != null)
                {
                    db.ProductVisits.Remove(productVisit);
                    db.SaveChanges();
                }
            }
            visRep.DeleteVisit(sessionID);
        }

        //Validation of quantity when ViewCart is Saved
        public string Validate(List<SingleProduct> singleProd)
        {
            string message = "";
            if (singleProd != null){
            foreach (SingleProduct singleP in singleProd)
            {
            
            if (singleP.Quantity < 0)
            {
                message = "<p>Please enter a valid quantity</p>";           
            }
                
        }           
        }return message;
    }
    }
}

