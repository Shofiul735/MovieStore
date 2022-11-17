using AutoMapper;
using VidlyWeb.Dtos;
using VidlyWeb.Models;

namespace VidlyWeb.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
