﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Core.Enteties
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Address Address { get; set; }
        public ICollection<Offer> Offers { get; set; } = new List<Offer>();
         //AddressId?  Inte egen tabell i db
    }
}
