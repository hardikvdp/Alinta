using Alinta.Data.Models;
using Alinta.Data.Repository.v1;
using Alinta.Domain.Query;
using Alinta.Domain.Query.v1;
using Alinta.Domain.ViewModel;
using Alinta.Domain.ViewModel.v1;
using Alinta.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alinta.DomainLogic.Handlers.v1
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDetail>
    {
        private IDataRepository<Customer> CustomerRepository;

        public GetCustomerByIdHandler(IDataRepository<Customer> CustomerRepository)
        {
            this.CustomerRepository = CustomerRepository;
        }

        public async Task<CustomerDetail> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            if (!request.CustomerId.HasValue)
            {
                throw new ArgumentException("Customer id is required field");
            }

            var resource = CustomerRepository.GetById(request.CustomerId.Value);

            if (resource == null)
            {
                throw new KeyNotFoundException("Record not found.");
            }

            // We can use AutoMapper here to map the entities.
            return new CustomerDetail()
            {
                CustomerId = resource.CustomerId,
                FirstName = resource.FirstName,
                LastName = resource.LastName,
                DateofBirth = resource.DateofBirth                
            };
        }
    }
}
