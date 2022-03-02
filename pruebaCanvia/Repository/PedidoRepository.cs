using Entity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaCanvia.Repository
{
    public class PedidoRepository
    {
        private readonly string _connectionString;
        public PedidoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        public async Task<List<PedidoModel>> GetAll()
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_get_pedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    var list = new List<PedidoModel>();
                    await conexion.OpenAsync();
                    using (var reader = await comando.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            PedidoModel pedido = new PedidoModel();
                            pedido.idPedido = Convert.ToInt32(reader[0]);
                            pedido.codigo = Convert.ToString(reader[1]);
                            pedido.fechaEmision = Convert.ToDateTime(reader[2]);
                            pedido.total = Convert.ToDecimal(reader[3]);
                            pedido.observaciones = Convert.ToString(reader[4]);
                            list.Add(pedido);
                        }
                    }
                    await conexion.CloseAsync();
                    return list;
                }
            }
        }

        public async Task<List<PedidoModel>> GetById(int idPedido)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_get_pedido_id", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idPedido", idPedido);
                    var list = new List<PedidoModel>();
                    await conexion.OpenAsync();
                    using (var reader = await comando.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            PedidoModel pedido = new PedidoModel();
                            pedido.idPedido = Convert.ToInt32(reader[0]);
                            pedido.codigo = Convert.ToString(reader[1]);
                            pedido.fechaEmision = Convert.ToDateTime(reader[2]);
                            pedido.total = Convert.ToDecimal(reader[3]);
                            pedido.observaciones = Convert.ToString(reader[4]);
                            list.Add(pedido);
                        }
                    }
                    await conexion.CloseAsync();
                    return list;
                }
            }
        }

        public async Task<List<PedidoModel>> GetByPage(int pageNo)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_get_pedido_page", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@pageNo", pageNo);
                    var list = new List<PedidoModel>();
                    await conexion.OpenAsync();
                    using (var reader = await comando.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            PedidoModel pedido = new PedidoModel();
                            pedido.idPedido = Convert.ToInt32(reader[0]);
                            pedido.codigo = Convert.ToString(reader[1]);
                            pedido.fechaEmision = Convert.ToDateTime(reader[2]);
                            pedido.total = Convert.ToDecimal(reader[3]);
                            pedido.observaciones = Convert.ToString(reader[4]);
                            list.Add(pedido);
                        }
                    }
                    await conexion.CloseAsync();
                    return list;
                }
            }
        }

        public async Task Insert(PedidoInsertModel pedido)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_post_pedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@total", pedido.total);
                    comando.Parameters.AddWithValue("@observaciones", pedido.observaciones);
                    comando.Parameters.AddWithValue("@idEstadoPedido", pedido.idEstadoPedido);
                    await conexion.OpenAsync();
                    await comando.ExecuteNonQueryAsync();
                    await conexion.CloseAsync();
                    return;
                }
            }
        }
        public async Task Update(PedidoUpdateModel pedido)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_put_pedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idPedido", pedido.idPedido);
                    comando.Parameters.AddWithValue("@observaciones", pedido.observaciones);
                    
                    await conexion.OpenAsync();
                    await comando.ExecuteNonQueryAsync();
                    await conexion.CloseAsync();
                    return;
                }

            }
        }
        public async Task DeleteLogic(long idPedido , long idEstadoPedido)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_put_estado_pedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idPedido", idPedido);
                    comando.Parameters.AddWithValue("@idEstadoPedido", idEstadoPedido);

                    await conexion.OpenAsync();
                    await comando.ExecuteNonQueryAsync();
                    await conexion.CloseAsync();
                    return;
                }

            }
        }
    }
}

