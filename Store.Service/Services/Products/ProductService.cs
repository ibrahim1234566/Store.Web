using AutoMapper;
using Store.Data.Entity;
using Store.Repository.Interfaces;
using Store.Repository.Specification.ProductSpecs;
using Store.Service.Helper;
using Store.Service.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products
{
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAll();

           /* IReadOnlyList<BrandTypeDetailsDto> MappedBrands = brands.Select(x => new BrandTypeDetailsDto
            {
                Id = x.Id,
                CreatedAt = x.CreatedAt,
                Name = x.Name
            }).ToList();*/
           var MappedBrands = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(brands);

            return MappedBrands;
        }

        //public async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync()
        //{
        //    var products = await _unitOfWork.Repository<Product, int>().GetAll();

        //    var MappedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);

        //    /* var MappedProducts = products.Select(x => new ProductDto
        //     {
        //         Id = x.Id,
        //         Name = x.Name,
        //         BrandName = x.Brand.Name,
        //         TypeName = x.Type.Name,
        //         CreatedAt = x.CreatedAt,
        //         Description = x.Description,
        //         ImageUrl = x.ImageUrl,
        //         price = x.price
        //     }).ToList();*/

        //    return MappedProducts;
        //}

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAll();
            var mappedTypes = _mapper.Map<IReadOnlyList< BrandTypeDetailsDto >>(types);

          /*  var mappedTypes = types.Select(x => new BrandTypeDetailsDto
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt
            }).ToList();*/

            return mappedTypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int? id)
        {
            if (id == null)
            {
                throw new Exception("Id IS NULL");
            }
            var specs = new ProductWithSpecification(id);

            var product = await _unitOfWork.Repository<Product, int>().GetWithSpecificationByIdAsync(specs);

            if (product == null)
            {
                throw new Exception("Product not Found");
            }

            /* var MappedProduct = new ProductDto
             {
                 Id = product.Id,
                 Name = product.Name,
                 BrandName = product.Brand.Name,
                 CreatedAt = product.CreatedAt,
                 Description = product.Description,
                 ImageUrl = product.ImageUrl,
                 price = product.price,
                 TypeName = product.Type.Name
             };*/
            var MappedProduct = _mapper.Map<ProductDto>(product);

            return MappedProduct;
        }
        public async Task<PaginatedResultDto<ProductDto>> GetAllProductsAsync(ProductSpecification input)
        {
            var specs = new ProductWithSpecification(input);
            var products = await _unitOfWork.Repository<Product, int>().GetAllWithSpecification(specs);

            var MappedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);
            var CountSpecs = new ProductWithCountSpecification(input);
            var count =await _unitOfWork.Repository<Product,int>().GetCountWithSpecification(specs);

            /* var MappedProducts = products.Select(x => new ProductDto
             {
                 Id = x.Id,
                 Name = x.Name,
                 BrandName = x.Brand.Name,
                 TypeName = x.Type.Name,
                 CreatedAt = x.CreatedAt,
                 Description = x.Description,
                 ImageUrl = x.ImageUrl,
                 price = x.price
             }).ToList();*/

            return new PaginatedResultDto<ProductDto>(input.PageIndex,input.PageSize, count, MappedProducts);
        }
    }
}
