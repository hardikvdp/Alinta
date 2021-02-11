using Alinta.Data.Models;
using Alinta.Data.Repository.v1;
using Alinta.Domain.Command.v1;
using Alinta.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alinta.DomainLogic.Handlers.v1
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private IDataRepository<Customer> CustomerRepository;
    
        public UpdateCustomerCommandHandler(IDataRepository<Customer> CustomerRepository)
        {
            this.CustomerRepository = CustomerRepository;
        }
        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Validate(request);

            var resource = CustomerRepository.UpdateCustomer(new Customer()
            {
                CustomerId = request.CustomerId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateofBirth = request.DateofBirth
            });
           
            //EmailHelper.SendEmail("", "hr@hardiktest.com", "Customer detail updated.", "Body Of the email");

            return true;

        }

        public void Validate(UpdateCustomerCommand request)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(request, null, null);
            Validator.TryValidateObject(request, context, results, true);
            if (results.Count > 0)
                throw new ArgumentException(string.Join(", ", results));
        }
    }
}
