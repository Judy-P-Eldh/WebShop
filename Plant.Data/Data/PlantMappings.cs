using AutoMapper;
using Plant.Core.Enteties;
using Plant.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant.Data.Data
{
    public class PlantMappings  : Profile
    {
        public PlantMappings()
        {
            CreateMap<Offer, OfferDto>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
        }
    }
}
