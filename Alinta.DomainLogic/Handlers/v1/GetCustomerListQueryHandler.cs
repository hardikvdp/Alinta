using Alinta.Data.Models;
using Alinta.Data.Repository.v1;
using Alinta.Domain.Query.v1;
using Alinta.Domain.ViewModel.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alinta.DomainLogic.Handlers.v1
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, IEnumerable<CustomerDetail>>
    {
        public IDataRepository<Customer> CustomerRepository { get; }

        public GetCustomerListQueryHandler(IDataRepository<Customer> CustomerRepository)
        {
            this.CustomerRepository = CustomerRepository;
        }


        public async Task<IEnumerable<CustomerDetail>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var resource = CustomerRepository.GetAll();

            if (resource == null)
            {
                throw new KeyNotFoundException("Record not found.");
            }

            return resource.Select(x => new CustomerDetail()
            {
                CustomerId = x.CustomerId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateofBirth = x.DateofBirth
            });
        }
    }
}
