using System.Data.SqlClient;
using System.Collections.Generic;
using Entidades;
using NorthwindAccesoDatos;
using System;

namespace NorthwindReglasNegocio
{
    public class ProductoBR:brGeneral
    {
        public List<ProductoEntidad> ListarNegocio()
        {
            List<ProductoEntidad> ListProducto = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                //donde hay using debe haber try- catch
                //try
                //{
                //        con.Open();
                //        ProductoDAO daoproducto = new ProductoDAO();
                //        ListProducto = daoproducto.ListarEntidad(con);
                //}
                //    catch (Exception ex)
                //    {
                //        GrabarLog(ex);
                //    }

                con.Open();
                ProductoDAO daoproducto = new ProductoDAO();
                ListProducto = daoproducto.ListarEntidad(con);
            }
            return ListProducto;
        }
    }
}
