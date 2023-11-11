using AutoMapper;
using Maharat.Data.DTOs.Users;
using rayverz.Data.DTOs.Newsletters;
using rayverz.Data.Entities;

namespace rayverz.Configs
{
    public class AutoMapperConfiguration: Profile
    {
        public AutoMapperConfiguration()
        {
                    CreateMap<Newsletter, NewsletterAddDTO>().ReverseMap();
                    CreateMap<Newsletter, NewsletterGetDTO>().ReverseMap();

        }
    }
}
