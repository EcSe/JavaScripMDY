window.onload = function ()
{
    get("../Producto/listar", mostrarLista);
}

function get(url,success)
{
    //creo el objeto
    var xhr = new XMLHttpRequest();

    //abrimos la conexion y para conectarse
    xhr.open("get",url);

    //para recibir, pero aqui va a entrar varias vces, la respuesta
    //viene en varios paquetes readystate es cuando esta completa
    // status =200 es que el http esta ok, pero quizas aun no completo
    xhr.onloadend = function ()
    {
        if (xhr.status==200 && xhr.readyState==4)
        {
            success(xhr.responseText);
        }
    }

    //para ejecutar la url
    xhr.send();
}

function mostrarLista(rpta)
{
    var contenido = "";

    if (rpta != "")
    {
        var lista = rpta.split(";");
        var nRegistros = lista.length;
        contenido = "<table><thead><tr class='FilaCabecera'>";
        var campos = lista[0].split("|");
        var nCampos = campos.length;
        for (var j = 0; j < nCampos; j++)
        {
            contenido += "<th>";
            contenido += campos[j];
            contenido += "</th>";
        }
        contenido += "<tr></thead><tbody>"; 
        for (var i = 1;i<nRegistros;i++)
        {
            campos = lista[i].split("|");
            contenido += "<tr class='FilaDatos'>";
            for (var j = 0; j < nCampos; j++)
            {
                contenido += "<td>";
                contenido += campos[j];
                contenido += "</td>";
            }
            contenido += "</tr>";
        }
        contenido += "</tbody></table>";
    }

    document.getElementById("divProducto").innerHTML = contenido;
}


