using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Company : EntitytBase
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTow { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}