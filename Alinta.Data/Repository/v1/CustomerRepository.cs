using Alinta.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alinta.Data.Repository.v1
{
    public class CustomerRepository : IDataRepository<Customer>
    {
        private List<Customer> _CustomerList;
        public CustomerRepository()
        {
            _CustomerList = new List<Customer>() {
                new Customer(){ CustomerId =1, FirstName="Hardik", LastName="Patel", DateofBirth=DateTime.Parse("10/04/1984") },
                new Customer(){ CustomerId =2, FirstName="Masum", LastName="Patel", DateofBirth=DateTime.Parse("15/05/1984") },
                new Customer(){ CustomerId =3, FirstName="Sonia", LastName="Sharma", DateofBirth=DateTime.Parse("20/08/1984") }
            };
        }

        public List<Customer> CustomerList { get { return _CustomerList; } }

        public IEnumerable<Customer> GetAll()
        {
            if(_CustomerList == null) throw new Exception("Couldn't retrieve customers");
            return _CustomerList;
        }

        public Customer GetById(int Id)
        {
            return _CustomerList.FirstOrDefault(x => x.CustomerId == Id);
        }

        public Customer GetByName(string name)
        {
            return _CustomerList.FirstOrDefault(x => String.Equals(x.FirstName, name, StringComparison.OrdinalIgnoreCase) || String.Equals(x.LastName, name, StringComparison.OrdinalIgnoreCase));
        }

        public Customer AddCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException();

            if (String.IsNullOrEmpty(customer.FirstName)) throw new Exception("first name is required.");

            customer.CustomerId = _CustomerList.Max(e => e.CustomerId) + 1;
            _CustomerList.Add(customer);            
            return customer;
        }

        public Customer UpdateCustomer(Customer CustomerChange)
        {
            if (CustomerChange == null) throw new ArgumentNullException();

            if (String.IsNullOrEmpty(CustomerChange.FirstName)) throw new Exception("first name is required.");

            var Customer = _CustomerList.FirstOrDefault(x => x.CustomerId == CustomerChange.CustomerId);
            
            Customer.FirstName = CustomerChange.FirstName;
            Customer.LastName = CustomerChange.LastName;
            Customer.DateofBirth = CustomerChange.DateofBirth;

            return Customer;
        }

        public Customer DeleteCustomer(int Id)
        {
            var Customer = _CustomerList.FirstOrDefault(e => e.CustomerId == Id);
            if (Customer != null)
            {
                _CustomerList.Remove(Customer);              
            }
            return Customer;
        }


    }
}
