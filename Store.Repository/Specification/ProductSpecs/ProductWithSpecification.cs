using Store.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification.ProductSpecs
{
    public class ProductWithSpecification:BaseSpescification<Product>
    {
        public ProductWithSpecification(ProductSpecification specs) :
            base(prod => (!specs.BrandId.HasValue ||prod.BrandId==specs.BrandId.Value)&&
                          (!specs.TypeId.HasValue || prod.BrandId == specs.TypeId.Value))
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);
            AddOrderBy(x => x.Name);
            ApplyPagination(specs.PageSize * (specs.PageIndex - 1),specs.PageSize);
            if (!string.IsNullOrEmpty(specs.Sort))
            {
                switch (specs.Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(x=>x.price);
                        break;
                    case "PriceDesc":
                        AddOrderByDescending(x => x.price);
                        break;
                    default:
                        AddOrderBy(x=>x.Name);
                        break;



                }
            }
        }

        public ProductWithSpecification(int? id) : base(prod=>prod.Id==id)
        {
            AddInclude(x=>x.Brand);    
            AddInclude(x => x.Type);

        }
    }
}
