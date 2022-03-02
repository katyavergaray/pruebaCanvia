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
    public class DetallePedidoRepository
    {
        private readonly string _connectionString;
        public DetallePedidoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        public async Task<List<DetallePedidoModel>> GetById(int idPedido)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_get_detalle_pedido_id", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idPedido", idPedido);
                    var list = new List<DetallePedidoModel>();
                    await conexion.OpenAsync();
                    using (var reader = await comando.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            DetallePedidoModel dpedido = new DetallePedidoModel();
                            dpedido.idDetallePedido = Convert.ToInt32(reader[0]);
                            dpedido.idPedido = Convert.ToInt32(reader[1]);
                            dpedido.nombreProducto = Convert.ToString(reader[2]);
                            dpedido.cantidad = Convert.ToInt32(reader[3]);
                            dpedido.precioUnitario = Convert.ToDecimal(reader[4]);
                            dpedido.subTotal = Convert.ToDecimal(reader[5]);
                            list.Add(dpedido);
                        }
                    }
                    await conexion.CloseAsync();
                    return list;
                }
            }
        }

        public async Task<List<DetallePedidoModel>> GetByPage(int pageNo, int idPedido)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_get_detalle_pedido_page", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@pageNo", pageNo);
                    comando.Parameters.AddWithValue("@idPedido", idPedido);
                    var list = new List<DetallePedidoModel>();
                    await conexion.OpenAsync();
                    using (var reader = await comando.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            DetallePedidoModel dpedido = new DetallePedidoModel();
                            dpedido.idDetallePedido = Convert.ToInt32(reader[0]);
                            dpedido.idPedido = Convert.ToInt32(reader[1]);
                            dpedido.nombreProducto = Convert.ToString(reader[2]);
                            dpedido.cantidad = Convert.ToInt32(reader[3]);
                            dpedido.precioUnitario = Convert.ToDecimal(reader[4]);
                            dpedido.subTotal = Convert.ToDecimal(reader[5]);
                            list.Add(dpedido);
                        }
                    }
                    await conexion.CloseAsync();
                    return list;
                }
            }
        }

        public async Task Insert(DetallePedidoInsertModel dpedido)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_post_detalle_pedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idPedido", dpedido.idPedido);
                    comando.Parameters.AddWithValue("@idProducto", dpedido.idProducto);
                    comando.Parameters.AddWithValue("@cantidad", dpedido.cantidad);
                    comando.Parameters.AddWithValue("@precioUnitario", dpedido.precioUnitario);
                    comando.Parameters.AddWithValue("@subTotal", dpedido.subTotal);
                    await conexion.OpenAsync();
                    await comando.ExecuteNonQueryAsync();
                    await conexion.CloseAsync();
                    return;
                }
            }
        }
        public async Task Update(DetallePedidoUpdateModel dpedido)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_put_detalle_pedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idPedido", dpedido.idPedido);
                    comando.Parameters.AddWithValue("@cantidad", dpedido.cantidad);
                    comando.Parameters.AddWithValue("@precioUnitario", dpedido.precioUnitario);
                    comando.Parameters.AddWithValue("@subTotal", dpedido.subTotal);

                    await conexion.OpenAsync();
                    await comando.ExecuteNonQueryAsync();
                    await conexion.CloseAsync();
                    return;
                }

            }
        }
    }
}