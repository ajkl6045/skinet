using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>>  GetProducts()
        {
            // return View();
            var product = await _repo.GetProductsAsync();
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>>  GetProduct(int id)
        {
            // return View();
            var product = await _repo.GetProductByIdAsync(id);
            return Ok(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
           
            var brands = await _repo.GetProductBrandsAsync();
            return Ok(brands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            
            var types = await _repo.GetProductTypesAsync();
            return Ok(types);
        }
    }
}
