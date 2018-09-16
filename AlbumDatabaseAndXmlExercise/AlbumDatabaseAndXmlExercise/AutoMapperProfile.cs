using AlbumDatabaseAndXmlExercise.Dtos;
using AlbumDatabaseAndXmlExercise.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumDatabaseAndXmlExercise
{
  public  class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, Users>();
            CreateMap<CategoriesDto, Categories>();
            CreateMap<ProductsDto, Products>();
        }

    }
}
