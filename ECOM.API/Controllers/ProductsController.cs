﻿using AutoMapper;
using ECOM.API.Dto;
using ECOM.API.Errors;
using ECOM.API.Helpers;
using ECOM.Core.Entities;
using ECOM.Core.Interfaces;
using ECOM.Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.API.Controllers
{
    public class ProductsController : ApiBaseController
    {
        private readonly IGenericService<ProductBrand, int> _productBrandService;
        private readonly IMapper _mapper;
        private readonly IGenericService<ProductType, int> _productTypeService;
        private readonly IGenericService<Product, int> _productService;

        public ProductsController(IGenericService<Product, int> productService,
            IGenericService<ProductType, int> productTypeService,
            IGenericService<ProductBrand, int> productBrandService,
            IMapper mapper)
        {
            _productService = productService;
            _productTypeService = productTypeService;
            _productBrandService = productBrandService;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductsWithFiltersForCountSpecification(productParams);
            var totalItems = await _productService.CountAsync(countSpec);
            var products = await _productService.ListAsync(spec);
            var productsToReturn = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);
            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex,
                productParams.PageSize, totalItems, productsToReturn));
        }

        /// <summary>
        /// Data
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productService.GetEntityWithSpec(spec);
            if (product == null) return NotFound(new ApiResponse(404));
            var productToReturn = _mapper.Map<ProductToReturnDto>(product);
            return Ok(productToReturn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            return Ok(await _productBrandService.ListAllAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetTypes()
        {
            return Ok(await _productTypeService.ListAllAsync());
        }
    }
}
