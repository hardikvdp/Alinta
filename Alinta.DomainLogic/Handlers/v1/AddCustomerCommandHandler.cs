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
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, bool>
    {
        private IDataRepository<Customer> _CustomerRepository;
        
        public AddCustomerCommandHandler(IDataRepository<Customer> CustomerRepository)
        {
            this._CustomerRepository = CustomerRepository;
        }
        public async Task<bool> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            Validate(request);

            var resource = _CustomerRepository.AddCustomer(new Data.Models.Customer()
            {
               CustomerId = request.CustomerId,
               FirstName = request.FirstName,
               LastName = request.LastName,
               DateofBirth = request.DateofBirth
            });

            //EmailHelper.SendEmail("", "hr@hardiktest.com", "Customer details added successfully", "Body Of the email");

            return true;

        }

        public void Validate(AddCustomerCommand request)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(request, null, null);
            Validator.TryValidateObject(request, context, results, true);
            if (results.Count > 0)
                throw new ArgumentException(string.Join(", ", results));
        }
    }
}
