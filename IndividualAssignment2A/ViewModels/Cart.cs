using IndividualAssignment2A;
using IndividualAssignment2A.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividualAssignment2A.ViewModels
{
    public class Cart
    {
        public string SessionID { get; set; }
        public List<SingleProduct> Products { get; set; }

        public Cart() { }

        public Cart(string sessionID, List<SingleProduct> products)
        {
            SessionID = sessionID;
            Products = products;
        }
    }
}