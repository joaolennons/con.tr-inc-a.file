using AutoMapper;
using Domain;
using Write.Pocos;

namespace System
{
    public class DomainToPocoProfile : Profile
    {
        public DomainToPocoProfile()
        {
            CreateMap<NoReasonBarbecue, Barbecue>();
        }
    }
}
