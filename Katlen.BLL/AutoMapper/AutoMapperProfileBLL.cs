using AutoMapper;
using Katlen.BLL.DTO;
using Katlen.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.BLL.AutoMapper
{
    public class AutoMapperBLL : Profile
    {
        public AutoMapperBLL()
        {
            CreateMap<Product, ProductDTO>();
            //CreateMap<Image, ProductDTO>();
            //CreateMap<Price, ProductDTO>();
            //CreateMap<Size, ProductDTO>();
        }
    }
}
