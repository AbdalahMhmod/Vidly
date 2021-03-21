using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList(); 

            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            try
            {
                var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
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
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var ViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", ViewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);

        }

    }
}