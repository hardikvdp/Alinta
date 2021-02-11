using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AlintaAPI.Controllers;
using Xunit;
using AlintaAPI.Controllers.v1;
using Alinta.Domain.Command.v1;
using Alinta.Domain.Query.v1;
using Alinta.Domain.ViewModel.v1;

namespace AlintaAPI.Test.Controllers
{
    public class CustomerControllerTests
    {
        private readonly CustomerController _testee;
        private readonly IMediator _mediator;

        public CustomerControllerTests()
        {
            _mediator = A.Fake<IMediator>();
            _testee = new CustomerController(_mediator);

            var CustomerLists = new List<CustomerDetail>
            {
                new CustomerDetail
                {
                      CustomerId= 1,
                      FirstName = "Hardik",
                      LastName = "Patel"
                }
            };

            A.CallTo(() => _mediator.Send(A<AddCustomerCommand>._, A<CancellationToken>._)).Returns(true);
            A.CallTo(() => _mediator.Send(A<UpdateCustomerCommand>._, A<CancellationToken>._)).Returns(true);
            A.CallTo(() => _mediator.Send(A<DeleteCustomerCommand>._, A<CancellationToken>._)).Returns(true);
            A.CallTo(() => _mediator.Send(A<GetCustomerByIdQuery>._, A<CancellationToken>._)).Returns(CustomerLists.FirstOrDefault());
            A.CallTo(() => _mediator.Send(A<GetCustomerListQuery>._, A<CancellationToken>._)).Returns(CustomerLists);
        }
    }
}
