using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using TestEntityFramework.Models;

namespace TestEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListCustomers()
        {
            // 1. Creating an object for the ORM
            NorthwindEntities ORM = new NorthwindEntities();

            // 2. Load the datat from the DBset into a data structure
            List<Customer> CustomerList = ORM.Customers.ToList();

            // 3. Filter the data (Optional)
            ViewBag.CustomerList = CustomerList;

            return View("CustomersView");
        }

        public ActionResult ListCustomersByCountry(string Country)
        {
            NorthwindEntities ORM = new NorthwindEntities();

            List<Customer> OutputList = new List<Customer>();

            foreach (Customer CustomerRecord in ORM.Customers.ToList())
            {
                if (CustomerRecord.Country.ToLower() == Country.ToLower())
                {
                    OutputList.Add(CustomerRecord);
                }
            }

            ViewBag.CustomerList = OutputList;

            return View("CustomersView");
        }

        public ActionResult ListCustomersBySearch(string SearchID)
        {
            NorthwindEntities ORM = new NorthwindEntities();

            List<Customer> OutputList = new List<Customer>();

            foreach (Customer CustomerRecord in ORM.Customers.ToList())
            {
                if (CustomerRecord.CustomerID.ToLower().Contains(SearchID.ToLower()))
                {
                    OutputList.Add(CustomerRecord);
                }
            }

            ViewBag.CustomerList = OutputList;

            return View("CustomersView");
        }
    }
}