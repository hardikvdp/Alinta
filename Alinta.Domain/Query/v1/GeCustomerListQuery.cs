using Alinta.Domain.ViewModel;
using Alinta.Domain.ViewModel.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alinta.Domain.Query.v1
{
   public class GetCustomerListQuery : IRequest<IEnumerable<CustomerDetail>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
