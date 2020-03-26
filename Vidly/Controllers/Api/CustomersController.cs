using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET /api/customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomer()
        {
            var customer = _context.Customers.ToList();
            return customer;
        }

        //GET /api/customers/1
        [HttpGet]
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        //POST /api/customers/customersData
        [HttpPost]
        public Customer CreateCustomer(int id, Customer customer)
        {
            var customerInDb = _context.Customers.SingleOrDefault( c=> c.Id == id);

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customerInDb);
            _context.SaveChanges();
            return customerInDb;
        }


        //PUT /api/customers/1
        [HttpPut]
        public Customer UpdateCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = _context.Customers.SingleOrDefault( c=> c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.SaveChanges();
            return customer;
        }


        //DELETE /api/customers/1
        [HttpDelete]
        public Customer DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault( c=>c.Id == id);
            
            
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return customer;
        }

    }
}
