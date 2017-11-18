using System.Data; //comandtype
using System.Data.SqlClient; //sqlconnection, sqlcomand,sqldatareader
using System.Collections.Generic; //List
using Entidades;

namespace NorthwindAccesoDatos
{
    public class ProductoDAO
    {
        public List<ProductoEntidad> ListarEntidad(SqlConnection con)
        {
            List<ProductoEntidad> ListProducto = null;
            SqlCommand cmd = new SqlCommand("ProductoListar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            //si tu store procedure tiene varios select, solo lee el primero
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                ListProducto = new List<ProductoEntidad>();
                /*se podria crear dentro del while de la siguiente manera
                ProductoEntidad productoent = new ProductoEntidad
                pero, de esa manera estarias creando muchos objetos 
                es preferible crear el objeto fuera, y luego dentro del 
                while solo cambiar valores*/
                ProductoEntidad productoent;
                int posIdProducto = drd.GetOrdinal("IdProducto");
                int posNombre = drd.GetOrdinal("NombreProducto");
                int posIdProveedor = drd.GetOrdinal("IdProveedor");
                int posIdCategoria = drd.GetOrdinal("IdCategoría");
                int posPrecioUnitario = drd.GetOrdinal("PrecioUnidad");
                int posStock = drd.GetOrdinal("UnidadesEnExistencia");

                while (drd.Read())
                {
                    productoent = new ProductoEntidad()
                    {
                        IdProducto = drd.GetInt32(posIdProducto),
                        Nombre = drd.GetString(posNombre),
                        IdProveedor = drd.GetInt32(posIdProveedor),
                        IdCategoria = drd.GetInt32(posIdCategoria),
                        PrecioUnitario = drd.GetDecimal(posPrecioUnitario),
                        Stock = drd.GetInt16(posStock)
                    };
                    ListProducto.Add(productoent);
                }

            }
            return ListProducto;
        }
    }
}
