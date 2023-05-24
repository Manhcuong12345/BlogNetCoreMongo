using Project_NetCore_MongoDB.Dto;
using Project_NetCore_MongoDB.Models;
using System.Diagnostics.Metrics;
using AutoMapper;

namespace Project_NetCore_MongoDB.AutoMapper
{
    public class DataAM:Profile
    {
        public DataAM()
        {

            CreateMap<Categories, CategoriesDto>();
            CreateMap<CategoriesDto, Categories>();

            CreateMap<Users, UsersDto>();
            CreateMap<UsersDto, Users>();

            CreateMap<Articles, ArticlesDto>();
            CreateMap<ArticlesDto, Articles>();
        }
    }
}
