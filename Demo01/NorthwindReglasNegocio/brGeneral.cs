using System;
using System.Configuration;
namespace NorthwindReglasNegocio
{
    public class brGeneral
    {
        public string CadenaConexion { get; set; }

        public brGeneral()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["conNW"].ConnectionString;
        }

        public void GrabarLog(Exception ex)
        {

        }
    }
}
/*
 esto sirve para generar la cadena de conexion y despues heredarla a las 
 distintas clases para hacer la conexion una sola vez

     */