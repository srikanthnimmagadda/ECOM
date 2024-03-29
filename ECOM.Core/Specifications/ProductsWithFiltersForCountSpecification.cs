﻿using ECOM.Core.Entities;

namespace ECOM.Core.Specifications
{
    public class ProductsWithFiltersForCountSpecification : BaseSpecifcation<Product, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productParams"></param>
        public ProductsWithFiltersForCountSpecification(ProductSpecParams productParams) : base(x =>
           (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
           (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
           (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {

        }

    }
}
