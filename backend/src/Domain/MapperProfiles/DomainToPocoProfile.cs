﻿using AutoMapper;
using Domain;
using Write.Pocos;

namespace System
{
    public class DomainToPocoProfile : Profile
    {
        public DomainToPocoProfile()
        {
            CreateMap<NoReasonBarbecue, Barbecue>()
                .ForMember(destination => destination.Date, src => src.MapFrom(o => DateTime.Now))
                .ForAllOtherMembers(o => o.MapAtRuntime());
        }
    }
}