using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetAllCustomer();

            var viewmodel = new RandomMoviewViewModel
            {
                Customers = customers
            };
            return View(viewmodel);
        }

        public ActionResult Details(int? id)
        {
            try
            {
                var customer = GetAllCustomer().SingleOrDefault(c => c.Id == id);
                if (customer==null)
                {
                    return HttpNotFound();
                }
                return View(customer);
            }
            catch (NullReferenceException NE)
            {
                return Content(NE.ToString());
            }
        }

        public List<Customer> GetAllCustomer()
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 1,Name = "aya"},
                new Customer {Id = 2,Name = "rania"},
                new Customer {Id = 3,Name = "mohamed"},
                new Customer {Id = 4,Name = "youssef"}
            };
            return customers.ToList();
        }
    }
}