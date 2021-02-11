using Alinta.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Alinta.Data.Repository.v1;

namespace Alinta.Data.Test.Repository
{
    public class CustomerRepositoryTests 
    {
        private readonly CustomerRepository _testCustomerRepository;
        private readonly Customer _newCustomer;
        private readonly List<Customer> _customerList;

        public CustomerRepositoryTests()
        {
            _testCustomerRepository = new CustomerRepository();
            _customerList = _testCustomerRepository.CustomerList;
            _newCustomer = new Customer
            {
                CustomerId = 1,
                FirstName = "Masum",
                LastName = "Patel",
                DateofBirth = DateTime.Parse("04/01/1985")
            };
        }

        [Fact]
        public void AddAsync_WhenEntityIsNull_ThrowsException()
        {
            _testCustomerRepository.Invoking(x => x.AddCustomer(null)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddAsync_WhenExceptionOccurs_ThrowsException()
        {
            _testCustomerRepository.Invoking(x => x.AddCustomer(new Customer())).Should().Throw<Exception>().WithMessage("first name is required.");
        }

        [Fact]
        public void AddCustomerAsync_WhenCustomerIsNotNull_ShouldReturnBool()
        {
            var result = _testCustomerRepository.AddCustomer(_newCustomer);

            result.Should().BeOfType<Customer>();
        }

        [Fact]
        public void AddCustomerAsync_WhenCustomerIsNotNull_ShouldShouldAddCustomer()
        {
            var CustomerCount = _customerList.Count();

            _testCustomerRepository.AddCustomer(_newCustomer);

            _customerList.Count().Should().Be(CustomerCount + 1);
        }

        //[Fact]
        //public void GetAll_WhenExceptionOccurs_ThrowsException()
        //{
        //    _testeeFake.Invoking(x => x.GetAll()).Should().Throw<Exception>().WithMessage("Couldn't retrieve customers");
        //}

        [Fact]
        public void UpdateAsync_WhenEntityIsNull_ThrowsException()
        {
            _testCustomerRepository.Invoking(x => x.UpdateCustomer(null)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void UpdateAsync_WhenExceptionOccurs_ThrowsException()
        {
            _testCustomerRepository.Invoking(x => x.UpdateCustomer(new Customer())).Should().Throw<Exception>().WithMessage("first name is required.");
        }


    }
}
