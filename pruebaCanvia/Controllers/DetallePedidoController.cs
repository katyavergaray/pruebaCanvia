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
    public class DetallePedidoController : ControllerBase
    {
        private readonly DetallePedidoRepository _dpedidoRepository;
        public DetallePedidoController(DetallePedidoRepository dpedidoRepository)
        {
            _dpedidoRepository = dpedidoRepository;
        }

        [HttpGet("GetbyID/{id}")]
        public async Task<ActionResult<IEnumerable<DetallePedidoModel>>> GetbyID(int id)
        {
            var response = await _dpedidoRepository.GetById(id);
            if (response == null) { return NotFound(); }
            return response;
        }

        [HttpGet("GetbyPage")]
        public async Task<ActionResult<IEnumerable<DetallePedidoModel>>> GetByPage(int pageNo, int idPedido)
        {
            var response = await _dpedidoRepository.GetByPage(pageNo, idPedido);
            if (response == null) { return NotFound(); }
            return response;
        }

        [HttpPost]
        public async Task Post([FromBody] DetallePedidoInsertModel dpedido)
        {
            await _dpedidoRepository.Insert(dpedido);
        }

        [HttpPut]
        public async Task Put([FromBody] DetallePedidoUpdateModel dpedido)
        {
            await _dpedidoRepository.Update(dpedido);
        }
    }
}


