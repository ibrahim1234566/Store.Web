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

        }
    }
}
