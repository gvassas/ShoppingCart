using IndividualAssignment2A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividualAssignment2A.BusinessLogic
{
    public class SessionHelper
    {
        public void DeleteSession()
        {

            CartAssignmentEntities context = new CartAssignmentEntities();
            List<ProductVisit> productVisits = context.ProductVisits.ToList();

            DateTime now = DateTime.Now;

            foreach (ProductVisit productVisit in productVisits)
            {
                string session = productVisit.sessionID;
                DateTime? updated = productVisit.updated;
                if (now - updated >= TimeSpan.FromDays(1))
                {
                    ProductVisitRepository prodRep = new ProductVisitRepository();
                    prodRep.DeleteProductVisits(session);
                }
            }
        }
    }
}