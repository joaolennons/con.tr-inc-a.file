using AutoMapper;
using Domain;
using Write.Pocos;

namespace System
{
    public class DomainToPocoProfile : Profile
    {
        public DomainToPocoProfile()
        {
            CreateMap<CreateNoReasonBarbecue, Barbecue>()
                .ForMember(destination => destination.UpdateDate, src => src.MapFrom(o => DateTime.Now))
                .ForAllOtherMembers(o => o.MapAtRuntime());
        }
    }
}
