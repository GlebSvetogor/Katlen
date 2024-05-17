using AutoMapper;
using Azure;
using Katlen.BLL.DTO;
using Katlen.BLL.Interfaces;
using Katlen.DAL.EF;
using Katlen.DAL.Entities;
using Katlen.DAL.Implementations;
using Katlen.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using static System.Net.Mime.MediaTypeNames;

namespace Katlen.BLL.Implementations
{
    public class Catalog : ICatalog
    {
        private readonly IMapper _mapper;
        UnitOfWork unitOfWork;
        public Catalog(KatlenContext db, IMapper mapper)
        {
            unitOfWork = new UnitOfWork(db);
            _mapper = mapper;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            var list = unitOfWork.Products.GetAll()
                .Include(p => p.Sizes)
                .Include(p => p.Images);

            
            foreach(var item in list)
            {
                List<string> imgSources = new List<string>();
                List<string> sizes = new List<string>();
                List<string> sizesAreAvailable = new List<string>();
                ProductDTO product = _mapper.Map<ProductDTO>(item);
                imgSources = item.Images.Select(image => image.ImageSource).ToList();
                sizes = item.Sizes.Select(size => size.SizeValue).ToList();
                sizesAreAvailable = item.Sizes.Where(size => (size.IsAvailable == 1) ? size.SizeValue : size.SizeValue).ToList();
            }
            


        }
        public IEnumerable<ProductDTO> GetAllByAges(string[] ages)
        {
           
        }

        public IEnumerable<ProductDTO> GetAllByNames(string[] names)
        {
            

        }

        public IEnumerable<ProductDTO> GetAllByPrice(int from, int to)
        {
            
        }

        public IEnumerable<ProductDTO> GetAllByMaterials(string[] materials)
        {

        }

        public IEnumerable<ProductDTO> GetAllBySizes(string[] sizes)
        {
            
        }

        public IEnumerable<ProductDTO> GetAllBySizons(string[] sizons)
        {
            
        }

        public void GetSizesOfProduct(int id)
        {
            
        }

        public void GetImagesSourcesOfProduct()

        
    }
}
