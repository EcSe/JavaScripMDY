using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using NorthwindReglasNegocio;
using GeneralCodigoUsuario;
using Entidades;

namespace Demo01._1.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Lista()
        {
            return View();
        }

        public string listar()
        {
            string rpta = "";
            //usando codigo xhr

            ProductoBR brproducto = new ProductoBR();
            List<ProductoEntidad> listProducto = brproducto.ListarNegocio();
            if (listProducto != null && listProducto.Count > 0)
            {

                rpta = CSV.SerializarLista(listProducto);
            }
       
            return rpta;
        }
    }
}