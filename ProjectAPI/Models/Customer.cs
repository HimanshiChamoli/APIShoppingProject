﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string EmailId { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public long PhoneNo { get; set; }

        public string Password { get; set; }

        public string Country { get; set; }

        public string state { get; set; }

        public int Zip { get; set; }

        public bool Shipping_Address { get; set; }
        public List<Order> Orders { get; set; }
        public List<Feedback> Feedbacks{ get; set; }
   
 
    }
}
