using AutoMapper;
using Katlen.BLL.DTO;
using Katlen.DAL.Entities;
using Katlen.WEB.ViewModels;

namespace Katlen.WEB.AutoMapper
{
    public class AutoMapperWEB : Profile
    {
        public AutoMapperWEB()
        {
            CreateMap<ProductDTO, ProductCardViewModel>();
        }

        
    }
}
