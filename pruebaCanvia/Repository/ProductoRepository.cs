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
    public class ProductoRepository
    {
        private readonly string _connectionString;
        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        public async Task<List<ProductoModel>> GetAll()
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_get_producto", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    var list = new List<ProductoModel>();
                    await conexion.OpenAsync();
                    using (var reader = await comando.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ProductoModel producto = new ProductoModel();
                            producto.idProducto = Convert.ToInt32(reader[0]);
                            producto.nombreProducto = Convert.ToString(reader[1]);
                            producto.precio = Convert.ToDecimal(reader[2]);
                            producto.stock = Convert.ToInt32(reader[3]);
                            producto.nombreCategoria = Convert.ToString(reader[4]);
                            list.Add(producto);
                        }
                    }
                    await conexion.CloseAsync();
                    return list;
                } 
            }
        }

        public async Task<List<ProductoModel>> GetById(int idProducto)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_get_producto_id", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idProducto", idProducto);
                    var list = new List<ProductoModel>();
                    await conexion.OpenAsync();
                    using (var reader = await comando.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ProductoModel producto = new ProductoModel();
                            producto.idProducto = Convert.ToInt32(reader[0]);
                            producto.nombreProducto = Convert.ToString(reader[1]);
                            producto.precio = Convert.ToDecimal(reader[2]);
                            producto.stock = Convert.ToInt32(reader[3]);
                            producto.nombreCategoria = Convert.ToString(reader[4]);
                            list.Add(producto);
                        }
                    }
                    await conexion.CloseAsync();
                    return list;
                }
            }
        }

        public async Task<List<ProductoModel>> GetByPage(int pageNo)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_get_producto_page", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@pageNo", pageNo);
                    var list = new List<ProductoModel>();
                    await conexion.OpenAsync();
                    using (var reader = await comando.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ProductoModel producto = new ProductoModel();
                            producto.idProducto = Convert.ToInt32(reader[0]);
                            producto.nombreProducto = Convert.ToString(reader[1]);
                            producto.precio = Convert.ToDecimal(reader[2]);
                            producto.stock = Convert.ToInt32(reader[3]);
                            producto.nombreCategoria = Convert.ToString(reader[4]);
                            list.Add(producto);
                        }
                    }
                    await conexion.CloseAsync();
                    return list;
                }
            }
        }

        public async Task Insert(ProductoInsertModel product)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_post_producto", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nombre", product.nombreProducto);
                    comando.Parameters.AddWithValue("@precio", product.precio);
                    comando.Parameters.AddWithValue("@stock", product.stock);
                    comando.Parameters.AddWithValue("@idCategoria", product.idCategoria);
                    await conexion.OpenAsync();
                    await comando.ExecuteNonQueryAsync();
                    await conexion.CloseAsync();
                    return;
                }
            }
        }
        public async Task Update(ProductoUpdateModel product)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_put_producto", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idProducto", product.idProducto);
                    comando.Parameters.AddWithValue("@nombre", product.nombreProducto);
                    comando.Parameters.AddWithValue("@precio", product.precio);
                    comando.Parameters.AddWithValue("@stock", product.stock);
                    comando.Parameters.AddWithValue("@idCategoria", product.idCategoria);

                    await conexion.OpenAsync();
                    await comando.ExecuteNonQueryAsync();
                    await conexion.CloseAsync();
                    return;
                }

            }
        }

        public async Task DeleteById(int Id)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_delete_producto", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@P_idProducto", Id));
                    await conexion.OpenAsync();
                    await comando.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
    }
}
