using Alinta.Data.Models;
using Alinta.Data.Repository.v1;
using Alinta.Domain.Command.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alinta.DomainLogic.Handlers.v1
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private IDataRepository<Customer> CustomerRepository;

        public DeleteCustomerCommandHandler(IDataRepository<Customer> CustomerRepository)
        {
            this.CustomerRepository = CustomerRepository;
        }
        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException("Invalid Customer id");
            }

            var resource = CustomerRepository.DeleteCustomer(Convert.ToInt32(request.Id));

            if (resource == null)
            {
                throw new KeyNotFoundException("Record not found.");
            }

            return true;
        }
    }
}
