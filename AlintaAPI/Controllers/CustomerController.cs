using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using Alinta.Domain.Command.v1;
using Alinta.Domain.Query.v1;
using Alinta.Domain.ViewModel.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlintaAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// This will get list of all Customers.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ApiResponse> GetAllCustomers()
        {
            try
            {
                var response = await _mediator.Send(new GetCustomerListQuery() { });
                return new ApiResponse(response, 201);
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, ex);
            }
        }

        /// <summary>
        /// This will Customer details via passing Customer Id.
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{CustomerId}")]
        public async Task<ApiResponse> GetCustomerById(int CustomerId)
        {
            try
            {
                var response = await _mediator.Send(new GetCustomerByIdQuery() { CustomerId = CustomerId });
                return new ApiResponse(response, 201);
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, ex);
            }
        }

        /// <summary>
        /// This will add Customer record. 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public async Task<ApiResponse> SaveCustomer(AddCustomerCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return new ApiResponse(response, 201);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message, 400);
            }

        }

        /// <summary>
        /// This will add Customer record. 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        public async Task<ApiResponse> UpdateCustomer(UpdateCustomerCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return new ApiResponse(response, 201);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message, 400);
            }

        }


        [HttpDelete]
        [Route("Delete/{CustomerId}")]
        public async Task<ApiResponse> DeleteCustomer(int CustomerId)
        {
            try
            {
                var response = await _mediator.Send(new DeleteCustomerCommand() { Id = CustomerId });
                return new ApiResponse(response, 201);
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, ex);
            }

        }

    }
}
