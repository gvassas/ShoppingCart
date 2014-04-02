using IndividualAssignment2A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividualAssignment2A.Repositories
{
    public class VisitRepository
    {
        public void DeleteVisit(string sessionID)
        {
            CartAssignmentEntities context = new CartAssignmentEntities();
            var visit = context.Visits.Where(s => s.sessionID == sessionID).FirstOrDefault();
            if (visit != null)
            {
                context.Visits.Remove(visit);
                context.SaveChanges();
            }
        }

        public void GetVisit(string sessionID)
        {
            CartAssignmentEntities context = new CartAssignmentEntities();
            var aVisit = context.Visits.Where(x => x.sessionID == sessionID).FirstOrDefault();

            if (aVisit.sessionID == null)
            {
                Visit newVisit = new Visit();
                newVisit.sessionID = sessionID;
                context.Visits.Add(newVisit);
                context.SaveChanges();
            }

        }
    }
}
