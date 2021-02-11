using Alinta.Data.Models;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Alinta.Domain.Command.v1
{
    public class AddCustomerCommand : IRequest<bool>
    {
        [Required]
        public int CustomerId { get; set; }
        [Required] 
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set; }
        [Required] 
        public DateTime DateofBirth { get; set; }

    }
}
