﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCodeCamp.Data.Entities;

namespace MyCodeCamp.Models
{
    public class CampMappingProfile : Profile
    {
        public CampMappingProfile()
        {
            CreateMap<Camp, CampModel>()
                .ForMember(c => c.StartDate, opt => opt.MapFrom(camp => camp.EventDate))
                .ForMember(c => c.EndDate, opt => opt.ResolveUsing(camp => camp.EventDate.AddDays(camp.Length - 1)))
                .ForMember(c => c.Url, opt => opt.ResolveUsing<CampUrlResolver>())
                .ReverseMap()
                .ForMember(c => c.Length, opt => opt.ResolveUsing(model => (model.EndDate - model.StartDate).Days + 1))
                // This wasn't needed with the version I'm using.
                // I wrote just as reference.
                //.ForMember(m => m.Location, opt => opt.ResolveUsing(c => new Location()
                //    {
                //        Address1 = c.LocationAddress1,
                //        Address2 = c.LocationAddress2,
                //        Address3 = c.LocationAddress3,
                //        CityTown = c.LocationCityTown,
                //        StateProvince = c.LocationStateProvince,
                //        PostalCode = c.LocationPostalCode,
                //        Country = c.LocationCountry
                //    }))
                    ;

            CreateMap<Speaker, SpeakerModel>()
                .ForMember(c => c.Url, opt => opt.ResolveUsing<SpeakerUrlResolver>())
                .ReverseMap();

            CreateMap<Talk, TalkModel>()
                .ForMember(c => c.Url, opt => opt.ResolveUsing<TalkUrlResolver>())
                .ReverseMap();
        }
    }
}
