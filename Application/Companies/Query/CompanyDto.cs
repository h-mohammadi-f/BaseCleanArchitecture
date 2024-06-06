using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Companies.Query
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTow { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}