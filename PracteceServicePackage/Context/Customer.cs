using System;
using System.Collections.Generic;
using System.Text;

namespace PracteceServicePackage.Context
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumebr { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime? BirthDate { get; set; }

    }
}
