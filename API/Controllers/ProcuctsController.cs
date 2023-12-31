using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public IProductRepository _repo;
     
      public ProductsController(IProductRepository repo)
      {
            _repo = repo;
        
      }
      [HttpGet]
      public async Task<ActionResult<List<Product>>> GetProducts()
      {
        var products = await _repo.GetProductsAsync();
        return Ok(products);
      }

      [HttpGet("{id}")]
      
      public async Task<ActionResult<Product>> GetProduct(int id) 
      {
        return await _repo.GetProductByIdAsync(id);
        //Added a comment
      }

      [HttpGet("brands")]
      public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
      {
        return Ok(await _repo.GetProductBrandsAsync());
      }

      [HttpGet("types")]
      public async Task<ActionResult<List<ProductType>>> GetProductTypes()
      {
        return Ok(await _repo.GetProductTypesAsync());
      }
    }

}
