using AutoMapper;
using Read.Dtos;

namespace Read
{
    public class ProjectionProfile : Profile
    {
        public ProjectionProfile()
        {
            CreateMap<BarbecueDetail, BarbecueInfo>();
        }
    }
}
