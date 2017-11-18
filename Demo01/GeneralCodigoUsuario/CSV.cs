using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;


namespace GeneralCodigoUsuario
{
    public class CSV
    {
        public static string SerializarLista<T>(List<T> lista, 
            char separadorCampo = '|', char separadorRegistro = ';',
            bool tieneCabeceras=true)
        {
            StringBuilder sb = new StringBuilder();

            if (lista != null && lista.Count > 0)
            {
                PropertyInfo[] propiedades;  
                if (tieneCabeceras)
                {
                    /*toma el 1er obj, luego gettype apunta a la clase,
                     luego toma las propiedades*/
                    propiedades = lista[0].GetType().GetProperties();
                    foreach (PropertyInfo propiedad in propiedades)
                    {
                        sb.Append(propiedad.Name);
                        sb.Append(separadorCampo); 
                    } 
                    sb = sb.Remove(sb.Length - 1, 1);
                    sb.Append(separadorRegistro);
                }
                //conviene hacer esto asi ya que en el for
                //se harian muchas veces, performance, que ya este hecha la
                //comparacion
                int nRegistros = lista.Count;
                for (int i = 0; i < nRegistros; i++)
                {
                    propiedades = lista[i].GetType().GetProperties();
                    foreach (PropertyInfo propiedad in propiedades)
                    {
                        sb.Append(propiedad.GetValue(lista[i],null));
                        sb.Append(separadorCampo);
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                    sb.Append(separadorRegistro);
                }
                sb = sb.Remove(sb.Length - 1, 1);
            }


            return sb.ToString();
        }
            



    }
}
