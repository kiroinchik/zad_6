using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using BackendApi.Contracts.Product;
namespace FirstSaturday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductsService _productService;
        public ProductController (IProductsService GoodService)
        {
            _productService = GoodService;
        }
        /// <summary>
        /// Получение всех товаров
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }
        /// <summary>
        /// Получение товара по id
        /// </summary>
        [HttpGet("byid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetById(id);
            var response = result.Adapt<GetProductResponse>();
            return Ok(response);
        }
        /// <summary>
        /// Получение товаров по id_C
        /// </summary>

        //[HttpGet("byc/{categoty_id}")]
        //public async Task<IActionResult> GetByCategory(int categoty_id)
        //{
        //    var result = await _goodService.GetByCategory(categoty_id);
        //    var response = result.Adapt<GetGoodResponse>();
        //    return Ok(response);
        //}

        /// <summary>
        /// Добавление товара
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductRequest request)
        {
            var userDto = request.Adapt<Product>();
            await _productService.Create(userDto);
            return Ok();
        }
        /// <summary>
        /// Обновление товара
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(CreateProductRequest request)
        {
            var userDto = request.Adapt<Product>();
            await _productService.Update(userDto);
            return Ok();
        }
        /// <summary>
        /// Удаление товара
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Ok();
        }
    }
}
