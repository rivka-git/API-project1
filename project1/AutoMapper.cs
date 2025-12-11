using AutoMapper;
using Dto;
using Model;
using Model;

namespace Api
{
    public class AutoMapper:Profile
    {
        public AutoMapper() {
        // CreateMap<User, DtoPassword_Password_Strength>().ReverseMap();
            CreateMap<PassWord, DtoPassword_Password_Strength>().ReverseMap();
        }
    }
}
