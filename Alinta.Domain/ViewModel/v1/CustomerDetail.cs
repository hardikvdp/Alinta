using Alinta.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alinta.Domain.ViewModel.v1
{
    public class CustomerDetail
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}
