using AutoMapper;
using DataAccess.Database.Schema;
using TalasUrlManager.Models;

namespace TalasUrlManager
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ShortUrlSet, ShortUrlDto>();
            CreateMap<ShortUrlDto, ShortUrlSet>();
        }
    }
}
