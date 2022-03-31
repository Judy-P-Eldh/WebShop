using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Core.Enteties
{
    public class Offer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate => StartDate.AddDays(7);
        public string Description { get; set; }
        public int Discount { get; set; } 
    }
}
