using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Core.DTOs
{
    public class OfferDto
    {
        public string Title { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate => StartDate.AddDays(7);
        public string Description { get; set; }

        [Display(Name = "Discount (%)")]
        public int Discount { get; set; }
    }
}
