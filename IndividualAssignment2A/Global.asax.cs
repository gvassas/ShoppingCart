using IndividualAssignment2A.BusinessLogic;
using IndividualAssignment2A.Models;
using IndividualAssignment2A.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IndividualAssignment2A
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private const string COLLECTION_ITEM_A = "TimeStamp";    

        void Session_Start(object sender, EventArgs e)
        {

            HttpContext.Current.Session["Guillaume"] = 1234;
            SessionHelper sessionHelper = new SessionHelper();
            //Delete if session has been updated more than 24 hours ago
            sessionHelper.DeleteSession();               

            string sessionID = HttpContext.Current.Session.SessionID;
            ProductVisitRepository prodVis = new ProductVisitRepository();
            prodVis.DeleteProductVisits(sessionID);

            CartAssignmentEntities db = new CartAssignmentEntities();
            
            Visit newVisit = new Visit();
            newVisit.sessionID = sessionID;
            db.Visits.Add(newVisit);
            db.SaveChanges();
        }
    }
}