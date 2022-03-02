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
    public class PedidoController : ControllerBase
    {
        private readonly PedidoRepository _pedidoRepository;
        public PedidoController(PedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoModel>>> GetAll()
        {
            return await _pedidoRepository.GetAll(); ;
        }

        [HttpGet("GetbyID/{id}")]
        public async Task<ActionResult<IEnumerable<PedidoModel>>> GetbyID(int id)
        {
            var response = await _pedidoRepository.GetById(id);
            if (response == null) { return NotFound(); }
            return response;
        }

        [HttpGet("GetbyPage/{id}")]
        public async Task<ActionResult<IEnumerable<PedidoModel>>> GetByPage(int pageNo)
        {
            var response = await _pedidoRepository.GetByPage(pageNo);
            if (response == null) { return NotFound(); }
            return response;
        }

        [HttpPost]
        public async Task Post([FromBody] PedidoInsertModel pedido)
        {
            await _pedidoRepository.Insert(pedido);
        }

        [HttpPut]
        public async Task Put([FromBody] PedidoUpdateModel pedido)
        {
            await _pedidoRepository.Update(pedido);
        }

        [HttpPut("DeleteLogic/")]
        public async Task DeleteLogic(long idPedido, long idEstadoPedido)
        {
            await _pedidoRepository.DeleteLogic(idPedido, idEstadoPedido);
        }
    }
}

