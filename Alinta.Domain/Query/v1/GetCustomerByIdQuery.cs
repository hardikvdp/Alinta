using Alinta.Domain.ViewModel;
using Alinta.Domain.ViewModel.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alinta.Domain.Query.v1
{
    public class GetCustomerByIdQuery : IRequest<CustomerDetail>
    {
        public int? CustomerId { get; set; }
    }
}
