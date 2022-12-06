using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceBuddy.Data.Models;
using PriceBuddy.Data.Repositories;

namespace PriceBuddy.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/product")]
    public class ProductController : ControllerBase
    {
        private ProductRepository _productRepository;
        public ProductController(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            var products = await this._productRepository.Get();
            return Results.Ok(products);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public IResult Get(Guid id)
        {
            var product = this._productRepository.GetById(id);
            return product == null ? Results.NotFound() : Results.Ok(product);
        }

        [HttpPost]
        public async Task<IResult> Post(Product product)
        {
            var result = await this._productRepository.Add(product);
            return Results.Json(result);
            //return result == null? Results.BadRequest("Erro ao salvar o produto") : Results.CreatedAtRoute("GetProductById", new { id = product.Id });
        }
    }
}