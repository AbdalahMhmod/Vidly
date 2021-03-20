﻿using System;
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

            var ViewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult Create(NewCustomerViewModel viewModel)
        {
            return View();
        }
    }
}