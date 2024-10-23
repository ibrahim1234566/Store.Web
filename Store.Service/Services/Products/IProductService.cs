﻿using Store.Repository.Specification.ProductSpecs;
using Store.Service.Helper;
using Store.Service.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(int? id);
        Task<PaginatedResultDto<ProductDto>> GetAllProductsAsync(ProductSpecification input);
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync();
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync();
    }
}
