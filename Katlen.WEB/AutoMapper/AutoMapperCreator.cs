using AutoMapper;
using Katlen.BLL.DTO;
using Katlen.DAL.Entities;
using Katlen.WEB.ViewModels;

namespace Katlen.WEB.AutoMapper
{
    public class AutoMapperCreator : Profile
    {
        public AutoMapperCreator()
        {
            CreateMap<ProductDTO, ProductCardViewModel>();
        }
        
    }
}
