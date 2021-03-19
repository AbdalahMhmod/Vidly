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
        private readonly List<Customer> _customers;

        public CustomersController(List<Customer> customers)
        {
            _customers = customers;

        }
       
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 1,Name = "aya"},
                new Customer {Id = 2,Name = "rania"},
                new Customer {Id = 3,Name = "mohamed"},
                new Customer {Id = 4,Name = "youssef"}
            };

            var viewmodel = new RandomMoviewViewModel
            {
                Customers = customers
            };
            return View(viewmodel);
        }

        public ActionResult Details(int? id)
        {
            return Content("hi"+id);
        }
    }
}