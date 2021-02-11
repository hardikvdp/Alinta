using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alinta.Domain.Command.v1
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
