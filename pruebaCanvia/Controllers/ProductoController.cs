using Entity;
using Microsoft.AspNetCore.Mvc;
using pruebaCanvia.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaCanvia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoRepository _productoRepository;
        public ProductoController(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoModel>>> GetAll()
        {
            return await _productoRepository.GetAll(); ;
        }

        [HttpGet("GetbyID/{id}")]
        public async Task<ActionResult<IEnumerable<ProductoModel>>> GetbyID(int id)
        {
            var response = await _productoRepository.GetById(id);
            if (response == null) { return NotFound(); }
            return response;
        }

        [HttpGet("GetbyPage/{id}")]
        public async Task<ActionResult<IEnumerable<ProductoModel>>> GetByPage(int pageNo)
        {
            var response = await _productoRepository.GetByPage(pageNo);
            if (response == null) { return NotFound(); }
            return response;
        }

        [HttpPost]
        public async Task Post([FromBody] ProductoInsertModel producto)
        {
            await _productoRepository.Insert(producto);
        }

        [HttpPut]
        public async Task Put([FromBody] ProductoUpdateModel product)
        {
            await _productoRepository.Update(product);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _productoRepository.DeleteById(id);
        }
    }
}
