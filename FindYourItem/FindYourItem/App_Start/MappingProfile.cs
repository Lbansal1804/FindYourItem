using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using FindYourItem.Dtos;
using FindYourItem.Models;

namespace FindYourItem.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ProductDetails, ProductDetailDto>();
            Mapper.CreateMap<ProductDetailDto, ProductDetails>();
            Mapper.CreateMap<AdminDetail, AdminDetailDto>();
            Mapper.CreateMap<AdminDetailDto, AdminDetail>();
        }
    }
}